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
using System.Text.RegularExpressions;

namespace Giro.Animes.Application.Services
{
    public class AuthApplicationService : ApplicationServiceBase<IAccountDomainService>, IAuthApplicationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IAccountDomainService _domainService;

        public AuthApplicationService(IApplicationUser applicationUser, IHttpContextAccessor httpContextAccessor, INotificationService notificationService, ITokenService tokenService, IAccountDomainService domainService) :
            base(applicationUser, notificationService, domainService)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _domainService = domainService;
        }

        public async Task<AuthDTO> Auth(AuthRequest request)
        {
            Account account = await _domainService.GetAccountByLogin(request.Login);

            if (account is null)
            {
                await _notificationService.AddNotification("Login ou senha inválidos", "Login", "Senha");
                return null;
            }

            if(account.User.Status != UserStatus.Active)
            {
                await _notificationService.AddNotification("A conta de usuário está inativa ou bloqueada", "Login", "Status");
                return null;
            }

            Password password = new Password(request.Password, account.Password.Salt);
            bool isValidPassword = account.Password.VerifyPassword(password);

            if (!isValidPassword)
            {
                await _notificationService.AddNotification("Login ou senha inválidos", "Login", "Senha");
                return null;
            }

            UserTokenDTO tokenDTO = await _tokenService.GenerateUserToken(account);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("access_token", tokenDTO.Token);

            return AuthDTO.Create(account.User.Name, account.User.Status.Map());
        }
    }
}
