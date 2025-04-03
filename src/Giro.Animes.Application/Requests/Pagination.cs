using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Requests
{
    public class Pagination : IPagination
    {
        public int Page { get; set; }

        public int RowsPerPage { get; set; }

        public int Count { get; set; }

        public void SetPagination(int page, int rowsPerPage, int count)
        {
            Page = page;
            RowsPerPage = rowsPerPage;
            Count = count;
        }
    }
}
