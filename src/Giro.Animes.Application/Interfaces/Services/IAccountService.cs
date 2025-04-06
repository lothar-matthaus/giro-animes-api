using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests.User;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAccountService : IApplicationServiceBase
    {
        Task<AccountDTO> GetAccountAndUserByAccountIdAsync(long accountId);
        Task<AccountDTO> CreateAccountAsync(AccountCreateRequest request);
    }
}
