﻿using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities.Joint
{
    public class SettingsAnimeSubtitleLanguage : EntityBase
    {
        public long LanguageId { get; private set; }
        public long SettingsId { get; private set; }
        public Settings Settings { get; set; }
        public Language Language { get; set; }

        public SettingsAnimeSubtitleLanguage()
        {
            CreationDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }
    }
}
