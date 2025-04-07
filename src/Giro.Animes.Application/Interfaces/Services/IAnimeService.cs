using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAnimeService : IApplicationServiceBase
    {
        Task<AnimeDTO> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<IPagedEnumerable<AnimeDTO>> GetAllPagedAsync(IPagination pagination, CancellationToken cancellationToken);
    }
}
