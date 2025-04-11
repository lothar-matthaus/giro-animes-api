using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Mappers;
using Giro.Animes.Application.Requests.Auth;
using Giro.Animes.Application.Services.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Services;
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

        public async Task<AuthDTO> Auth(AuthRequest request)
        {
            Account account = await _domainService.GetAccountByLogin(request.Login);

            if (account is null)
            {
                await _notificationService.AddNotification("Login ou senha inválidos", "Login", "Senha");
                return null;
            }

            if (!account.Email.IsConfirmed)
            {
                await _notificationService.AddNotification("A conta precisa de confirmação do e-mail cadastrado. Verifique sua caixa de entrada.", "Login", "Status");
                return null;
            }

            bool isValidPassword = account.Password.VerifyPassword(request.Password, account.Password.Salt);

            if (!isValidPassword)
            {
                await _notificationService.AddNotification("Login ou senha inválidos", "Login", "Senha");
                return null;
            }

            UserTokenDTO tokenDTO = await _tokenService.GenerateUserToken(account);

            SetCookie(tokenDTO);

            return AuthDTO.Create(account.User.Name, account.User.Role.Map(), account.Id.Value);
        }

        public async Task<AuthDTO> GuestAuth()
        {
            UserTokenDTO userTokenDTO = await _tokenService.GenerateGuestToken();

            SetCookie(userTokenDTO);
            return AuthDTO.Create("Guest", UserRole.Guest.Map(), 0);
        }

        private void SetCookie(UserTokenDTO userTokenDTO)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append("access_token", userTokenDTO.Token, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddMinutes(userTokenDTO.ExpirationTime),
                Secure = true,
                SameSite = SameSiteMode.None,
                Domain = _httpContextAccessor.HttpContext.Request.Host.Host,
                IsEssential = true
            });
        }
    }
}
