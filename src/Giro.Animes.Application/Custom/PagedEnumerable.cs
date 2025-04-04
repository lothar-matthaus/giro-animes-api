using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Domain.Interfaces.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Custom
{
    public class PagedEnumerable<TType> : IPagedEnumerable<TType> where TType : class
    {
        private readonly IEnumerable<TType> _items;
        public int Page { get; }
        public int RowsPerPage { get; }
        public int TotalPages { get; }
        public int TotalCount { get; set; }
        public PagedEnumerable(IEnumerable<TType> items, int page, int rowsPerPage, int totalCount)
        {
            _items = items;
            Page = page;
            RowsPerPage = rowsPerPage;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling((double)TotalCount / RowsPerPage);
        }

        public IEnumerator<TType> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
