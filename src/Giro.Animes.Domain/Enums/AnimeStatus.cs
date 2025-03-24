using Giro.Animes.Domain.Enums.Base;

namespace Giro.Animes.Domain.Enums
{
    public class AnimeStatus : Enumeration<AnimeStatus, int>
    {
        /// <summary>
        /// Indica que o anime foi concluído e não terá mais episódios
        /// </summary>
        public static readonly AnimeStatus Completed = new AnimeStatus(0, "Completed");
        /// <summary>
        /// Indica que o anime está em andamento e terá mais episódios no futuro
        /// </summary>
        public static readonly AnimeStatus OnGoing = new AnimeStatus(1, "OnGoing");
        /// <summary>
        /// Indica que o anime foi cancelado e não terá mais episódios no futuro
        /// </summary>
        public static readonly AnimeStatus Canceled = new AnimeStatus(2, "Canceled");
        /// <summary>
        /// Indica que o anime está em hiato e não terá episódios por um tempo indeterminado
        /// </summary>
        public static readonly AnimeStatus Hiatus = new AnimeStatus(3, "Hiatus");

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
