using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleUserDTO
    {
        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Papel do usuário.
        /// </summary>
        public EnumDTO<UserRole> Role { get; set; }

        /// <summary>
        /// Identificador da conta do usuário.
        /// </summary>
        public long AccountId { get; private set; }

        /// <summary>
        /// Avaliações feitas pelo usuário.
        /// </summary>
        public IEnumerable<SimpleRatingDTO> Ratings { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SimpleAnimeDTO> Watchlist { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="accountId"></param>
        /// <param name="ratings"></param>
        /// <param name="watchlist"></param>
        private SimpleUserDTO(string name, EnumDTO<UserRole> role, long accountId, IEnumerable<SimpleRatingDTO> ratings, IEnumerable<SimpleAnimeDTO> watchlist)
        {
            Name = name;
            Role = role;
            AccountId = accountId;
            Ratings = ratings;
            Watchlist = watchlist;
        }

        /// <summary>
        /// Método fábrica para criar um novo objeto SimpleUserDTO.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="accountId"></param>
        /// <param name="ratings"></param>
        /// <param name="watchlist"></param>
        /// <returns></returns>
        public static SimpleUserDTO Create(string name, EnumDTO<UserRole> role, long accountId, IEnumerable<SimpleRatingDTO> ratings, IEnumerable<SimpleAnimeDTO> watchlist)
        {
            return new SimpleUserDTO(name, role, accountId, ratings, watchlist);
        }
    }
}
