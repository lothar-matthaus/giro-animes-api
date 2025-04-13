using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Giro.Animes.Domain.Common.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize()]
    public abstract class GiroAnimesBaseController<TApplicationService> : ControllerBase where TApplicationService : IApplicationServiceBase
    {
        protected readonly TApplicationService _applicationService;

        public GiroAnimesBaseController(TApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<IActionResult> Ok<TData>(TData data, string resultMessage, string emptyMessage) where TData : BaseSimpleDTO
        {
            if (data is null)
            {
                DetailResponse<TData> result = DetailResponse<TData>.Create(true, HttpStatusCode.OK, emptyMessage);
                return StatusCode((int)HttpStatusCode.OK, result);
            }

            DetailResponse<TData> response = DetailResponse<TData>.Create(data, true, HttpStatusCode.OK, resultMessage);
            return await Task.Run(() =>
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            });
        }

        public async Task<IActionResult> Ok<TData, TFilter>(IPagedEnumerable<TData> data, Pagination<TFilter> pagination, string resultMessage, string emptyMessage) where TData : BaseSimpleDTO where TFilter : BaseFilter
        {
            if (data is null || !data.Any())
            {
                ListPagedResponse<TData> result = ListPagedResponse<TData>.Create(HttpStatusCode.OK, emptyMessage, pagination.Page, pagination.RowsPerPage, data?.TotalCount ?? 0);
                return StatusCode((int)HttpStatusCode.OK, result);
            }

            ListPagedResponse<TData> response = ListPagedResponse<TData>.Create(data, true, HttpStatusCode.OK, resultMessage, pagination.Page, pagination.RowsPerPage, data.TotalCount);

            return await Task.Run(() =>
            {
                return StatusCode((int)HttpStatusCode.OK, response);
            });
        }
    }
}
