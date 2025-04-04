﻿using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    public static class AnimeTitleMapper
    {
        public static AnimeTitleDTO Map(this AnimeTitle title)
        {
            AnimeTitleDTO titleDTO = AnimeTitleDTO.Create(title.Name, title.AnimeId, LanguageMapper.Map(title.Language), title.Id, title.CreationDate, title.UpdateDate);
            return titleDTO;
        }

        public static IEnumerable<AnimeTitleDTO> Map(this IEnumerable<AnimeTitle> titles)
        {
            IEnumerable<AnimeTitleDTO> titleDTOs = titles.Select(Map);
            return titleDTOs;
        }
    }
}
