using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers
{
    public static class SeasonSinopseMapper
    {
        /// <summary>
        /// Método de extensão para mapear uma coleção de Sinopses em um DTO simples de Sinopse.
        /// </summary>
        /// <param name="sinopses"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleSeasonSinopseDTO> MapSimple(this IEnumerable<SeasonSinopse> sinopses)
        {
            IEnumerable<SimpleSeasonSinopseDTO> simpleSeasonSinopsesDTO = sinopses.Select(sinopse => sinopse.MapSimple());
            return simpleSeasonSinopsesDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma Sinopse em um DTO simples de Sinopse.
        /// </summary>
        /// <param name="sinopse"></param>
        /// <returns></returns>
        public static SimpleSeasonSinopseDTO MapSimple(this SeasonSinopse sinopse)
        {
            SimpleSeasonSinopseDTO simpleSeasonSinopseDTO = SimpleSeasonSinopseDTO.Create(
                sinopse.Text,
                sinopse.Language?.MapSimple(),
                sinopse.Id);
            return simpleSeasonSinopseDTO;
        }
    }
}
