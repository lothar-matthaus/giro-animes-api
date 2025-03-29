using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities.Joint
{
    public class SettingsAnimesLanguage : EntityBase
    {
        public long LanguageId { get; private set; }
        public long SettingsId { get; private set; }
        public Settings Settings { get; set; }
        public Language Language { get; set; }
    }
}
