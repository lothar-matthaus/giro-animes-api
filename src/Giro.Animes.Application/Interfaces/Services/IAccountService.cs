using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests.Account;
using Giro.Animes.Application.Requests.User;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAccountService : IApplicationServiceBase
    {
        Task<DetailedAccountDTO> GetAccountAndUserByUserIdAsync(CancellationToken cancellationToken);
        Task CreateAccountAsync(AccountCreateRequest request);
        Task<SimpleAccountDTO> UpdateAccountAsync(AccountUpdateRequest request, CancellationToken cancellationToken);
        Task UpdatePasswordAsync(AccountPasswordUpdateRequest request, CancellationToken cancellationToken);
        Task<SimpleSettingsDTO> UpdateSettingsAsync(AccountSettingsUpdateRequest request, CancellationToken cancellationToken);
    }
}
