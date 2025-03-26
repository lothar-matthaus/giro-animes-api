using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Giro.Animes.Domain.Entities
{
    /// <summary>
    /// Representa a avaliação de um anime por um usuário.
    /// </summary>
    public class Rating : EntityBase
    {
        /// <summary>
        /// Nota dada pelo usuário.
        /// </summary>
        public float Rate { get; private set; }

        /// <summary>
        /// Identificador do usuário que fez a avaliação.
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Identificador do anime avaliado.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Usuário que fez a avaliação.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Anime avaliado.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public Rating() { }

        /// <summary>
        /// Construtor com parâmetros. Garanta a construção do objeto através do método Create
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="user"></param>
        /// <param name="anime"></param>
        public Rating(float rate, User user, Anime anime)
        {
            Rate = rate;
            User = user;
            Anime = anime;
        }

        /// <summary>
        /// Cria uma instância de Rating. Utilize este método para garantir a construção do objeto.
        /// </summary>
        /// <param name="rate">Nota dada pelo usuário.</param>
        /// <param name="userId">Identificador do usuário que fez a avaliação.</param>
        /// <param name="animeId">Identificador do anime avaliado.</param>
        /// <param name="user">Usuário que fez a avaliação.</param>
        /// <param name="anime">Anime avaliado.</param>
        /// <returns>Uma nova instância de Rating.</returns>
        public static Rating Create(float rate, User user, Anime anime) => new Rating(rate, user, anime);
    }
}
