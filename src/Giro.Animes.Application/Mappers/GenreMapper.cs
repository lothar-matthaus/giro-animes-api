using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class GenreMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public static DetailedGenreDTO Map(this Genre genre)
        {
            DetailedGenreDTO genreDTO = DetailedGenreDTO.Create(
                genre.Id,
                genre.CreationDate,
                genre.UpdateDate,
                genre.Titles.Map(),
                genre.Descriptions?.Map());
            return genreDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de gêneros para uma coleção de DTOs
        /// </summary>
        /// <param name="genres"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedGenreDTO> Map(this IEnumerable<Genre> genres)
        {
            IEnumerable<DetailedGenreDTO> result = genres.Select(g => g.Map());
            return result;
        }

        /// <summary>
        /// Método de extensão para mapear um gênero para um SimpleGenreDTO.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public static SimpleGenreDTO MapSimple(this Genre genre)
        {
            SimpleGenreDTO simpleGenreDTO = SimpleGenreDTO.Create(
                genre.Titles.MapSimple(),
                genre.Id
            );

            return simpleGenreDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de gêneros para uma coleção de SimpleGenreDTOs.
        /// </summary>
        /// <param name="genres"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleGenreDTO> MapSimple(this IEnumerable<Genre> genres)
        {
            IEnumerable<SimpleGenreDTO> simpleGenreDTOs = genres?.Select(genre => genre.MapSimple());
            return simpleGenreDTOs;
        }
    }
}
