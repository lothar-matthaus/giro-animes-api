using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services.Base;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IAccountDomainService : IDomainServiceBase
    {
        Task<Account> GetAccountAndUserByUserIdAsync(long userId, CancellationToken cancellationToken);
        Task<EntityResult<Account>> CreateAccountAsync(string username, string email, string password, string confirmPassword, CancellationToken cancellationToken);
        Task<EntityResult<Account>> AuthByLoginAsync(string login, string password, CancellationToken cancellationToken);
        Task<EntityResult<Account>> UpdateAccountAsync(long userId, string email, CancellationToken cancellationToken);
        Task<EntityResult<Account>> UpdatePasswordAsync(long userId, string currentPassword, string newPassword, string newPasswordConfirm, CancellationToken cancellationToken);
        Task<EntityResult<Settings>> UpdateSettingsAsync(long userId, Theme theme, bool enableApplicationNotifications, bool enableEmailNotifications, long interfaceLanguageId, IEnumerable<long> audioLanguagesIds, IEnumerable<long> subtitleLangugesIds, CancellationToken cancellationToken);
    }
}
