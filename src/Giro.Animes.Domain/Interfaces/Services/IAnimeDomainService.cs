using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IAnimeDomainService : IDomainServiceBase
    {
        Task<(IEnumerable<Anime>, int)> GetAllPagedAsync(IPagination pagination, CancellationToken cancellationToken);
        Task<Anime> GetByIdAsync(long id, CancellationToken cancellationToken);
    }
}
