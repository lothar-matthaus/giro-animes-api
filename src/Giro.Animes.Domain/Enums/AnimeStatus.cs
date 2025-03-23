using Giro.Animes.Domain.Enums.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Enums
{
    public class AnimeStatus : Enumeration
    {
        /// <summary>
        /// Indica que o anime foi concluído e não terá mais episódios
        /// </summary>
        public static readonly AnimeStatus Completed = new AnimeStatus(1, "Completed");
        /// <summary>
        /// Indica que o anime está em andamento e terá mais episódios no futuro
        /// </summary>
        public static readonly AnimeStatus OnGoing = new AnimeStatus(2, "OnGoing");
        /// <summary>
        /// Indica que o anime foi cancelado e não terá mais episódios no futuro
        /// </summary>
        public static readonly AnimeStatus Canceled = new AnimeStatus(3, "Canceled");
        /// <summary>
        /// Indica que o anime está em hiato e não terá episódios por um tempo indeterminado
        /// </summary>
        public static readonly AnimeStatus Hiatus = new AnimeStatus(4, "Hiatus");

        /// <summary>
        /// Construtor privado para garantir a criação das instâncias
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private AnimeStatus(int id, string name) : base(id, name)
        {
        }
    }
}
