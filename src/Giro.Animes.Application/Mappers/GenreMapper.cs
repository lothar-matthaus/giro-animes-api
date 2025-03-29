using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Mappers
{
    internal static class GenreMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public static GenreDTO Map(this Genre genre)
        {
            GenreDTO genreDTO = GenreDTO.Create(
                genre.Id,
                genre.CreationDate,
                genre.UpdateDate,
                genre.DeletionDate,
                genre.Titles.Map(),
                genre.Descriptions?.Map());
            return genreDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de gêneros para uma coleção de DTOs
        /// </summary>
        /// <param name="genres"></param>
        /// <returns></returns>
        public static IEnumerable<GenreDTO> Map(this IEnumerable<Genre> genres)
        {
            IEnumerable<GenreDTO> result = genres.Select(g => g.Map());
            return result;
        }
    }
}
