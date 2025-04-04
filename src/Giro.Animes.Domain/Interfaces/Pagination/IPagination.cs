namespace Giro.Animes.Domain.Interfaces.Pagination
{
    public interface IPagination
    {
        public int Page { get; }
        public int RowsPerPage { get; }
    }
}
