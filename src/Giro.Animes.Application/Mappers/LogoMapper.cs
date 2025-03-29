using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                logo.DeletionDate,
                logo.StudioId,
                logo.Url,
                logo.FileName,
                logo.Extension
                );

            return logoDTO;
        }
    }
}
