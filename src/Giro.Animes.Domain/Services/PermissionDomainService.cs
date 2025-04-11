using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Services
{
    public class PermissionDomainService : DomainServiceBase<IPermissionRepository, Permission>, IPermissionDomainService
    {
        public PermissionDomainService(IPermissionRepository repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Permission>> GetAllByUserRoleAsync(UserRole role, CancellationToken cancellationToken)
        {
            return await _repository.GetAllByRoleAsync(role, cancellationToken);
        }
    }
}
