using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities.Joint
{
    /// <summary>
    /// Representa a junção entre autores e animes
    /// </summary>
    public class Works : EntityBase
    {
        /// <summary>
        /// Identificador do autor
        /// </summary>
        public long AuthorId { get; set; }

        /// <summary>
        /// Identificador do anime
        /// </summary>
        public long AnimeId { get; set; }

        /// <summary>
        /// Navegação para o autor
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Navegação para o anime
        /// </summary>
        public Anime Anime { get; set; }

        /// <summary>
        /// Construtor padrão 
        /// </summary>
        public Works()
        {
            CreationDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }

    }
}
