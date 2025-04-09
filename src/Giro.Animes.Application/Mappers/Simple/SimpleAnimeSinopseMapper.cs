using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers.Simple
{
    public static class SimpleAnimeSinopseMapper
    {
        /// <summary>
        /// Método de extensão para mapear um anime sinopse para um SimpleAnimeSinopseDTO.
        /// </summary>
        /// <param name="animeSinopse"></param>
        /// <returns></returns>
        public static SimpleAnimeSinopseDTO MapSimple(this AnimeSinopse animeSinopse)
        {
            SimpleAnimeSinopseDTO dTO = SimpleAnimeSinopseDTO.Create(
                animeSinopse.Text,
                animeSinopse.Language.MapSimple(),
                animeSinopse.AnimeId,
                animeSinopse.Id
            );
            return dTO;
        }

        public static IEnumerable<SimpleAnimeSinopseDTO> MapSimple(this IEnumerable<AnimeSinopse> animeSinopses)
        {
            IEnumerable<SimpleAnimeSinopseDTO> simpleAnimeSinopseDTOs = animeSinopses?.Select(animeSinopse => animeSinopse.MapSimple());
            return simpleAnimeSinopseDTOs;
        }
    }
}
