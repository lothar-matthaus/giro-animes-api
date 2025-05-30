﻿using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade User.
    /// </summary>
    public class DetailedUserDTO : BaseDTO
    {
        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Identificador da conta do usuário.
        /// </summary>
        public DetailedAccountDTO Account { get; private set; }

        /// <summary>
        /// Papel do usuário.
        /// </summary>
        public EnumDTO<UserRole> Role { get; private set; }

        /// <summary>
        /// Avaliações feitas pelo usuário.
        /// </summary>
        public IReadOnlyCollection<DetailedRatingDTO> Ratings { get; private set; }

        /// <summary>
        /// Lista de animes favoritos do usuário.
        /// </summary>
        public IReadOnlyCollection<DetailedAnimeDTO> Watchlist { get; private set; }


        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <param name="creationDate">Data de criação do usuário.</param>
        /// <param name="updateDate">Data de atualização do usuário.</param>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="role">Papel do usuário.</param>
        /// <param name="ratings">Avaliações feitas pelo usuário.</param>
        /// <param name="account">Conta do usuário.</param>
        private DetailedUserDTO(long? id, DetailedAccountDTO account, DateTime creationDate, DateTime updateDate, string name, EnumDTO<UserRole> role, IReadOnlyCollection<DetailedRatingDTO> ratings, IReadOnlyCollection<DetailedAnimeDTO> watchlist) :
            base(id, creationDate, updateDate)
        {
            Name = name;
            Role = role;
            Ratings = ratings;
            Account = account;
            Watchlist = watchlist;
        }

        /// <summary>
        /// Cria uma nova instância de UserDTO.
        /// </summary>
        /// <param name="id">Identificador do usuário.</param>
        /// <param name="creationDate">Data de criação do usuário.</param>
        /// <param name="updateDate">Data de atualização do usuário.</param>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="role">Papel do usuário.</param>
        /// <param name="ratings">Avaliações feitas pelo usuário.</param>
        /// <param name="account">Conta do usuário.</param>
        /// <returns>Uma nova instância de UserDTO.</returns>
        public static DetailedUserDTO Create(long? id, DetailedAccountDTO account, DateTime creationDate, DateTime updateDate, string name, EnumDTO<UserRole> role, IReadOnlyCollection<DetailedRatingDTO> ratings, IReadOnlyCollection<DetailedAnimeDTO> watchlist)
            => new DetailedUserDTO(id, account, creationDate, updateDate, name, role, ratings, watchlist);
    }
}
