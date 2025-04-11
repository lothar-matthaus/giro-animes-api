using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAllByRoleAsync(UserRole role, CancellationToken cancellationToken = default);
    }
}
