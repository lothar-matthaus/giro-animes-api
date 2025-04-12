using Giro.Animes.Domain.Common.Filters;

namespace Giro.Animes.Domain.Interfaces.Pagination
{
    public interface IPagination<Filter> where Filter : BaseFilter
    {
        public int Page { get; }
        public int RowsPerPage { get; }
        public Filter Filters { get; }
    }
}
