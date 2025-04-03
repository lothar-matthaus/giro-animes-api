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
        private readonly DbContext _dbContext;

        public SaveChangesHandlingMiddleware(GiroAnimesWriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

                if (_dbContext.ChangeTracker.HasChanges())
                {
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
