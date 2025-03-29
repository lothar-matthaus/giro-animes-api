using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Requests
{
    public class Pagination : IPagination
    {
        public int Page { get; set; }

        public int RowsPerPage { get; set; }

        public int Count { get; set; }
    }
}
