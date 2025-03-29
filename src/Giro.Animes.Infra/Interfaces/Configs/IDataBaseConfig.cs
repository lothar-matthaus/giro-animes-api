using Microsoft.Extensions.Logging;

namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IDataBaseConfig
    {
        public string ConnectionString { get; }
        public bool EnableSensitiveDataLogging { get; }
        public LogLevel LogLevel { get; }
    }
}
