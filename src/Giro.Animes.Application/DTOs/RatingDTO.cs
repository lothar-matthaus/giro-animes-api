using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    public class RatingDTO : BaseDTO
    {
        public double Rate { get; private set; }
        public long UserId { get; private set; }

        /// <summary>
        /// Construtor privado de RatingDTO que inicializa as propriedades da classe com os valores informados. Garanta a constru~ção no método Create.
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="deletionDate"></param>
        private RatingDTO(double rate, long userId, long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) : base(id, creationDate, updateDate, deletionDate)
        {
            UserId = userId;
            Rate = rate;
        }

        /// <summary>
        /// Cria uma instância de RatingDTO com os parâmetros informados e retorna a instância criada.
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="deletionDate"></param>
        /// <returns></returns>
        public static RatingDTO Create(double rate, long userId, long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, long animeId)
        {
            return new RatingDTO(rate, userId, id, creationDate, updateDate, deletionDate);
        }
    }
}
