using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Interfaces.Enumerations
{
    public interface IPagedEnumerable<TType> : IEnumerable<TType> where TType : class
    {
        public int Page { get; }
        public int RowsPerPage { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
    }
}
