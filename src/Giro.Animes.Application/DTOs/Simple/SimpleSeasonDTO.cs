using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Enums;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleSeasonDTO : BaseSimpleDTO
    {
        /// <summary>
        /// Número da temporada.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Coleção de sinopses da temporada.
        /// </summary>
        public IEnumerable<SimpleSeasonSinopseDTO> SinopseIds { get; set; }

        /// <summary>
        /// Data de lançamento da temporada.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Status da temporada.
        /// </summary>
        public EnumDTO<SeasonStatus> Status { get; set; }

        /// <summary>
        /// Coleção de episódios da temporada.
        /// </summary>
        public IEnumerable<SimpleEpisodeDTO> Episodes { get; set; }

        /// <summary>
        /// Identificador do anime ao qual a temporada pertence.
        /// </summary>
        public long AnimeId { get; set; }

        /// <summary>
        /// Construtor privado para garantir que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sinopseIds"></param>
        /// <param name="releaseDate"></param>
        /// <param name="status"></param>
        /// <param name="episodes"></param>
        /// <param name="animeId"></param>
        /// <param name="id"></param>
        private SimpleSeasonDTO(int number, IEnumerable<SimpleSeasonSinopseDTO> sinopseIds, DateTime releaseDate, EnumDTO<SeasonStatus> status, IEnumerable<SimpleEpisodeDTO> episodes, long animeId, long? id) : base(id)
        {
            Number = number;
            SinopseIds = sinopseIds;
            ReleaseDate = releaseDate;
            Status = status;
            Episodes = episodes;
            AnimeId = animeId;
        }

        /// <summary>
        /// Método de fábrica para criar uma instância de SimpleSeasonDTO com os parâmetros informados e retorna a instância criada.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sinopseIds"></param>
        /// <param name="releaseDate"></param>
        /// <param name="status"></param>
        /// <param name="episodes"></param>
        /// <param name="animeId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleSeasonDTO Create(long? id, int number, IEnumerable<SimpleSeasonSinopseDTO> sinopseIds, DateTime releaseDate, EnumDTO<SeasonStatus> status, IEnumerable<SimpleEpisodeDTO> episodes, long animeId)
        {
            return new SimpleSeasonDTO(number, sinopseIds, releaseDate, status, episodes, animeId, id);

        }
    }
}
