using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Classe responsável por mapear um avatar para um DTO de avatar
    /// </summary>
    public static class AvatarMapper
    {
        /// <summary>
        /// Mapeia um avatar para um DTO de avatar 
        /// </summary>
        /// <param name="avatar"></param>
        /// <returns></returns>
        public static AvatarDTO Map(this Avatar avatar)
        {
            AvatarDTO avatarDTO = AvatarDTO.Create(
                avatar.Id,
                avatar.CreationDate,
                avatar.UpdateDate,
                avatar.AccountId,
                avatar.Url,
                avatar.FileName,
                avatar.Extension
                );

            return avatarDTO;
        }

        /// <summary>
        /// Mapeia uma lista de avatares para uma lista de DTOs de avatares
        /// </summary>
        /// <param name="avatars"></param>
        /// <returns></returns>
        public static IEnumerable<AvatarDTO> Map(this IEnumerable<Avatar> avatars)
        {
            IEnumerable<AvatarDTO> result = avatars.Select(avatar => avatar.Map());
            return result;
        }
    }
}
