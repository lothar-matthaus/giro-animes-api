using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Requests
{
    public class Pagination : IPagination
    {
        public int Page { get; set; } = 1;
        public int RowsPerPage { get; set; } = 10;
    }
}
