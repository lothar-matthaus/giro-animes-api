using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs.Detailed;
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
        [HttpGet("{id:long}")]
        [Authorize(Policies.Account.CAN_GET_DETAIL)]
        [ProducesResponseType<DetailResponse<DetailedAccountDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAccount([FromRoute] long id)
        {
            DetailedAccountDTO accountDTO = await _applicationService.GetAccountAndUserByAccountIdAsync(id);
            return await Ok(accountDTO, Messages.Response.Account.ACCOUNT_FOUND, Messages.Response.Account.ACCOUNT_NOT_FOUND);
        }

        [HttpPut()]
        [Authorize(Policies.Account.CAN_UPDATE)]
        [ProducesResponseType<string>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountUpdateRequest request)
        {
            // TODO: Implementar o método de atualização de conta
            await _applicationService.UpdateAccountAsync(request, HttpContext.RequestAborted);
            return StatusCode((int)HttpStatusCode.OK, Messages.Response.Account.ACCOUNT_UPDATED);
        }
    }
}
