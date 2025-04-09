using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers.Simple
{
    /// <summary>
    /// Classe de mapeamento para o objeto GenreDescription.
    /// </summary>
    internal static class SimpleGenreDescriptionMapper
    {
        /// <summary>
        /// Método de extensão para mapear um objeto GenreDescription para um objeto SimpleGenreDescriptionDTO.
        /// </summary>
        /// <param name="genreDescription"></param>
        /// <returns></returns>
        public static SimpleGenreDescriptionDTO MapSimple(this GenreDescription genreDescription)
        {
            SimpleGenreDescriptionDTO simpleGenreDescriptionDTO = SimpleGenreDescriptionDTO.Create(
                genreDescription.Id,
                genreDescription.Text,
                genreDescription.Language.MapSimple(),
                genreDescription.GenreId
            );

            return simpleGenreDescriptionDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de GenreDescription para uma coleção de SimpleGenreDescriptionDTO.
        /// </summary>
        /// <param name="genreDescriptions"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleGenreDescriptionDTO> MapSimple(this IEnumerable<GenreDescription> genreDescriptions)
        {
            IEnumerable<SimpleGenreDescriptionDTO> simpleGenreDescriptionDTOs = genreDescriptions?.Select(genreDescription => genreDescription.MapSimple());
            return simpleGenreDescriptionDTOs;
        }
    }
}
