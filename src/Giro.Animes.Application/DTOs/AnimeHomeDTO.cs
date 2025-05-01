using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs
{
    public class AnimeHomeDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Anime em destaque.
        /// </summary>
        public SimpleAnimeDTO FeaturedAnime { get; private set; }

        /// <summary>
        /// Últimos animes atualizados.
        /// </summary>
        public IEnumerable<SimpleAnimeDTO> LastUpdated { get; private set; }

        /// <summary>
        /// Animes mais populares.
        /// </summary>
        public IEnumerable<SimpleAnimeDTO> MostPopular { get; private set; }

        /// <summary>
        /// Animes mais bem avaliados.
        /// </summary>
        public IEnumerable<SimpleAnimeDTO> MostRated { get; private set; }

        /// <summary>
        /// Animes populares da semana.
        /// </summary>
        public IEnumerable<SimpleAnimeDTO> PopularWeek { get; private set; }

        /// <summary>
        /// Animes mais assistidos.
        /// </summary>
        public IEnumerable<SimpleAnimeDTO> MostViewed { get; private set; }

        /// <summary>
        /// Construtor privado para garantir que a classe só pode ser instanciada através do método Create.
        /// </summary>
        /// <param name="featuredAnime"></param>
        /// <param name="lastUpdated"></param>
        /// <param name="mostPopular"></param>
        /// <param name="mostRated"></param>
        /// <param name="popularWeek"></param>
        /// <param name="mostViewed"></param>
        private AnimeHomeDTO(SimpleAnimeDTO featuredAnime, IEnumerable<SimpleAnimeDTO> lastUpdated, IEnumerable<SimpleAnimeDTO> mostPopular, IEnumerable<SimpleAnimeDTO> mostRated, IEnumerable<SimpleAnimeDTO> popularWeek, IEnumerable<SimpleAnimeDTO> mostViewed) :
            base(0)
        {
            FeaturedAnime = featuredAnime;
            LastUpdated = lastUpdated;
            MostPopular = mostPopular;
            MostRated = mostRated;
            PopularWeek = popularWeek;
            MostViewed = mostViewed;
        }

        /// <summary>
        /// Método estático para criar uma instância de AnimeHomeAgregateDTO.
        /// </summary>
        /// <param name="featuredAnime"></param>
        /// <param name="lastUpdated"></param>
        /// <param name="mostPopular"></param>
        /// <param name="mostRated"></param>
        /// <param name="popularWeek"></param>
        /// <param name="mostViewed"></param>
        /// <returns></returns>
        public static AnimeHomeDTO Create(SimpleAnimeDTO featuredAnime, IEnumerable<SimpleAnimeDTO> lastUpdated, IEnumerable<SimpleAnimeDTO> mostPopular, IEnumerable<SimpleAnimeDTO> mostRated, IEnumerable<SimpleAnimeDTO> popularWeek, IEnumerable<SimpleAnimeDTO> mostViewed)
        {
            return new AnimeHomeDTO(featuredAnime, lastUpdated, mostPopular, mostRated, popularWeek, mostViewed);
        }
    }
}
