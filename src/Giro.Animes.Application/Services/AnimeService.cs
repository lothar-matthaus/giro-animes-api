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
using Microsoft.AspNetCore.WebUtilities;

namespace Giro.Animes.Application.Services
{
    internal class AnimeService : ApplicationServiceBase<IAnimeDomainService>, IAnimeService
    {
        private readonly ITokenService _tokenService;
        private readonly IFileMediaStorageService _storageService;

        public AnimeService(IApplicationUser applicationUser, INotificationService notificationService, ITokenService tokenService, IAnimeDomainService domainService, IFileMediaStorageService storageService) : 
            base(applicationUser, notificationService, domainService)
        {
            _tokenService = tokenService;
            _storageService = storageService;
        }

        public async Task<DetailedAnimeDTO> CreateAnimeAsync(AnimeCreateRequest request, CancellationToken cancellationToken)
        {
            IList<AnimeTitle> titles = new List<AnimeTitle>();
            IList<AnimeSinopse> sinopses = new List<AnimeSinopse>();
            IList<Cover> covers = new List<Cover>();
            IList<AnimeScreenshot> screenshots = new List<AnimeScreenshot>();


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

            // Cria as capas de animes]
            foreach(CoverRequest cover in request.Covers)
            {
                byte[] fileBytes = cover.File.ReadAsBytes();

                EntityResult<Cover> coverResult = await _domainService.CreateCoverAsync(fileBytes, cover.Extension, cover.LanguageId, cancellationToken);

                if (!coverResult.IsValid)
                {
                    await _notificationService.AddNotification(coverResult.Errors);
                    continue;
                }

                covers.Add(coverResult.Entity);
            }

            // Persiste temporariamente as capas no storage 
            await _storageService.UploadAsync(covers.ToArray());

            // Cria os screenshots de animes
            foreach(ScreenshotRequest screenshot in request.Screenshots)
            {
                byte[] fileBytes = screenshot.File.ReadAsBytes();
                EntityResult<AnimeScreenshot> screenshotResult = await _domainService.CreateScreenshotAsync(fileBytes, screenshot.Extension, cancellationToken);
                
                if (!screenshotResult.IsValid)
                {
                    await _notificationService.AddNotification(screenshotResult.Errors);
                    continue;
                }

                screenshots.Add(screenshotResult.Entity);
            }

            // Persiste temporariamente os screenshots no storage
            await _storageService.UploadAsync(screenshots.ToArray());

            EntityResult<Anime> animeResult = await _domainService.CreateAnimeAsync(titles, sinopses, covers, screenshots, request.Authors, request.Genres, AnimeStatus.Unknown, request.StudioId, cancellationToken);
            
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

            foreach(Anime anime in animes)
            {
                anime.Covers.Select(cover => cover.SetUrl(_tokenService.GenerateMediaToken(cover))).ToList();
                anime.Screenshots.Select(screenshot => screenshot.SetUrl(_tokenService.GenerateMediaToken(screenshot))).ToList();
            }

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
