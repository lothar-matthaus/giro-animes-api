using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    public static class SettingsMapper
    {
        public static SettingsDTO Map(this Settings settings)
        {
            SettingsDTO settingsDTO = SettingsDTO.Create(
                settings.Id,
                settings.CreationDate,
                settings.UpdateDate,
                settings.EnableApplicationNotifications,
                settings.EnableEmailNotifications,
                settings.Theme.Map(),
                settings.InterfaceLanguage.Map(),
                settings.AnimeLanguages.Map(),
                settings.AccountId);

            return settingsDTO;
        }
    }
}
