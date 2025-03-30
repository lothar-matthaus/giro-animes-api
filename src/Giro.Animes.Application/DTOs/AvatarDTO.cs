namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Avatar.
    /// </summary>
    public class AvatarDTO : MediaDTO
    {
        /// <summary>
        /// Obtém ou define o identificador do usuário ao qual o avatar pertence.
        /// </summary>
        public long AccountId { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="id">Identificador do avatar.</param>
        /// <param name="creationDate">Data de criação do avatar.</param>
        /// <param name="updateDate">Data de atualização do avatar.</param>
        /// <param name="accountId">Identificador do usuário ao qual o avatar pertence.</param>
        /// <param name="url">URL do avatar.</param>
        /// <param name="fileName">Nome do arquivo do avatar.</param>
        /// <param name="extension">Extensão do arquivo do avatar.</param>
        private AvatarDTO(long? id, DateTime creationDate, DateTime updateDate, long accountId, string url, string fileName, string extension) :
            base(id, creationDate, updateDate, url, fileName, extension)
        {
            AccountId = accountId;
        }

        /// <summary>
        /// Cria uma nova instância de AvatarDTO.
        /// </summary>
        /// <param name="id">Identificador do avatar.</param>
        /// <param name="creationDate">Data de criação do avatar.</param>
        /// <param name="updateDate">Data de atualização do avatar.</param>
        /// <param name="accountId">Identificador do usuário ao qual o avatar pertence.</param>
        /// <param name="url">URL do avatar.</param>
        /// <param name="fileName">Nome do arquivo do avatar.</param>
        /// <param name="extension">Extensão do arquivo do avatar.</param>
        /// <returns>Uma nova instância de AvatarDTO.</returns>
        public static AvatarDTO Create(long? id, DateTime creationDate, DateTime updateDate, long accountId, string url, string fileName, string extension)
            => new AvatarDTO(id, creationDate, updateDate, accountId, url, fileName, extension);
    }
}