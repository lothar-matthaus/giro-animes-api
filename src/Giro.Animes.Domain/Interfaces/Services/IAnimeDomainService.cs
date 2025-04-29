using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IAnimeDomainService : IDomainServiceBase
    {
        Task<(IEnumerable<Anime>, int)> GetAllPagedAsync(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken);
        Task<Anime> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<EntityResult<Anime>> IncrementView(long id, CancellationToken cancellationToken);
        Task<EntityResult<Anime>> CreateAnimeAsync(IEnumerable<AnimeTitle> titles, IEnumerable<AnimeSinopse> sinopses, Cover cover, IEnumerable<Screenshot> screenshots, IEnumerable<long> authors, IEnumerable<long> genres, AnimeStatus status, long studioId, CancellationToken cancellation);
        Task<EntityResult<AnimeTitle>> CreateAnimeTitleAsync(string title, long languageId, CancellationToken cancellationToken);
        Task<EntityResult<AnimeSinopse>> CreateAnimeSinopseAsync(string sinopse, long languageId, CancellationToken cancellationToken);
        Task<EntityResult<Cover>> CreateCoverAsync(string url, CancellationToken cancellationToken);
        Task<EntityResult<Screenshot>> CreateScreenshotAsync(string url, CancellationToken cancellationToken);
    }
}
