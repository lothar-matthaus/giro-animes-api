using Giro.Animes.Infra.Data.Contexts;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Shared.Filters
{
    public class SaveChangesResultFilter : IAsyncResultFilter
    {
        private readonly GiroAnimesDbContext _dbContext;

        public SaveChangesResultFilter(GiroAnimesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                _dbContext.SaveChanges();
            }
            await next();
        }
    }
}
