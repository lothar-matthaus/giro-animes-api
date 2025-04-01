using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear uma conta para um DTO de conta
    /// </summary>
    public static class AccountMapper
    {
        /// <summary>
        /// Mapeia uma conta para um DTO de conta 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static AccountDTO Map(this Account account)
        {
            AccountDTO accountDTO = AccountDTO.Create(
                account.Email.Value,
                account.Plan.Map(),
                account.Avatar?.Map(),
                account.Settings.Map(),
                account.Watchlist?.Map(),
                account.UserId,
                account.Id,
                account.CreationDate,
                account.UpdateDate);

            return accountDTO;
        }

        /// <summary>
        /// Mapeia uma lista de contas para uma lista de DTOs de contas
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static IEnumerable<AccountDTO> Map(this IEnumerable<Account> accounts)
        {
            IEnumerable<AccountDTO> result = accounts.Select(account => account.Map());
            return result;
        }
    }
}
