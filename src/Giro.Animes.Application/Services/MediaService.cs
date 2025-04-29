using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Infra.Interfaces.Services;

namespace Giro.Animes.Application.Services
{
    public class MediaService : IApplicationServiceBase, IMediaService
    {
        private readonly ITokenService tokenService;
        private readonly INotificationService notificationService;

        public MediaService(ITokenService tokenService, INotificationService notificationService)
        {
            this.tokenService = tokenService;
            this.notificationService = notificationService;
        }
    }
}
