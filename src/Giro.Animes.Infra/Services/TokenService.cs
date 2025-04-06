using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
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
        private readonly IAppConfig _appConfig;

        public TokenService(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public async Task<UserTokenDTO> GenerateUserToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appConfig.JwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Role.Name),
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Account?.Email.Value)
                }),
                Issuer = _appConfig.JwtSettings.Issuer,
                Audience = _appConfig.JwtSettings.Audience,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var userTokenDTO = UserTokenDTO.Create(user.Name, tokenString, tokenDescriptor.Expires.Value.Subtract(DateTime.UtcNow).TotalSeconds, user.Role.Name);

            return await Task.Run(() =>
            {
                return userTokenDTO;
            });
        }

        public async Task<UserTokenDTO> GenerateUserToken()
        {
            User user = User.Create("Guest", UserStatus.Inactive, UserRole.Guest);
            return await GenerateUserToken(user);
        }
    }
}
