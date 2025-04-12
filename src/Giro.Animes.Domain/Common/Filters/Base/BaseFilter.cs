using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Common.Filters
{
    public class BaseFilter
    {
        public string SortBy { get; set; } = "Id";
        public bool OrderByDescending { get; set; } = false;
        public string Search { get; set; } = string.Empty;
    }
}
