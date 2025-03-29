using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Giro.Animes.Infra.Configs
{
    public class DataBaseConfig : IDataBaseConfig
    {
        private readonly IConfiguration _configuration;

        public DataBaseConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetSection("DataBaseConfig:ConnectionString").Value ?? string.Empty;
        public bool EnableSensitiveDataLogging => bool.Parse(_configuration.GetSection("DataBaseConfig:EnableSensitiveDataLogging").Value ?? "false");
        public LogLevel LogLevel => Enum.Parse<LogLevel>(_configuration.GetSection("DataBaseConfig:LogLevel").Value ?? "6");
    }
}
