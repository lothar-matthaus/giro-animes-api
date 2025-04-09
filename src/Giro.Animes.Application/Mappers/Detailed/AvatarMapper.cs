using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
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
        public static DetailedAvatarDTO Map(this Avatar avatar)
        {
            DetailedAvatarDTO avatarDTO = DetailedAvatarDTO.Create(
                avatar.Id,
                avatar.CreationDate,
                avatar.UpdateDate,
                avatar.UserId,
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
        public static IEnumerable<DetailedAvatarDTO> Map(this IEnumerable<Avatar> avatars)
        {
            IEnumerable<DetailedAvatarDTO> result = avatars.Select(avatar => avatar.Map());
            return result;
        }
    }
}
