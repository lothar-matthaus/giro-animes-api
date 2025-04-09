using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
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
        public static DetailedEpisodeDTO Map(this Episode episode)
        {
            DetailedEpisodeDTO episodeDTO = DetailedEpisodeDTO.Create(
                episode.Titles.Map(),
                episode.Sinopses.Map(),
                episode.Number,
                episode.Duration,
                episode.AirDate,
                episode.Files.Map(),
                episode.AnimeId,
                episode.Id,
                episode.CreationDate,
                episode.UpdateDate
            );

            return episodeDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de objetos Episode para uma coleção de EpisodeDTO.
        /// </summary>
        /// <param name="episodes"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedEpisodeDTO> Map(this IEnumerable<Episode> episodes)
        {
            IEnumerable<DetailedEpisodeDTO> result = episodes.Select(e => e.Map());
            return result;
        }
    }
}
