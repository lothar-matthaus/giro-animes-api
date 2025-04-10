using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Giro.Animes.Infra
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly IHttpContextAccessor _context;
        public ApplicationUser(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor;

            Id = long.Parse(_context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Sid)).Select(cl => cl.Value).FirstOrDefault() ?? "0");
            Nome = _context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Name)).Select(cl => cl.Value).FirstOrDefault() ?? "Guest";
            Email = _context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Email)).Select(cl => cl.Value).FirstOrDefault() ?? "";
            Role = GetUserRole(_context.HttpContext.User.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.Role)?.Value);
        }

        private UserRole GetUserRole(string role)
        {
            return Enum.TryParse<UserRole>(role, out var userRole) ? userRole : UserRole.Guest;
        }

        public long Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public UserRole Role { get; }
    }
}
