﻿using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Domain.Entities
{
    public class Settings : EntityBase
    {
        /// <summary>
        /// Indica se as notificações estão habilitadas para o usuário 
        /// </summary>
        public bool EnableApplicationNotifications { get; private set; }

        /// <summary>
        /// Indica se as notificações por e-mail estão habilitadas para o usuário
        /// </summary>
        public bool EnableEmailNotifications { get; private set; }

        /// <summary>
        /// Thema favorito do usuário no aplicativo
        /// </summary>
        public UserTheme Theme { get; private set; }

        /// <summary>
        /// Identificador do idioma da interface 
        /// </summary>
        public long InterfaceLanguageId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o idioma favorito do usuário 
        /// </summary>
        public Language InterfaceLanguage { get; private set; }

        /// <summary>
        /// Idiomas em que os animes serão mostrados.
        /// </summary>
        public IEnumerable<Language> AnimeLanguages { get; private set; }
        /// <summary>
        /// Identificador do usuário ao qual as configurações pertencem
        /// </summary>
        public long AccountId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o usuário ao qual as configurações pertencem
        /// </summary>
        public Account Account { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção no EntityFramework
        /// </summary>
        public Settings() { }

        /// <summary>
        /// Construtor privado para inicializar as propriedades da classe Settings
        /// </summary>
        /// <param name="enableNotifications"></param>
        /// <param name="language"></param>
        private Settings(Language interfaceLanguage, IEnumerable<Language> animeLanguages)
        {
            EnableApplicationNotifications = true;
            EnableApplicationNotifications = false;
            Theme = UserTheme.Light;
            InterfaceLanguage = interfaceLanguage ?? Language.Create("Portuguese (Brazil)", "pt-BR", "Português");
            AnimeLanguages = animeLanguages ?? [Language.Create("Portuguese (Brazil)", "pt-BR", "Português")];
        }

        /// <summary>
        /// Método para criar uma instância de Setting com os valores padrões definidos
        /// </summary>
        /// <param name="enableNotifications"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Settings Create(Language interfaceLanguage, IEnumerable<Language> animeLanguages) => new(interfaceLanguage, animeLanguages);

        #region Behaviors
        /// <summary>
        /// Altera o tema favorito do usuário no aplicativo
        /// </summary>
        /// <param name="theme"></param>
        public void ChangeFavoriteTheme(UserTheme theme) => Theme = theme;

        /// <summary>
        /// Alterna as notificações do usuário no aplicativo
        /// </summary>
        public void ToggleNotifications() => EnableApplicationNotifications = !EnableApplicationNotifications;

        /// <summary>
        /// Alterna as notificações por e-mail do usuário 
        /// </summary>
        public void ToggleEmailNotifications() => EnableEmailNotifications = !EnableEmailNotifications;

        /// <summary>
        /// Altera o idioma favorito do usuário 
        /// </summary>
        /// <param name="language"></param>
        public void ChangeFavoriteLanguage(Language interfaceLanguage) => InterfaceLanguage = interfaceLanguage;

        /// <summary>
        /// Altera os idiomas de animes que devem aparecer para o usuário.
        /// </summary>
        /// <param name="animeLanguages"></param>
        public void ChangeAnimeLanguages(IEnumerable<Language> animeLanguages) => AnimeLanguages = animeLanguages;
        #endregion
    }
}
