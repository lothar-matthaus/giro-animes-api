using Giro.Animes.Domain.Entities.Base;
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
        public Theme Theme { get; private set; }

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
        public ICollection<Language> AudioLanguages { get; private set; }

        /// <summary>
        /// Idiomas em que as legendas dos animes serão mostradas.
        /// </summary>
        public ICollection<Language> SubtitleLanguages { get; set; }
        /// <summary>
        /// Identificador do usuário ao qual as configurações pertencem
        /// </summary>
        public long AccountId { get; }

        /// <summary>
        /// Propriedade de navegação para o usuário ao qual as configurações pertencem
        /// </summary>
        public Account Account { get; }

        /// <summary>
        /// Construtor padrão para garantir a construção no EntityFramework
        /// </summary>
        public Settings() { }

        /// <summary>
        /// Construtor privado para inicializar as propriedades da classe Settings
        /// </summary>
        /// <param name="enableNotifications"></param>
        /// <param name="language"></param>
        private Settings(Language interfaceLanguage, IEnumerable<Language> audioLanguages, IEnumerable<Language> subtitleLanguages)
        {
            EnableApplicationNotifications = true;
            EnableApplicationNotifications = false;
            Theme = Theme.Light;
            InterfaceLanguage = interfaceLanguage;
            AudioLanguages = [.. audioLanguages];
            SubtitleLanguages = [.. subtitleLanguages];

        }

        /// <summary>
        /// Método para criar uma instância de Setting com os valores padrões definidos
        /// </summary>
        /// <param name="enableNotifications"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Settings Create(Language interfaceLanguage, IEnumerable<Language> audioLanguages, IEnumerable<Language> subtitleLanguages) => new(interfaceLanguage, audioLanguages, subtitleLanguages);

        #region Behaviors
        /// <summary>
        /// Altera o tema favorito do usuário no aplicativo
        /// </summary>
        /// <param name="theme"></param>
        public void ChangeFavoriteTheme(Theme theme) => Theme = theme;

        /// <summary>
        /// Altera as configurações de notificação do usuário
        /// </summary>
        /// <param name="enableApplicationNotifications"></param>
        /// <param name="enableEmailNotifications"></param>
        public void ChangeNotificationSettings(bool enableApplicationNotifications, bool enableEmailNotifications)
        {
            EnableApplicationNotifications = enableApplicationNotifications;
            EnableEmailNotifications = enableEmailNotifications;
        }

        /// <summary>
        /// Altera os idiomas de animes que devem aparecer para o usuário.
        /// </summary>
        /// <param name="audioLanguages"></param>
        public void ChangeAudioLanguages(IEnumerable<Language> audioLanguages) => AudioLanguages = [.. audioLanguages];

        /// <summary>
        /// Altera os idiomas de legendas que devem aparecer para o usuário.
        /// </summary>
        /// <param name="subtitleLanguages">Lista de idiomas para as legendas</param>
        public void ChangeSubtitleLanguages(IEnumerable<Language> subtitleLanguages) => SubtitleLanguages = [.. subtitleLanguages];

        /// <summary>
        /// Remove um idioma da lista de idiomas de animes
        /// </summary>
        /// <param name="language"></param>
        public void ChangeInterfaceLanguage(Language language) => InterfaceLanguage = language;


        #endregion
    }
}
