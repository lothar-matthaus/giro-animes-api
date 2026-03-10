using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Interfaces.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Giro.Animes.Shared.Filters
{
    public class SaveChangesResultFilter : IAsyncActionFilter
    {
        private readonly GiroAnimesDbContext _dbContext;
        private readonly INotificationService _notificationService;

        public SaveChangesResultFilter(GiroAnimesDbContext dbContext, INotificationService notificationService)
        {
            _dbContext = dbContext;
            _notificationService = notificationService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executed = await next();

            bool hasException = executed.Exception != null && !executed.ExceptionHandled;

            if (!hasException && !_notificationService.HasNotifications() && _dbContext.ChangeTracker.HasChanges())
            {
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
