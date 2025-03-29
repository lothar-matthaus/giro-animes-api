using Giro.Animes.Application.DTOs;
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
        public static GenreTitleDTO Map(this GenreTitle genreTitle)
        {
            GenreTitleDTO genreTitleDTO = GenreTitleDTO.Create(
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
        public static IEnumerable<GenreTitleDTO> Map(this IEnumerable<GenreTitle> genreTitles)
        {
            IEnumerable<GenreTitleDTO> genreTitleDTOs = genreTitles.Select(g => g.Map());
            return genreTitleDTOs;
        }
    }
}
