using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Services
{
    public class AccountDomainService : DomainServiceBase<IAccountRepository, Account>, IAccountDomainService
    {
        private readonly ILanguageRepository _languageRepository;

        public AccountDomainService(IAccountRepository userRepository, ILanguageRepository languageRepository) :
            base(userRepository)
        {
            _languageRepository = languageRepository;
        }

        /// TODO: Adicionar evento de domínio para enviar e-mail de confirmação e notificação
        /// <summary>
        /// Cria uma nova conta para o usuário
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<EntityResult<Account>> CreateAccountAsync(string username, string email, string password, string confirmPassword, CancellationToken cancellationToken)
        {
            bool usernameAlreadyExists = await _repository.UsernameAlreadyExists(username, cancellationToken);
            bool emailAlreadyExists = await _repository.EmailAlreadyExists(email, cancellationToken);

            Language interfaceLanguage = await _languageRepository.GetLanguageByCode("en-US");
            IEnumerable<Language> defaultLanguages = await _languageRepository.GetLanguagesByCodes("en-US");

            List<Notification> notifications = new List<Notification>();

            if (interfaceLanguage is null)
            {
                notifications.Add(Notification.Create(nameof(Account), "InterfaceLanguage", Message.Language.LANGUAGE_NOT_FOUND));
            }

            if (defaultLanguages is null || !defaultLanguages.Any())
            {
                notifications.Add(Notification.Create(nameof(Settings), "DefaultLanguages", Message.Language.LANGUAGES_NOT_FOUND));
            }

            if (notifications.Any())
            {
                return EntityResult<Account>.Create(null, notifications);
            }

            Email newEmail = Email.Create(email);
            Password newPassword = Password.Create(password, confirmPassword);
            User user = User.Create(username, UserRole.User, UserPlan.Free);
            Settings settings = Settings.Create(interfaceLanguage, defaultLanguages, defaultLanguages);

            Account account = Account.Create(user, newEmail, newPassword, settings);

            notifications = new List<Notification>()
                        .Concat(account.User.IsValid ? [] : account.User.GetErrors())
                        .Concat(account.IsValid ? Enumerable.Empty<Notification>() : account.GetErrors())
                        .Concat(account.Password.IsValid ? Enumerable.Empty<Notification>() : account.Password.GetErrors())
                        .Concat(account.Email.IsValid ? Enumerable.Empty<Notification>() : account.Email.GetErrors())
                        .Concat(account.IsValid ? Enumerable.Empty<Notification>() : account.GetErrors())
                        .Concat(usernameAlreadyExists ? new List<Notification> { Notification.Create(account.GetType().Name, "Username", Message.Validation.User.USERNAME_ALREADY_EXISTS) } : Enumerable.Empty<Notification>())
                        .Concat(emailAlreadyExists ? new List<Notification> { Notification.Create(account.GetType().Name, "Email", Message.Validation.User.EMAIL_ALREADY_EXISTS) } : Enumerable.Empty<Notification>())
                        .ToList();

            if (notifications.Any())
            {
                return EntityResult<Account>.Create(account, notifications);
            }

            await _repository.AddAsync(account, cancellationToken);

            return EntityResult<Account>.Create(account, notifications);
        }

        /// <summary>
        /// Obtém uma conta e o usuário associado a ela pelo ID do usuário
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountAndUserByUserIdAsync(long userId, CancellationToken cancellationToken)
        {
            return await _repository.GetAccountByUserIdAsync(userId, cancellationToken);
        }

        /// <summary>
        /// Obtém uma conta pelo login (e-mail ou nome de usuário)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<EntityResult<Account>> AuthByLoginAsync(string login, string password, CancellationToken cancellationToken)
        {
            Account account = Regex.IsMatch(login, Patterns.Account.EMAIL)
                ? await _repository.GetAccountByEmail(login, cancellationToken)
                : await _repository.GetAccountByUsername(login, cancellationToken);

            if (account is null)
            {
                return EntityResult<Account>.Create(null, new[]
                {
                    Notification.Create(nameof(Account), string.Empty, Message.Account.LOGIN_OR_PASSWORD_INVALID)
                });
            }

            if (!account.Password.VerifyPassword(password))
            {
                return EntityResult<Account>.Create(account,
                [
                    Notification.Create(nameof(Account), string.Empty, Message.Account.LOGIN_OR_PASSWORD_INVALID)
                ]);
            }

            if (!account.IsConfirmed)
            {
                return EntityResult<Account>.Create(account,
                [
                    Notification.Create(nameof(Account), string.Empty, Message.Account.ACCOUNT_NOT_CONFIRMED)
                ]);
            }

            return EntityResult<Account>.Create(account, Enumerable.Empty<Notification>());
        }

        /// Adcionar evento de domínio para notificar o usuário da mudança de e-mail
        /// <summary>
        /// Atualiza o e-mail da conta do usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EntityResult<Account>> UpdateAccountAsync(long userId, string email, CancellationToken cancellationToken)
        {
            Account account = await _repository.GetAccountByUserIdAsync(userId, cancellationToken);
            EntityResult<Account> entityResult;

            Email newEmail = Email.Create(email);

            IEnumerable<Notification> notifications = (newEmail.IsValid ? [] : newEmail.GetErrors())
                        .ToList();

            account.TryChangeEmail(newEmail);
            entityResult = EntityResult<Account>.Create(account, notifications);

            _repository.Update(account);

            return entityResult;
        }

        /// TODO: Adicionar evento de domínio para notificar o usuário da mudança de senha
        /// <summary>
        /// Atualiza a senha da conta do usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="newPasswordConfirm"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<EntityResult<Account>> UpdatePasswordAsync(long userId, string currentPassword, string newPassword, string newPasswordConfirm, CancellationToken cancellationToken)
        {
            // Obter conta do usuário
            Account account = await _repository.GetAccountByUserIdAsync(userId, cancellationToken);

            Password password = Password.Create(newPassword, newPasswordConfirm);

            IEnumerable<Notification> notifications = Enumerable.Empty<Notification>()
            .Concat(!password.IsValid ? password.GetErrors() : [])
            .Concat(!account.Password.VerifyPassword(currentPassword) ? new[] { Notification.Create(nameof(Account), "Password", Message.Validation.Account.INVALID_CURRENT_PASSWORD) } : [])
            .ToList();

            // Atualizar senha
            account.TryChangePassword(password);
            _repository.Update(account);

            return EntityResult<Account>.Create(account, notifications);
        }

        /// <summary>
        /// Atualiza as configurações da conta do usuário
        /// </summary>
        /// <param name="userId">Usuário da aplicação</param>
        /// <param name="theme">Tema do usuário</param>
        /// <param name="enableApplicationNotifications">Se deve receber notificações na aplicação</param>
        /// <param name="enableEmailNotifications">Se deve receber notificações por email</param>
        /// <param name="interfaceLanguageId">Id do idioma de interface</param>
        /// <param name="audioLanguagesIds">Ids dos audios dos animes</param>
        /// <param name="subtitleLangugesIds">Ids das legendas dos animes</param>
        /// <param name="cancellationToken">Token de cancelamento caso a requisição seja abortada</param>
        /// <returns></returns>
        public async Task<EntityResult<Settings>> UpdateSettingsAsync(long userId, Theme theme, bool enableApplicationNotifications, bool enableEmailNotifications, long interfaceLanguageId, IEnumerable<long> audioLanguagesIds, IEnumerable<long> subtitleLangugesIds, CancellationToken cancellationToken)
        {
            // Obter conta do usuário
            Account account = await _repository.GetAccountByUserIdAsync(userId, cancellationToken);

            // Buscar idiomas em paralelo
            Language interfaceLanguage = await _languageRepository.GetByIdAsync(interfaceLanguageId, cancellationToken);
            IEnumerable<Language> audioLanguages = await _languageRepository.GetLanguagesByIdsAsync(audioLanguagesIds, cancellationToken);
            IEnumerable<Language> subtitleLanguages = await _languageRepository.GetLanguagesByIdsAsync(subtitleLangugesIds, cancellationToken);


            // Validar resultados
            var notifications = new List<Notification>();
            if (interfaceLanguage == null)
            {
                notifications.Add(Notification.Create(nameof(Settings), "InterfaceLanguage", Message.Language.LANGUAGE_NOT_FOUND));
            }
            if (audioLanguages == null || !audioLanguages.Any())
            {
                notifications.Add(Notification.Create(nameof(Settings), "AudioLanguages", Message.Language.LANGUAGES_NOT_FOUND));
            }
            if (subtitleLanguages == null || !subtitleLanguages.Any())
            {
                notifications.Add(Notification.Create(nameof(Settings), "SubtitleLanguages", Message.Language.LANGUAGES_NOT_FOUND));
            }

            // Atualizar configurações
            Settings newSettings = account.Settings;

            newSettings.ChangeInterfaceLanguage(interfaceLanguage);
            newSettings.ChangeAudioLanguages(audioLanguages);
            newSettings.ChangeSubtitleLanguages(subtitleLanguages);
            newSettings.ChangeFavoriteTheme(theme);
            newSettings.ChangeNotificationSettings(enableApplicationNotifications, enableEmailNotifications);

            if (!newSettings.IsValid)
            {
                notifications.AddRange(newSettings.GetErrors());
                return EntityResult<Settings>.Create(newSettings, notifications);
            }

            // Persistir alterações
            account.TryChangeSettings(newSettings);
            _repository.Update(account);

            return EntityResult<Settings>.Create(newSettings, notifications);
        }

        public async Task<EntityResult<Account>> AuthAdminByLoginAsync(string login, string password, CancellationToken cancellationToken)
        {
            EntityResult<Account> accountResult = await AuthByLoginAsync(login, password, cancellationToken);

            if (!accountResult.IsValid)
                return accountResult;

            if(accountResult.Entity.User.Role != UserRole.Administrator || accountResult.Entity.User.Role != UserRole.Publisher)
            {
                return EntityResult<Account>.Create(accountResult.Entity, new List<Notification>
                {
                    Notification.Create(nameof(Account), string.Empty, Message.User.USER_ROLE_NOT_ALLOWED)
                });
            }

            return accountResult;
        }
    }
}
