using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Pagination;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Services
{
    public class AnimeDomainService : DomainServiceBase<IAnimeRepository, Anime>, IAnimeDomainService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IStudioRepository _studioRepository;

        public AnimeDomainService(IAnimeRepository repository,
            ILanguageRepository languageRepository,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository,
            IStudioRepository studioRepository) : base(repository)
        {
            _languageRepository = languageRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _studioRepository = studioRepository;
        }

        /// <summary>
        /// Cria uma nova entidade Anime com os detalhes fornecidos e a valida.
        /// </summary>
        /// <param name="titles">Coleção de títulos para o anime.</param>
        /// <param name="sinopses">Coleção de sinopses para o anime.</param>
        /// <param name="cover">Imagem de capa do anime.</param>
        /// <param name="screenshots">Coleção de capturas de tela para o anime.</param>
        /// <param name="authors">IDs dos autores associados ao anime.</param>
        /// <param name="genres">IDs dos gêneros associados ao anime.</param>
        /// <param name="status">Status do anime.</param>
        /// <param name="studioId">ID do estúdio associado ao anime.</param>
        /// <param name="cancellation">Token de cancelamento.</param>
        /// <returns>EntityResult contendo o Anime criado e quaisquer notificações de validação.</returns>
        public async Task<EntityResult<Anime>> CreateAnimeAsync(IEnumerable<AnimeTitle> titles, IEnumerable<AnimeSinopse> sinopses, Cover cover, Banner banner, IEnumerable<Screenshot> screenshots, IEnumerable<long> authors, IEnumerable<long> genres, AnimeStatus status, long studioId, CancellationToken cancellation)
        {
            IEnumerable<Author> authorsList = await _authorRepository.GetAuthorsByIdsAsync(authors, cancellation); // Fetch authors by IDs
            IEnumerable<Genre> genresList = await _genreRepository.GetAllByIdsAsync(genres, cancellation); // Fetch genres by IDs
            Studio studio = await _studioRepository.GetByIdAsync(studioId, cancellation); // Fetch studio by ID

            // Create the anime with the provided details
            Anime anime = Anime.Create(titles, cover, banner, screenshots, authorsList, sinopses, genresList, studio, status);

            // Validate the anime
            IList<Notification> notifications = new List<Notification>()
                .Concat(anime.IsValid ? [] : anime.GetErrors())
                .Concat((cover?.IsValid ?? true) ? [] : anime.Cover.GetErrors())
                .Concat((banner?.IsValid ?? true) ? [] : anime.Banner.GetErrors())
                .Concat(screenshots.Any(scr => !scr.IsValid) ? anime.Screenshots.SelectMany(scr => scr.GetErrors()).Distinct() : [])
                .Concat(authorsList.Any(auth => !auth.IsValid) ? anime.Authors.SelectMany(auth => auth.GetErrors()).Distinct() : [])
                .Concat(genresList.Any(gen => !gen.IsValid) ? anime.Genres.SelectMany(gen => gen.GetErrors()).Distinct() : [])
                .Concat(sinopses.Any(sin => !sin.IsValid) ? anime.Sinopses.SelectMany(sin => sin.GetErrors()).Distinct() : [])
                .Concat(titles.Any(tit => !tit.IsValid) ? anime.Titles.SelectMany(tit => tit.GetErrors()).Distinct() : [])
                .ToList();

            if (!notifications.Any())
                await _repository.AddAsync(anime, cancellation);

            return EntityResult<Anime>.Create(anime, notifications);
        }

        public async Task<EntityResult<Anime>> UpdateAnimeAsync(long id, IEnumerable<AnimeTitle> titles, IEnumerable<AnimeSinopse> sinopses, Cover cover, Banner banner, IEnumerable<Screenshot> screenshots, IEnumerable<long> authors, IEnumerable<long> genres, AnimeStatus status, long studioId, CancellationToken cancellation)
        {
            Anime anime = await _repository.GetByIdAsync(id, cancellation);

            if (anime == null)
            {
                return EntityResult<Anime>.Create(null, new List<Notification>() { Notification.Create(nameof(UpdateAnimeAsync), "Id", Message.Anime.ANIME_NOT_FOUND) });
            }

            IEnumerable<Author> authorsList = await _authorRepository.GetAuthorsByIdsAsync(authors, cancellation); // Fetch authors by IDs
            IEnumerable<Genre> genresList = await _genreRepository.GetAllByIdsAsync(genres, cancellation); // Fetch genres by IDs
            Studio studio = await _studioRepository.GetByIdAsync(studioId, cancellation); // Fetch studio by ID

            anime.UpdateAuthors(authorsList);
            anime.UpdateGenres(genresList);
            anime.UpdateStudio(studio);
            anime.UpdateStatus(status);
            anime.UpdateTitles(titles);
            anime.UpdateSinopses(sinopses);
            anime.UpdateCover(cover);
            anime.UpdateBanner(banner);
            anime.UpdateScreenshots(screenshots);

            // Validate the anime
            IList<Notification> notifications = new List<Notification>()
                .Concat(anime.IsValid ? [] : anime.GetErrors())
                .Concat((cover?.IsValid ?? true) ? [] : anime.Cover.GetErrors())
                .Concat((banner?.IsValid ?? true) ? [] : anime.Banner.GetErrors())
                .Concat(screenshots.Any(scr => !scr.IsValid) ? anime.Screenshots.SelectMany(scr => scr.GetErrors()).Distinct() : [])
                .Concat(authorsList.Any(auth => !auth.IsValid) ? anime.Authors.SelectMany(auth => auth.GetErrors()).Distinct() : [])
                .Concat(genresList.Any(gen => !gen.IsValid) ? anime.Genres.SelectMany(gen => gen.GetErrors()).Distinct() : [])
                .Concat(sinopses.Any(sin => !sin.IsValid) ? anime.Sinopses.SelectMany(sin => sin.GetErrors()).Distinct() : [])
                .Concat(titles.Any(tit => !tit.IsValid) ? anime.Titles.SelectMany(tit => tit.GetErrors()).Distinct() : [])
                .ToList();

            if (!notifications.Any())
                _repository.Update(anime);

            return EntityResult<Anime>.Create(anime, notifications);
        }

        /// <summary>
        /// Cria uma nova entidade AnimeSinopse com o texto e idioma fornecidos.
        /// </summary>
        /// <param name="sinopse">Texto da sinopse.</param>
        /// <param name="languageId">ID do idioma para a sinopse.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>EntityResult contendo a AnimeSinopse criada e quaisquer notificações de validação.</returns>
        public async Task<EntityResult<AnimeSinopse>> CreateAnimeSinopseAsync(string sinopse, long languageId, CancellationToken cancellationToken)
        {
            Language language = await _languageRepository.GetLanguageByIdAsync(languageId, cancellationToken);

            if (language is null)
                return EntityResult<AnimeSinopse>.Create(null, new List<Notification> { Notification.Create("AnimeSinopse", "CreateAnimeSinopse", Message.Language.LANGUAGE_NOT_FOUND) });

            AnimeSinopse animeSinopse = AnimeSinopse.Create(sinopse, language);

            return EntityResult<AnimeSinopse>.Create(animeSinopse, animeSinopse.GetErrors());
        }

        /// <summary>
        /// Cria uma nova entidade AnimeTitle com o título e idioma fornecidos.
        /// </summary>
        /// <param name="title">Título do anime.</param>
        /// <param name="languageId">ID do idioma para o título.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>EntityResult contendo o AnimeTitle criado e quaisquer notificações de validação.</returns>
        public async Task<EntityResult<AnimeTitle>> CreateAnimeTitleAsync(string title, long languageId, CancellationToken cancellationToken)
        {
            Language language = await _languageRepository.GetLanguageByIdAsync(languageId, cancellationToken);

            if (language is null)
                return EntityResult<AnimeTitle>.Create(null, new List<Notification> { Notification.Create("AnimeTitle", "CreateAnimeTitle", Message.Language.LANGUAGE_NOT_FOUND) });

            AnimeTitle animeTitle = AnimeTitle.Create(title, language);

            return EntityResult<AnimeTitle>.Create(animeTitle, animeTitle.GetErrors());
        }

        public Task<EntityResult<Banner>> CreateBannerAsync(string url, CancellationToken cancellationToken)
        {
            Banner banner = Banner.Create(url);

            return Task.FromResult(EntityResult<Banner>.Create(banner, banner.GetErrors()));
        }

        /// <summary>
        /// Cria uma nova entidade Cover com a URL fornecida.
        /// </summary>
        /// <param name="url">URL da imagem de capa.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>EntityResult contendo a Cover criada e quaisquer notificações de validação.</returns>
        public async Task<EntityResult<Cover>> CreateCoverAsync(string url, CancellationToken cancellationToken)
        {
            Cover animeCover = Cover.Create(url);

            return EntityResult<Cover>.Create(animeCover, animeCover.GetErrors());
        }

        /// <summary>
        /// Cria uma nova entidade Screenshot com a URL fornecida.
        /// </summary>
        /// <param name="url">URL da captura de tela.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>EntityResult contendo a Screenshot criada e quaisquer notificações de validação.</returns>
        public Task<EntityResult<Screenshot>> CreateScreenshotAsync(string url, CancellationToken cancellationToken)
        {
            Screenshot animeScreenshot = Screenshot.Create(url);

            return Task.FromResult(EntityResult<Screenshot>.Create(animeScreenshot, animeScreenshot.GetErrors()));
        }

        /// <summary>
        /// Recupera uma lista paginada de entidades Anime com base no filtro fornecido.
        /// </summary>
        /// <param name="pagination">Parâmetros de paginação e filtro.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Tupla contendo a lista de entidades Anime e a contagem total.</returns>
        public async Task<(IEnumerable<Anime>, int)> GetAllPagedAsync(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken)
        {
            return await _repository.GetAllPagedAsync(pagination, cancellationToken);
        }

        /// <summary>
        /// Recupera uma entidade Anime pelo seu ID.
        /// </summary>
        /// <param name="id">ID do anime.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A entidade Anime, se encontrada, caso contrário, null.</returns>
        public async Task<Anime> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Incrementa a contagem de visualizações de uma entidade Anime pelo seu ID.
        /// </summary>
        /// <param name="id">ID do anime.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>EntityResult contendo o Anime atualizado e quaisquer notificações de validação.</returns>
        public async Task<EntityResult<Anime>> IncrementView(long id, CancellationToken cancellationToken)
        {
            Anime anime = await _repository.GetByIdAsync(id, cancellationToken);

            if (anime is null)
                return EntityResult<Anime>.Create(anime, new List<Notification> { Notification.Create("Anime", "IncrementView", "Anime não encontrado") });

            anime.IncrementView();
            _repository.Update(anime);

            return EntityResult<Anime>.Create(anime, null);
        }
    }
}
