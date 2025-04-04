using Giro.Animes.Domain.Interfaces.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Interfaces.Enumerations
{
    public interface IPagedEnumerable<TType> : IEnumerable<TType>, IPagination where TType : class
    {
        public int TotalPages { get; }
        public int TotalCount { get; }
    }
}
