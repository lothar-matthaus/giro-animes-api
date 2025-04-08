using Giro.Animes.Application.Constants;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Giro.Animes.Application.Responses.Base;
using Giro.Animes.Presentation.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.API.Controllers
{
    public class AuthorsController(IAuthorService applicationService) : GiroAnimesBaseController<IAuthorService>(applicationService)
    {
        [HttpGet("{id}")]
        [Authorize()]
        [ProducesResponseType<DetailResponse<AuthorDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAuthorById([FromRoute] long id)
        {
            AuthorDTO authorDTO = await _applicationService.GetAuthorByIdAsync(id);
            return await Ok(authorDTO, Messages.Response.Author.AUTHOR_FOUND, Messages.Response.Author.AUTHOR_NOT_FOUND);
        }


        [HttpGet()]
        [Authorize]
        [ProducesResponseType<DetailResponse<AuthorDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllPaged([FromQuery] Pagination param)
        {
            IPagedEnumerable<AuthorDTO> authors = await _applicationService.GetAllAuthorsPagedAsync(param);
            return await Ok(authors, param, Messages.Response.Author.AUTHORS_FOUND, Messages.Response.Author.AUTHORS_NOT_FOUND);
        }
    }
}
