﻿using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Settings.
    /// </summary>
    public class DetailedSettingsDTO : BaseDTO
    {
        /// <summary>
        /// Indica se as notificações estão habilitadas para o usuário.
        /// </summary>
        public bool EnableApplicationNotifications { get; private set; }

        /// <summary>
        /// Indica se as notificações por e-mail estão habilitadas para o usuário.
        /// </summary>
        public bool EnableEmailNotifications { get; private set; }

        /// <summary>
        /// Thema favorito do usuário no aplicativo.
        /// </summary>
        public EnumDTO<Theme> Theme { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o idioma favorito do usuário.
        /// </summary>
        public DetailedLanguageDTO InterfaceLanguage { get; private set; }

        /// <summary>
        /// Idiomas em que os animes serão mostrados.
        /// </summary>
        public IEnumerable<DetailedLanguageDTO> AnimeAudioLanguages { get; private set; }

        /// <summary>
        /// Idiomas em que as legendas dos animes serão mostradas.
        /// </summary>
        public IEnumerable<DetailedLanguageDTO> AnimeSubtitleLanguages { get; private set; }

        /// <summary>
        /// Identificador do usuário ao qual as configurações pertencem.
        /// </summary>
        public long AccountId { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="id">Identificador das configurações.</param>
        /// <param name="creationDate">Data de criação das configurações.</param>
        /// <param name="updateDate">Data de atualização das configurações.</param>
        /// <param name="enableApplicationNotifications">Indica se as notificações estão habilitadas para o usuário.</param>
        /// <param name="enableEmailNotifications">Indica se as notificações por e-mail estão habilitadas para o usuário.</param>
        /// <param name="theme">Thema favorito do usuário no aplicativo.</param>
        /// <param name="interfaceLanguage">Propriedade de navegação para o idioma favorito do usuário.</param>
        /// <param name="animeAudioLanguages">Idiomas em que os animes serão mostrados.</param>
        /// <param name="accountId">Identificador do usuário ao qual as configurações pertencem.</param>
        private DetailedSettingsDTO(long? id, DateTime creationDate, DateTime updateDate, bool enableApplicationNotifications, bool enableEmailNotifications, EnumDTO<Theme> theme, DetailedLanguageDTO interfaceLanguage, IEnumerable<DetailedLanguageDTO> animeAudioLanguages, IEnumerable<DetailedLanguageDTO> animeSubtitlesLanguages, long accountId) :
            base(id, creationDate, updateDate)
        {
            EnableApplicationNotifications = enableApplicationNotifications;
            EnableEmailNotifications = enableEmailNotifications;
            Theme = theme;
            InterfaceLanguage = interfaceLanguage;
            AnimeAudioLanguages = animeAudioLanguages;
            AnimeSubtitleLanguages = animeSubtitlesLanguages;
            AccountId = accountId;
        }

        /// <summary>
        /// Cria uma nova instância de SettingsDTO.
        /// </summary>
        /// <param name="id">Identificador das configurações.</param>
        /// <param name="creationDate">Data de criação das configurações.</param>
        /// <param name="updateDate">Data de atualização das configurações.</param>
        /// <param name="enableApplicationNotifications">Indica se as notificações estão habilitadas para o usuário.</param>
        /// <param name="enableEmailNotifications">Indica se as notificações por e-mail estão habilitadas para o usuário.</param>
        /// <param name="theme">Thema favorito do usuário no aplicativo.</param>
        /// <param name="interfaceLanguage">Propriedade de navegação para o idioma favorito do usuário.</param>
        /// <param name="animeAudioLanguages">Idiomas em que os animes serão mostrados.</param>
        /// <param name="accountId">Identificador do usuário ao qual as configurações pertencem.</param>
        /// <returns>Uma nova instância de SettingsDTO.</returns>
        public static DetailedSettingsDTO Create(long? id, DateTime creationDate, DateTime updateDate, bool enableApplicationNotifications, bool enableEmailNotifications, EnumDTO<Theme> theme, DetailedLanguageDTO interfaceLanguage, IEnumerable<DetailedLanguageDTO> animeAudioLanguages, IEnumerable<DetailedLanguageDTO> animeSubtitleLanguages, long accountId)
            => new DetailedSettingsDTO(id, creationDate, updateDate, enableApplicationNotifications, enableEmailNotifications, theme, interfaceLanguage, animeAudioLanguages, animeSubtitleLanguages, accountId);
    }
}