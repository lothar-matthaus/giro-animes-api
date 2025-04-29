namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IMediaConfig
    {

        string Host { get; }
        string Path(string name);
        string MaxSize(string name);
        string[] AllowedExtensions(string name);
        string DefaultMedia(string name);
    }
}
