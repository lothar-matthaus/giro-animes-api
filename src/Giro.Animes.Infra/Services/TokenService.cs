using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Infra.DTOs;
using Giro.Animes.Infra.Interfaces;
using Giro.Animes.Infra.Interfaces.Configs;
using Giro.Animes.Infra.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Giro.Animes.Infra.Services
{
    public class TokenService : ITokenService
    {
        private readonly IJwtSettings _jwtSettings;
        private readonly ICookieConfig _cookieConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPermissionDomainService _permissionDomainService;

        public TokenService(IJwtSettings appConfig, ICookieConfig cookieConfig, IHttpContextAccessor httpContextAccessor, IPermissionDomainService permissionDomainService, IApplicationUser user)
        {
            _jwtSettings = appConfig;
            _cookieConfig = cookieConfig;
            _httpContextAccessor = httpContextAccessor;
            _permissionDomainService = permissionDomainService;
        }

        /// <summary>
        /// Valida o token JWT e retorna as claims
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private Task<Claim[]> ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            try
            {
                // Configurações de validação do token
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = _jwtSettings.ValidateIssuer,
                    ValidIssuer = _jwtSettings.Issuer,
                    ValidateAudience = _jwtSettings.ValidateAudience,
                    ValidAudience = _jwtSettings.Audience,
                    ValidateLifetime = _jwtSettings.ValidateLifetime, // Valida a expiração do token
                    ClockSkew = TimeSpan.Zero, // Remove tolerância de tempo para expiração
                    ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                // Valida o token e retorna as claims
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                if (validatedToken is not JwtSecurityToken jwtToken ||
                    !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Token inválido ou algoritmo de assinatura não suportado.");
                }

                return Task.FromResult(jwtToken.Claims.ToArray());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gera um descriptor de token JWT com base nas claims fornecidas.
        /// </summary>
        /// <param name="tokenHandler">Instância do manipulador de tokens JWT.</param>
        /// <param name="claims">Claims do usuário que serão incluídas no token.</param>
        /// <returns>Um <see cref="SecurityTokenDescriptor"/> configurado com as informações do token.</returns>
        /// <exception cref="ArgumentNullException">Lançado se o manipulador de token for nulo.</exception>
        /// <exception cref="ArgumentException">Lançado se as claims forem nulas ou vazias.</exception>
        private Task<SecurityTokenDescriptor> GenerateToken(JwtSecurityTokenHandler tokenHandler, Claim[] claims)
        {
            if (tokenHandler == null)
                throw new ArgumentNullException(nameof(tokenHandler), "O manipulador de token não pode ser nulo.");

            if (claims == null || claims.Length == 0)
                throw new ArgumentException("As claims não podem ser nulas ou vazias.", nameof(claims));

            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.Now,
                CompressionAlgorithm = "HmacSha256Signature"
            };

            return Task.FromResult(tokenDescriptor);
        }
        // Busca as permissões do usuário no banco de dados e adiciona as claims ao token
        private Task<Claim[]> GetPermissions(IEnumerable<Permission> permissions)
        {
            return Task.FromResult(permissions.Select(permission => new Claim("Permission", $"{permission.Resource}:{permission.Action}")).ToArray());
        }

        public async Task<UserTokenDTO> GenerateUserToken(Account account, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            Claim[] claims = await GetPermissions(account.User.Permissions);
            claims.Union(new[] {
                        new Claim(ClaimTypes.Name, account.User.Name),
                        new Claim(ClaimTypes.Role, account.User.Role.ToString()),
                        new Claim(ClaimTypes.Sid, account.User.Id.ToString()),
                        new Claim(ClaimTypes.Email, account?.Email.Value)
                });

            SecurityTokenDescriptor tokenDescriptor = await GenerateToken(tokenHandler, claims);
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            UserTokenDTO userTokenDTO = UserTokenDTO.Create(account.User.Name, tokenString, tokenDescriptor.Expires.Value.Subtract(DateTime.UtcNow).TotalSeconds, account.User.Role.ToString());
            SetCookie(userTokenDTO);

            return userTokenDTO;
        }

        public async Task<UserTokenDTO> GenerateGuestToken(CancellationToken cancellationToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                Claim[] claims = await GetPermissions(await _permissionDomainService.GetAllGuestPermissions(cancellationToken));
                claims.Union(new[]
                {
                    new Claim(ClaimTypes.Name, "Guest"),
                    new Claim(ClaimTypes.Role, UserRole.Guest.ToString()),
                });

                SecurityTokenDescriptor tokenDescriptor = await GenerateToken(tokenHandler, claims);
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                string tokenString = tokenHandler.WriteToken(token);
                UserTokenDTO userTokenDTO = UserTokenDTO.Create("Guest", tokenString, tokenDescriptor.Expires.Value.Subtract(DateTime.UtcNow).TotalSeconds, UserRole.Guest.ToString());

                SetCookie(userTokenDTO);

                return userTokenDTO;
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
        public async Task<UserTokenDTO> GenerateAccountActivationToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            Claim[] claims = new[]
            {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, UserRole.User.ToString()),
                    new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString())
            };

            SecurityTokenDescriptor tokenDescriptor = await GenerateToken(tokenHandler, claims);
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string tokenString = tokenHandler.WriteToken(token);
            UserTokenDTO userTokenDTO = UserTokenDTO.Create(username, tokenString, tokenDescriptor.Expires.Value.Subtract(DateTime.UtcNow).TotalSeconds, UserRole.Guest.ToString());

            return userTokenDTO;
        }
        public async Task<string> ValidateAccountActivationToken(string token)
        {
            Claim[] claims = await ValidateToken(token);

            return claims.First(x => x.Type == JwtRegisteredClaimNames.UniqueName).Value;
        }
    }
}
