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
        public async Task<EntityResult<Account>> CreateAccountAsync(Account account)
        {
            bool usernameAlreadyExists = await _repository.UsernameAlreadyExists(account.User.Name, CancellationToken.None);
            bool emailAlreadyExists = await _repository.EmailAlreadyExists(account.Email.Value, CancellationToken.None);

            IEnumerable<Notification> notifications = new List<Notification>()
                        .Concat(account.User.IsValid ? [] : account.User.GetErrors())
                        .Concat(account.IsValid ? Enumerable.Empty<Notification>() : account.GetErrors())
                        .Concat(account.Password.IsValid ? Enumerable.Empty<Notification>() : account.Password.GetErrors())
                        .Concat(account.Email.IsValid ? Enumerable.Empty<Notification>() : account.Email.GetErrors())
                        .Concat(usernameAlreadyExists ? new List<Notification> { Notification.Create(account.GetType().Name, "Username", Message.Validation.User.USERNAME_ALREADY_EXISTS) } : Enumerable.Empty<Notification>())
                        .Concat(emailAlreadyExists ? new List<Notification> { Notification.Create(account.GetType().Name, "Email", Message.Validation.User.EMAIL_ALREADY_EXISTS) } : Enumerable.Empty<Notification>())
                        .ToList();

            await _repository.AddAsync(account, CancellationToken.None);
            EntityResult<Account> result = EntityResult<Account>.Create(account, notifications);

            return result;
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
        public async Task<Account> GetAccountByLogin(string login)
        {
            if (Regex.IsMatch(login, Patterns.Account.EMAIL))
            {
                return await _repository.GetAccountByEmail(login, CancellationToken.None);
            }
            else
            {
                return await _repository.GetAccountByUsername(login, CancellationToken.None);
            }
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
            EntityResult<Account> entityResult;

            Password password = Password.Create(newPassword, newPasswordConfirm);
            
            bool isPasswordMatch = account.Password.VerifyPassword(currentPassword, account.Password.Salt);

            IEnumerable<Notification> notifications = (password.IsValid ? Enumerable.Empty<Notification>() : password.GetErrors())
                        .Concat(isPasswordMatch ? [] : new List<Notification> { Notification.Create(nameof(Account), "Password", Message.Validation.Account.INVALID_CURRENT_PASSWORD) })
                        .Concat(password.IsValid ? [] : password.GetErrors())
                        .ToList();

            if (notifications.Any())
            {
                entityResult = EntityResult<Account>.Create(account, notifications);
                return entityResult;
            }

            // Atualizar senha
            account.TryChangePassword(password);
            _repository.Update(account);

            entityResult = EntityResult<Account>.Create(account, notifications);
            return entityResult;
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
            Task<Language> interfaceLanguageTask = _languageRepository.GetByIdAsync(interfaceLanguageId, cancellationToken);
            Task<IEnumerable<Language>> audioLanguagesTask = _languageRepository.GetLanguagesByIdsAsync(audioLanguagesIds, cancellationToken);
            Task<IEnumerable<Language>> subtitleLanguagesTask = _languageRepository.GetLanguagesByIdsAsync(subtitleLangugesIds, cancellationToken);

            // Aguardar todas as tarefas
            await Task.WhenAll(interfaceLanguageTask, audioLanguagesTask, subtitleLanguagesTask);

            // Obter resultados
            Language interfaceLanguage = interfaceLanguageTask.Result;
            IEnumerable<Language> audioLanguages = audioLanguagesTask.Result;
            IEnumerable<Language> subtitleLanguages = subtitleLanguagesTask.Result;

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

            if (notifications.Any())
            {
                return EntityResult<Settings>.Create(null, notifications);
            }

            // Atualizar configurações
            Settings newSettings = account.Settings;

            newSettings.ChangeInterfaceLanguage(interfaceLanguage);
            newSettings.AddAudioLanguages(audioLanguages);
            newSettings.AddSubtitleLanguages(subtitleLanguages);
            newSettings.ChangeFavoriteTheme(theme);
            newSettings.ChangeNotificationSettings(enableApplicationNotifications, enableEmailNotifications);

            // Validar configurações
            notifications = newSettings.IsValid ? new List<Notification>() : newSettings.GetErrors().ToList();

            // Persistir alterações
            account.TryChangeSettings(newSettings);
            _repository.Update(account);

            return EntityResult<Settings>.Create(newSettings, notifications);
        }
    }
}
