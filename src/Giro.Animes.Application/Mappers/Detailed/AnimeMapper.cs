using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    internal static class AnimeMapper
    {
        /// <summary>
        /// Método para mapear um anime para um AnimeDTO.
        /// </summary>
        /// <param name="anime"></param>
        /// <returns></returns>
        public static DetailedAnimeDTO Map(this Anime anime)
        {
            DetailedAnimeDTO animeDTO = DetailedAnimeDTO.Create(
                anime.Id,
                anime.CreationDate,
                anime.UpdateDate,
                anime.Titles.Map(),
                anime.Sinopses?.Map(),
                anime.Covers.Map(),
                anime.Screenshots?.Map(),
                anime.Episodes?.Map(),
                anime.Authors.Map(),
                anime.Ratings?.Map(),
                anime.Genres.Map(),
                anime.Studio.Map(),
                anime.Status.Map());

            return animeDTO;
        }

        /// <summary>
        /// Método para mapear uma coleção de animes para uma coleção de AnimeDTOs.
        /// </summary>
        /// <param name="animes"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<DetailedAnimeDTO> Map(this IEnumerable<Anime> animes)
        {
            IReadOnlyCollection<DetailedAnimeDTO> result = animes.Select(Map).ToList();
            return result;
        }
    }
}
