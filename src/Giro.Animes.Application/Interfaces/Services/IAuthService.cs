using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests.Auth;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAuthService : IApplicationServiceBase
    {
        Task<AuthDTO> Auth(AuthRequest request);
    }
}
