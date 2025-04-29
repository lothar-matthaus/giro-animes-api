using Microsoft.AspNetCore.Http;

namespace Giro.Animes.Application.Requests.Anime
{
    public class AnimeCreateOrUpdateRequest
    {
        public ICollection<AnimeTitleRequest> Titles { get; set; } = new List<AnimeTitleRequest>();
        public IEnumerable<AnimeSinopseRequest> Sinopses { get; set; } = new List<AnimeSinopseRequest>();
        public IEnumerable<long> Genres { get; set; } = new List<long>();
        public string CoverUrl { get; set; } = string.Empty;
        public IEnumerable<string> Screenshots { get; set; } = new List<string>();
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
}
