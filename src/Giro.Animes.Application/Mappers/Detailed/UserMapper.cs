using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    /// <summary>
    /// Classe responsável por mapear um usuário para um DTO de usuário
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Mapeia um usuário para um DTO de usuário 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static DetailedUserDTO Map(this User user, bool mapWithAccount = false)
        {
            DetailedUserDTO userDTO = DetailedUserDTO.Create(
                user.Id,
                mapWithAccount ? user.Account?.Map() : null,
                user.CreationDate,
                user.UpdateDate,
                user.Name,
                user.Role.Map(),
                user.Ratings?.Map(),
                user.Watchlist?.Map());

            return userDTO;
        }

        /// <summary>
        /// Mapeia uma lista de usuários para uma lista de DTOs de usuários 
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedUserDTO> Map(this IEnumerable<User> users)
        {
            IEnumerable<DetailedUserDTO> result = users.Select(user => user.Map());
            return result;
        }
    }
}
