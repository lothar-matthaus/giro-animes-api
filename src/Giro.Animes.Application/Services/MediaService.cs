using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Infra.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Services
{
    public class MediaService : IApplicationServiceBase, IMediaService
    {
        private readonly ITokenService tokenService;
        private readonly IFileMediaStorageService fileMediaStorageService;
        private readonly INotificationService notificationService;

        public MediaService(ITokenService tokenService, IFileMediaStorageService fileMediaStorageService, INotificationService notificationService)
        {
            this.tokenService = tokenService;
            this.fileMediaStorageService = fileMediaStorageService;
            this.notificationService = notificationService;
        }

        public async Task<FileDTO> DownloadAsync(string token, CancellationToken cancellationToken)
        {
            (var path, var type, var name) = await tokenService.GetMediaByMediaToken(token, cancellationToken);

            if(string.IsNullOrEmpty(path) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(name))
            {
                await notificationService.AddNotification("Token enviado inválido ou expirado. Verifique a resposta dos dados oriudos da mídia requisitada", "Download", "Token");
                return null;
            }

            byte[] file = await fileMediaStorageService.DownloadAsync(path, cancellationToken);

            if (file is null)
                return null;

            return FileDTO.Create(name, file, type);
        }
    }
}
