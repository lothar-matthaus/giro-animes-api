namespace Giro.Animes.Domain.Common.Filters
{
    public class AnimeFilter : BaseFilter
    {
        public long? GenreId { get; set; }
        public long? AuthorId { get; set; }
        public bool OrderByMostViewed { get; set; } = false;
    }
}
