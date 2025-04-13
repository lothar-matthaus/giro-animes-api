using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
using Giro.Animes.Application.Requests.Account;
using Giro.Animes.Application.Requests.User;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.Interfaces;

namespace Giro.Animes.Application.Services
{
    public class AccountService : ApplicationServiceBase<IAccountDomainService>, IAccountService
    {
        private readonly ILanguageDomainService _languageDomainService;

        public AccountService(IApplicationUser applicationUser, IAccountDomainService domainService, INotificationService notificationService, ILanguageDomainService languageDomainService) :
            base(applicationUser, notificationService, domainService)
        {
            _languageDomainService = languageDomainService;
        }

        /// <summary>
        /// Obtém uma conta e o usuário associado a ela pelo ID da conta
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<DetailedAccountDTO> GetAccountAndUserByUserIdAsync(CancellationToken cancellationToken)
        {
            Account account = await _domainService.GetAccountAndUserByUserIdAsync(_applicationUser.Id, cancellationToken);
            DetailedAccountDTO accountDTO = account?.Map();

            return accountDTO;
        }

        /// <summary>
        /// Cria uma nova conta de usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CreateAccountAsync(AccountCreateRequest request)
        {
            // Cria as tasks para obter o idioma da interface e os idiomas favoritos
            Language interfaceLanguage = await _languageDomainService.GetLanguageByCode();
            IEnumerable<Language> defaultLanguages = await _languageDomainService.GetLanguagesByCodes("en-US");

            // Cria as configurações do usuário
            Settings settings = Settings.Create(interfaceLanguage, defaultLanguages, defaultLanguages);

            // Cria os objetos de valor para senha e email
            Password password = Password.Create(request.Password, request.ConfirmPassword);
            Email email = Email.Create(request.Email);

            // Cria o usuário com status inativo
            User user = User.Create(request.Username, UserRole.User, UserPlan.Free);

            // Cria a conta do usuário
            Account account = Account.Create(user, email, password, settings);

            // Chama o serviço de domínio para demais validações e persistência
            EntityResult<Account> resultAccount = await _domainService.CreateAccountAsync(account);

            if (!resultAccount.IsValid)
            {
                // Adiciona as notificações de erro
                await _notificationService.AddNotification(resultAccount.Errors);
                return;
            }
        }

        /// <summary>
        /// Atualiza os dados da conta do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<SimpleAccountDTO> UpdateAccountAsync(AccountUpdateRequest request, CancellationToken cancellationToken)
        {
            EntityResult<Account> result = await _domainService.UpdateAccountAsync(_applicationUser.Id, request.Email, cancellationToken);

            if (!result.IsValid)
            {
                await _notificationService.AddNotification(result.Errors);
                return null;
            }

            return result.Entity.MapSimple();
        }

        /// <summary>
        /// Atualiza a senha da conta do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdatePasswordAsync(AccountPasswordUpdateRequest request, CancellationToken cancellationToken)
        {
            EntityResult<Account> result = await _domainService.UpdatePasswordAsync(_applicationUser.Id, request.CurrentPassword, request.Password, request.ConfirmPassword, cancellationToken);

            if (!result.IsValid)
            {
                await _notificationService.AddNotification(result.Errors);
                return;
            }

            return;
        }
        public async Task<SimpleSettingsDTO> UpdateSettingsAsync(AccountSettingsUpdateRequest request, CancellationToken cancellationToken)
        {
            EntityResult<Settings> updateResult = await _domainService.UpdateSettingsAsync(
                _applicationUser.Id,
                (Theme)request.Theme,
                request.EnableApplicationNotifications,
                request.EnableEmailNotifications,
                request.InterfaceLanguage,
                request.AudioLanguages,
                request.SubtitleLanguages,
                cancellationToken);

            if (!updateResult.IsValid)
            {
                await _notificationService.AddNotification(updateResult.Errors);
                return null;
            }

            // Retorna o DTO atualizado
            return updateResult.Entity.MapSimple();
        }

        /// <summary>
        /// Valida se o idioma existe
        /// </summary>
        /// <param name="language"></param>
        /// <param name="context"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateLanguage(Language language, string context, string errorMessage)
        {
            if (language is null)
            {
                _notificationService.AddNotification(Notification.Create(context, "Id", errorMessage));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida se os idiomas existem
        /// </summary>
        /// <param name="languages"></param>
        /// <param name="context"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateLanguages(IEnumerable<Language> languages, string context, string errorMessage)
        {
            if (languages is null || !languages.Any())
            {
                _notificationService.AddNotification(Notification.Create(context, "Id", errorMessage));
                return false;
            }
            return true;
        }


    }
}