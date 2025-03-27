using Giro.Animes.Application.Interfaces;
using Giro.Animes.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Giro.Animes.Application
{
    public class ApplicationUser : IApplicationUser
    {
        private readonly HttpContext _context;

        public ApplicationUser(IHttpContextAccessor context)
        {
            Id = long.Parse(context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Sid)).Select(cl => cl.Value).FirstOrDefault() ?? "0");
            Nome = context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Name)).Select(cl => cl.Value).FirstOrDefault() ?? "Guest";
            Email = context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Email)).Select(cl => cl.Value).FirstOrDefault() ?? "";
            Role = GetUserRole(context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Role)).Select(cl => cl.Value).FirstOrDefault() ?? "");
        }

        private UserRole GetUserRole(string role)
        {
            return role switch
            {
                "Admin" => UserRole.Admin,
                "User" => UserRole.User,
                "Guest" => UserRole.Guest,
                "Moderator" => UserRole.Moderator,
                "Publisher" => UserRole.Publisher,
                _ => UserRole.Guest
            };
        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public UserRole Role { get; private set; }
    }
}
