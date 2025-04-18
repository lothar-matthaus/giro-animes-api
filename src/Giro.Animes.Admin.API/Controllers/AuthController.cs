using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests.Auth;
using Giro.Animes.Application.Responses;
using Giro.Animes.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Giro.Animes.API.Controllers
{
    public class AuthController : GiroAnimesBaseController<IAuthService>
    {
        private readonly IAccountService _accountService;

        public AuthController(IAuthService applicationService, IAccountService accountService) : base(applicationService)
        {
            _accountService = accountService;
        }

        [HttpPost()]
        [AllowAnonymous]
        [ProducesResponseType<DetailResponse<AuthDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Auth([FromForm] AuthRequest request)
        {
            AuthDTO authDTO = await _applicationService.AuthAdminAsync(request, HttpContext.RequestAborted);
            return await Ok(authDTO, Messages.Response.Auth.AUTHENTICATION_SUCCESS, Messages.Response.Auth.AUTHENTICATION_FAILED);
        }
    }
}
