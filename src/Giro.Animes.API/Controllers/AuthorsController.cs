using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Giro.Animes.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Giro.Animes.API.Controllers
{
    public class AuthorsController(IAuthorService applicationService) : GiroAnimesBaseController<IAuthorService>(applicationService)
    {
        [HttpGet("{id}")]
        public async Task<DetailResponse<AuthorDTO>> GetAuthorById([FromRoute] long id)
        {
            AuthorDTO authorDTO = await _applicationService.GetAuthorByIdAsync(id);
            return await Ok(authorDTO);
        }

        [HttpGet()]
        public async Task<ListPagedResponse<AuthorDTO>> GetAll([FromQuery] Pagination param)
        {
            IEnumerable<AuthorDTO> authors = await _applicationService.GetAllAuthorsPagedAsync(param);
            return await Ok(authors, param);   
        }
    }
}
