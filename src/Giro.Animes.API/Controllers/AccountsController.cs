﻿using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests.User;
using Giro.Animes.Application.Responses;
using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Presentation.Controllers;
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
        [Authorize]
        [ProducesResponseType<DetailResponse<AccountDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAccount([FromRoute] long id)
        {
            AccountDTO accountDTO = await _applicationService.GetAccountAndUserByAccountIdAsync(id);
            return await Ok(accountDTO, Messages.Response.Account.ACCOUNT_FOUND);
        }
    }
}
