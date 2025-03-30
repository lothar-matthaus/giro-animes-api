using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Extensions
{
    public static class FileStorageExtensions
    {
        public static byte[] ReadAsBytes(this IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                return bytes;
            }
        }
    }
}
