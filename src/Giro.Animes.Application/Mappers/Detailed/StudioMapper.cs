using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    internal static class StudioMapper
    {
        public static DetailedStudioDTO Map(this Studio studio)
        {
            DetailedStudioDTO studioDTO = DetailedStudioDTO.Create(
                studio.Id,
                studio.CreationDate,
                studio.UpdateDate,
                studio.Name,
                studio.EstablishedDate,
                studio.Country,
                studio.City,
                studio.Website,
                studio.Twitter,
                studio.Instagram,
                studio.Logo?.Map()
                );

            return studioDTO;
        }

        public static IEnumerable<DetailedStudioDTO> Map(this IEnumerable<Studio> studios)
        {
            IEnumerable<DetailedStudioDTO> result = studios?.Select(Map);
            return result;
        }
    }
}
