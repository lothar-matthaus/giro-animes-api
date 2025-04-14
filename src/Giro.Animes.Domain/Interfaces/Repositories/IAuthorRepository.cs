using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories.Base;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<(IEnumerable<Author>, int)> GetAllPagedAsync(IPagination<AuthorFilter> param, CancellationToken cancellationToken);
        Task<IEnumerable<Author>> GetAuthorsByIdsAsync(IEnumerable<long> ids, CancellationToken cancellationToken);
    }
}
