using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Infra.DTOs;
using Giro.Animes.Infra.Interfaces;
using Giro.Animes.Infra.Interfaces.Configs;
using Giro.Animes.Infra.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace Giro.Animes.Infra.Services
{
    public class TokenService : ITokenService
    {
        private readonly IJwtSettings _jwtSettings;
        private readonly ICookieConfig _cookieConfig;
        private readonly IMediaConfig _mediaConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPermissionDomainService _permissionDomainService;

        public TokenService(IJwtSettings appConfig, ICookieConfig cookieConfig, IMediaConfig mediaConfig, IHttpContextAccessor httpContextAccessor, IPermissionDomainService permissionDomainService, IApplicationUser user)
        {
            _jwtSettings = appConfig;
            _cookieConfig = cookieConfig;
            _mediaConfig = mediaConfig;
            _httpContextAccessor = httpContextAccessor;
            _permissionDomainService = permissionDomainService;
        }

        // Busca as permissões do usuário no banco de dados e adiciona as claims ao token
        private async Task<Claim[]> GetPermissionsByDefault(IEnumerable<Permission> permissions)
        {
            return permissions.Select(permission => new Claim("Permission", $"{permission.Resource}:{permission.Action}")).ToArray();
        }

        public async Task<UserTokenDTO> GenerateUserToken(Account account, CancellationToken cancellationToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                Claim[] claims = await GetPermissionsByDefault(account.User.Permissions);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, account.User.Name),
                        new Claim(ClaimTypes.Role, account.User.Role.ToString()),
                        new Claim(ClaimTypes.Sid, account.User.Id.ToString()),
                        new Claim(ClaimTypes.Email, account?.Email.Value),
                    }.Union(claims)),
                    Issuer = _jwtSettings.Issuer,
                    Audience = _jwtSettings.Audience,
                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var userTokenDTO = UserTokenDTO.Create(account.User.Name, tokenString, tokenDescriptor.Expires.Value.Subtract(DateTime.UtcNow).TotalSeconds, account.User.Role.ToString());

                SetCookie(userTokenDTO);

                return userTokenDTO;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao gerar o token do usuário. Contate o adminstrador para mais detalhes.", ex);
            }
        }

        public async Task<UserTokenDTO> GenerateGuestToken(CancellationToken cancellationToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                Claim[] claims = await GetPermissionsByDefault(await _permissionDomainService.GetAllByGuest(cancellationToken));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, "Guest"),
                        new Claim(ClaimTypes.Role, UserRole.Guest.ToString()),
                }.Union(claims)),
                    Issuer = _jwtSettings.Issuer,
                    Audience = _jwtSettings.Audience,
                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                var userTokenDTO = UserTokenDTO.Create("Guest", tokenString, tokenDescriptor.Expires.Value.Subtract(DateTime.UtcNow).TotalSeconds, UserRole.Guest.ToString());

                SetCookie(userTokenDTO);

                return await Task.Run(() =>
                {
                    return userTokenDTO;
                });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Não foi possível gerar o token de convidado. Tente novamente mais tarde.", ex);
            }

        }

        private void SetCookie(UserTokenDTO userTokenDTO)
        {
            _httpContextAccessor?.HttpContext?.Response.Cookies.Append(_cookieConfig.Name, userTokenDTO.Token, new CookieOptions
            {
                HttpOnly = _cookieConfig.HttpOnly,
                Expires = DateTime.Now.AddMinutes(userTokenDTO.ExpirationTime),
                Secure = _cookieConfig.Secure,
                SameSite = _cookieConfig.SameSite,
                Domain = _httpContextAccessor.HttpContext.Request.Host.Host,
                IsEssential = true,
                Path = _cookieConfig.Path
            });
        }

        public async Task<(string, string, string)> GetMediaByMediaToken(string token, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true, // Valida a expiração do token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var filePath = jwtToken.Claims.First(x => x.Type == "fullPath").Value;
                var contentType = jwtToken.Claims.First(x => x.Type == "contentType").Value;

                if (!System.IO.File.Exists(filePath))
                    throw new FileNotFoundException("Arquivo não encontrado.", filePath);

                return (filePath, contentType, Path.GetFileName(filePath));
            }
            catch (SecurityTokenExpiredException)
            {
                throw;
            }
        }

        public string GenerateMediaToken(Media media)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("fullPath", $"{media.Url}"),
                        new Claim("contentType", media.Extension)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _jwtSettings.Issuer,
                    Audience = _jwtSettings.Audience,
                    NotBefore = DateTime.UtcNow,
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return $"{_mediaConfig.Host}{"api/Medias/Download?token="}{tokenString}";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
