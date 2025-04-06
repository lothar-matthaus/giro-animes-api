using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Giro.Animes.API.Controllers
{
    public class AuthController : GiroAnimesBaseController<IAuthApplicationService>
    {
        public AuthController(IAuthApplicationService applicationService) : base(applicationService)
        {
        }
    }
}
