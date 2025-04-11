using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe de mapeamento para títulos de anime detalhados.
    /// </summary>
    public static class AnimeTitleMapper
    {
        /// <summary>
        /// Método de extensão para mapear um título de anime para um DTO de título de anime detalhado
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static DetailedAnimeTitleDTO Map(this AnimeTitle title)
        {
            DetailedAnimeTitleDTO titleDTO = DetailedAnimeTitleDTO.Create(title.Name, title.AnimeId, title.Language.Map(), title.Id, title.CreationDate, title.UpdateDate);
            return titleDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma lista de títulos de anime para uma lista de DTOs de título de anime detalhados
        /// </summary>
        /// <param name="titles"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedAnimeTitleDTO> Map(this IEnumerable<AnimeTitle> titles)
        {
            IEnumerable<DetailedAnimeTitleDTO> titleDTOs = titles.Select(Map);
            return titleDTOs;
        }

        /// <summary>
        /// Método de extensão para mapear um título de anime para um DTO de título de anime simples
        /// </summary>
        /// <param name="animeTitle"></param>
        /// <returns></returns>
        public static SimpleAnimeTitleDTO MapSimple(this AnimeTitle animeTitle)
        {
            SimpleAnimeTitleDTO simpleAnimeTitleDTO = SimpleAnimeTitleDTO.Create(
                animeTitle.Id.Value,
                animeTitle.Name,
                animeTitle.Language.MapSimple(),
                animeTitle.AnimeId
            );

            return simpleAnimeTitleDTO;
        }

        /// <summary>
        /// /// Método de extensão para mapear uma lista de títulos de anime para uma lista de DTOs de título de anime simples
        /// </summary>
        /// <param name="animeTitles"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleAnimeTitleDTO> MapSimple(this IEnumerable<AnimeTitle> animeTitles)
        {
            IEnumerable<SimpleAnimeTitleDTO> simpleAnimeTitleDTOs = animeTitles?.Select(animeTitle => animeTitle.MapSimple());
            return simpleAnimeTitleDTOs;
        }
    }
}
