using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers.Simple
{
    internal static class SimpleCoverMapper
    {
        /// <summary>
        /// Método de extensão para mapear uma capa para um SimpleCoverDTO.
        /// </summary>
        /// <param name="cover"></param>
        /// <returns></returns>
        public static SimpleCoverDTO MapSimple(this Cover cover)
        {
            SimpleCoverDTO simpleCoverDTO = SimpleCoverDTO.Create(
                cover.Url,
                cover.AnimeId,
                cover.Language.MapSimple(),
                cover.Id
            );
            
            return simpleCoverDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de capas para uma coleção de SimpleCoverDTOs.
        /// </summary>
        /// <param name="covers"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleCoverDTO> MapSimple(this IEnumerable<Cover> covers)
        {
            // Verifica se a coleção de capas é nula ou vazia
            IEnumerable<SimpleCoverDTO> simpleCoverDTOs = covers?.Select(cover => cover.MapSimple());
            return simpleCoverDTOs;
        }
    }
}
