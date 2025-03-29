using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Mapeador de Cover para CoverDTO.
    /// </summary>
    public static class CoverMapper
    {
        /// <summary>
        /// Mapeia uma capa para um CoverDTO.
        /// </summary>
        /// <param name="cover"></param>
        /// <returns></returns>
        public static CoverDTO Map(this Cover cover)
        {
            CoverDTO coverDTO = CoverDTO.Create(cover.Id, cover.CreationDate, cover.UpdateDate, cover.DeletionDate, cover.AnimeId, cover.Language.Map(), cover.Url, cover.FileName, cover.Extension);
            return coverDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de capas para uma coleção de CoverDTO.
        /// </summary>
        /// <param name="covers"></param>
        /// <returns></returns>
        public static IEnumerable<CoverDTO> Map(this IEnumerable<Cover> covers)
        {
            IEnumerable<CoverDTO> result = covers.Select(c => c.Map());
            return result;
        }
    }
}
