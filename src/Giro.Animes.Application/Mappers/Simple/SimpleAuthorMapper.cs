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
    /// Classe de mapeamento para autores simples.
    /// </summary>
    internal static class SimpleAuthorMapper
    {
        /// <summary>
        /// Método de extensão para mapear um autor para um SimpleAuthorDTO.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public static SimpleAuthorDTO MapSimple(this Author author)
        {
            SimpleAuthorDTO simpleAuthorDTO = SimpleAuthorDTO.Create(
                author.Name,
                author.PenName,
                author.Id
            );

            return simpleAuthorDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de autores para uma coleção de SimpleAuthorDTOs.
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleAuthorDTO> MapSimple(this IEnumerable<Author> authors)
        {
            IEnumerable<SimpleAuthorDTO> simpleAuthorDTOs = authors?.Select(author => author.MapSimple());
            return simpleAuthorDTOs;
        }
    }
}
