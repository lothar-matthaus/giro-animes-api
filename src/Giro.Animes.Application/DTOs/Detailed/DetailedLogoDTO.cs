namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Data Transfer Object for Logo entity.
    /// </summary>
    public class DetailedLogoDTO : MediaDTO
    {
        /// <summary>
        /// Identifier of the studio to which the logo belongs.
        /// </summary>
        public long StudioId { get; private set; }

        private DetailedLogoDTO(long? id, DateTime creationDate, DateTime updateDate, long studioId, string url) :
            base(id, url, creationDate, updateDate)
        {
        }

        public static DetailedLogoDTO Create(long? id, string url, long studioId, DateTime creationDate, DateTime updateDate)
        {
            return new DetailedLogoDTO(id, creationDate, updateDate, studioId, url);
        }
    }
}
