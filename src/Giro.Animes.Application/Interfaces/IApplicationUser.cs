using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.Interfaces
{
    public interface IApplicationUser
    {
        public long Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public UserRole Role { get; }
    }
}
