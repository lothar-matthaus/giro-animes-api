using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.ValueObjects;

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
            get { return _titles; }
            set
            {
                Validate(isInvalidIf: value == null || !value.Any(),
                    ifInvalid: () => Notification.Create(GetType().Name, "Titles", Message.Validation.Anime.TITLE_REQUIRED),
                    ifValid: () => _titles = value);
            }
        }
        #endregion

        /// <summary>
        /// Descrições do anime, em diferentes idiomas
        /// </summary>
        public IEnumerable<AnimeSinopse> Sinopses { get; private set; }

        /// <summary>
        /// Capa de exibição do anime 
        /// </summary>
        public Cover Cover { get; private set; }

        /// <summary>
        /// Screenshots de resumo para o anime em questão
        /// </summary>
        public IEnumerable<Screenshot> Screenshots { get; private set; }

        /// <summary>
        /// Episódios que o anime possui
        /// </summary>
        public IEnumerable<Episode> Episodes { get; private set; }

        /// <summary>
        /// Lista de autores do anime
        /// </summary>
        #region Authors
        private IEnumerable<Author> _authors;
        public IEnumerable<Author> Authors
        {
            get { return _authors; }
            set
            {
                Validate(isInvalidIf: value == null || !value.Any(),
                    ifInvalid: () => Notification.Create(GetType().Name, "Authors", Message.Validation.Anime.AUTHOR_REQUIRED),
                    ifValid: () => _authors = value);
            }
        }
        #endregion

        /// <summary>
        /// Notas dos usuário recebidas neste anime
        /// </summary>
        public IEnumerable<Rating> Ratings { get; private set; }

        /// <summary>
        /// Gêneros do anime
        /// </summary>
        #region Genres
        private IEnumerable<Genre> _genres;
        public IEnumerable<Genre> Genres
        {
            get { return _genres; }
            set
            {
                Validate(
                    isInvalidIf: value == null || !value.Any(),
                    ifInvalid: () => Notification.Create(GetType().Name, "Genres", Message.Validation.Anime.GENRE_REQUIRED),
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
        /// Construtor com parâmetros
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="cover"></param>
        /// <param name="authors"></param>
        /// <param name="sinopses"></param>
        /// <param name="status"></param>
        private Anime(IEnumerable<AnimeTitle> titles, Cover cover, IEnumerable<Author> authors, IEnumerable<AnimeSinopse> sinopses, IEnumerable<Genre> genres, Studio studio, AnimeStatus status)
        {
            Titles = titles;
            Cover = cover;
            Authors = authors;
            Sinopses = sinopses;
            Status = status;
            Studio = studio;
            Genres = genres;
        }

        /// <summary>
        /// Método para criar um novo anime 
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="cover"></param>
        /// <param name="authors"></param>
        /// <param name="sinopses"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Anime Create(IEnumerable<AnimeTitle> titles, Cover cover, IEnumerable<Author> authors, IEnumerable<AnimeSinopse> sinopses, IEnumerable<Genre> genres, Studio studio, AnimeStatus status)
            => new(titles, cover, authors, sinopses, genres, studio, status);

        #region Behaviors
        public void IncrementView() => ++Views;
        #endregion
    }
}
