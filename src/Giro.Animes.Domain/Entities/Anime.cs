using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Domain.Entities
{
    public class Anime : EntityBase
    {
        /// <summary>
        /// Lista de títulos do anime
        /// </summary>
        public ICollection<Title> Titles { get; private set; }

        /// <summary>
        /// Descrições do anime, em diferentes idiomas
        /// </summary>
        public ICollection<Description> Sinopses { get; private set; }

        /// <summary>
        /// Lista de capas do anime 
        /// </summary>
        public ICollection<Cover> Covers { get; private set; }

        /// <summary>
        /// Lista de autores do anime
        /// </summary>
        public ICollection<Author> Authors { get; private set; }

        /// <summary>
        /// Studio que criou o anime
        /// </summary>
        public Studio Studio { get; private set; }

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
        private Anime(ICollection<Title> titles, ICollection<Cover> covers, ICollection<Author> authors, ICollection<Description> sinopses, AnimeStatus status)
        {
            Titles = titles;
            Covers = covers;
            Authors = authors;
            Sinopses = sinopses;
            Status = status;
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
        public static Anime Create(ICollection<Title> titles, ICollection<Cover> covers, ICollection<Author> authors, ICollection<Description> sinopses, AnimeStatus status) => new Anime(titles, covers, authors, sinopses, status);

    }
}
