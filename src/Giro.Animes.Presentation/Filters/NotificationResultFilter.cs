using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Responses;
using Giro.Animes.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Shared.Filters
{
    using Giro.Animes.Application.Responses;
    using Giro.Animes.Domain.ValueObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    public class NotificationResultFilter : IAsyncResultFilter
    {
        private readonly INotificationService _notificationService;

        public NotificationResultFilter(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationService.HasNotifications() && !context.HttpContext.Response.HasStarted)
            {
                IEnumerable<Notification> notifications = await _notificationService.GetNotifications();
                var errorResponse = NotificationResponse.Create(
                    notifications,
                    false,
                    HttpStatusCode.BadRequest,
                    "Houve um ou mais erros de validação"
                );

                context.Result = new ObjectResult(errorResponse)
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
            await next();
        }
    }

}
