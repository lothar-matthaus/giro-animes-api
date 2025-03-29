using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities.Joint
{
    public class Watchlist : EntityBase
    {
        public long AccountId { get; private set; }
        public Account Account { get; private set; }

        public long AnimeId { get; private set; }
        public Anime Anime { get; private set; }

        public Watchlist() { }
    }
}
