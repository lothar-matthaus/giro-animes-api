using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> UsernameAlreadyExists(string username, CancellationToken cancellationToken);
        Task<bool> EmailAlreadyExists(string email, CancellationToken cancellationToken);
    }
}
