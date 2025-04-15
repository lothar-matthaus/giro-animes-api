using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Giro.Animes.Application.Requests.Anime
{
    public class AnimeCreateRequest
    {
       public ICollection<AnimeTitleRequest> Titles { get; set; } = new List<AnimeTitleRequest>();
       public IEnumerable<AnimeSinopseRequest> Sinopses { get; set; } = new List<AnimeSinopseRequest>();
       public IEnumerable<long> Genres { get; set; } = new List<long>();
       public IEnumerable<CoverRequest> Covers { get; set; } = new List<CoverRequest>();
       public IEnumerable<ScreenshotRequest> Screenshots { get; set; } = new List<ScreenshotRequest>();
       public IEnumerable<long> Authors { get; set; } = new List<long>();
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
        public IFormFile File { get; set; }
        public long LanguageId { get; set; }
        public string Extension => File.ContentType;
    }

    public class ScreenshotRequest
    {
        public IFormFile File { get; set; }
        public string Extension => File.ContentType;
    }
}
