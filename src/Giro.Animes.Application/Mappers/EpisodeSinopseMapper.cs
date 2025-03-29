using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Mapeador de sinopses de episódios.
    /// </summary>
    internal static class EpisodeSinopseMapper
    {
        /// <summary>
        /// Mapeia uma sinopse de episódio para DTO.
        /// </summary>
        /// <param name="sinopse"></param>
        /// <returns></returns>
        public static EpisodeSinopseDTO Map(this EpisodeSinopse sinopse)
        {
            EpisodeSinopseDTO episodeSinopseDTO = EpisodeSinopseDTO.Create(
                sinopse.Id,
                sinopse.CreationDate,
                sinopse.UpdateDate,
                sinopse.Text,
                sinopse.EpisodeId,
                sinopse.Language?.Map()
            );

            return episodeSinopseDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de sinopses de episódios para DTO.
        /// </summary>
        /// <param name="sinopses"></param>
        /// <returns></returns>
        public static IEnumerable<EpisodeSinopseDTO> Map(this IEnumerable<EpisodeSinopse> sinopses)
        {
            IEnumerable<EpisodeSinopseDTO> result = sinopses.Select(Map);
            return result;
        }
    }
}
