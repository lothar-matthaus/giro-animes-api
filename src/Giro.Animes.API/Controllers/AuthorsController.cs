using Giro.Animes.API.Controllers.Base;
using Giro.Animes.Application.DTOs;
using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Giro.Animes.API.Controllers
{
    public class AuthorsController(IAuthorService applicationService) : GiroAnimesBaseController<IAuthorService>(applicationService)
    {
        [HttpGet("{id}")]
        public async Task<DetailResponse<AuthorDTO>> GetAuthorById([FromRoute] long id)
        {
            AuthorDTO data = await _applicationService.GetAuthorByIdAsync(id);
            return DetailResponse<AuthorDTO>.Create(data, true, System.Net.HttpStatusCode.OK, "Autor encontrado com sucesso");
        }

        [HttpGet()]
        public async Task<ListPagedResponse<AuthorDTO>> GetAll([FromQuery] Pagination param)
        {
            IEnumerable<AuthorDTO> list = await _applicationService.GetAllAuthorsPagedAsync(param);
            return ListPagedResponse<AuthorDTO>.Create(list, param, true, System.Net.HttpStatusCode.OK, "Lista encontrada com sucesso");
        }
    }
}
