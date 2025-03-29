using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                studio.DeletionDate,
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
