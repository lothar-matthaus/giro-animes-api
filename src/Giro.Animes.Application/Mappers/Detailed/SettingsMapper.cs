using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    public static class SettingsMapper
    {
        public static DetailedSettingsDTO Map(this Settings settings)
        {
            DetailedSettingsDTO settingsDTO = DetailedSettingsDTO.Create(
                settings.Id,
                settings.CreationDate,
                settings.UpdateDate,
                settings.EnableApplicationNotifications,
                settings.EnableEmailNotifications,
                settings.Theme.Map(),
                settings.InterfaceLanguage.Map(),
                settings.AnimeAudioLanguages.Map(),
                settings.AnimeSubtitleLanguages.Map(),
                settings.AccountId);

            return settingsDTO;
        }
    }
}
