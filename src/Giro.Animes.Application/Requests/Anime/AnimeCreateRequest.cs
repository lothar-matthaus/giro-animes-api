using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Giro.Animes.Application.Requests.Anime
{
    public class AnimeCreateRequest
    {
        public IEnumerable<AnimeTitleRequest> Titles { get; set; }
        public IEnumerable<AnimeSinopseRequest> Sinopses { get; set; }
        public IEnumerable<long> Genres { get; set; }
        public IEnumerable<CoverRequest> Covers { get; set; }
        public IEnumerable<ScreenshotRequest> Screenshots { get; internal set; }
        public IEnumerable<long> Authors { get; set; }
        public long StudioId { get; set; }
    }

    public class AnimeTitleRequest
    {
        public string Name { get; set; }
        public long LanguageId { get; set; }
    }

    public class AnimeSinopseRequest
    {
        public string Descrition { get; set; }
        public long LanguageId { get; set; }
    }

    public class CoverRequest
    {
        [FromForm]
        public IFormFile File { get; set; }
        public long LanguageId { get; set; }
        public string Extension => File.ContentType;
    }

    public class ScreenshotRequest
    {
        [FromForm]
        public IFormFile File { get; set; }
        public string Extension => File.ContentType;
    }
}
