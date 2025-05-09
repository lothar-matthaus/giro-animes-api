﻿using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests.Auth;
using Giro.Animes.Application.Requests.User;
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
            AuthDTO authDTO = await _applicationService.AuthAsync(request, HttpContext.RequestAborted);
            return await Ok(authDTO, Messages.Response.Auth.AUTHENTICATION_SUCCESS, Messages.Response.Auth.AUTHENTICATION_FAILED);
        }

        [HttpPost("guest")]
        [AllowAnonymous]
        [ProducesResponseType<DetailResponse<AuthDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GuestAuth()
        {
            AuthDTO authDTO = await _applicationService.GuestAuth(HttpContext.RequestAborted);
            return await Ok(authDTO, Messages.Response.Auth.AUTHENTICATION_SUCCESS, Messages.Response.Auth.AUTHENTICATION_FAILED);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType<string>((int)HttpStatusCode.Created)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromForm] AccountCreateRequest request)
        {
            await _accountService.CreateAccountAsync(request, HttpContext.RequestAborted);
            return StatusCode((int)HttpStatusCode.Created, Messages.Response.Account.ACCOUNT_CREATED);
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            await _accountService.ConfirmEmailAsync(token, HttpContext.RequestAborted);
            return Redirect("google.com");
        }
    }
}
