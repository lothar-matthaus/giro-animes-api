﻿using Giro.Animes.Application.DTOs;
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
        [ProducesResponseType<DetailResponse<UserDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<DetailResponse<UserDTO>>((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType<ErrorResponse>((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAuthorById([FromRoute] long id)
        {
            AuthorDTO authorDTO = await _applicationService.GetAuthorByIdAsync(id);
            DetailResponse<AuthorDTO> response = DetailResponse<AuthorDTO>.Create(authorDTO, true, HttpStatusCode.OK, "O autor foi encontrado com sucesso");
            return StatusCode((int)HttpStatusCode.OK, response);
        }


        [HttpGet()]
        [ProducesResponseType<DetailResponse<AuthorDTO>>((int)HttpStatusCode.OK)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType<ApiResponse>((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllPaged([FromQuery] Pagination param)
        {
            IPagedEnumerable<AuthorDTO> authors = await _applicationService.GetAllAuthorsPagedAsync(param);
            return await Ok(authors, param);
        }
    }
}
