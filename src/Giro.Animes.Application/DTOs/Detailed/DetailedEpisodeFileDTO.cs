namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeFile.
    /// </summary>
    public class DetailedEpisodeFileDTO : MediaDTO
    {
        /// <summary>
        /// Identificador do episódio ao qual o arquivo pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Idiomma do audio do arquivo.
        /// </summary>
        public DetailedLanguageDTO AudioLanguage { get; private set; }

        /// <summary>
        /// Idioma da legenda do arquivo.
        /// </summary>
        public DetailedLanguageDTO SubtitleLanguage { get; private set; }

        private DetailedEpisodeFileDTO(long? id, DateTime creationDate, DateTime updateDate, string url, string fileName, string extension, long episodeId, DetailedLanguageDTO audioLanguage, DetailedLanguageDTO subtitleLanguage) :
            base(id, creationDate, updateDate, url, fileName, extension)
        {
            EpisodeId = episodeId;
            AudioLanguage = audioLanguage;
            SubtitleLanguage = subtitleLanguage;
        }

        public static DetailedEpisodeFileDTO Create(long? id, DateTime creationDate, DateTime updateDate, string url, string fileName, string extension, long episodeId, DetailedLanguageDTO audioLanguage, DetailedLanguageDTO subtitleLanguage)
            => new DetailedEpisodeFileDTO(id, creationDate, updateDate, url, fileName, extension, episodeId, audioLanguage, subtitleLanguage);
    }
}