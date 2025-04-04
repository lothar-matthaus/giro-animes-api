using Giro.Animes.Application.Custom;
using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.Interfaces.Enumerations;
using Giro.Animes.Application.Responses;
using Giro.Animes.Application.Responses.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Shared.Filters
{
    public class StandardApiResponseFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // No action needed before the action executes
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                if (objectResult.Value is IPagedEnumerable<BaseDTO> list)
                {
                    context.Result = new ObjectResult(ListPagedResponse<BaseDTO>
                        .Create(list, true, HttpStatusCode.OK, "A consulta retornou resultados.", list.Page, list.RowsPerPage, list.TotalCount));
                }

                else if (objectResult.Value is BaseDTO dto)
                {
                    context.Result = new ObjectResult(DetailResponse<BaseDTO>.Create(dto, true, HttpStatusCode.OK, "A consulta retornou os detalhes."));
                }
                else
                {
                    context.Result = new ObjectResult(null);
                }
            }
        }
    }
}
