using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
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
        public async Task<DetailedAccountDTO> GetAccountAndUserByAccountIdAsync(long accountId)
        {
            Account account = await _domainService.GetAccountAndUserByAccountIdAsync(accountId);
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
    }
}
