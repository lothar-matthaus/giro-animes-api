using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services.Base;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IMediaService : IApplicationServiceBase
    {
        Task<FileDTO> DownloadAsync(string token, CancellationToken cancellationToken);
    }
}
