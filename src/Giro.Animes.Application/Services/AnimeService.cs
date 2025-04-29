using Giro.Animes.Application.Custom;
using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Application.Extensions;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
using Giro.Animes.Application.Requests.Anime;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.Interfaces;
using Giro.Animes.Infra.Interfaces.Services;

namespace Giro.Animes.Application.Services
{
    internal class AnimeService : ApplicationServiceBase<IAnimeDomainService>, IAnimeService
    {
        private readonly ITokenService _tokenService;

        public AnimeService(IApplicationUser applicationUser, INotificationService notificationService, ITokenService tokenService, IAnimeDomainService domainService) :
            base(applicationUser, notificationService, domainService)
        {
            _tokenService = tokenService;
        }

        public async Task<DetailedAnimeDTO> CreateAnimeAsync(AnimeCreateOrUpdateRequest request, CancellationToken cancellationToken)
        {
            IList<AnimeTitle> titles = new List<AnimeTitle>();
            IList<AnimeSinopse> sinopses = new List<AnimeSinopse>();
            IList<Screenshot> screenshots = new List<Screenshot>();
            Cover cover = null;

            // Cria os título de animes
            foreach (AnimeTitleRequest title in request.Titles)
            {
                EntityResult<AnimeTitle> titleResult = await _domainService.CreateAnimeTitleAsync(title.Name, title.LanguageId, cancellationToken);

                if (!titleResult.IsValid)
                {
                    await _notificationService.AddNotification(titleResult.Errors);
                    continue;
                }

                titles.Add(titleResult.Entity);
            }

            // Cria as sinopses de animes
            foreach (AnimeSinopseRequest sinopse in request.Sinopses)
            {
                EntityResult<AnimeSinopse> sinopseResult = await _domainService.CreateAnimeSinopseAsync(sinopse.Descrition, sinopse.LanguageId, cancellationToken);

                if (!sinopseResult.IsValid)
                {
                    await _notificationService.AddNotification(sinopseResult.Errors);
                    continue;
                }

                sinopses.Add(sinopseResult.Entity);
            }

            // Cria a capa do anime
            EntityResult<Cover> coverResult = await _domainService.CreateCoverAsync(request.CoverUrl, cancellationToken);

            if (!coverResult.IsValid)
            {
                await _notificationService.AddNotification(coverResult.Errors);
            }
            else
            {
                cover = coverResult.Entity;
            }

            // Cria os screenshots de animes
            foreach (string screenshotUrl in request.Screenshots)
            {
                EntityResult<Screenshot> screenshotResult = await _domainService.CreateScreenshotAsync(screenshotUrl, cancellationToken);

                if (!screenshotResult.IsValid)
                {
                    await _notificationService.AddNotification(screenshotResult.Errors);
                    continue;
                }

                screenshots.Add(screenshotResult.Entity);
            }

            EntityResult<Anime> animeResult = await _domainService.CreateAnimeAsync(titles, sinopses, cover, screenshots, request.Authors, request.Genres, AnimeStatus.Ongoing, request.StudioId, cancellationToken);

            if (!animeResult.IsValid)
            {
                await _notificationService.AddNotification(animeResult.Errors);
                return null;
            }

            return animeResult.Entity.Map();
        }

        /// <summary>
        /// Método para obter uma lista paginada de animes. 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IPagedEnumerable<SimpleAnimeDTO>> GetAllPagedAsync(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken)
        {
            (IEnumerable<Anime> animes, int totalCount) = await _domainService.GetAllPagedAsync(pagination, cancellationToken);

            IPagedEnumerable<SimpleAnimeDTO> result = PagedEnumerable<SimpleAnimeDTO>.Create(animes?.MapSimple(), pagination.Page, pagination.RowsPerPage, totalCount);
            return result;
        }

        /// <summary>
        /// Método para obter um anime pelo seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<DetailedAnimeDTO> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            Anime anime = await _domainService.GetByIdAsync(id, cancellationToken);

            return anime?.Map();
        }

        public async Task IncrementViewAsync(long id, CancellationToken cancellationToken)
        {
            EntityResult<Anime> result = await _domainService.IncrementView(id, cancellationToken);

            if (!result.IsValid)
            {
                await _notificationService.AddNotification(result.Errors);
            }
        }
    }
}
