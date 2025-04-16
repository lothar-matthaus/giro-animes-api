using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;

namespace Giro.Animes.Domain.Services
{
    public class PermissionDomainService : DomainServiceBase<IPermissionRepository, Permission>, IPermissionDomainService
    {
        public PermissionDomainService(IPermissionRepository repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Permission>> GetAllByGuest(CancellationToken cancellationToken)
        {
            return await _repository.GetAllByGuestAsync(cancellationToken);
        }
    }
}
