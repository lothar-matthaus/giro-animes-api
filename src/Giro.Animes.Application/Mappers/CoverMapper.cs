using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

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
        public static DetailedCoverDTO Map(this Cover cover)
        {
            DetailedCoverDTO coverDTO = DetailedCoverDTO.Create(cover.Id, cover.Url, cover.AnimeId, cover.CreationDate, cover.UpdateDate);
            return coverDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de capas para uma coleção de CoverDTO.
        /// </summary>
        /// <param name="covers"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedCoverDTO> Map(this IEnumerable<Cover> covers)
        {
            IEnumerable<DetailedCoverDTO> result = covers.Select(c => c.Map());
            return result;
        }

        /// <summary>
        /// Método de extensão para mapear uma capa para um SimpleCoverDTO.
        /// </summary>
        /// <param name="cover"></param>
        /// <returns></returns>
        public static SimpleCoverDTO MapSimple(this Cover cover)
        {
            SimpleCoverDTO simpleCoverDTO = SimpleCoverDTO.Create(
                cover.Id.Value,
                cover.Url,
                cover.AnimeId
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
