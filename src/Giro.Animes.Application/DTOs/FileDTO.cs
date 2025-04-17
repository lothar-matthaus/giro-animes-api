using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    public class FileDTO
    {
        public string FileName { get; private set; }
        public byte[] File { get; private set; }
        public string ContentType { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante que a classe só pode ser instanciada através do método Create.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="file"></param>
        /// <param name="contenType"></param>
        private FileDTO(string fileName, byte[] file, string contenType)
        {
            FileName = fileName;
            File = file;
            ContentType = contenType;
        }

        /// <summary>
        /// Método estático para criar uma instância de FileDTO. Garante que a classe só pode ser instanciada através deste método.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="file"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static FileDTO Create(string fileName, byte[] file, string contentType)
        {
            return new FileDTO(fileName, file, contentType);
        }
    }
}
