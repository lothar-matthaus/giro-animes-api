using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe de mapeamento para o DTO detalhado de estúdio.
    /// </summary>
    internal static class StudioMapper
    {
        /// <summary>
        /// Método de extensão para mapear um estúdio para um DetailedStudioDTO.
        /// </summary>
        /// <param name="studio"></param>
        /// <returns></returns>
        public static DetailedStudioDTO Map(this Studio studio)
        {
            DetailedStudioDTO studioDTO = DetailedStudioDTO.Create(
                studio.Id,
                studio.CreationDate,
                studio.UpdateDate,
                studio.Name,
                studio.EstablishedDate,
                studio.Country,
                studio.City,
                studio.Website,
                studio.Twitter,
                studio.Instagram,
                studio.Logo?.Map()
                );

            return studioDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de estúdios para uma coleção de DetailedStudioDTOs.
        /// </summary>
        /// <param name="studios"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedStudioDTO> Map(this IEnumerable<Studio> studios)
        {
            IEnumerable<DetailedStudioDTO> result = studios?.Select(Map);
            return result;
        }

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
