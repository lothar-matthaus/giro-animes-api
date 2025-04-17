using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IMediaService : IApplicationServiceBase
    {
        Task<FileDTO> DownloadAsync(string token, CancellationToken cancellationToken);
    }
}
