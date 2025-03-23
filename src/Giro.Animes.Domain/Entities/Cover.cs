using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class Cover : EntityBase
    {
        public string Url { get; set; }

        /// <summary>
        /// Nome do arquivo da capa
        /// </summary>
        #region FileName
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "FileName", string.Format(Message.Validation.General.REQUIRED, "FileName")),
                    ifValid: () => _extension = value
                );

                Validate(
                   isInvalidIf: !Regex.IsMatch(Patterns.Cover.FILE_NAME_LENGTH, value),
                   ifInvalid: () => ValidationError.Create(GetType().Name, "FileName", Message.Validation.Cover.INVALID_FILE_NAME_LENGHT),
                   ifValid: () => _extension = value
               );
            }
        }
        #endregion

        /// <summary>
        /// Extensão do arquivo da capa 
        /// </summary>
        #region Extension
        private string _extension;
        public string Extension
        {
            get { return _extension; }
            set
            {
                Validate(
                    isInvalidIf: string.IsNullOrEmpty(value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Extension", string.Format(Message.Validation.General.REQUIRED, "Extension")),
                    ifValid: () => _extension = value
                );

                Validate(
                    isInvalidIf: !Regex.IsMatch(Patterns.Cover.ALLOWED_EXTENSIONS, value),
                    ifInvalid: () => ValidationError.Create(GetType().Name, "Extension", Message.Validation.Cover.INVALID_EXTENSION),
                    ifValid: () => _extension = value
                );
            }
        }
        #endregion

        private Cover(string path, string fileName, string extension) : base(DateTime.Now)
        {
            Url = path;
            FileName = fileName;
            Extension = extension;
        }

        /// <summary>
        /// Cria uma nova capa de anime 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public static Cover Create(string path, string fileName, string extension) => new Cover(path, fileName, extension);
    }
}
