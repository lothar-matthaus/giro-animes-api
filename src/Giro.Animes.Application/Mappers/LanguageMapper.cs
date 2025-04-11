using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear a entidade Language para o DTO LanguageDTO.
    /// </summary>
    public static class LanguageMapper
    {
        /// <summary>
        /// Mapeia a entidade Language para o DTO LanguageDTO.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static DetailedLanguageDTO Map(this Language language)
        {
            return DetailedLanguageDTO.Create(
                language.Id,
                language.CreationDate,
                language.UpdateDate,
                language.Name,
                language.Code,
                language.NativeName);
        }

        /// <summary>
        /// Mapeia uma coleção de entidades Language para uma coleção de DTOs LanguageDTO.
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedLanguageDTO> Map(this IEnumerable<Language> authors)
        {
            IEnumerable<DetailedLanguageDTO> result = authors?.Select(Map);
            return result;
        }

        /// <summary>
        /// Método de extensão para mapear um idioma para um DTO de idioma simples
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static SimpleLanguageDTO MapSimple(this Language language)
        {
            SimpleLanguageDTO simpleLanguageDTO = SimpleLanguageDTO.Create(
                language.Id.Value,
                language.Name
            );

            return simpleLanguageDTO;
        }

        /// <summary>
        /// Mapeia uma lista de idiomas para uma lista de DTOs de idiomas simples
        /// </summary>
        /// <param name="languages"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleLanguageDTO> MapSimple(this IEnumerable<Language> languages)
        {
            IEnumerable<SimpleLanguageDTO> simpleLanguageDTOs = languages?.Select(language => language.MapSimple());
            return simpleLanguageDTOs;
        }
    }
}
