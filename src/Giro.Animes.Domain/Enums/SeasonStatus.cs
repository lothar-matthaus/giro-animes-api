using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Enums
{
    /// <summary>
    /// Status da temporada do anime.
    /// </summary>
    public enum SeasonStatus
    {
        ToBeReleased = 0,
        Ongoing = 1,
        Finished = 2,
        Canceled = 3,
        Hiatus = 4,
        Unknown = 5
    }
}
