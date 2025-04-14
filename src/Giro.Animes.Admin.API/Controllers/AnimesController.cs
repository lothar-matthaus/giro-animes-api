using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Requests.Anime;
using Giro.Animes.Application.Responses;
using Giro.Animes.Domain.Common.Filters;
using Giro.Animes.Presentation.Controllers;
using Giro.Animes.Shared.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.API.Controllers
{
    public class AnimesController : GiroAnimesBaseController<IAnimeService>
    {
        public AnimesController(IAnimeService applicationService) : base(applicationService)
        {
        }

        /// <summary>
        /// Busca todos os animes paginados, dado filtros específicos
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType<IPagedEnumerable<SimpleAnimeDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [Authorize(Policy = Policies.Animes.CAN_GET_ALL)]
        public async Task<IActionResult> GetAllPaged([FromQuery] Pagination<AnimeFilter> pagination)
        {
            IPagedEnumerable<SimpleAnimeDTO> pagedResult = await _applicationService.GetAllPagedAsync(pagination, HttpContext.RequestAborted);
            return await Ok(pagedResult, pagination, Messages.Response.Anime.ANIMES_FOUND, Messages.Response.Anime.ANIMES_NOT_FOUND);
        }

        /// <summary>
        /// Busca um anime pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType<DetailedAnimeDTO>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [Authorize(Policy = Policies.Animes.CAN_GET_DETAIL)]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            DetailedAnimeDTO anime = await _applicationService.GetByIdAsync(id, HttpContext.Request.HttpContext.RequestAborted);
            return await Ok(anime, Messages.Response.Anime.ANIME_FOUND, Messages.Response.Anime.ANIME_NOT_FOUND);
        }

        [HttpPost()]
        [ProducesResponseType<DetailedAnimeDTO>((int)HttpStatusCode.Created)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<NotificationResponse>((int)HttpStatusCode.BadRequest)]
        [Authorize(Policy = Policies.Animes.CAN_CREATE)]
        public async Task<IActionResult> CreateAnime([FromForm] AnimeCreateRequest request)
        {
            DetailedAnimeDTO detailedAnimeDTO = await _applicationService.CreateAnimeAsync(request, HttpContext.RequestAborted);
            return await Ok(detailedAnimeDTO, Messages.Response.Anime.ANIME_CREATED);
        }
    }
}
