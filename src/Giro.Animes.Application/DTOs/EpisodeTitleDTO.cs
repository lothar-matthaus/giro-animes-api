namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeTitle.
    /// </summary>
    public class EpisodeTitleDTO : TitleDTO
    {
        /// <summary>
        /// Identificador do episódio ao qual o título pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        private EpisodeTitleDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long episodeId, string name, LanguageDTO language) :
            base(id, creationDate, updateDate, deletionDate, name, language)
        {
            EpisodeId = episodeId;
        }

        public static EpisodeTitleDTO Create(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long episodeId, string name, LanguageDTO language)
            => new EpisodeTitleDTO(id, creationDate, updateDate, deletionDate, episodeId, name, language);
    }
}