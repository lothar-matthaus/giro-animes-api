using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    /// <summary>
    /// Classe responsável por mapear objetos do tipo AnimeScreenshot para AnimeScreenshotDTO.
    /// </summary>
    internal static class ScreenshotMapper
    {
        /// <summary>
        /// Mapeia um objeto AnimeScreenshot para AnimeScreenshotDTO. 
        /// </summary>
        /// <param name="screenshot"></param>
        /// <returns></returns>
        public static DetailedAnimeScreenshotDTO Map(this AnimeScreenshot screenshot)
        {
            DetailedAnimeScreenshotDTO animeScreenshot = DetailedAnimeScreenshotDTO.Create(screenshot.Id, screenshot.CreationDate, screenshot.UpdateDate, screenshot.AnimeId, screenshot.Url, screenshot.FileName, screenshot.Extension);
            return animeScreenshot;
        }

        /// <summary>
        /// Mapeia uma coleção de objetos AnimeScreenshot para AnimeScreenshotDTO.
        /// </summary>
        /// <param name="screenshots"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedAnimeScreenshotDTO> Map(this IEnumerable<AnimeScreenshot> screenshots)
        {
            IEnumerable<DetailedAnimeScreenshotDTO> result = screenshots.Select(Map);
            return result;
        }
    }
}
