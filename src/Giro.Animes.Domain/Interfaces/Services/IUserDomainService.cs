using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IAccountDomainService : IDomainServiceBase
    {
        Task<Account> GetAccountAndUserByAccountIdAsync(long accountId);
        Task<EntityResult<Account>> CreateAccountAsync(Account account);
        Task<Account> GetAccountByLogin(string login);
    }
}
