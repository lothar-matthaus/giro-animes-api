using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
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

        /// <summary>
        /// Método de extensão para mapear uma coleção de sinopses de episódios para DTOs simples.
        /// </summary>
        /// <param name="sinopses"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleEpisodeSinopseDTO> MapSimple(this ICollection<EpisodeSinopse> sinopses)
        {
            IEnumerable<SimpleEpisodeSinopseDTO> result = sinopses.Select(MapSimple);
            return result;
        }

        /// <summary>
        /// Método de extensão para mapear uma sinopse de episódio para um DTO simples.
        /// </summary>
        /// <param name="sinopse"></param>
        /// <returns></returns>
        public static SimpleEpisodeSinopseDTO MapSimple(this EpisodeSinopse sinopse)
        {
            SimpleEpisodeSinopseDTO simpleEpisodeSinopseDTO = SimpleEpisodeSinopseDTO.Create(
                sinopse.Text,
                sinopse.Language?.MapSimple(),
                sinopse.Id,
                sinopse.EpisodeId
            );
            return simpleEpisodeSinopseDTO;
        }
    }
}
