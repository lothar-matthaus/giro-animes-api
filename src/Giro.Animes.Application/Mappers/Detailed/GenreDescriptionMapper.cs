using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    /// <summary>
    /// Classe responsável por mapear um GenreDescription para um GenreDescriptionDTO
    /// </summary>
    internal static class GenreDescriptionMapper
    {
        /// <summary>
        /// Mapeia um GenreDescription para um GenreDescriptionDTO
        /// </summary>
        /// <param name="genreDescription"></param>
        /// <returns></returns>
        public static DetailedGenreDescriptionDTO Map(this GenreDescription genreDescription)
        {
            DetailedGenreDescriptionDTO genreDescriptionDTO = DetailedGenreDescriptionDTO.Create(
                genreDescription.Id,
                genreDescription.CreationDate,
                genreDescription.UpdateDate,
                genreDescription.GenreId,
                genreDescription.Text,
                genreDescription?.Language.Map());

            return genreDescriptionDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de GenreDescription para uma coleção de GenreDescriptionDTO
        /// </summary>
        /// <param name="genreDescriptions"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedGenreDescriptionDTO> Map(this IEnumerable<GenreDescription> genreDescriptions)
        {
            IEnumerable<DetailedGenreDescriptionDTO> result = genreDescriptions.Select(gd => gd.Map());
            return result;
        }
    }
}
