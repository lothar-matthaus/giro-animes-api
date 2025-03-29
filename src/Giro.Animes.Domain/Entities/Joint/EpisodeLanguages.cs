using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities.Joint
{
    public class EpisodeLanguages : EntityBase
    {
        public long EpisodeId { get; private set; }
        public long LanguageId { get; private set; }

        public Language Language { get; private set; }
        public Episode Episode { get; private set; }
    }
}
