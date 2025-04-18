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

        public async Task<EntityResult<Anime>> CreateAnimeAsync(IEnumerable<AnimeTitle> titles, IEnumerable<AnimeSinopse> sinopses, IEnumerable<Cover> covers, IEnumerable<AnimeScreenshot> screenshots, IEnumerable<long> authors, IEnumerable<long> genres, AnimeStatus status, long studioId, CancellationToken cancellation)
        {
            IEnumerable<Author> authorsList = await _authorRepository.GetAuthorsByIdsAsync(authors, cancellation);
            IEnumerable<Genre> genresList = await _genreRepository.GetAllByIdsAsync(genres, cancellation);
            Studio studio = await _studioRepository.GetByIdAsync(studioId, cancellation);

            List<Notification> notifications = new List<Notification>();

            if (studio is null)
                notifications.Add(Notification.Create("Anime", "CreateAnime", Message.Studio.STUDIO_NOT_FOUND));

            if (authorsList is null || !authorsList.Any())
                notifications.Add(Notification.Create("Anime", "CreateAnime", Message.Author.AUTHOR_NOT_FOUND));

            if (genresList is null || !genresList.Any())
                notifications.Add(Notification.Create("Anime", "CreateAnime", Message.Genre.GENRES_NOT_FOUND));

            if (notifications.Any())
            {
                return EntityResult<Anime>.Create(null, notifications);
            }

            Anime anime = Anime.Create(titles, covers, authorsList, sinopses, genresList, studio, status);

            await _repository.AddAsync(anime, cancellation);

            return EntityResult<Anime>.Create(anime, anime.GetErrors());
        }

        public async Task<EntityResult<AnimeSinopse>> CreateAnimeSinopseAsync(string sinopse, long languageId, CancellationToken cancellationToken)
        {
            Language language = await _languageRepository.GetLanguageByIdAsync(languageId, cancellationToken);

            if (language is null)
                return EntityResult<AnimeSinopse>.Create(null, new List<Notification> { Notification.Create("AnimeSinopse", "CreateAnimeSinopse", Message.Language.LANGUAGE_NOT_FOUND) });

            AnimeSinopse animeSinopse = AnimeSinopse.Create(sinopse, language);

            return EntityResult<AnimeSinopse>.Create(animeSinopse, animeSinopse.GetErrors());
        }

        public async Task<EntityResult<AnimeTitle>> CreateAnimeTitleAsync(string title, long languageId, CancellationToken cancellationToken)
        {
            Language language = await _languageRepository.GetLanguageByIdAsync(languageId, cancellationToken);

            if (language is null)
                return EntityResult<AnimeTitle>.Create(null, new List<Notification> { Notification.Create("AnimeTitle", "CreateAnimeTitle", Message.Language.LANGUAGE_NOT_FOUND) });

            AnimeTitle animeTitle = AnimeTitle.Create(title, language);

            return EntityResult<AnimeTitle>.Create(animeTitle, animeTitle.GetErrors());
        }

        public async Task<EntityResult<Cover>> CreateCoverAsync(byte[] cover, string extension, long languageId, CancellationToken cancellationToken)
        {
            Language language = await _languageRepository.GetLanguageByIdAsync(languageId, cancellationToken);

            if (language is null)
                return EntityResult<Cover>.Create(null, new List<Notification> { Notification.Create("Cover", "CreateCover", Message.Language.LANGUAGE_NOT_FOUND) });

            Cover animeCover = Cover.Create(cover, extension, language);

            return EntityResult<Cover>.Create(animeCover, animeCover.GetErrors());
        }

        public async Task<EntityResult<AnimeScreenshot>> CreateScreenshotAsync(byte[] screenshot, string extension, CancellationToken cancellationToken)
        {
            AnimeScreenshot animeScreenshot = AnimeScreenshot.Create(screenshot, extension);

            return EntityResult<AnimeScreenshot>.Create(animeScreenshot, animeScreenshot.GetErrors());
        }

        public async Task<(IEnumerable<Anime>, int)> GetAllPagedAsync(IPagination<AnimeFilter> pagination, CancellationToken cancellationToken)
        {
            return await _repository.GetAllPagedAsync(pagination, cancellationToken);
        }

        public async Task<Anime> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

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
