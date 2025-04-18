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
        private readonly IFileMediaStorageService _fileMediaStorageService;

        public SaveChangesResultFilter(GiroAnimesDbContext dbContext, INotificationService notificationService, IFileMediaStorageService fileMediaStorageService)
        {
            _dbContext = dbContext;
            _notificationService = notificationService;
            _fileMediaStorageService = fileMediaStorageService;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_dbContext.ChangeTracker.HasChanges() && !_notificationService.HasNotifications())
            {
                _dbContext.SaveChanges();
            }
            else if (_notificationService.HasNotifications())
            {
                await _fileMediaStorageService.Rollback();
            }

            await next();
        }
    }
}
