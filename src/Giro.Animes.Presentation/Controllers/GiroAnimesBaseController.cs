using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize()]
    public abstract class GiroAnimesBaseController<TApplicationService> : ControllerBase where TApplicationService : IApplicationServiceBase
    {
        protected readonly TApplicationService _applicationService;

        public GiroAnimesBaseController(TApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<IActionResult> Ok<TData>(TData data) where TData : BaseDTO
        {
            if (data is null)
            {
                DetailResponse<TData> result = DetailResponse<TData>.Create(true, HttpStatusCode.OK, "Nenhum resultado encontrado");
                return StatusCode((int)HttpStatusCode.OK, result);
            }

            DetailResponse<TData> response = DetailResponse<TData>.Create(data, true, HttpStatusCode.OK, "Consulta realizada com sucesso");
            return await Task.Run(() =>
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            });
        }

        public async Task<IActionResult> Ok<TData>(IPagedEnumerable<TData> data, Pagination pagination) where TData : BaseDTO
        {
            if (data is null)
            {
                ListPagedResponse<TData> result = ListPagedResponse<TData>.Create(HttpStatusCode.OK, "A consulta não retornou resultados.", pagination.Page, pagination.RowsPerPage, data?.TotalCount ?? 0);
                return StatusCode((int)HttpStatusCode.OK, result);
            }

            ListPagedResponse<TData> response = ListPagedResponse<TData>.Create(data, true, HttpStatusCode.OK, "Consulta realizada com sucesso", pagination.Page, pagination.RowsPerPage, data.TotalCount);

            return await Task.Run(() =>
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            });
        }
    }
}
