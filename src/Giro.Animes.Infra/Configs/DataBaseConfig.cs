using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Configs
{
    public class DataBaseConfig
    {
        private readonly IConfiguration _configuration;

        public DataBaseConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GiroAnimesDb => _configuration.GetConnectionString("GiroAnimesDb") ?? string.Empty;
    }
}
