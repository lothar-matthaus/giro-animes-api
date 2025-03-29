using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;

namespace Giro.Animes.Infra.Configs
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public IDataBaseConfig DataBaseConfig => new DataBaseConfig(_configuration);
        public IJwtConfig JwtConfig => new JwtConfig(_configuration);
    }
}
