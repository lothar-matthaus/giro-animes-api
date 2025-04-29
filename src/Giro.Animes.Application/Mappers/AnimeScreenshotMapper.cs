using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear objetos do tipo AnimeScreenshot para AnimeScreenshotDTO.
    /// </summary>
    internal static class AnimeScreenshotMapper
    {
        /// <summary>
        /// Mapeia um objeto AnimeScreenshot para AnimeScreenshotDTO. 
        /// </summary>
        /// <param name="screenshot"></param>
        /// <returns></returns>
        public static DetailedAnimeScreenshotDTO Map(this Screenshot screenshot)
        {
            DetailedAnimeScreenshotDTO animeScreenshot = DetailedAnimeScreenshotDTO.Create(screenshot.Id, screenshot.Url, screenshot.AnimeId, screenshot.CreationDate, screenshot.UpdateDate);
            return animeScreenshot;
        }

        /// <summary>
        /// Mapeia uma coleção de objetos AnimeScreenshot para AnimeScreenshotDTO.
        /// </summary>
        /// <param name="screenshots"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedAnimeScreenshotDTO> Map(this IEnumerable<Screenshot> screenshots)
        {
            IEnumerable<DetailedAnimeScreenshotDTO> result = screenshots.Select(Map);
            return result;
        }

        /// <summary>
        /// Método para mapear um objeto AnimeScreenshot para SimpleAnimeScreenshotDTO.
        /// </summary>
        /// <param name="screenshot"></param>
        /// <returns></returns>
        public static SimpleAnimeScreenshotDTO MapSimple(this Screenshot screenshot)
        {
            SimpleAnimeScreenshotDTO animeScreenshot = SimpleAnimeScreenshotDTO.Create(screenshot.Id, screenshot.Url, screenshot.AnimeId);
            return animeScreenshot;
        }

        /// <summary>
        /// Método para mapear uma coleção de objetos AnimeScreenshot para SimpleAnimeScreenshotDTO.
        /// </summary>
        /// <param name="screenshots"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleAnimeScreenshotDTO> MapSimple(this IEnumerable<Screenshot> screenshots)
        {
            IEnumerable<SimpleAnimeScreenshotDTO> result = screenshots.Select(MapSimple);
            return result;
        }
    }
}
