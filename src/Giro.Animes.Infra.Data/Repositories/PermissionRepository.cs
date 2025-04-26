using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Repositories
{
    public class PermissionRepository : BaseRepository<Permission, GiroAnimesDbContext>, IPermissionRepository
    {
        public PermissionRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsForNewAccounts(CancellationToken cancellationToken)
        {
            return await _dbSet.Where(permission => permission.IsDefault).ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Permission>> GetAllGuestPermissions(CancellationToken cancellationToken)
        {
            return await _dbSet.Where(permission => permission.IsGuest).ToListAsync(cancellationToken);
        }
    }
}
