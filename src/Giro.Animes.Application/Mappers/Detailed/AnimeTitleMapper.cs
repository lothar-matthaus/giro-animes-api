using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    public static class AnimeTitleMapper
    {
        public static DetailedAnimeTitleDTO Map(this AnimeTitle title)
        {
            DetailedAnimeTitleDTO titleDTO = DetailedAnimeTitleDTO.Create(title.Name, title.AnimeId, title.Language.Map(), title.Id, title.CreationDate, title.UpdateDate);
            return titleDTO;
        }

        public static IEnumerable<DetailedAnimeTitleDTO> Map(this IEnumerable<AnimeTitle> titles)
        {
            IEnumerable<DetailedAnimeTitleDTO> titleDTOs = titles.Select(Map);
            return titleDTOs;
        }
    }
}
