using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class BiographyMapper
    {
        public static BiographyDTO Map(this Biography biography)
        {
            BiographyDTO biographyDTO = BiographyDTO.Create(
                biography.Id,
                biography.CreationDate,
                biography.UpdateDate,
                biography.DeletionDate,
                biography.AuthorId,
                biography.Text,
                LanguageMapper.Map(biography.Language));

            return biographyDTO;
        }

        public static IEnumerable<BiographyDTO> Map(this IEnumerable<Biography> biographies)
        {
            IEnumerable<BiographyDTO> result = biographies?.Select(Map);
            return result;
        }
    }
}
