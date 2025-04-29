using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class LogoMapper
    {
        public static DetailedLogoDTO Map(this Logo logo)
        {
            DetailedLogoDTO logoDTO = DetailedLogoDTO.Create(
                logo.Id,
                logo.Url,
                logo.StudioId,
                logo.CreationDate,
                logo.UpdateDate);

            return logoDTO;
        }
    }
}
