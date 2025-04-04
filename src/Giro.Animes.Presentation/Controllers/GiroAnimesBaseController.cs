using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Shared.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.Presentation.Controllers
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
