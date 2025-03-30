using Giro.Animes.Application.Responses;
using Giro.Animes.Domain.Interfaces.Services;
using Giro.Animes.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Giro.Animes.Shared.Middlewares
{
    public class NotificationHandlingMiddleware : IMiddleware
    {
        private readonly INotificationService _notificationService;

        public NotificationHandlingMiddleware(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            if(await _notificationService.HasNotifications())
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                IEnumerable<Notification> notifications = await _notificationService.GetNotifications();

                NotificationResponse errorResponse = NotificationResponse.Create(notifications, false, HttpStatusCode.BadRequest, "Houve um ou mais erros de validação");

                var json = JsonConvert.SerializeObject(errorResponse);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
