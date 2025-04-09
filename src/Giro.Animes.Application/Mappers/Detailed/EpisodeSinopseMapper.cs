using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
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
        public static DetailedEpisodeSinopseDTO Map(this EpisodeSinopse sinopse)
        {
            DetailedEpisodeSinopseDTO episodeSinopseDTO = DetailedEpisodeSinopseDTO.Create(
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
        public static IEnumerable<DetailedEpisodeSinopseDTO> Map(this IEnumerable<EpisodeSinopse> sinopses)
        {
            IEnumerable<DetailedEpisodeSinopseDTO> result = sinopses.Select(Map);
            return result;
        }
    }
}
