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
        /// Construtor protegido para garantir que o objeto só pode ser criado através dos seus derivados.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        protected MediaDTO(long? id, string url, DateTime creationDate, DateTime updateDate) :
            base(id, creationDate, updateDate)
        {
            Url = url;
        }
    }
}
