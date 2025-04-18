using Microsoft.AspNetCore.Http;

namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface ICookieConfig
    {
        public string Name { get; }
        public string Path { get; }
        public bool HttpOnly { get; }
        public bool Secure { get; }
        public SameSiteMode SameSite { get; }
    }
}
