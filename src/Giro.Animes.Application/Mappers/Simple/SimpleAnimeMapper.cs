using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Application.Mappers.Detailed;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Application.Mappers.Simple
{
    /// <summary>
    /// Classe responsável por mapear entidades do tipo Anime para DTOs simples.
    /// </summary>
    public static class SimpleAnimeMapper
    {
        /// <summary>
        /// Método de extensão para mapear um anime para um SimpleAnimeDTO.
        /// </summary>
        /// <param name="anime"></param>
        /// <returns></returns>
        public static SimpleAnimeDTO MapSimple(this Anime anime)
        {
            SimpleAnimeDTO simpleAnimeDTO = SimpleAnimeDTO.Create(
                anime.Titles.MapSimple(),
                anime.Sinopses?.MapSimple(),
                anime.Covers.MapSimple(),
                anime.Genres.MapSimple(),
                anime.Authors.MapSimple(),
                anime.Studio.MapSimple(),
                anime.Status.Map(),
                anime.Id
            );

            return simpleAnimeDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de animes para uma coleção de SimpleAnimeDTOs.
        /// </summary>
        /// <param name="animes"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleAnimeDTO> MapSimple(this IEnumerable<Anime> animes)
        {
            // Verifica se a coleção de animes é nula ou vazia
            IEnumerable<SimpleAnimeDTO> simpleAnimeDTOs = animes?.Select(anime => anime.MapSimple());

            return simpleAnimeDTOs;
        }
    }
}
