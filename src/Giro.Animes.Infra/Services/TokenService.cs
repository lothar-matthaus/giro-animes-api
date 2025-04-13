using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Infra.DTOs;
using Giro.Animes.Infra.Interfaces.Configs;
using Giro.Animes.Infra.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Giro.Animes.Infra.Services
{
    public class TokenService : ITokenService
    {
        private readonly IJwtSettings _jwtSettings;
        private readonly IPermissionDomainService _permissionDomainService;

        public TokenService(IJwtSettings appConfig, IPermissionDomainService permissionDomainService)
        {
            _jwtSettings = appConfig;
            _permissionDomainService = permissionDomainService;
        }

        // Busca as permissões do usuário no banco de dados e adiciona as claims ao token
        private async Task<Claim[]> GetClaimsByUserRole(UserRole role)
        {
            IEnumerable<Permission> permissions = await _permissionDomainService.GetAllByUserRoleAsync(role, CancellationToken.None);
            return permissions.Select(permission => new Claim("Permission", $"{permission.Resource}:{permission.Action}")).ToArray();
        }

        public async Task<UserTokenDTO> GenerateUserToken(Account account)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                Claim[] claims = await GetClaimsByUserRole(account.User.Role);

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

                return userTokenDTO;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao gerar o token do usuário. Contate o adminstrador para mais detalhes.", ex);
            }
        }

        public async Task<UserTokenDTO> GenerateGuestToken()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
                Claim[] claims = await GetClaimsByUserRole(UserRole.Guest);

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
    }
}
