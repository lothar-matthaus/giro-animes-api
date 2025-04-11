using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear a entidade AnimeSinopse para o DTO DetailedAnimeSinopseDTO.
    /// </summary>
    internal static class AnimeSinopseMapper
    {
        /// <summary>
        /// Método de extensão para mapear um anime sinopse para um DetailedAnimeSinopseDTO.
        /// </summary>
        /// <param name="sinopse"></param>
        /// <returns></returns>
        public static DetailedAnimeSinopseDTO Map(this AnimeSinopse sinopse)
        {
            DetailedAnimeSinopseDTO sinopseDTO = DetailedAnimeSinopseDTO.Create(sinopse.Id, sinopse.CreationDate, sinopse.UpdateDate, sinopse.AnimeId, sinopse.Text, sinopse.Language.Map());

            return sinopseDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de anime sinopses para uma coleção de DetailedAnimeSinopseDTOs.
        /// </summary>
        /// <param name="sinopses"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedAnimeSinopseDTO> Map(this IEnumerable<AnimeSinopse> sinopses)
        {
            IEnumerable<DetailedAnimeSinopseDTO> sinopseDTOs = sinopses.Select(Map);
            return sinopseDTOs;
        }

        /// <summary>
        /// Método de extensão para mapear um anime sinopse para um SimpleAnimeSinopseDTO.
        /// </summary>
        /// <param name="animeSinopse"></param>
        /// <returns></returns>
        public static SimpleAnimeSinopseDTO MapSimple(this AnimeSinopse animeSinopse)
        {
            SimpleAnimeSinopseDTO dTO = SimpleAnimeSinopseDTO.Create(
                animeSinopse.Text,
                animeSinopse.Language.MapSimple(),
                animeSinopse.AnimeId,
                animeSinopse.Id
            );
            return dTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de anime sinopses para uma coleção de SimpleAnimeSinopseDTOs.
        /// </summary>
        /// <param name="animeSinopses"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleAnimeSinopseDTO> MapSimple(this IEnumerable<AnimeSinopse> animeSinopses)
        {
            IEnumerable<SimpleAnimeSinopseDTO> simpleAnimeSinopseDTOs = animeSinopses?.Select(MapSimple);
            return simpleAnimeSinopseDTOs;
        }
    }
}
