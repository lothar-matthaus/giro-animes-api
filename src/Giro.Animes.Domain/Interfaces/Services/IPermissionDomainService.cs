using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IPermissionDomainService : IDomainServiceBase
    {
        Task<IEnumerable<Permission>> GetAllByUserRoleAsync(UserRole role, CancellationToken cancellationToken);
    }
}
