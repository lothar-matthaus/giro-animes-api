using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IPermissionDomainService : IDomainServiceBase
    {
        Task<IEnumerable<Permission>> GetAllByGuest(CancellationToken cancellationToken);
    }
}
