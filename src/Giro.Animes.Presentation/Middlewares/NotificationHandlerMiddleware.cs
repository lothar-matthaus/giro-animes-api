using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Responses;
using Giro.Animes.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Giro.Animes.Shared.Middlewares
{
    public class NotificationHandlerMiddleware : IMiddleware
    {
        private readonly INotificationService _notificationService;

        public NotificationHandlerMiddleware(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

                if (_notificationService.HasNotifications())
                {
                    IEnumerable<Notification> notifications = await _notificationService.GetNotifications();
                    NotificationResponse errorResponse = NotificationResponse.Create(notifications, false, HttpStatusCode.BadRequest, "Houve um ou mais erros de validação");

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";

                    var json = JsonConvert.SerializeObject(errorResponse);
                    await context.Response.WriteAsync(json);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
