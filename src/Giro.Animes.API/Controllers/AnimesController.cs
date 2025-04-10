using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
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
        [ProducesResponseType<IPagedEnumerable<SimpleAnimeDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllPaged([FromQuery] Pagination pagination)
        {
            IPagedEnumerable<SimpleAnimeDTO> pagedResult = await _applicationService.GetAllPagedAsync(pagination, HttpContext.Request.HttpContext.RequestAborted);
            return await Ok(pagedResult, pagination, Messages.Response.Anime.ANIMES_FOUND, Messages.Response.Anime.ANIMES_NOT_FOUND);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType<DetailedAnimeDTO>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            DetailedAnimeDTO anime = await _applicationService.GetByIdAsync(id, HttpContext.Request.HttpContext.RequestAborted);
            return await Ok(anime, Messages.Response.Anime.ANIME_FOUND, Messages.Response.Anime.ANIME_NOT_FOUND);
        }
    }
}
