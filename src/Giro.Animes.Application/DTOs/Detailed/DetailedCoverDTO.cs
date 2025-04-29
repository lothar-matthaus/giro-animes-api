namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Cover.
    /// </summary>
    public class DetailedCoverDTO : MediaDTO
    {
        /// <summary>
        /// Obtém ou define o identificador do anime ao qual a capa pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Obtém ou define o idioma da capa.
        /// </summary>
        public DetailedLanguageDTO Language { get; private set; }

        private DetailedCoverDTO(long? id, string url, long animeId, DateTime creationDate, DateTime updateDate ) :
            base(id, url, creationDate, updateDate)
        {
            AnimeId = animeId;
        }

        public static DetailedCoverDTO Create(long? id, string url, long animeId, DateTime creationDate, DateTime updateDate)
            => new DetailedCoverDTO(id, url, animeId, creationDate, updateDate);
    }
}