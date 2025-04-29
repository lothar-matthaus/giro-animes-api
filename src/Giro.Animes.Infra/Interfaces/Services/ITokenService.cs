using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.DTOs;

namespace Giro.Animes.Infra.Interfaces.Services
{
    public interface ITokenService
    {
        Task<UserTokenDTO> GenerateUserToken(Account account, CancellationToken cancellationToken);
        Task<UserTokenDTO> GenerateGuestToken(CancellationToken cancellationToken);
        Task<UserTokenDTO> GenerateAccountActivationToken(string username);
        Task<string> ValidateAccountActivationToken(string token);
    }
}
