namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IAppConfig
    {
        public IDataBaseConfig DataBaseConfig { get; }
        public IJwtSettings JwtSettings { get; }
        public IMediaConfig MediaConfig { get; }
    }
}
