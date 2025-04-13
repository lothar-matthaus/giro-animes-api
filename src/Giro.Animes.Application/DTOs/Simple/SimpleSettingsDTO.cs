using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleSettingsDTO : BaseSimpleDTO
    {
        public bool EnableAppNotifications { get; private set; }
        public bool EnableEmailNotifications { get; private set; }
        public EnumDTO<Theme> Theme { get; private set; }
        public IEnumerable<SimpleLanguageDTO> AudioLanguage { get; set; }
        public IEnumerable<SimpleLanguageDTO> SubtitleLanguage { get; private set; }
        public long AccountId { get; set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enableAppNotifications"></param>
        /// <param name="enableEmailNotifications"></param>
        /// <param name="theme"></param>
        /// <param name="audioLanguage"></param>
        /// <param name="subtitleLanguage"></param>
        private SimpleSettingsDTO(long? id, bool enableAppNotifications, bool enableEmailNotifications, EnumDTO<Theme> theme, IEnumerable<SimpleLanguageDTO> audioLanguage, IEnumerable<SimpleLanguageDTO> subtitleLanguage) : base(id)
        {
            EnableAppNotifications = enableAppNotifications;
            EnableEmailNotifications = enableEmailNotifications;
            Theme = theme;
            AudioLanguage = audioLanguage;
            SubtitleLanguage = subtitleLanguage;
        }

        /// <summary>
        /// Método fábrica para criar uma nova instância de SimpleSettingsDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enableAppNotifications"></param>
        /// <param name="enableEmailNotifications"></param>
        /// <param name="theme"></param>
        /// <param name="audioLanguage"></param>
        /// <param name="subtitleLanguage"></param>
        /// <returns></returns>
        public static SimpleSettingsDTO Create(long? id, bool enableAppNotifications, bool enableEmailNotifications, EnumDTO<Theme> theme, IEnumerable<SimpleLanguageDTO> audioLanguage, IEnumerable<SimpleLanguageDTO> subtitleLanguage)
        {
            return new SimpleSettingsDTO(id, enableAppNotifications, enableEmailNotifications, theme, audioLanguage, subtitleLanguage);
        }
    }
}
