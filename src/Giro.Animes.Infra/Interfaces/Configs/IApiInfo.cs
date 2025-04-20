namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IApiInfo
    {
        string Name { get; }
        string Version { get; }
        string Description { get; }
        string Host { get; }
    }
}
