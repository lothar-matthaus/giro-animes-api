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
        /// ID do anime associado a este episódio.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="animeId"></param>
        /// <param name="id"></param>
        private SimpleEpisodeDTO(IEnumerable<SimpleEpisodeTitleDTO> titles, long animeId, long? id) : base(id)
        {
            Titles = titles;
            AnimeId = animeId;
        }

        /// <summary>
        /// Cria uma instância de SimpleEpisodeDTO.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="animeId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleEpisodeDTO Create(IEnumerable<SimpleEpisodeTitleDTO> titles, long animeId, long? id)
        {
            return new SimpleEpisodeDTO(titles, animeId, id);
        }
    }
}
