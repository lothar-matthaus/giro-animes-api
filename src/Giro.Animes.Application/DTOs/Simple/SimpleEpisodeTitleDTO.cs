using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleEpisodeTitleDTO : SimpleTitleDTO
    {
        /// <summary>
        /// ID do episódio associado a este título.
        /// </summary>
        public long EpisodeId { get; set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="id"></param>
        /// <param name="episodeId"></param>
        private SimpleEpisodeTitleDTO(string name, SimpleLanguageDTO language, long? id, long episodeId) : base(name, language, id)
        {
            EpisodeId = episodeId;
        }

        /// <summary>
        /// Cria uma instância de SimpleEpisodeTitleDTO.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="id"></param>
        /// <param name="episodeId"></param>
        /// <returns></returns>
        public static SimpleEpisodeTitleDTO Create(string name, SimpleLanguageDTO language, long? id, long episodeId)
        {
            return new SimpleEpisodeTitleDTO(name, language, id, episodeId);
        }
    }
}
