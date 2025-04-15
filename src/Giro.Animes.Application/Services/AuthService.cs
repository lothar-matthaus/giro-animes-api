using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
using Giro.Animes.Application.Requests.Auth;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.DTOs;
using Giro.Animes.Infra.Interfaces;
using Giro.Animes.Infra.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Giro.Animes.Application.Services
{
    public class AuthService : ApplicationServiceBase<IAccountDomainService>, IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;

        public AuthService(IApplicationUser applicationUser, IHttpContextAccessor httpContextAccessor, INotificationService notificationService, ITokenService tokenService, IAccountDomainService domainService) :
            base(applicationUser, notificationService, domainService)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
        }

        public async Task<AuthDTO> AuthAdminAsync(AuthRequest request, CancellationToken cancellationToken)
        {
            EntityResult<Account> result = await _domainService.AuthAdminByLoginAsync(request.Login, request.Password, cancellationToken);

            if (!result.IsValid)
            {
                await _notificationService.AddNotification(result.Errors);
                return null;
            }

            UserTokenDTO tokenDTO = await _tokenService.GenerateUserToken(result.Entity);
            return AuthDTO.Create(result.Entity.User.Name, result.Entity.User.Role.Map(), tokenDTO.ExpirationTime, result.Entity.Id.Value);
        }

        /// <summary>
        /// Realiza a autenticação do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AuthDTO> AuthAsync(AuthRequest request, CancellationToken cancellationToken)
        {
            EntityResult<Account> result = await _domainService.AuthByLoginAsync(request.Login, request.Password, cancellationToken);

            if (!result.IsValid)
            {
                await _notificationService.AddNotification(result.Errors);
                return null;
            }

            UserTokenDTO tokenDTO = await _tokenService.GenerateUserToken(result.Entity);
            return AuthDTO.Create(result.Entity.User.Name, result.Entity.User.Role.Map(), tokenDTO.ExpirationTime, result.Entity.Id.Value);
        }

        /// <summary>
        /// Gera um token de autenticação para o usuário convidado
        /// </summary>
        /// <returns></returns>
        public async Task<AuthDTO> GuestAuth()
        {
            UserTokenDTO userTokenDTO = await _tokenService.GenerateGuestToken();
            return AuthDTO.Create("Guest", UserRole.Guest.Map(), userTokenDTO.ExpirationTime, 0);
        }
    }
}
