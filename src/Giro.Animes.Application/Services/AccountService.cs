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
using Giro.Animes.Infra.Interfaces.Services;

namespace Giro.Animes.Application.Services
{
    public class AccountService : ApplicationServiceBase<IAccountDomainService>, IAccountService
    {
        private readonly ILanguageDomainService _languageDomainService;
        private readonly ITokenService _tokenService;

        public AccountService(IApplicationUser applicationUser, IAccountDomainService domainService, ITokenService tokenService, INotificationService notificationService, ILanguageDomainService languageDomainService) :
            base(applicationUser, notificationService, domainService)
        {
            _languageDomainService = languageDomainService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Obtém uma conta e o usuário associado a ela pelo ID do usuário
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
        public async Task CreateAccountAsync(AccountCreateRequest request, CancellationToken cancellationToken)
        {
            // Chama o serviço de domínio para demais validações e persistência
            EntityResult<Account> resultAccount = await _domainService.CreateAccountAsync(request.Username, request.Email, request.Password, request.ConfirmPassword, cancellationToken);

            if (!resultAccount.IsValid)
            {
                // Adiciona as notificações de erro
                await _notificationService.AddNotification(resultAccount.Errors);
                return;
            }

            return;
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

        /// <summary>
        /// Atualiza as configurações da conta do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SimpleSettingsDTO> UpdateSettingsAsync(AccountSettingsUpdateRequest request, CancellationToken cancellationToken)
        {
            EntityResult<Settings> updateResult = await _domainService.UpdateSettingsAsync(_applicationUser.Id, (Theme)request.Theme, request.EnableApplicationNotifications, request.EnableEmailNotifications, request.InterfaceLanguage, request.AudioLanguages, request.SubtitleLanguages, cancellationToken);

            if (!updateResult.IsValid)
            {
                await _notificationService.AddNotification(updateResult.Errors);
                return null;
            }

            // Retorna o DTO atualizado
            return updateResult.Entity.MapSimple();
        }

        public  async Task ConfirmEmailAsync(string token, CancellationToken cancellationToken)
        {
            string username = await _tokenService.ValidateAccountActivationToken(token);

            EntityResult<Account> result = await _domainService.ConfirmEmailAsync(username, cancellationToken);
            if (!result.IsValid)
            {
                await _notificationService.AddNotification(result.Errors);
                return;
            }

            return;
        }
    }
}