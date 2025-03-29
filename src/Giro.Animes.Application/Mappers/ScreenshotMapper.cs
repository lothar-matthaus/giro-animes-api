using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers
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
        public static AnimeScreenshotDTO Map (this AnimeScreenshot screenshot)
        {
            AnimeScreenshotDTO animeScreenshot = AnimeScreenshotDTO.Create(screenshot.Id, screenshot.CreationDate, screenshot.UpdateDate, screenshot.DeletionDate, screenshot.AnimeId, screenshot.Url, screenshot.FileName, screenshot.Extension);
            return animeScreenshot;            
        }

        /// <summary>
        /// Mapeia uma coleção de objetos AnimeScreenshot para AnimeScreenshotDTO.
        /// </summary>
        /// <param name="screenshots"></param>
        /// <returns></returns>
        public static IEnumerable<AnimeScreenshotDTO> Map(this IEnumerable<AnimeScreenshot> screenshots)
        {
            IEnumerable<AnimeScreenshotDTO> result = screenshots.Select(Map);
            return result;
        }
    }
}
