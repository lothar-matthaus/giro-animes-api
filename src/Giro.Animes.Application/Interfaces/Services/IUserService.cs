using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests.User;

namespace Giro.Animes.Application.Interfaces.Services
{
    public interface IUserService : IApplicationServiceBase
    {
        Task<UserDTO> GetUserAndAccountByUserIdAsync(long userId);
        Task<UserDTO> CreateUserAsync(UserCreateRequest request);
    }
}
