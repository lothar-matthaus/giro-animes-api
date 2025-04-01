using Microsoft.AspNetCore.Http;

namespace Giro.Animes.Application.Extensions
{
    public static class FileStorageExtensions
    {
        public static byte[] ReadAsBytes(this IFormFile file)
        {
            if (file == null) return null;

            using (var stream = file.OpenReadStream())
            {
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                return bytes;
            }
        }
    }
}
