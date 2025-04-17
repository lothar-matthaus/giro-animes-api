using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;

namespace Giro.Animes.Infra.Configs
{
    internal class MediaConfig : IMediaConfig
    {
        private readonly IConfiguration configuration;

        public MediaConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Host URL for media files.
        /// </summary>
        public string Host => configuration.GetSection("Media:Host").Value ?? "";

        /// <summary>
        /// Returns the allowed file extensions for a specific media type.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string[] AllowedExtensions(string name)
        {
            return configuration.GetSection(string.Format("Media:{0}:AllowedExtensions", name)).Value?.Split(",") ?? new string[] { };
        }

        public string DefaultMedia(string name)
        {
            return configuration.GetSection(string.Format("Media:{0}:DefaultMedia", name)).Value ?? "";
        }

        public string MaxSize(string name)
        {
            return configuration.GetSection(string.Format("Media:{0}:MaxSize", name)).Value ?? "";
        }

        public string Path(string name)
        {
            return configuration.GetSection(string.Format("Media:{0}:Path", name)).Value ?? "";
        }
    }
}
