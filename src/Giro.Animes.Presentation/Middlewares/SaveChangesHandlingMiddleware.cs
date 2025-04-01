using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Application.Responses;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace Giro.Animes.Shared.Middlewares
{
    public class SaveChangesHandlingMiddleware : IMiddleware
    {
        private readonly INotificationService _notificationService;
        private readonly DbContext _dbContext;

        public SaveChangesHandlingMiddleware(INotificationService notificationService, GiroAnimesWriteDbContext dbContext)
        {
            _notificationService = notificationService;
            _dbContext = dbContext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            if (_dbContext.ChangeTracker.HasChanges() && !_notificationService.HasNotifications())
            {
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                _dbContext.ChangeTracker.Clear();

                if (!context.Response.HasStarted)
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
}
