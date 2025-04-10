using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Application.Mappers.Simple;

namespace Giro.Animes.Application.Mappers.Detailed
{
    internal static class AuthorMapper
    {
        public static DetailedAuthorDTO Map(this Author author)
        {
            DetailedAuthorDTO authorDTO = DetailedAuthorDTO.Create(
                author.Id,
                author.Name,
                author.PenName,
                author.BirthDate,
                author.DeathDate,
                author.Website,
                author.Twitter,
                author.Instagram,
                author.Works?.MapSimple(),
                author.Biographies.Map(),
                author.CreationDate,
                author.UpdateDate);

            return authorDTO;
        }

        public static IEnumerable<DetailedAuthorDTO> Map(this IEnumerable<Author> authors)
        {
            IEnumerable<DetailedAuthorDTO> result = authors?.Select(Map);
            return result;
        }
    }
}
