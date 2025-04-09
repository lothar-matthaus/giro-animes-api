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
    /// Classe de mapeamento para converter entidades de gênero em DTOs simples.
    /// </summary>
    internal static class SimpleGenreMapper
    {
        /// <summary>
        /// Método de extensão para mapear um gênero para um SimpleGenreDTO.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public static SimpleGenreDTO MapSimple(this Genre genre)
        {
            SimpleGenreDTO simpleGenreDTO = SimpleGenreDTO.Create(
                genre.Titles.MapSimple(),
                genre.Descriptions.MapSimple(),
                genre.Id
            );

            return simpleGenreDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de gêneros para uma coleção de SimpleGenreDTOs.
        /// </summary>
        /// <param name="genres"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleGenreDTO> MapSimple(this IEnumerable<Genre> genres)
        {
            IEnumerable<SimpleGenreDTO> simpleGenreDTOs = genres?.Select(genre => genre.MapSimple());
            return simpleGenreDTOs;
        }
    }
}
