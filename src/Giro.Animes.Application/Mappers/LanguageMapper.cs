using Giro.Animes.Application.DTOs;
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
        public static LanguageDTO Map(this Language language)
        {
            return LanguageDTO.Create(
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
        public static IEnumerable<LanguageDTO> Map(this IEnumerable<Language> authors)
        {
            IEnumerable<LanguageDTO> result = authors?.Select(Map);
            return result;
        }
    }
}
