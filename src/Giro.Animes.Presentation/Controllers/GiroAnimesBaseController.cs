using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Interfaces.Services.Base;
using Giro.Animes.Application.Requests;
using Giro.Animes.Application.Responses;
using Giro.Animes.Application.Responses.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Giro.Animes.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GiroAnimesBaseController<TApplicationService> : ControllerBase where TApplicationService : IApplicationServiceBase
    {
        protected readonly TApplicationService _applicationService;

        public GiroAnimesBaseController(TApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<DetailResponse<TDto>> Ok<TDto>(TDto data) where TDto : BaseDTO
        {
            return await Task.Run(() =>
            {
                if (data == null)
                    return DetailResponse<TDto>.Create(true, HttpStatusCode.OK, "Não foi encontrado nenhum resultado.");

                DetailResponse<TDto> response = DetailResponse<TDto>.Create(data, true, HttpStatusCode.OK, "O recurso foi encontrado com sucesso.");
                return response;
            });
        }

        public async Task<ListPagedResponse<TDto>> Ok<TDto>(IEnumerable<TDto> items, Pagination pagination)
            where TDto : BaseDTO
        {
            return await Task.Run(() =>
            {
                if (items == null || !items.Any())
                    return ListPagedResponse<TDto>.Create(pagination, HttpStatusCode.OK, "A consulta não encontrou nenhum resultado.");

                ListPagedResponse<TDto> response = ListPagedResponse<TDto>.Create(items, pagination, true, HttpStatusCode.OK, "A consulta retornou uma lista de resultados.");

                return response;
            });
        }
    }
}
