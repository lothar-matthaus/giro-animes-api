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

        private DetailedCoverDTO(long? id, DateTime creationDate, DateTime updateDate, long animeId, DetailedLanguageDTO language, string url, string fileName, string extension) :
            base(id, creationDate, updateDate, url, fileName, extension)
        {
            AnimeId = animeId;
            Language = language;
        }

        public static DetailedCoverDTO Create(long? id, DateTime creationDate, DateTime updateDate, long animeId, DetailedLanguageDTO language, string url, string fileName, string extension)
            => new DetailedCoverDTO(id, creationDate, updateDate, animeId, language, url, fileName, extension);
    }
}