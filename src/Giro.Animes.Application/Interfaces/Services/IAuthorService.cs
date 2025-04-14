using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAuthorService : IApplicationServiceBase
    {
        Task<DetailedAuthorDTO> GetAuthorByIdAsync(long id);
        Task<IPagedEnumerable<DetailedAuthorDTO>> GetAllAuthorsPagedAsync(IPagination<AuthorFilter> param, CancellationToken cancellation);
        Task<IEnumerable<SimpleComboxDTO>> GetAllAuthorsComboxAsync(CancellationToken cancellationToken);
    }
}
