using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Giro.Animes.Presentation.Controllers;
using Giro.Animes.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.API.Controllers
{
    public class AuthorsController(IAuthorService applicationService) : GiroAnimesBaseController<IAuthorService>(applicationService)
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] long id)
        {
            AuthorDTO authorDTO = await _applicationService.GetAuthorByIdAsync(id);
            return Ok(authorDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllPaged([FromQuery] Pagination param)
        {
            IPagedEnumerable<AuthorDTO> authors = await _applicationService.GetAllAuthorsPagedAsync(param);
            return Ok(authors);   
        }
    }
}
