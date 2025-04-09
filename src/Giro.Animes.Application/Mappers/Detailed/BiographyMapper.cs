using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    /// <summary>
    /// Classe responsável por mapear a entidade Biography para o DTO BiographyDTO.
    /// </summary>
    internal static class BiographyMapper
    {
        /// <summary>
        /// Mapeia a entidade Biography para o DTO BiographyDTO.
        /// </summary>
        /// <param name="biography"></param>
        /// <returns></returns>
        public static DetaledBiographyDTO Map(this Biography biography)
        {
            DetaledBiographyDTO biographyDTO = DetaledBiographyDTO.Create(
                biography.Id,
                biography.CreationDate,
                biography.UpdateDate,
                biography.AuthorId,
                biography.Text,
                biography.Language.Map());

            return biographyDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de entidades Biography para uma coleção de DTOs BiographyDTO.
        /// </summary>
        /// <param name="biographies"></param>
        /// <returns></returns>
        public static IEnumerable<DetaledBiographyDTO> Map(this IEnumerable<Biography> biographies)
        {
            IEnumerable<DetaledBiographyDTO> result = biographies?.Select(Map);
            return result;
        }
    }
}
