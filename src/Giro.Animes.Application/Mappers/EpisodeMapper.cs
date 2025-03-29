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
    /// Mapeador de episódios.
    /// </summary>
    internal static class EpisodeMapper
    {
        /// <summary>
        /// Mapeia um objeto Episode para EpisodeDTO.
        /// </summary>
        /// <param name="episode"></param>
        /// <returns></returns>
        public static EpisodeDTO Map(this Episode episode)
        {
            EpisodeDTO episodeDTO = EpisodeDTO.Create(
                episode.Titles.Map(),
                episode.Sinopses.Map(),
                episode.Number,
                episode.Duration,
                episode.AirDate,
                episode.Files.Map(),
                episode.AnimeId,
                episode.Id,
                episode.CreationDate,
                episode.UpdateDate,
                episode.DeletionDate
            );

            return episodeDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de objetos Episode para uma coleção de EpisodeDTO.
        /// </summary>
        /// <param name="episodes"></param>
        /// <returns></returns>
        public static IEnumerable<EpisodeDTO> Map(this IEnumerable<Episode> episodes)
        {
            IEnumerable<EpisodeDTO> result = episodes.Select(e => e.Map());
            return result;
        }
    }
}
