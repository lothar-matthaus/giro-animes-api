using Giro.Animes.Application.Custom;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Infra.Interfaces;

namespace Giro.Animes.Application.Services
{
    internal class AnimeService : ApplicationServiceBase<IAnimeDomainService>, IAnimeService
    {
        public AnimeService(IApplicationUser applicationUser, INotificationService notificationService, IAnimeDomainService domainService) : base(applicationUser, notificationService, domainService)
        {
        }

        /// <summary>
        /// Método para obter uma lista paginada de animes. 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IPagedEnumerable<AnimeDTO>> GetAllPagedAsync(IPagination pagination, CancellationToken cancellationToken)
        {
            (IEnumerable<Anime> animes, int totalCount) = await _domainService.GetAllPagedAsync(pagination, cancellationToken);
            IPagedEnumerable<AnimeDTO> result = PagedEnumerable<AnimeDTO>.Create(animes?.Map(), pagination.Page, pagination.RowsPerPage, totalCount);
            return result;
        }

        /// <summary>
        /// Método para obter um anime pelo seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<AnimeDTO> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
