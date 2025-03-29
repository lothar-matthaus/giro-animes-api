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
        /// Idioma do arquivo.
        /// </summary>
        public LanguageDTO Language { get; private set; }

        private EpisodeFileDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, string url, string fileName, string extension, long episodeId, LanguageDTO language) :
            base(id, creationDate, updateDate, deletionDate, url, fileName, extension)
        {
            EpisodeId = episodeId;
            Language = language;
        }

        public static EpisodeFileDTO Create(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, string url, string fileName, string extension, long episodeId, LanguageDTO language)
            => new EpisodeFileDTO(id, creationDate, updateDate, deletionDate, url, fileName, extension, episodeId, language);
    }
}