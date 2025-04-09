using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers.Simple
{
    internal static class SimpleGenreTitleMapper
    {
        /// <summary>
        /// Método de extensão para mapear um título de gênero para um SimpleGenreTitleDTO.
        /// </summary>
        /// <param name="genreTitle"></param>
        /// <returns></returns>
        public static SimpleGenreTitleDTO MapSimple(this GenreTitle genreTitle)
        {
            SimpleGenreTitleDTO simpleGenreTitleDTO = SimpleGenreTitleDTO.Create(
                genreTitle.Id.Value,
                genreTitle.Name,
                genreTitle.Language.MapSimple(),
                genreTitle.GenreId
            );

            return simpleGenreTitleDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de títulos de gênero para uma coleção de SimpleGenreTitleDTOs.
        /// </summary>
        /// <param name="genreTitles"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleGenreTitleDTO> MapSimple(this IEnumerable<GenreTitle> genreTitles)
        {
            IEnumerable<SimpleGenreTitleDTO> simpleGenreTitleDTOs = genreTitles?.Select(genreTitle => genreTitle.MapSimple());
            return simpleGenreTitleDTOs;
        }
    }
}
