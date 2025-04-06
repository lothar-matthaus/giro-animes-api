using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests.User;
using Giro.Animes.Application.Responses;
using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Presentation.Controllers;
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
        [ProducesResponseType<DetailResponse<AccountDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAccount([FromRoute] long id)
        {
            AccountDTO accountDTO = await _applicationService.GetAccountAndUserByAccountIdAsync(id);
            return Ok(accountDTO);
        }

        /// <summary>
        /// Cria uma nova conta de usuário 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<DetailResponse<AccountDTO>>((int)HttpStatusCode.Created)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequest request)
        {
            AccountDTO accountDTO = await _applicationService.CreateAccountAsync(request);
            DetailResponse<AccountDTO> response = DetailResponse<AccountDTO>.Create(accountDTO, true, HttpStatusCode.Created, "O conta de usuário foi criado com sucesso");
            return StatusCode((int)HttpStatusCode.Created, response);
        }
    }
}
