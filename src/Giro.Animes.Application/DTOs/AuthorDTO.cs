using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Author entity.
    /// </summary>
    public class AuthorDTO : BaseDTO<Author>
    {
        /// <summary>
        /// Author's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Author's pen name.
        /// </summary>
        public string PenName { get; private set; }

        /// <summary>
        /// Author's birth date.
        /// </summary>
        public DateTime? BirthDate { get; private set; }

        /// <summary>
        /// Author's death date.
        /// </summary>
        public DateTime? DeathDate { get; private set; }

        /// <summary>
        /// Author's website.
        /// </summary>
        public string Website { get; private set; }

        /// <summary>
        /// Author's Twitter handle.
        /// </summary>
        public string Twitter { get; private set; }

        /// <summary>
        /// Author's Instagram handle.
        /// </summary>
        public string Instagram { get; private set; }

        /// <summary>
        /// List of animes the author has worked on.
        /// </summary>
        public IEnumerable<AnimeDTO> Works { get; private set; }

        /// <summary>
        /// List of biographies of the author.
        /// </summary>
        public IEnumerable<BiographyDTO> Biographies { get; private set; }

        /// <summary>
        /// Private constructor to initialize AuthorDTO with an Author entity.
        /// </summary>
        /// <param name="author">Author entity.</param>
        private AuthorDTO(Author author) : base(author)
        {
            Name = author.Name;
            PenName = author.PenName;
            BirthDate = author.BirthDate;
            DeathDate = author.DeathDate;
            Website = author.Website;
            Twitter = author.Twitter;
            Instagram = author.Instagram;
            Works = author.Works.Select(AnimeDTO.Create);
            Biographies = author.Biographies.Select(BiographyDTO.Create).ToList();
        }

        /// <summary>
        /// Creates a new instance of AuthorDTO.
        /// </summary>
        /// <param name="author">Author entity.</param>
        /// <returns>New instance of AuthorDTO.</returns>
        public static AuthorDTO Create(Author author)
        {
            return new AuthorDTO(author);
        }
    }
}
