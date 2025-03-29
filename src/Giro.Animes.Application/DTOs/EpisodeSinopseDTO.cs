using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeSinopse.
    /// </summary>
    public class EpisodeSinopseDTO : DescriptionDTO
    {
        /// <summary>
        /// Identificador do episódio ao qual a descrição pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        private EpisodeSinopseDTO(long? id, DateTime creationDate, DateTime updateDate, string text, long episodeId, LanguageDTO language) :
            base(id, creationDate, updateDate, text, language)
        {
            EpisodeId = episodeId;
        }

        public static EpisodeSinopseDTO Create(long? id, DateTime creationDate, DateTime updateDate, string text, long episodeId, LanguageDTO language)
            => new EpisodeSinopseDTO(id, creationDate, updateDate, text, episodeId, language);
    }
}