using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Infra.Interfaces
{
    public interface IApplicationUser
    {
        public long Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public UserRole Role { get; }
        public string[] Language { get; }
    }
}
