using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
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
        public static BiographyDTO Map(this Biography biography)
        {
            BiographyDTO biographyDTO = BiographyDTO.Create(
                biography.Id,
                biography.CreationDate,
                biography.UpdateDate,
                biography.AuthorId,
                biography.Text,
                LanguageMapper.Map(biography.Language));

            return biographyDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de entidades Biography para uma coleção de DTOs BiographyDTO.
        /// </summary>
        /// <param name="biographies"></param>
        /// <returns></returns>
        public static IEnumerable<BiographyDTO> Map(this IEnumerable<Biography> biographies)
        {
            IEnumerable<BiographyDTO> result = biographies?.Select(Map);
            return result;
        }
    }
}
