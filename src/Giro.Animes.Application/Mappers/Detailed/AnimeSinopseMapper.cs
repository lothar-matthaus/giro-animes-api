using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    internal static class AnimeSinopseMapper
    {
        public static DetailedAnimeSinopseDTO Map(this AnimeSinopse sinopse)
        {
            DetailedAnimeSinopseDTO sinopseDTO = DetailedAnimeSinopseDTO.Create(sinopse.Id, sinopse.CreationDate, sinopse.UpdateDate, sinopse.AnimeId, sinopse.Text, sinopse.Language.Map());

            return sinopseDTO;
        }

        public static IEnumerable<DetailedAnimeSinopseDTO> Map(this IEnumerable<AnimeSinopse> sinopses)
        {
            IEnumerable<DetailedAnimeSinopseDTO> sinopseDTOs = sinopses.Select(Map);
            return sinopseDTOs;
        }
    }
}
