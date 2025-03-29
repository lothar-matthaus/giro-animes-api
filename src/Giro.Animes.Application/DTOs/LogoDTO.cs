namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Logo entity.
    /// </summary>
    public class LogoDTO : MediaDTO
    {
        /// <summary>
        /// Identifier of the studio to which the logo belongs.
        /// </summary>
        public long StudioId { get; private set; }

        private LogoDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long studioId, string url, string fileName, string extension) : base(id, creationDate, updateDate, deletionDate, url, fileName, extension)
        {
        }

        public static LogoDTO Create(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long studioId, string url, string fileName, string extension)
        {
            return new LogoDTO(id, creationDate, updateDate, deletionDate, studioId, url, fileName, extension);
        }
    }
}
