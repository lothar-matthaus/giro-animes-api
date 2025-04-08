namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeFile.
    /// </summary>
    public class EpisodeFileDTO : MediaDTO
    {
        /// <summary>
        /// Identificador do episódio ao qual o arquivo pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Idiomma do audio do arquivo.
        /// </summary>
        public LanguageDTO AudioLanguage { get; private set; }

        /// <summary>
        /// Idioma da legenda do arquivo.
        /// </summary>
        public LanguageDTO SubtitleLanguage { get; private set; }

        private EpisodeFileDTO(long? id, DateTime creationDate, DateTime updateDate, string url, string fileName, string extension, long episodeId, LanguageDTO audioLanguage, LanguageDTO subtitleLanguage) :
            base(id, creationDate, updateDate, url, fileName, extension)
        {
            EpisodeId = episodeId;
            AudioLanguage = audioLanguage;
            SubtitleLanguage = subtitleLanguage;
        }

        public static EpisodeFileDTO Create(long? id, DateTime creationDate, DateTime updateDate, string url, string fileName, string extension, long episodeId, LanguageDTO audioLanguage, LanguageDTO subtitleLanguage)
            => new EpisodeFileDTO(id, creationDate, updateDate, url, fileName, extension, episodeId, audioLanguage, subtitleLanguage);
    }
}