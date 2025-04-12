using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Requests
{
    public class Pagination<Filter> : IPagination<Filter> where Filter : BaseFilter
    {
        public int Page { get; set; } = 1;
        public int RowsPerPage { get; set; } = 10;
        public Filter Filters { get; set; }

        public Pagination()
        {
            Filters = Activator.CreateInstance<Filter>();
        }
    }
}
