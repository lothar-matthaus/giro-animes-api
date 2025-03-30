using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Configs
{
    internal class MediaConfig : IMediaConfig
    {
        private readonly IConfiguration configuration;

        public MediaConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

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
            return configuration.GetSection(string.Format("Media:{0}:Peah", name)).Value ?? "";
        }
    }
}
