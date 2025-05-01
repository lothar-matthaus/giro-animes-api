using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe de mapeamento para a entidade Season.
    /// </summary>
    public static class SeasonMapper
    {
        /// <summary>
        /// Método de extensão para mapear uma coleção de temporadas para uma coleção de SimpleSeasonDTOs.
        /// </summary>
        /// <param name="seasons"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleSeasonDTO> MapSimple(this ICollection<Season> seasons)
        {
            IEnumerable<SimpleSeasonDTO> result = seasons.Select(MapSimple).ToList();
            return result;
        }

        /// <summary>
        /// Método de extensão para mapear uma temporada para um SimpleSeasonDTO.
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        public static SimpleSeasonDTO MapSimple(this Season season)
        {
            SimpleSeasonDTO simpleSeasonDTO = SimpleSeasonDTO.Create(season.Id, season.Number, season.Sinopses.MapSimple(), season.ReleaseDate, season.Status.Map(), season.Episodes.MapSimple(), season.AnimeId);
            return simpleSeasonDTO;
        }
    }
}
