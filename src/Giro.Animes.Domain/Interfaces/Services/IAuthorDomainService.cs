using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IAuthorDomainService : IDomainServiceBase
    {
        Task<(IEnumerable<Author>, int)> GetAllAuthorsPagedAsync(IPagination<AuthorFilter> param, CancellationToken cancellationToken);
        Task<IEnumerable<Author>> GetAllAuthorsAsync(CancellationToken cancellationToken);
        Task<Author> GetAuthorByIdAsync(long id);
    }
}
