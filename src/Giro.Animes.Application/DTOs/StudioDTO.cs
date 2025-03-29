using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Studio entity.
    /// </summary>
    public class StudioDTO : BaseDTO
    {
        /// <summary>
        /// Studio name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Studio's established date.
        /// </summary>
        public DateTime EstablishedDate { get; private set; }
        /// <summary>
        /// Country where the studio is located.
        /// </summary>
        public string Country { get; private set; }
        /// <summary>
        /// City where the studio is located.
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// Studio's website.
        /// </summary>
        public string Website { get; private set; }
        /// <summary>
        /// Studio's Twitter handle.
        /// </summary>
        public string Twitter { get; private set; }
        /// <summary>
        /// Studio's Instagram handle.
        /// </summary>
        public string Instagram { get; private set; }
        /// <summary>
        /// Studio's logo.
        /// </summary>
        public LogoDTO Logo { get; private set; }

        private StudioDTO(long? id, DateTime creationDate, DateTime updateDate, string name, DateTime establishedDate, string country, string city, string website, string twitter, string instagram, LogoDTO logo)
            : base(id, creationDate, updateDate)
        {
            Name = name;
            EstablishedDate = establishedDate;
            Country = country;
            City = city;
            Website = website;
            Twitter = twitter;
            Instagram = instagram;
            Logo = logo;
        }

        public static StudioDTO Create(long? id, DateTime creationDate, DateTime updateDate, string name, DateTime establishedDate, string country, string city, string website, string twitter, string instagram, LogoDTO logo)
        {
            return new StudioDTO(id, creationDate, updateDate, name, establishedDate, country, city, website, twitter, instagram, logo);
        }
    }
}
