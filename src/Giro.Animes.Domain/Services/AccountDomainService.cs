using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.Services.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Services
{
    public class AccountDomainService : DomainServiceBase<IAccountRepository, Account>, IAccountDomainService
    {
        public AccountDomainService(IAccountRepository userRepository) :
            base(userRepository)
        {
        }

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
                        .Concat(account.User.IsValid ? Enumerable.Empty<Notification>() : account.User.GetErrors())
                        .Concat(account.IsValid ? Enumerable.Empty<Notification>() : account.GetErrors())
                        .Concat(account.Password.IsValid ? Enumerable.Empty<Notification>() : account.Password.GetErrors())
                        .Concat(account.Email.IsValid ? Enumerable.Empty<Notification>() : account.Email.GetErrors())
                        .Concat(usernameAlreadyExists ? new List<Notification> { Notification.Create(account.GetType().Name, "Username", Message.Validation.User.USERNAME_ALREADY_EXISTS) } : Enumerable.Empty<Notification>())
                        .Concat(emailAlreadyExists ? new List<Notification> { Notification.Create(account.GetType().Name, "Email", Message.Validation.User.EMAIL_ALREADY_EXISTS) } : Enumerable.Empty<Notification>())
                        .ToList();

            await _repository.AddAsync(account, CancellationToken.None);
            EntityResult<Account> result = EntityResult<Account>.Create(account, notifications);

            if (result.IsValid)
            {
                await _repository.Commit();
            }

            return result;
        }

        /// <summary>
        /// Verifica se o nome de usuário já existe
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountAndUserByAccountIdAsync(long accountId)
        {
            return await _repository.GetByIdAsync(accountId, CancellationToken.None);
        }

        public async Task<Account> GetAccountByLogin(string login)
        {
            if(Regex.IsMatch(login, Patterns.Account.EMAIL))
            {
                return await _repository.GetAccountByEmail(login, CancellationToken.None);
            }
            else
            {
                return await _repository.GetAccountByUsername(login, CancellationToken.None);
            }
        }
    }
}
