using Giro.Animes.Domain.Interfaces.Pagination;

namespace Giro.Animes.Application.Interfaces.Enumerations
{
    public interface IPagedEnumerable<TType> : IEnumerable<TType>, IPagination where TType : class
    {
        public int TotalPages { get; }
        public int TotalCount { get; }
    }
}
