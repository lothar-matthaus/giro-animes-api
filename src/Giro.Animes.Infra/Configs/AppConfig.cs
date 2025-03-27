using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Configs
{
    public class AppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public DataBaseConfig DataBaseConfig => new DataBaseConfig(_configuration);
        public JwtConfig JwtConfig => new JwtConfig(_configuration);
    }
}
