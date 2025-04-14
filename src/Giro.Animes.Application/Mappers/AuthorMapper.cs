using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear a entidade Author para o DTO DetailedAuthorDTO e SimpleAuthorDTO.
    /// </summary>
    internal static class AuthorMapper
    {
        /// <summary>
        /// Método de extensão para mapear um autor para um DetailedAuthorDTO.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public static DetailedAuthorDTO Map(this Author author)
        {
            DetailedAuthorDTO authorDTO = DetailedAuthorDTO.Create(author.Id, author.Name, author.PenName,
                author.BirthDate, author.DeathDate, author.Website, author.Twitter, author.Instagram,
                author.Works?.MapSimple(), author.Biographies.Map(), author.CreationDate, author.UpdateDate);

            return authorDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de autores para uma coleção de DetailedAuthorDTOs.
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedAuthorDTO> Map(this IEnumerable<Author> authors)
        {
            IEnumerable<DetailedAuthorDTO> result = authors?.Select(Map);
            return result;
        }

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

        /// <summary>
        /// Método de extensão para mapear uma coleção de autores para uma coleção de SimpleComboxDTOs.
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleComboxDTO> MapCombox(this IEnumerable<Author> authors)
        {
            IEnumerable<SimpleComboxDTO> comboxDTOs = authors?.Select(author => SimpleComboxDTO.Create(author.Id.Value, author.Name));
            return comboxDTOs;
        }
    }
}
