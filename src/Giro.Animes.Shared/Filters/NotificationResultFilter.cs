using Giro.Animes.Application.Interfaces.Services;

namespace Giro.Animes.Shared.Filters
{
    using Giro.Animes.Application.Responses;
    using Giro.Animes.Domain.ValueObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
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
            IEnumerable<Notification> notifications = await _notificationService.GetNotifications();

            if (notifications.Any() && !context.HttpContext.Response.HasStarted)
            {
                var errorResponse = NotificationResponse.Create(
                    notifications,
                    false,
                    HttpStatusCode.BadRequest,
                    "Houve um ou mais erros de validação"
                );

                context.Result = new ObjectResult(errorResponse)
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ContentTypes = { "application/json" },
                    DeclaredType = typeof(NotificationResponse)
                };
            }
            await next();
        }
    }

}
