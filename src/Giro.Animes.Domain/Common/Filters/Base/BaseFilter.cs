namespace Giro.Animes.Domain.Common.Filters
{
    public class BaseFilter
    {
        public string SortBy { get; set; } = "Id";
        public bool OrderByDescending { get; set; } = false;
        public string Name { get; set; } = string.Empty;
    }
}
