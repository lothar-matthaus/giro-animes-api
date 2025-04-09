using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers.Simple
{
    /// <summary>
    /// Classe de mapeamento para o DTO simples de estúdio.
    /// </summary>
    internal static class SimpleStudioMapper
    {
        /// <summary>
        /// Método de extensão para mapear um estúdio para um SimpleStudioDTO.
        /// </summary>
        /// <param name="studio"></param>
        /// <returns></returns>
        public static SimpleStudioDTO MapSimple(this Studio studio)
        {
            SimpleStudioDTO simpleStudioDTO = SimpleStudioDTO.Create(
                studio.Id,
                studio.Name
            );

            return simpleStudioDTO;
        }   

        /// <summary>
        /// Método de extensão para mapear uma coleção de estúdios para uma coleção de SimpleStudioDTOs.
        /// </summary>
        /// <param name="studios"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleStudioDTO> MapSimple(this IEnumerable<Studio> studios)
        {
            IEnumerable<SimpleStudioDTO> simpleStudioDTOs = studios?.Select(studio => studio.MapSimple());
            return simpleStudioDTOs;
        }
    }
}
