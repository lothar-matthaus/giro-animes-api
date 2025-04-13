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

        /// <summary>
        /// Realiza a autenticação do usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AuthDTO> Auth(AuthRequest request)
        {
            Account account = await _domainService.GetAccountByLogin(request.Login);

            if (account is null)
            {
                await _notificationService.AddNotification("Login ou senha inválidos", "Login", "Senha");
                return null;
            }

            bool isValidPassword = account.Password.VerifyPassword(request.Password, account.Password.Salt);

            if (!isValidPassword)
            {
                await _notificationService.AddNotification("Login ou senha inválidos", "Login", "Senha");
                return null;
            }

            if (!account.IsConfirmed)
            {
                await _notificationService.AddNotification("A conta precisa ser confirmada. Verifique sua caixa de entrada.", "Login", "Status");
                return null;
            }

            UserTokenDTO tokenDTO = await _tokenService.GenerateUserToken(account);

            SetCookie(tokenDTO);

            return AuthDTO.Create(account.User.Name, account.User.Role.Map(), tokenDTO.ExpirationTime, account.Id.Value);
        }

        /// <summary>
        /// Gera um token de autenticação para o usuário convidado
        /// </summary>
        /// <returns></returns>
        public async Task<AuthDTO> GuestAuth()
        {
            UserTokenDTO userTokenDTO = await _tokenService.GenerateGuestToken();

            SetCookie(userTokenDTO);
            return AuthDTO.Create("Guest", UserRole.Guest.Map(), userTokenDTO.ExpirationTime, 0);
        }

        /// <summary>
        /// Define o token de autenticação no cookie do usuário
        /// </summary>
        /// <param name="userTokenDTO"></param>
        private void SetCookie(UserTokenDTO userTokenDTO)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append("access_token", userTokenDTO.Token, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMinutes(userTokenDTO.ExpirationTime),
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Domain = _httpContextAccessor.HttpContext.Request.Host.Host,
                IsEssential = true,
            });
        }
    }
}
