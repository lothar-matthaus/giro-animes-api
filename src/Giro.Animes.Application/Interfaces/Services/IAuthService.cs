using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests.Auth;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IAuthService : IApplicationServiceBase
    {
        Task<AuthDTO> AuthAsync(AuthRequest request, CancellationToken cancellationToken);
        Task<AuthDTO> AuthAdminAsync(AuthRequest request, CancellationToken cancellationToken);
        Task<AuthDTO> GuestAuth();
    }
}
