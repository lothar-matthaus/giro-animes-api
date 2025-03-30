using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests.User;
using Giro.Animes.Application.Responses;
using Giro.Animes.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Giro.Animes.API.Controllers
{
    public class UsersController : GiroAnimesBaseController<IUserService>
    {
        public UsersController(IUserService applicationService) : base(applicationService)
        {
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<DetailResponse<UserDTO>>> GetUser([FromRoute] long id)
        {
            return Ok(await _applicationService.GetUserAndAccountByUserIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<DetailResponse<UserDTO>>> CreateUser([FromForm]UserCreateRequest request)
        {
            return Ok(await _applicationService.CreateUserAsync(request));
        }
    }
}
