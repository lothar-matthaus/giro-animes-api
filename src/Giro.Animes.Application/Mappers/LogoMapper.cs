using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class LogoMapper
    {
        public static LogoDTO Map(this Logo logo)
        {
            LogoDTO logoDTO = LogoDTO.Create(
                logo.Id,
                logo.CreationDate,
                logo.UpdateDate,
                logo.StudioId,
                logo.Url,
                logo.FileName,
                logo.Extension
                );

            return logoDTO;
        }
    }
}
