using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    /// <summary>
    /// Mapeador de títulos de episódios.
    /// </summary>
    internal static class EpisodeTitleMapper
    {
        /// <summary>
        /// Mapeia um título de episódio para um DTO. 
        /// </summary>
        /// <param name="episodeTitle"></param>
        /// <returns></returns>
        public static DetailedEpisodeTitleDTO Map(this EpisodeTitle episodeTitle)
        {
            DetailedEpisodeTitleDTO episodeTitleDto = DetailedEpisodeTitleDTO.Create(episodeTitle.Id, episodeTitle.CreationDate, episodeTitle.UpdateDate, episodeTitle.EpisodeId, episodeTitle.Name, episodeTitle.Language.Map());
            return episodeTitleDto;
        }

        /// <summary>
        /// Mapeia uma coleção de títulos de episódios para uma coleção de DTOs.
        /// </summary>
        /// <param name="episodeTitles"></param>
        /// <returns></returns>
        public static IEnumerable<DetailedEpisodeTitleDTO> Map(this IEnumerable<EpisodeTitle> episodeTitles)
        {
            IEnumerable<DetailedEpisodeTitleDTO> result = episodeTitles?.Select(Map);
            return result;
        }

        /// <summary>
        /// Mapeia um título de episódio para um DTO simples.
        /// </summary>
        /// <param name="episodeTitle"></param>
        /// <returns></returns>
        public static SimpleEpisodeTitleDTO MapSimple(this EpisodeTitle episodeTitle)
        {
            SimpleEpisodeTitleDTO simpleEpisodeTitleDTO = SimpleEpisodeTitleDTO.Create(episodeTitle.Name, episodeTitle.Language.MapSimple(), episodeTitle.Id, episodeTitle.EpisodeId);
            return simpleEpisodeTitleDTO;
        }

        /// <summary>
        /// Mapeia uma coleção de títulos de episódios para uma coleção de DTOs simples.
        /// </summary>
        /// <param name="episodeTitles"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleEpisodeTitleDTO> MapSimple(this IEnumerable<EpisodeTitle> episodeTitles)
        {
            IEnumerable<SimpleEpisodeTitleDTO> result = episodeTitles?.Select(MapSimple);
            return result;
        }
    }
}
