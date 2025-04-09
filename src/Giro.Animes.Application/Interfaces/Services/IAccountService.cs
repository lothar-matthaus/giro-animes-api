using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests.User;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAccountService : IApplicationServiceBase
    {
        Task<DetailedAccountDTO> GetAccountAndUserByAccountIdAsync(long accountId);
        Task<DetailedAccountDTO> CreateAccountAsync(AccountCreateRequest request);
    }
}
