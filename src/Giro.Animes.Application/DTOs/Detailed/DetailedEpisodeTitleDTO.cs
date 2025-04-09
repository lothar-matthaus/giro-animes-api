namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeTitle.
    /// </summary>
    public class DetailedEpisodeTitleDTO : TitleDTO
    {
        /// <summary>
        /// Identificador do episódio ao qual o título pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        private DetailedEpisodeTitleDTO(long? id, DateTime creationDate, DateTime updateDate, long episodeId, string name, DetailedLanguageDTO language) :
            base(id, creationDate, updateDate, name, language)
        {
            EpisodeId = episodeId;
        }

        public static DetailedEpisodeTitleDTO Create(long? id, DateTime creationDate, DateTime updateDate, long episodeId, string name, DetailedLanguageDTO language)
            => new DetailedEpisodeTitleDTO(id, creationDate, updateDate, episodeId, name, language);
    }
}