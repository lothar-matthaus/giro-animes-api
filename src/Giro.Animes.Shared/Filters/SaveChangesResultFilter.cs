using Giro.Animes.Application.Interfaces.Services;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Interfaces.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Giro.Animes.Shared.Filters
{
    public class SaveChangesResultFilter : IAsyncResultFilter
    {
        private readonly GiroAnimesDbContext _dbContext;
        private readonly INotificationService _notificationService;

        public SaveChangesResultFilter(GiroAnimesDbContext dbContext, INotificationService notificationService)
        {
            _dbContext = dbContext;
            _notificationService = notificationService;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_dbContext.ChangeTracker.HasChanges() && !_notificationService.HasNotifications())
            {
                _dbContext.SaveChanges();
            }

            await next();
        }
    }
}
