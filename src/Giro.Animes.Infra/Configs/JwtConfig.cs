using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;

namespace Giro.Animes.Infra.Configs
{
    public class JwtConfig : IJwtConfig
    {
        private readonly IConfiguration _configuration;

        public JwtConfig(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Issuer => Convert.ToString(_configuration.GetSection("JwtConfig:Issuer").Value ?? string.Empty);
        public string Audience => Convert.ToString(_configuration.GetSection("JwtConfig:Audience").Value ?? string.Empty);
        public string SecretKey => Convert.ToString(_configuration.GetSection("JwtConfig:SecretKey").Value ?? string.Empty);
        public bool ValidateIssuer => Convert.ToBoolean(_configuration.GetSection("JwtConfig:ValidateIssuer").Value ?? "false");
        public bool ValidateAudience => Convert.ToBoolean(_configuration.GetSection("JwtConfig:ValidateAudience").Value ?? "false");
        public bool ValidateLifetime => Convert.ToBoolean(_configuration.GetSection("JwtConfig:ValidateLifetime").Value ?? "false");
        public bool ValidateIssuerSigningKey => Convert.ToBoolean(_configuration.GetSection("JwtConfig:ValidateIssuerSigningKey").Value ?? "false");
    }
}
