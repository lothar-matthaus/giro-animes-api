using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear um GenreTitle para um GenreTitleDTO
    /// </summary>
    internal static class GenreTitleMapper
    {
        /// <summary>
        /// Mapeia um GenreTitle para um GenreTitleDTO
        /// </summary>
        /// <param name="genreTitle"></param>
        /// <returns></returns>
        public static DetailedGenreTitleDTO Map(this GenreTitle genreTitle)
        {
            DetailedGenreTitleDTO genreTitleDTO = DetailedGenreTitleDTO.Create(
                genreTitle.Id,
                genreTitle.CreationDate,
                genreTitle.UpdateDate,
                genreTitle.GenreId,
                genreTitle.Name,
                genreTitle?.Language.Map());

            return genreTitleDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de GenreTitle para uma coleção de GenreTitleDTO
        /// </summary>
        /// <param name="genreTitles"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedGenreTitleDTO> Map(this IEnumerable<GenreTitle> genreTitles)
        {
            IEnumerable<DetailedGenreTitleDTO> genreTitleDTOs = genreTitles.Select(g => g.Map());
            return genreTitleDTOs;
        }

        /// <summary>
        /// Método de extensão para mapear um título de gênero para um SimpleGenreTitleDTO.
        /// </summary>
        /// <param name="genreTitle"></param>
        /// <returns></returns>
        public static SimpleGenreTitleDTO MapSimple(this GenreTitle genreTitle)
        {
            SimpleGenreTitleDTO simpleGenreTitleDTO = SimpleGenreTitleDTO.Create(
                genreTitle.Id.Value,
                genreTitle.Name,
                genreTitle.Language.MapSimple(),
                genreTitle.GenreId
            );

            return simpleGenreTitleDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de títulos de gênero para uma coleção de SimpleGenreTitleDTOs.
        /// </summary>
        /// <param name="genreTitles"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleGenreTitleDTO> MapSimple(this IEnumerable<GenreTitle> genreTitles)
        {
            IEnumerable<SimpleGenreTitleDTO> simpleGenreTitleDTOs = genreTitles?.Select(genreTitle => genreTitle.MapSimple());
            return simpleGenreTitleDTOs;
        }
    }
}
