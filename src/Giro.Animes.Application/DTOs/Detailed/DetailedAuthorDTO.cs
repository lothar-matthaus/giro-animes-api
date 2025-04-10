using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Simple;

namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Data Transfer Object for Author entity.
    /// </summary>
    public class DetailedAuthorDTO : BaseDTO
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
        public IEnumerable<SimpleAnimeDTO> Works { get; private set; }

        /// <summary>
        /// List of biographies of the author.
        /// </summary>
        public IEnumerable<DetaledBiographyDTO> Biographies { get; private set; }

        private DetailedAuthorDTO(long? id, string name, string penName, DateTime? birthDate, DateTime? deathDate, string website, string twitter, string instagram, IEnumerable<SimpleAnimeDTO> works, IEnumerable<DetaledBiographyDTO> biographies, DateTime creationDate, DateTime updateDate) :
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

        public static DetailedAuthorDTO Create(long? id, string name, string penName, DateTime? birthDate, DateTime? deathDate, string website, string twitter, string instagram, IEnumerable<SimpleAnimeDTO> works, IEnumerable<DetaledBiographyDTO> biographies, DateTime creationDate, DateTime updateDate)
        {
            return new DetailedAuthorDTO(id, name, penName, birthDate, deathDate, website, twitter, instagram, works, biographies, creationDate, updateDate);
        }
    }
}
