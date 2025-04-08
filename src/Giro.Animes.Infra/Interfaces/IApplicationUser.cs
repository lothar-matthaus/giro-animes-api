using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Infra.Interfaces
{
    public interface IApplicationUser
    {
        public long Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public UserRole Role { get; }
        public string InterfaceLanguage { get; }
        public string[] AudioAnimeLanguages { get; }
        public string[] SubtitleAnimeLanguages { get; }
    }
}
