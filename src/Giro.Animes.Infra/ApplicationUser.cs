using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Giro.Animes.Infra
{
    public class ApplicationUser(IHttpContextAccessor context) : IApplicationUser
    {
        private static UserRole GetUserRole(string role)
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

        public long Id { get; private set; } = long.Parse(context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Sid)).Select(cl => cl.Value).FirstOrDefault() ?? "0");
        public string Nome { get; private set; } = context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Name)).Select(cl => cl.Value).FirstOrDefault() ?? "Guest";
        public string Email { get; private set; } = context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Email)).Select(cl => cl.Value).FirstOrDefault() ?? "";
        public UserRole Role { get; private set; } = GetUserRole(context.HttpContext.User.Claims.Where(cl => cl.Type.Equals(ClaimTypes.Role)).Select(cl => cl.Value).FirstOrDefault() ?? "");
        public string[] Language { get; private set; } = context.HttpContext?.Request.Headers["Accept-Language"].FirstOrDefault()?.Split(',', StringSplitOptions.TrimEntries) ?? ["en-US"];
    }
}
