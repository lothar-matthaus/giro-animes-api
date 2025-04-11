using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Repositories
{
    public class PermissionRepository : BaseRepository<Permission, GiroAnimesDbContext>, IPermissionRepository
    {
        public PermissionRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Permission>> GetAllByRoleAsync(UserRole role, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(x => x.Role == role).ToListAsync(cancellationToken);
        }
    }
}
