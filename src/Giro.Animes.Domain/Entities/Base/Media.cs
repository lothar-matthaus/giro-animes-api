using Giro.Animes.Domain.Constants;
using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Giro.Animes.Domain.Entities
{
    public abstract class Media : EntityBase
    {
        /// <summary>
        /// Url da mídia
        /// </summary>
        public string Url { get; private set; }
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
                    isInvalidIf: string.IsNullOrWhiteSpace(value),
                    ifInvalid: () => Notification.Create(GetType().Name, "FileName", string.Format(Message.Validation.General.REQUIRED, "FileName")),
                    ifValid: () => _fileName = value
                );

                Validate(
                   isInvalidIf: Regex.IsMatch(Patterns.Cover.FILE_NAME_LENGTH, value),
                   ifInvalid: () => Notification.Create(GetType().Name, "FileName", Message.Validation.Cover.INVALID_FILE_NAME_LENGHT),
                   ifValid: () => _fileName = value
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
                    isInvalidIf: string.IsNullOrWhiteSpace(value),
                    ifInvalid: () => Notification.Create(GetType().Name, "Extension", string.Format(Message.Validation.General.REQUIRED, "Extension")),
                    ifValid: () => _extension = value
                );

                Validate(
                    isInvalidIf: Regex.IsMatch(Patterns.Cover.ALLOWED_EXTENSIONS, value),
                    ifInvalid: () => Notification.Create(GetType().Name, "Extension", Message.Validation.Cover.INVALID_EXTENSION),
                    ifValid: () => _extension = value
                );
            }
        }
        #endregion

        /// <summary>
        /// Identificador do anime a qual o cover pertence
        /// </summary>

        public byte[] File { get; set; }

        public Media() { }

        /// <summary>
        /// Construtor com parâmetros. Garanta a constução do objeto no método Create.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="extension"></param>
        protected Media(string extension, byte[] file = null)
        {
            FileName = Guid.NewGuid().ToString();
            Extension = extension.Split("/")[1];
            File = file;
        }

        /// <summary>
        /// Define uma nova url para a mídia
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Media SetUrl(string url)
        {
            Url = url;
            return this;
        }
    }
}
