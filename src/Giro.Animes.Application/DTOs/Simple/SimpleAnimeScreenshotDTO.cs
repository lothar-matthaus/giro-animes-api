using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleAnimeScreenshotDTO : SimpleMediaDTO
    {
        /// <summary>
        /// Identificador do anime associado a esta captura de tela.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <param name="animeId"></param>
        private SimpleAnimeScreenshotDTO(string url, long? id, long animeId)
            : base(url, id)
        {
            AnimeId = animeId;
        }

        /// <summary>
        /// Método fábrica para criar um objeto SimpleAnimeScreenshotDTO.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <param name="animeId"></param>
        /// <returns></returns>
        public static SimpleAnimeScreenshotDTO Create(string url, long? id, long animeId)
        {
            return new SimpleAnimeScreenshotDTO(url, id, animeId);
        }
    }
}
