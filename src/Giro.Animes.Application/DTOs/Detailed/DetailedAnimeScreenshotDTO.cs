namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade AnimeScreenshot.
    /// </summary>
    public class DetailedAnimeScreenshotDTO : MediaDTO
    {
        /// <summary>
        /// Obtém ou define o identificador do anime ao qual a captura de tela pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        private DetailedAnimeScreenshotDTO(long? id, DateTime creationDate, DateTime updateDate, long animeId, string url, string fileName, string extension) :
            base(id, creationDate, updateDate, url, fileName, extension)
        {
            AnimeId = animeId;
        }

        public static DetailedAnimeScreenshotDTO Create(long? id, DateTime creationDate, DateTime updateDate, long animeId, string url, string fileName, string extension)
            => new DetailedAnimeScreenshotDTO(id, creationDate, updateDate, animeId, url, fileName, extension);
    }
}