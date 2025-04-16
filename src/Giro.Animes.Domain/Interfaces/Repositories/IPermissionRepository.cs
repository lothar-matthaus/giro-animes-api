using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Repositories.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAllByGuestAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Permission>> GetAllByDefaultAsync(CancellationToken cancellationToken);
    }
}
