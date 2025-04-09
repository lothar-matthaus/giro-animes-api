using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers.Simple
{
    public static class SimpleAnimeTitleMapper
    {
        /// <summary>
        /// Método de extensão para mapear um título de anime para um DTO de título de anime simples
        /// </summary>
        /// <param name="animeTitle"></param>
        /// <returns></returns>
        public static SimpleAnimeTitleDTO MapSimple(this AnimeTitle animeTitle)
        {
            SimpleAnimeTitleDTO simpleAnimeTitleDTO = SimpleAnimeTitleDTO.Create(
                animeTitle.Id.Value,
                animeTitle.Name,
                animeTitle.Language.MapSimple(),
                animeTitle.AnimeId
            );

            return simpleAnimeTitleDTO;
        }

        /// <summary>
        /// /// Método de extensão para mapear uma lista de títulos de anime para uma lista de DTOs de título de anime simples
        /// </summary>
        /// <param name="animeTitles"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleAnimeTitleDTO> MapSimple(this IEnumerable<AnimeTitle> animeTitles)
        {
            IEnumerable<SimpleAnimeTitleDTO> simpleAnimeTitleDTOs = animeTitles?.Select(animeTitle => animeTitle.MapSimple());
            return simpleAnimeTitleDTOs;
        }
    }
}
