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
            InterfaceLanguage = Role == UserRole.Guest ? _context.HttpContext.Request.Headers["Interface-Language"].ToString() : string.Empty;
            AudioAnimeLanguages = Role == UserRole.Guest ? _context.HttpContext.Request.Headers["Audio-Anime-Languages"].ToString().Split(',').Select(x => x.Trim()).ToArray() : new string[0];
            SubtitleAnimeLanguages = Role == UserRole.Guest ? _context.HttpContext.Request.Headers["Subtitle-Anime-Languages"].ToString().Split(',').Select(x => x.Trim()).ToArray() : new string[0];
        }

        private UserRole GetUserRole(string role)
        {
            return Enum.TryParse<UserRole>(role, out var userRole) ? userRole : UserRole.Guest;
        }

        public long Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string InterfaceLanguage { get; }
        public string[] AudioAnimeLanguages { get; }
        public string[] SubtitleAnimeLanguages { get; }
        public UserRole Role { get; }
    }
}
