using Giro.Animes.Application.DTOs.Detailed;
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
        public static DetailedAccountDTO Map(this Account account)
        {
            DetailedAccountDTO accountDTO = DetailedAccountDTO.Create(account.Id.Value,
                account.Email.Value,
                account.Settings.MapSimple(),
                account.Status.Map(),
                account.User.MapSimple(),
                account.CreationDate,
                account.UpdateDate);

            return accountDTO;
        }

        /// <summary>
        /// Mapeia uma lista de contas para uma lista de DTOs de contas
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedAccountDTO> Map(this IEnumerable<Account> accounts)
        {
            IEnumerable<DetailedAccountDTO> result = accounts.Select(account => account.Map());
            return result;
        }
    }
}
