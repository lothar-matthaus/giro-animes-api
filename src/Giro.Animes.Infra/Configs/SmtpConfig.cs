using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Configs
{
    public class SmtpConfig : ISmtpConfig
    {
        private readonly IConfigurationSection _configSection;
        public SmtpConfig(IConfiguration configuration)
        {
            _configSection = configuration.GetSection("SmtpConfig");
        }

        public string Host => _configSection["Host"] ?? string.Empty;

        public int Port => _configSection.GetValue<int>("Port");

        public string UserName => _configSection["UserName"] ?? string.Empty;

        public string Password => _configSection["Password"] ?? string.Empty;

        public bool EnableSsl => _configSection.GetValue<bool>("EnableSsl");

        public string FromEmail => _configSection["FromEmail"] ?? string.Empty;

        public string FromName => _configSection["FromName"] ?? string.Empty;
    }
}
