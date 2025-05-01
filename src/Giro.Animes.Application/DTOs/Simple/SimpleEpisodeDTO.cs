using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleEpisodeDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Coleção de títulos do episódio.
        /// </summary>
        public IEnumerable<SimpleEpisodeTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Identificador da temporada associada a este episódio.
        /// </summary>
        public long SeasonId { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="seasonId"></param>
        /// <param name="id"></param>
        private SimpleEpisodeDTO(IEnumerable<SimpleEpisodeTitleDTO> titles, long seasonId, long? id) : base(id)
        {
            Titles = titles;
            SeasonId = seasonId;
        }

        /// <summary>
        /// Cria uma instância de SimpleEpisodeDTO.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="seasonId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleEpisodeDTO Create(IEnumerable<SimpleEpisodeTitleDTO> titles, long seasonId, long? id)
        {
            return new SimpleEpisodeDTO(titles, seasonId, id);
        }
    }
}
