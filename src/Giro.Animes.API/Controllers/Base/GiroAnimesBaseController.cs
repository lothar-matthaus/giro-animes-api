using Giro.Animes.Application.Interfaces.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace Giro.Animes.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GiroAnimesBaseController<TApplicationService> : ControllerBase where TApplicationService : IApplicationServiceBase
    {
        protected readonly TApplicationService _applicationService;

        public GiroAnimesBaseController(TApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

    }
}
