using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
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
    }
}
