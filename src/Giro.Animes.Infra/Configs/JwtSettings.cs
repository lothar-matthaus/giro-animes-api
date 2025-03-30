using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;

namespace Giro.Animes.Infra.Configs
{
    public class JwtSettings : IJwtSettings
    {
        private readonly IConfiguration _configuration;

        public JwtSettings(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Issuer => Convert.ToString(_configuration.GetSection("JwtSettings:Issuer").Value ?? string.Empty);
        public string Audience => Convert.ToString(_configuration.GetSection("JwtSettings:Audience").Value ?? string.Empty);
        public string SecretKey => Convert.ToString(_configuration.GetSection("JwtSettings:SecretKey").Value ?? string.Empty);
        public bool ValidateIssuer => Convert.ToBoolean(_configuration.GetSection("JwtSettings:ValidateIssuer").Value ?? "false");
        public bool ValidateAudience => Convert.ToBoolean(_configuration.GetSection("JwtSettings:ValidateAudience").Value ?? "false");
        public bool ValidateLifetime => Convert.ToBoolean(_configuration.GetSection("JwtSettings:ValidateLifetime").Value ?? "false");
        public bool ValidateIssuerSigningKey => Convert.ToBoolean(_configuration.GetSection("JwtSettings:ValidateIssuerSigningKey").Value ?? "false");
        public bool RequireHttpsMetadata => Convert.ToBoolean(_configuration.GetSection("JwtSettings:RequireHttpsMetadata").Value ?? "false");
        public bool SaveToken => Convert.ToBoolean(_configuration.GetSection("JwtSettings:SaveToken").Value ?? "false");
        public int ClockSkewSeconds => Convert.ToInt32(_configuration.GetSection("JwtSettings:ClockSkewSeconds").Value ?? "0");
        public int TokenExpirationMinutes => Convert.ToInt32(_configuration.GetSection("JwtSettings:TokenExpirationMinutes").Value ?? "0");
    }
}
