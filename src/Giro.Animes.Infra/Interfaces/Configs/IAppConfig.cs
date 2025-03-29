namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IAppConfig
    {
        public IDataBaseConfig DataBaseConfig { get; }
        public IJwtConfig JwtConfig { get; }
    }
}
