namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Cover.
    /// </summary>
    public class CoverDTO : MediaDTO
    {
        /// <summary>
        /// Obtém ou define o identificador do anime ao qual a capa pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Obtém ou define o idioma da capa.
        /// </summary>
        public LanguageDTO Language { get; private set; }

        private CoverDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long animeId, LanguageDTO language, string url, string fileName, string extension) :
            base(id, creationDate, updateDate, deletionDate, url, fileName, extension)
        {
            AnimeId = animeId;
            Language = language;
        }

        public static CoverDTO Create(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long animeId, LanguageDTO language, string url, string fileName, string extension)
            => new CoverDTO(id, creationDate, updateDate, deletionDate, animeId, language, url, fileName, extension);
    }
}