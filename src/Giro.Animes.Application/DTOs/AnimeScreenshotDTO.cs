namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade AnimeScreenshot.
    /// </summary>
    public class AnimeScreenshotDTO : MediaDTO
    {
        /// <summary>
        /// Obtém ou define o identificador do anime ao qual a captura de tela pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        private AnimeScreenshotDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long animeId, string url, string fileName, string extension) :
            base(id, creationDate, updateDate, deletionDate, url, fileName, extension)
        {
            AnimeId = animeId;
        }

        public static AnimeScreenshotDTO Create(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long animeId, string url, string fileName, string extension)
            => new AnimeScreenshotDTO(id, creationDate, updateDate, deletionDate, animeId, url, fileName, extension);
    }
}