using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class StudioMapper
    {
        public static StudioDTO Map(this Studio studio)
        {
            StudioDTO studioDTO = StudioDTO.Create(
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
                studio.Logo.Map()
                );

            return studioDTO;
        }

        public static IEnumerable<StudioDTO> Map(this IEnumerable<Studio> studios)
        {
            IEnumerable<StudioDTO> result = studios?.Select(Map);
            return result;
        }
    }
}
