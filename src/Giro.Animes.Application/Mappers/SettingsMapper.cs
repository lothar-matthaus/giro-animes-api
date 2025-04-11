using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear uma configuração para um DTO de configuração
    /// </summary>
    public static class SettingsMapper
    {
        /// <summary>
        /// Mapeia uma configuração para um DTO de configuração
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
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
                settings.AudioLanguages.Map(),
                settings.SubtitleLanguages.Map(),
                settings.AccountId);

            return settingsDTO;
        }

        /// <summary>
        /// Mapeia uma lista de configurações para uma lista de DTOs de configurações
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedSettingsDTO> Map(this IEnumerable<Settings> settings)
        {
            IEnumerable<DetailedSettingsDTO> result = settings.Select(setting => setting.Map());
            return result;
        }

        /// <summary>
        /// /// Mapeia uma configuração para um DTO de configuração simples
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static SimpleSettingsDTO MapSimple(this Settings settings)
        {
            SimpleSettingsDTO settingsDTO = SimpleSettingsDTO.Create(settings.Id,
                settings.EnableApplicationNotifications,
                settings.EnableEmailNotifications,
                settings.Theme.Map(),
                settings.AudioLanguages.MapSimple(),
                settings.SubtitleLanguages.MapSimple());

            return settingsDTO;
        }

        /// <summary>
        /// /// Mapeia uma lista de configurações para uma lista de DTOs de configurações
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleSettingsDTO> MapSimple(this IEnumerable<Settings> settings)
        {
            IEnumerable<SimpleSettingsDTO> result = settings.Select(setting => setting.MapSimple());
            return result;
        }
    }
}
