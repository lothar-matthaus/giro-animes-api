using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class AuthorMapper
    {
        public static AuthorDTO Map(this Author author)
        {
            AuthorDTO authorDTO = AuthorDTO.Create(
                author.Id,
                author.Name,
                author.PenName,
                author.BirthDate,
                author.DeathDate,
                author.Website,
                author.Twitter,
                author.Instagram,
                author.Works?.Map(),
                BiographyMapper.Map(author.Biographies),
                author.CreationDate,
                author.UpdateDate,
                author.DeletionDate);

            return authorDTO;
        }

        public static IEnumerable<AuthorDTO> Map(this IEnumerable<Author> authors)
        {
            IEnumerable<AuthorDTO> result = authors?.Select(Map);
            return result;
        }
    }
}
