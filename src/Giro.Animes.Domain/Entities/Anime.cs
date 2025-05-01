using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Giro.Animes.Domain.Entities
{
    public class Anime : EntityBase
    {
        /// <summary>
        /// Título do anime, em diferentes idiomas
        /// </summary>
        #region Titles
        private IEnumerable<AnimeTitle> _titles;
        public IEnumerable<AnimeTitle> Titles
        {
            get { return _titles ?? []; }
            set
            {
                // Verifica se existem títulos
                Validate(isInvalidIf: value == null || !value.Any(),
                    ifInvalid: () => Notification.Create(GetType().Name, nameof(Titles), Message.Validation.Anime.TITLE_REQUIRED),
                    ifValid: () => _titles = value);

                // Verifica se existem títulos duplicados
                Validate(isInvalidIf: value.GroupBy(title => title.Language.Id).Any(group => group.Count() > 1),
                    ifInvalid: () => Notification.Create(GetType().Name, nameof(Titles), string.Format(Message.Validation.Anime.DUPLICATED_LANGUAGE, "Os títulos")),
                    ifValid: () => _titles = value);
            }
        }
        #endregion

        #region Sinopses
        private IEnumerable<AnimeSinopse> _sinopes;
        public IEnumerable<AnimeSinopse> Sinopses
        {
            get { return _sinopes ?? []; }
            set
            {
                Validate(isInvalidIf: value is not null && value.GroupBy(title => title.Language.Id).Any(group => group.Count() > 1),
                    ifInvalid: () => Notification.Create(GetType().Name, nameof(Sinopses), string.Format(Message.Validation.Anime.DUPLICATED_LANGUAGE, "As sinopses")),
                    ifValid: () => _sinopes = value);
            }
        }
        #endregion

        /// <summary>
        /// Capa de exibição do anime 
        /// </summary>
        public Cover Cover { get; private set; }

        /// <summary>
        /// Banner de exibição do anime
        /// </summary>
        public Banner Banner { get; private set; }

        /// <summary>
        /// Screenshots de resumo para o anime em questão
        /// </summary>
        public IEnumerable<Screenshot> Screenshots { get; private set; }

        /// <summary>
        /// Lista de episódios do anime
        /// </summary>
        public ICollection<Season> Seasons { get; private set; }

        /// <summary>
        /// Lista de autores do anime
        /// </summary>
        #region Authors
        private IEnumerable<Author> _authors;
        public IEnumerable<Author> Authors
        {
            get { return _authors ?? []; }
            set
            {
                Validate(isInvalidIf: value == null || !value.Any(),
                    ifInvalid: () => Notification.Create(GetType().Name, nameof(Authors), Message.Validation.Anime.AUTHOR_REQUIRED),
                    ifValid: () => _authors = value);

                Validate(isInvalidIf: value.GroupBy(auth => auth.Id).Any(group => group.Count() > 1),
                    ifInvalid: () => Notification.Create(GetType().Name, nameof(Authors), Message.Validation.Anime.DUPLICATED_AUTHORS),
                    ifValid: () => _authors = value);
            }
        }
        #endregion

        /// <summary>
        /// Notas dos usuário recebidas neste anime
        /// </summary>
        public ICollection<Rating> Ratings { get; private set; }

        /// <summary>
        /// Gêneros do anime
        /// </summary>
        #region Genres
        private IEnumerable<Genre> _genres;
        public IEnumerable<Genre> Genres
        {
            get { return _genres ?? []; }
            set
            {
                Validate(
                    isInvalidIf: value == null || !value.Any(),
                    ifInvalid: () => Notification.Create(GetType().Name, nameof(Genres), Message.Validation.Anime.GENRE_REQUIRED),
                    ifValid: () => _genres = value);

                Validate(isInvalidIf: value.GroupBy(gen => gen.Id).Any(group => group.Count() > 1),
                    ifInvalid: () => Notification.Create(GetType().Name, nameof(Genres), Message.Validation.Anime.DUPLICATED_GENRES),
                    ifValid: () => _genres = value);
            }
        }
        #endregion


        /// <summary>
        /// Identificador do estúdio de animação
        /// </summary>
        public long StudioId { get; private set; }

        #region Studio
        private Studio _studio;
        public Studio Studio
        {
            get { return _studio; }
            set
            {
                Validate(
                    isInvalidIf: value == null,
                    ifInvalid: () => Notification.Create(GetType().Name, "Studio", Message.Validation.Anime.STUDIO_REQUIRED),
                    ifValid: () => _studio = value);
            }
        }
        #endregion

        /// <summary>
        /// Contas de usuário que o anime é favoritado
        /// </summary>
        public IEnumerable<User> Users { get; private set; }

        /// <summary>
        /// Número de visualizações do anime
        /// </summary>
        public long Views { get; private set; } = 0;

        /// <summary>
        /// Status do anime
        /// </summary>
        #region Status
        private AnimeStatus _status;
        public AnimeStatus Status
        {
            get { return _status; }
            set
            {
                Validate(
                    isInvalidIf: !Enum.IsDefined(value),
                    ifInvalid: () => Notification.Create(GetType().Name, "Studio", Message.Validation.Anime.INVALID_STATUS),
                    ifValid: () => _status = value);
            }
        }
        #endregion

        public Anime()
        {

        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="cover"></param>
        /// <param name="screenshots"></param>
        /// <param name="authors"></param>
        /// <param name="sinopses"></param>
        /// <param name="genres"></param>
        /// <param name="studio"></param>
        /// <param name="status"></param>
        /// <param name="banner"></param>
        private Anime(IEnumerable<AnimeTitle> titles, Cover cover, Banner banner, IEnumerable<Screenshot> screenshots, IEnumerable<Author> authors, IEnumerable<AnimeSinopse> sinopses, IEnumerable<Genre> genres, Studio studio, AnimeStatus status)
        {
            Titles = titles;
            Cover = cover;
            Screenshots = screenshots;
            Authors = authors;
            Sinopses = sinopses;
            Status = status;
            Studio = studio;
            Genres = genres;
            Banner = banner;
        }

        /// <summary>
        /// Método estático para criar um objeto Anime com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="cover"></param>
        /// <param name="screenshots"></param>
        /// <param name="authors"></param>
        /// <param name="sinopses"></param>
        /// <param name="genres"></param>
        /// <param name="studio"></param>
        /// <param name="status"></param>
        /// <param name="banner"></param>
        /// <returns></returns>
        public static Anime Create(IEnumerable<AnimeTitle> titles, Cover cover, Banner banner, IEnumerable<Screenshot> screenshots, IEnumerable<Author> authors, IEnumerable<AnimeSinopse> sinopses, IEnumerable<Genre> genres, Studio studio, AnimeStatus status)
            => new(titles, cover, banner, screenshots, authors, sinopses, genres, studio, status);

        #region Behaviors
        public void IncrementView() => ++Views;

        public void UpdateCover(Cover cover) => Cover = cover;
        public void UpdateBanner(Banner banner) => Banner = banner;
        public void UpdateStatus(AnimeStatus status) => Status = status;
        public void UpdateStudio(Studio studio) => Studio = studio;
        public void UpdateGenres(IEnumerable<Genre> genres) => Genres = genres;
        public void UpdateAuthors(IEnumerable<Author> authors) => Authors = authors;
        public void UpdateSinopses(IEnumerable<AnimeSinopse> sinopses) => Sinopses = sinopses;
        public void UpdateTitles(IEnumerable<AnimeTitle> titles) => Titles = titles;
        public void UpdateScreenshots(IEnumerable<Screenshot> screenshots) => Screenshots = screenshots;

        public void AddRating(Rating rating)
        {
            Ratings ??= new List<Rating>();
            Ratings.Add(rating);
        }
        public void RemoveRating(Rating rating)
        {
            if (Ratings == null) return;
            Ratings.Remove(rating);
        }

        #endregion
    }
}
