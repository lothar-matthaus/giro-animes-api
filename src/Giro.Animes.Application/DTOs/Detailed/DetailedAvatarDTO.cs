namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Avatar.
    /// </summary>
    public class DetailedAvatarDTO : MediaDTO
    {
        /// <summary>
        /// Obtém ou define o identificador do usuário ao qual o avatar pertence.
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="id">Identificador do avatar.</param>
        /// <param name="creationDate">Data de criação do avatar.</param>
        /// <param name="updateDate">Data de atualização do avatar.</param>
        /// <param name="userId">Identificador do usuário ao qual o avatar pertence.</param>
        /// <param name="url">URL do avatar.</param>
        /// <param name="fileName">Nome do arquivo do avatar.</param>
        /// <param name="extension">Extensão do arquivo do avatar.</param>
        private DetailedAvatarDTO(long? id, string url, long userId, DateTime creationDate, DateTime updateDate) :
            base(id, url, creationDate, updateDate)
        {
            UserId = userId;
        }

        /// <summary>
        /// Cria uma nova instância de AvatarDTO.
        /// </summary>
        /// <param name="id">Identificador do avatar.</param>
        /// <param name="creationDate">Data de criação do avatar.</param>
        /// <param name="updateDate">Data de atualização do avatar.</param>
        /// <param name="userId">Identificador do usuário ao qual o avatar pertence.</param>
        /// <param name="url">URL do avatar.</param>
        /// <param name="fileName">Nome do arquivo do avatar.</param>
        /// <param name="extension">Extensão do arquivo do avatar.</param>
        /// <returns>Uma nova instância de AvatarDTO.</returns>
        public static DetailedAvatarDTO Create(long? id, string url, long userId, DateTime creationDate, DateTime updateDate)
            => new DetailedAvatarDTO(id, url, userId, creationDate, updateDate);
    }
}