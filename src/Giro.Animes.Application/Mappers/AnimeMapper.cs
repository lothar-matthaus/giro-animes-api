using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
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
                anime.Titles.MapSimple(),
                anime.Sinopses?.MapSimple(),
                anime.Cover.MapSimple(),
                anime.Screenshots?.MapSimple(),
                anime.Episodes?.MapSimple(),
                anime.Authors.MapSimple(),
                anime.Ratings?.MapSimple(),
                anime.Genres.MapSimple(),
                anime.Studio.MapSimple(),
                anime.Status.Map(),
                anime.Id,
                anime.CreationDate,
                anime.UpdateDate);

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

        /// <summary>
        /// Método de extensão para mapear um anime para um SimpleAnimeDTO.
        /// </summary>
        /// <param name="anime"></param>
        /// <returns></returns>
        public static SimpleAnimeDTO MapSimple(this Anime anime)
        {
            SimpleAnimeDTO simpleAnimeDTO = SimpleAnimeDTO.Create(
                anime.Titles.MapSimple(),
                anime.Sinopses?.MapSimple(),
                anime.Cover?.MapSimple(),
                anime.Screenshots?.MapSimple(),
                anime.Genres.MapSimple(),
                anime.Authors.MapSimple(),
                anime.Studio.MapSimple(),
                anime.Status.Map(),
                anime.Id
            );

            return simpleAnimeDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de animes para uma coleção de SimpleAnimeDTOs.
        /// </summary>
        /// <param name="animes"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleAnimeDTO> MapSimple(this IEnumerable<Anime> animes)
        {
            // Verifica se a coleção de animes é nula ou vazia
            IEnumerable<SimpleAnimeDTO> simpleAnimeDTOs = animes?.Select(anime => anime.MapSimple());

            return simpleAnimeDTOs;
        }
    }
}
