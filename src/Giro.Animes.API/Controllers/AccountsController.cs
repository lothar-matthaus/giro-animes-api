using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests.Account;
using Giro.Animes.Application.Responses;
using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Presentation.Controllers;
using Giro.Animes.Shared.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.API.Controllers
{
    public class AccountsController : GiroAnimesBaseController<IAccountService>
    {
        public AccountsController(IAccountService applicationService) : base(applicationService)
        {
        }

        /// <summary>
        /// Obtém uma conta de usuário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Authorize(Policies.Account.CAN_GET_DETAIL)]
        [ProducesResponseType<DetailResponse<DetailedAccountDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAccount()
        {
            DetailedAccountDTO accountDTO = await _applicationService.GetAccountAndUserByUserIdAsync(HttpContext.RequestAborted);
            return await Ok(accountDTO, Messages.Response.Account.ACCOUNT_FOUND, Messages.Response.Account.ACCOUNT_NOT_FOUND);
        }

        [HttpPatch()]
        [Authorize(Policies.Account.CAN_UPDATE)]
        [ProducesResponseType<DetailResponse<SimpleAccountDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountUpdateRequest request)
        {
            await _applicationService.UpdateAccountAsync(request, HttpContext.RequestAborted);
            return StatusCode((int)HttpStatusCode.OK, Messages.Response.Account.ACCOUNT_UPDATED);
        }

        [HttpPatch("Password")]
        [Authorize(Policies.Account.CAN_UPDATE)]
        [ProducesResponseType<string>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePassword([FromBody] AccountPasswordUpdateRequest request)
        {
            await _applicationService.UpdatePasswordAsync(request, HttpContext.RequestAborted);
            return StatusCode((int)HttpStatusCode.OK, Messages.Response.Account.PASSWORD_UPDATED);
        }

        [HttpPatch("Settings")]
        [Authorize(Policies.Account.CAN_UPDATE)]
        [ProducesResponseType<DetailResponse<SimpleSettingsDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateSettings([FromBody] AccountSettingsUpdateRequest request)
        {
            SimpleSettingsDTO simpleSettingsDTO = await _applicationService.UpdateSettingsAsync(request, HttpContext.RequestAborted);
            return await Ok(simpleSettingsDTO, Messages.Response.Account.SETTINGS_UPDATED, Messages.Response.Account.SETTINGS_NOT_UPDATED);
        }
    }
}
