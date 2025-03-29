using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                language.DeletionDate,
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
