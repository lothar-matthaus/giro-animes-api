using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests.Auth;
using Giro.Animes.Application.Responses;
using Giro.Animes.Presentation.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace Giro.Animes.API.Controllers
{
    public class AuthController : GiroAnimesBaseController<IAuthService>
    {
        public AuthController(IAuthService applicationService) : base(applicationService)
        {
        }

        [HttpPost()]
        [AllowAnonymous]
        [ProducesResponseType<DetailResponse<AuthDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Auth([FromBody] AuthRequest request)
        {
            AuthDTO authDTO = await _applicationService.Auth(request);
            return await Ok(authDTO, Messages.Response.Auth.AUTHENTICATION_SUCCESS);
        }
    }
}
