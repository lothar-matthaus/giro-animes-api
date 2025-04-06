using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

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
        /// Papel do usuário.
        /// </summary>
        public EnumDTO<UserRole> Role { get; private set; }

        /// <summary>
        /// Avaliações feitas pelo usuário.
        /// </summary>
        public IEnumerable<RatingDTO> Ratings { get; private set; }

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
        private UserDTO(long? id, DateTime creationDate, DateTime updateDate, string name, EnumDTO<UserRole> role, IEnumerable<RatingDTO> ratings) :
            base(id, creationDate, updateDate)
        {
            Name = name;
            Role = role;
            Ratings = ratings;
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
        public static UserDTO Create(long? id, DateTime creationDate, DateTime updateDate, string name, EnumDTO<UserRole> role, IEnumerable<RatingDTO> ratings)
            => new UserDTO(id, creationDate, updateDate, name, role, ratings);
    }
}
