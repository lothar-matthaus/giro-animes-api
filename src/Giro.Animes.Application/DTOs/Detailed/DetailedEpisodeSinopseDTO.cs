using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeSinopse.
    /// </summary>
    public class DetailedEpisodeSinopseDTO : DescriptionDTO
    {
        /// <summary>
        /// Identificador do episódio ao qual a descrição pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        private DetailedEpisodeSinopseDTO(long? id, DateTime creationDate, DateTime updateDate, string text, long episodeId, DetailedLanguageDTO language) :
            base(id, creationDate, updateDate, text, language)
        {
            EpisodeId = episodeId;
        }

        public static DetailedEpisodeSinopseDTO Create(long? id, DateTime creationDate, DateTime updateDate, string text, long episodeId, DetailedLanguageDTO language)
            => new DetailedEpisodeSinopseDTO(id, creationDate, updateDate, text, episodeId, language);
    }
}