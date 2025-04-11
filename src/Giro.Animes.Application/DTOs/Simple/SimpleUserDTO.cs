using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleUserDTO : BaseSimpleDTO
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
        /// Plano do usuário.
        /// </summary>
        public EnumDTO<UserPlan> Plan { get; private set; }

        /// <summary>
        /// Identificador da conta do usuário.
        /// </summary>
        public long AccountId { get; private set; }

        /// <summary>
        /// Avaliações feitas pelo usuário.
        /// </summary>
        public IEnumerable<SimpleRatingDTO> Ratings { get; private set; }

        /// <summary>
        /// Lista de animes do usuário.
        /// </summary>
        public IEnumerable<SimpleAnimeDTO> Watchlist { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="plan"></param>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
        /// <param name="ratings"></param>
        /// <param name="watchlist"></param>
        private SimpleUserDTO(
            string name, EnumDTO<UserRole> role, EnumDTO<UserPlan> plan, long id, long accountId, IEnumerable<SimpleRatingDTO> ratings, IEnumerable<SimpleAnimeDTO> watchlist) :
            base(id)
        {
            Name = name;
            Role = role;
            Plan = plan;
            AccountId = accountId;
            Ratings = ratings;
            Watchlist = watchlist;
        }

        /// <summary>
        /// Método fábrica para criar um novo objeto SimpleUserDTO.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="plan"></param>
        /// <param name="id"></param>
        /// <param name="accountId"></param>
        /// <param name="ratings"></param>
        /// <param name="watchlist"></param>
        /// <returns></returns>
        public static SimpleUserDTO Create(string name, EnumDTO<UserRole> role, EnumDTO<UserPlan> plan, long id, long accountId, IEnumerable<SimpleRatingDTO> ratings, IEnumerable<SimpleAnimeDTO> watchlist)
        {
            return new SimpleUserDTO(name, role, plan, id, accountId, ratings, watchlist);
        }
    }
}
