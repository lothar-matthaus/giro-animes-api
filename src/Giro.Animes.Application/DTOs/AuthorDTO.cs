using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Author entity.
    /// </summary>
    public class AuthorDTO : BaseDTO
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

        private AuthorDTO(long? id, string name, string penName, DateTime? birthDate, DateTime? deathDate, string website, string twitter, string instagram, IEnumerable<AnimeDTO> works, IEnumerable<BiographyDTO> biographies, DateTime creationDate, DateTime updateDate) :
            base(id, creationDate, updateDate)
        {
            Name = name;
            PenName = penName;
            BirthDate = birthDate;
            DeathDate = deathDate;
            Website = website;
            Twitter = twitter;
            Instagram = instagram;
            Works = works;
            Biographies = biographies;
        }

        public static AuthorDTO Create(long? id, string name, string penName, DateTime? birthDate, DateTime? deathDate, string website, string twitter, string instagram, IEnumerable<AnimeDTO> works, IEnumerable<BiographyDTO> biographies, DateTime creationDate, DateTime updateDate)
        {
            return new AuthorDTO(id, name, penName, birthDate, deathDate, website, twitter, instagram, works, biographies, creationDate, updateDate);
        }
    }
}
