using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;

namespace Giro.Animes.Infra.Configs
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDataBaseConfig DataBaseConfig => new DataBaseConfig(_configuration);
        public IJwtSettings JwtSettings => new JwtSettings(_configuration);
        public IMediaConfig MediaConfig => new MediaConfig(_configuration);
    }
}
