using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAllGuestPermissions(CancellationToken cancellationToken);
        Task<IEnumerable<Permission>> GetAllPermissionsForNewAccounts(CancellationToken cancellationToken);
    }
}
