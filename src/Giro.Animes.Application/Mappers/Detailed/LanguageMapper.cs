using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
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
    }
}
