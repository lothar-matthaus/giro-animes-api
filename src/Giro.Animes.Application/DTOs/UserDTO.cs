using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade User.
    /// </summary>
    public class UserDTO : BaseDTO
    {
        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Status do usuário.
        /// </summary>
        public EnumDTO<int> Status { get; private set; }

        /// <summary>
        /// Papel do usuário.
        /// </summary>
        public EnumDTO<int> Role { get; private set; }

        /// <summary>
        /// Avaliações feitas pelo usuário.
        /// </summary>
        public IEnumerable<RatingDTO> Ratings { get; private set; }

        /// <summary>
        /// Conta do usuário.
        /// </summary>
        public AccountDTO Account { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <param name="creationDate">Data de criação do usuário.</param>
        /// <param name="updateDate">Data de atualização do usuário.</param>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="status">Status do usuário.</param>
        /// <param name="role">Papel do usuário.</param>
        /// <param name="ratings">Avaliações feitas pelo usuário.</param>
        /// <param name="account">Conta do usuário.</param>
        private UserDTO(long? id, DateTime creationDate, DateTime updateDate, string name, EnumDTO<int> status, EnumDTO<int> role, IEnumerable<RatingDTO> ratings, AccountDTO account) :
            base(id, creationDate, updateDate)
        {
            Name = name;
            Status = status;
            Role = role;
            Ratings = ratings;
            Account = account;
        }

        /// <summary>
        /// Cria uma nova instância de UserDTO.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <param name="creationDate">Data de criação do usuário.</param>
        /// <param name="updateDate">Data de atualização do usuário.</param>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="status">Status do usuário.</param>
        /// <param name="role">Papel do usuário.</param>
        /// <param name="ratings">Avaliações feitas pelo usuário.</param>
        /// <param name="account">Conta do usuário.</param>
        /// <returns>Uma nova instância de UserDTO.</returns>
        public static UserDTO Create(long? id, DateTime creationDate, DateTime updateDate, string name, EnumDTO<int> status, EnumDTO<int> role, IEnumerable<RatingDTO> ratings, AccountDTO account)
            => new UserDTO(id, creationDate, updateDate, name, status, role, ratings, account);
    }
}
