using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

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
        public static DetailedEpisodeDTO Map(this Episode episode)
        {
            DetailedEpisodeDTO episodeDTO = DetailedEpisodeDTO.Create(
                episode.Titles.MapSimple(),
                episode.Sinopses.MapSimple(),
                episode.Number,
                episode.Duration,
                episode.AirDate,
                episode.Files.MapSimple(),
                episode.SeasonId,
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

        /// <summary>
        /// Método de extensão para mapear um episódio para um DTO simples.
        /// </summary>
        /// <param name="episode"></param>
        /// <returns></returns>
        public static SimpleEpisodeDTO MapSimple(this Episode episode)
        {
            SimpleEpisodeDTO simpleEpisodeDTO = SimpleEpisodeDTO.Create(episode.Titles.MapSimple(), episode.SeasonId, episode.Id);
            return simpleEpisodeDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de episódios para uma coleção de DTOs simples.
        /// </summary>
        /// <param name="episodes"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleEpisodeDTO> MapSimple(this IEnumerable<Episode> episodes)
        {
            IEnumerable<SimpleEpisodeDTO> result = episodes.Select(e => e.MapSimple());
            return result;
        }
    }
}
