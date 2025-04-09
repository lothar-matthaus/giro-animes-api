using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.DTOs;

namespace Giro.Animes.Infra.Interfaces.Services
{
    public interface ITokenService
    {
        Task<UserTokenDTO> GenerateUserToken(Account account);
        Task<UserTokenDTO> GenerateGuestToken();
    }
}
