using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IAuthorDomainService : IDomainServiceBase
    {
        Task<(IEnumerable<Author>, int)> GetAllAuthorsPagedAsync(IPagination param);
        Task<Author> GetAuthorByIdAsync(long id);
    }
}
