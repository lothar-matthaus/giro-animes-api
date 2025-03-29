namespace Giro.Animes.Domain.Interfaces.Pagination
{
    public interface IPagination
    {
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
        public int Count { get; set; }
    }
}
