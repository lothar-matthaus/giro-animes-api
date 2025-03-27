using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Utils
{
    internal interface IPagination
    {
        public int Page { get; }
        public int RowsPerPage { get; }
        public int Count { get; }
    }
}
