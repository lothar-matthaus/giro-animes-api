using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Requests.Anime
{
    public class AnimeUpdateRequest : AnimeCreateRequest
    {
        public long Id { get; set; }
    }
}
