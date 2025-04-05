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
    public class UsersController : GiroAnimesBaseController<IUserService>
    {
        public UsersController(IUserService applicationService) : base(applicationService)
        {
        }

        /// <summary>
        /// Obtém um usuário pelo seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType<DetailResponse<UserDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            UserDTO userDTO = await _applicationService.GetUserAndAccountByUserIdAsync(id);
            return Ok(userDTO);
        }

        /// <summary>
        /// Cria um novo usuário. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<DetailResponse<UserDTO>>((int)HttpStatusCode.Created)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
        {
            UserDTO userDTO = await _applicationService.CreateUserAsync(request);
            DetailResponse<UserDTO> response = DetailResponse<UserDTO>.Create(userDTO, true, HttpStatusCode.Created, "O usuário foi criado com sucesso");
            return StatusCode((int)HttpStatusCode.Created, response);
        }
    }
}
