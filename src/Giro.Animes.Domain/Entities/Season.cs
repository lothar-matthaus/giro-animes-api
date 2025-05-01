using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Domain.Entities
{
    public class Season : EntityBase
    {
        /// <summary>
        /// Número da temporada.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Sinopses da temporada.
        /// </summary>
        public ICollection<SeasonSinopse> Sinopses { get; private set; }

        /// <summary>
        /// Episódios da temporada.
        /// </summary>
        public ICollection<Episode> Episodes { get; private set; }

        /// <summary>
        /// Data de lançamento da temporada.
        /// </summary>
        public DateTime ReleaseDate { get; private set; }

        /// <summary>
        /// Status da temporada.
        /// </summary>
        public SeasonStatus Status { get; private set; }

        /// <summary>
        /// Identificador do anime ao qual a temporada pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Propriedade de navegação para o anime ao qual a temporada pertence.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Construtor padrão para garantir a construção do objeto pelo EntityFramework.
        /// </summary>
        public Season()
        {
            
        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sinopses"></param>
        /// <param name="episodes"></param>
        /// <param name="releaseDate"></param>
        /// <param name="status"></param>
        /// <param name="animeId"></param>
        /// <param name="anime"></param>
        private Season(int number, ICollection<SeasonSinopse> sinopses, ICollection<Episode> episodes, DateTime releaseDate, SeasonStatus status, long animeId, Anime anime)
        {
            Number = number;
            Sinopses = sinopses;
            Episodes = episodes;
            ReleaseDate = releaseDate;
            Status = status;
            AnimeId = animeId;
            Anime = anime;
        }

        /// <summary>
        /// Método estático para criar um objeto Season com validações de propriedades e retorno do objeto.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sinopses"></param>
        /// <param name="episodes"></param>
        /// <param name="releaseDate"></param>
        /// <param name="status"></param>
        /// <param name="animeId"></param>
        /// <param name="anime"></param>
        /// <returns></returns>
        public static Season Create(int number, ICollection<SeasonSinopse> sinopses, ICollection<Episode> episodes, DateTime releaseDate, SeasonStatus status, long animeId, Anime anime)
        {
            return new Season(number, sinopses, episodes, releaseDate, status, animeId, anime);
        }
    }
}
