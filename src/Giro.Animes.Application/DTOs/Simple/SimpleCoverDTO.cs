using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleCoverDTO : SimpleMediaDTO
    {
        /// <summary>
        /// Id do anime associado a esta capa.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="animeId"></param>
        /// <param name="id"></param>
        private SimpleCoverDTO(long? id, string url, long animeId)
            : base(url, id)
        {
            AnimeId = animeId;
        }

        /// <summary>
        /// Cria uma instância de SimpleCoverDTO.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="animeId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleCoverDTO Create(long? id, string url, long animeId)
        {
            return new SimpleCoverDTO(id, url, animeId);
        }
    }
}
