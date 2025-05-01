using Giro.Animes.Application.Custom;
using Giro.Animes.Application.DTOs;
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
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.Interfaces;
using Giro.Animes.Infra.Interfaces.Services;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Threading;

namespace Giro.Animes.Application.Services
{
    /// <summary>
    /// Serviço responsável por gerenciar operações relacionadas a animes.
    /// </summary>
    internal class AnimeService : ApplicationServiceBase<IAnimeDomainService>, IAnimeService
    {
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Construtor do AnimeService.
        /// </summary>
        /// <param name="applicationUser">O contexto do usuário da aplicação.</param>
        /// <param name="notificationService">Serviço para lidar com notificações.</param>
        /// <param name="tokenService">Serviço para lidar com a geração de tokens.</param>
        /// <param name="domainService">Serviço de domínio para operações de anime.</param>
        public AnimeService(IApplicationUser applicationUser, INotificationService notificationService, ITokenService tokenService, IAnimeDomainService domainService) :
            base(applicationUser, notificationService, domainService)
        {
            _tokenService = tokenService;
        }

        private async Task<(IEnumerable<AnimeTitle>, IEnumerable<AnimeSinopse>, IEnumerable<Screenshot>)> AnimeDetailListCreator(IEnumerable<AnimeTitleRequest> titlesRequest, IEnumerable<AnimeSinopseRequest> sinopseRequests, IEnumerable<string> screenshotsRequest, CancellationToken cancellationToken)
        {
            IList<AnimeTitle> titles = new List<AnimeTitle>();
            IList<AnimeSinopse> sinopses = new List<AnimeSinopse>();
            IList<Screenshot> screenshots = new List<Screenshot>();

            // Cria os títulos do anime
            foreach (AnimeTitleRequest title in titlesRequest)
            {
                EntityResult<AnimeTitle> titleResult = await _domainService.CreateAnimeTitleAsync(title.Name, title.LanguageId, cancellationToken);
                titles.Add(titleResult.Entity);
            }

            // Cria as sinopses do anime
            foreach (AnimeSinopseRequest sinopse in sinopseRequests)
            {
                EntityResult<AnimeSinopse> sinopseResult = await _domainService.CreateAnimeSinopseAsync(sinopse.Descrition, sinopse.LanguageId, cancellationToken);
                sinopses.Add(sinopseResult.Entity);
            }


            // Cria as capturas de tela do anime
            foreach (string screenshotUrl in screenshotsRequest)
            {
                EntityResult<Screenshot> screenshotResult = await _domainService.CreateScreenshotAsync(screenshotUrl, cancellationToken);
                screenshots.Add(screenshotResult.Entity);
            }

            // Retorna os títulos, sinopses e capturas de tela criados
            return (titles, sinopses, screenshots);
        }

        /// <summary>
        /// Cria um novo anime com os detalhes fornecidos.
        /// </summary>
        /// <param name="request">A requisição contendo os detalhes do anime.</param>
        /// <param name="cancellationToken">Token para cancelar a operação.</param>
        /// <returns>Um DTO detalhado do anime criado.</returns>
        public async Task<DetailedAnimeDTO> CreateAnimeAsync(AnimeCreateRequest request, CancellationToken cancellationToken)
        {
            (IEnumerable<AnimeTitle> titles, IEnumerable<AnimeSinopse> sinopses, IEnumerable<Screenshot> screenshots) = await AnimeDetailListCreator(request.Titles, request.Sinopses, request.Screenshots, cancellationToken);
            
            EntityResult<Cover> coverResult = await _domainService.CreateCoverAsync(request.CoverUrl, cancellationToken);
            EntityResult<Banner> bannerResult = await _domainService.CreateBannerAsync(request.BannerUrl, cancellationToken);

            EntityResult<Anime> animeResult = await _domainService.CreateAnimeAsync(titles, sinopses, coverResult.Entity, bannerResult.Entity, screenshots, request.Authors, request.Genres, AnimeStatus.Ongoing, request.StudioId, cancellationToken);

            if (!animeResult.IsValid)
            {
                await _notificationService.AddNotification(animeResult.Errors);
                return null;
            }

            return animeResult.Entity.Map();
        }

        /// <summary>
        /// Recupera uma lista paginada de animes para a página inicial.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<AnimeHomeDTO> GetAllHomePage(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recupera uma lista paginada de animes.
        /// </summary>
        /// <param name="pagination">Detalhes de paginação e filtros.</param>
        /// <param name="cancellationToken">Token para cancelar a operação.</param>
        /// <returns>Uma lista paginada de DTOs simples de animes.</returns>
        public async Task<IPagedEnumerable<SimpleAnimeDTO>> GetAllPagedAsync(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken)
        {
            (IEnumerable<Anime> animes, int totalCount) = await _domainService.GetAllPagedAsync(pagination, cancellationToken);

            IPagedEnumerable<SimpleAnimeDTO> result = PagedEnumerable<SimpleAnimeDTO>.Create(animes?.MapSimple(), pagination.Page, pagination.RowsPerPage, totalCount);
            return result;
        }

        /// <summary>
        /// Recupera um anime pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do anime.</param>
        /// <param name="cancellationToken">Token para cancelar a operação.</param>
        /// <returns>Um DTO detalhado do anime.</returns>
        public async Task<DetailedAnimeDTO> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            Anime anime = await _domainService.GetByIdAsync(id, cancellationToken);

            return anime?.Map();
        }

        /// <summary>
        /// Incrementa o contador de visualizações de um anime.
        /// </summary>
        /// <param name="id">O ID do anime.</param>
        /// <param name="cancellationToken">Token para cancelar a operação.</param>
        public async Task IncrementViewAsync(long id, CancellationToken cancellationToken)
        {
            EntityResult<Anime> result = await _domainService.IncrementView(id, cancellationToken);

            if (!result.IsValid)
            {
                await _notificationService.AddNotification(result.Errors);
            }
        }

        /// <summary>
        /// Atualiza os detalhes de um anime existente.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<DetailedAnimeDTO> UpdateAnimeAsync(AnimeUpdateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
