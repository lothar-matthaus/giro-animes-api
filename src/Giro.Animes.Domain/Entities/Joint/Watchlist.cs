using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities.Joint
{
    public class Watchlist : EntityBase
    {
        public long UserId { get; private set; }
        public User User { get; private set; }

        public long AnimeId { get; private set; }
        public Anime Anime { get; private set; }

        public Watchlist() { }
    }
}
