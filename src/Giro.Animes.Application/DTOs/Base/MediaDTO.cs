using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Media.
    /// </summary>
    public abstract class MediaDTO : BaseDTO
    {
        /// <summary>
        /// URL da mídia.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Nome do arquivo da mídia.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Extensão do arquivo da mídia.
        /// </summary>
        public string Extension { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="media">Instância da entidade Media.</param>
        protected MediaDTO(long? id, DateTime creationDate, DateTime updateDate, string url, string fileName, string extension) :
            base(id, creationDate, updateDate)
        {
            Url = url;
            FileName = fileName;
            Extension = extension;
        }
    }
}
