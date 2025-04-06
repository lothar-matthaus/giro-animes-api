using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Giro.Animes.Infra
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly IHttpContextAccessor _context;
        public ApplicationUser(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        }

        public long Id => long.Parse(_context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Sid)).Select(cl => cl.Value).FirstOrDefault() ?? "0");
        public string Nome => _context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Name)).Select(cl => cl.Value).FirstOrDefault() ?? "Guest";
        public string Email => _context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Email)).Select(cl => cl.Value).FirstOrDefault() ?? "";
        public UserRole Role => Enum.Parse<UserRole>(_context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Role, StringComparison.InvariantCultureIgnoreCase)).Select(cl => cl.Value).FirstOrDefault());
        public string[] Languages => _context.HttpContext?.Request.Headers["Accept-Language"].FirstOrDefault()?.Split(',', StringSplitOptions.TrimEntries) ?? ["en-US"];
    }
}
