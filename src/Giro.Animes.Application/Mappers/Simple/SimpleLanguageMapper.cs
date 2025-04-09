using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers.Simple
{
    public static class SimpleLanguageMapper
    {
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
