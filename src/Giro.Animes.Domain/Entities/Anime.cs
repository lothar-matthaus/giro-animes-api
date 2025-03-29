using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Domain.Entities
{
    public class Anime : EntityBase
    {
        /// <summary>
        /// Lista de títulos do anime
        /// </summary>
        public IEnumerable<AnimeTitle> Titles { get; private set; }

        /// <summary>
        /// Descrições do anime, em diferentes idiomas
        /// </summary>
        public IEnumerable<AnimeSinopse> Sinopses { get; private set; }

        /// <summary>
        /// Lista de capas do anime 
        /// </summary>
        public IEnumerable<Cover> Covers { get; private set; }

        /// <summary>
        /// Screenshots de resumo para o anime em questão
        /// </summary>
        public IEnumerable<AnimeScreenshot> Screenshots { get; private set; }

        /// <summary>
        /// Episódios que o anime possui
        /// </summary>
        public IEnumerable<Episode> Episodes { get; private set; }

        /// <summary>
        /// Lista de autores do anime
        /// </summary>
        public IEnumerable<Author> Authors { get; private set; }

        /// <summary>
        /// Notas dos usuário recebidas neste anime
        /// </summary>
        public IEnumerable<Rating> Ratings { get; private set; }

        /// <summary>
        /// Gêneros que o anime possui
        /// </summary>
        public IEnumerable<Genre> Genres { get; private set; }

        /// <summary>
        /// Identificador do estúdio de animação
        /// </summary>
        public long StudioId { get; private set; }

        /// <summary>
        /// Studio que criou o anime
        /// </summary>
        public Studio Studio { get; private set; }

        /// <summary>
        /// Contas de usuário que o anime é favoritado
        /// </summary>
        public IEnumerable<Account> Accounts { get; private set; }

        /// <summary>
        /// Indica o status do anime 
        /// </summary>
        public AnimeStatus Status { get; private set; }

        public Anime()
        {

        }

        /// <summary>
        /// Construtor com parâmetros
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="covers"></param>
        /// <param name="authors"></param>
        /// <param name="sinopses"></param>
        /// <param name="status"></param>
        private Anime(IEnumerable<AnimeTitle> titles, IEnumerable<Cover> covers, IEnumerable<Author> authors, IEnumerable<AnimeSinopse> sinopses, IEnumerable<Genre> genres, Studio studio, AnimeStatus status)
        {
            Titles = titles;
            Covers = covers;
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
        /// <param name="covers"></param>
        /// <param name="authors"></param>
        /// <param name="sinopses"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Anime Create(IEnumerable<AnimeTitle> titles, IEnumerable<Cover> covers, IEnumerable<Author> authors, IEnumerable<AnimeSinopse> sinopses, IEnumerable<Genre> genres, Studio studio, AnimeStatus status)
            => new(titles, covers, authors, sinopses, genres, studio, status);

    }
}
