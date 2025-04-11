using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
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

        /// <summary>
        /// Método de extensão para mapear um objeto GenreDescription para um objeto SimpleGenreDescriptionDTO.
        /// </summary>
        /// <param name="genreDescription"></param>
        /// <returns></returns>
        public static SimpleGenreDescriptionDTO MapSimple(this GenreDescription genreDescription)
        {
            SimpleGenreDescriptionDTO simpleGenreDescriptionDTO = SimpleGenreDescriptionDTO.Create(
                genreDescription.Id,
                genreDescription.Text,
                genreDescription.Language.MapSimple(),
                genreDescription.GenreId
            );

            return simpleGenreDescriptionDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de GenreDescription para uma coleção de SimpleGenreDescriptionDTO.
        /// </summary>
        /// <param name="genreDescriptions"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleGenreDescriptionDTO> MapSimple(this IEnumerable<GenreDescription> genreDescriptions)
        {
            IEnumerable<SimpleGenreDescriptionDTO> simpleGenreDescriptionDTOs = genreDescriptions?.Select(genreDescription => genreDescription.MapSimple());
            return simpleGenreDescriptionDTOs;
        }
    }
}
