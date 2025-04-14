using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests.Anime;
using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAnimeService : IApplicationServiceBase
    {
        Task<DetailedAnimeDTO> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<IPagedEnumerable<SimpleAnimeDTO>> GetAllPagedAsync(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken);
        Task IncrementViewAsync(long id, CancellationToken requestAborted);
        Task<DetailedAnimeDTO> CreateAnimeAsync(AnimeCreateRequest request, CancellationToken cancellationToken);
    }
}
