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

        private DetailedAnimeScreenshotDTO(long? id, string url, long animeId, DateTime creationDate, DateTime updateDate) :
            base(id, url, creationDate, updateDate)
        {
            AnimeId = animeId;
        }

        public static DetailedAnimeScreenshotDTO Create(long? id, string url, long animeId, DateTime creationDate, DateTime updateDate)
            => new DetailedAnimeScreenshotDTO(id, url, animeId, creationDate, updateDate);
    }
}