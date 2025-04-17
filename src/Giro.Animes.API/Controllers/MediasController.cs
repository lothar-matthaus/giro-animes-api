using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Presentation.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Giro.Animes.Shared.Controllers
{
    public class MediasController : GiroAnimesBaseController<IMediaService>
    {
        public MediasController(IMediaService applicationService) : base(applicationService)
        {
        }

        [HttpGet("Download")]
        [AllowAnonymous]
        public async Task<IActionResult> Download([FromQuery]string token, CancellationToken cancellationToken)
        {
            FileDTO media = await _applicationService.DownloadAsync(token, cancellationToken);
            return File(media.File, media.ContentType, true);
        }
    }
}
