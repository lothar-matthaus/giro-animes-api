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

        private DetailedLogoDTO(long? id, DateTime creationDate, DateTime updateDate, long studioId, string url, string fileName, string extension) :
            base(id, creationDate, updateDate, url, fileName, extension)
        {
        }

        public static DetailedLogoDTO Create(long? id, DateTime creationDate, DateTime updateDate, long studioId, string url, string fileName, string extension)
        {
            return new DetailedLogoDTO(id, creationDate, updateDate, studioId, url, fileName, extension);
        }
    }
}
