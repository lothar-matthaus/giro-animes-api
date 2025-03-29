using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers
{
    internal static class AnimeSinopseMapper
    {
        public static AnimeSinopseDTO Map(this AnimeSinopse sinopse)
        {
            AnimeSinopseDTO sinopseDTO = AnimeSinopseDTO.Create(sinopse.Id, sinopse.CreationDate, sinopse.UpdateDate, sinopse.DeletionDate, sinopse.AnimeId, sinopse.Text, LanguageMapper.Map(sinopse.Language));

            return sinopseDTO;
        }

        public static IEnumerable<AnimeSinopseDTO> Map(this IEnumerable<AnimeSinopse> sinopses)
        {
            IEnumerable<AnimeSinopseDTO> sinopseDTOs = sinopses.Select(Map);
            return sinopseDTOs;
        }
    }
}
