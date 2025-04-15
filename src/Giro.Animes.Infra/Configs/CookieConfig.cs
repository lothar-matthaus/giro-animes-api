using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Configs
{
    internal class CookieConfig : ICookieConfig
    {
        private readonly IConfigurationSection _section;
        public CookieConfig(IConfiguration configuration)
        {
            _section = configuration.GetSection("CookieConfig");
        }
        public string Name => _section["Name"] ?? "Giro.Animes.Access.Token";
        public string Path => _section["Path"] ?? "/";
        public bool HttpOnly => bool.TryParse(_section["HttpOnly"], out bool httpOnly) ? httpOnly : true;
        public bool Secure => bool.TryParse(_section["Secure"], out bool secure) ? secure : true;

        /// <summary>
        /// Define o modo SameSite do cookie. 0 - None, 1 - Lax, 2 - Strict
        /// </summary>
        public SameSiteMode SameSite => _section["SameSite"] switch
        {
            "0" => SameSiteMode.None,
            "1" => SameSiteMode.Lax,
            "2" => SameSiteMode.Strict,
            _ => SameSiteMode.None
        };
    }
}
