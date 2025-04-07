using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Giro.Animes.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.API.Controllers
{
    public class AnimesController : GiroAnimesBaseController<IAnimeService>
    {
        public AnimesController(IAnimeService applicationService) : base(applicationService)
        {
        }

        [HttpGet]
        [ProducesResponseType<IPagedEnumerable<AnimeDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllPaged([FromQuery] Pagination pagination)
        {
            IPagedEnumerable<AnimeDTO> pagedResult = await _applicationService.GetAllPagedAsync(pagination, HttpContext.Request.HttpContext.RequestAborted);
            return await Ok(pagedResult, pagination, Messages.Response.Anime.ANIMES_FOUND);
        }
    }
}
