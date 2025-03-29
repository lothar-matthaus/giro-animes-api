using Giro.Animes.Application.DTOs;
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
        public static EpisodeTitleDTO Map(this EpisodeTitle episodeTitle)
        {
            EpisodeTitleDTO episodeTitleDto = EpisodeTitleDTO.Create(episodeTitle.Id, episodeTitle.CreationDate, episodeTitle.UpdateDate, episodeTitle.EpisodeId, episodeTitle.Name, episodeTitle.Language.Map());
            return episodeTitleDto;
        }

        /// <summary>
        /// Mapeia uma coleção de títulos de episódios para uma coleção de DTOs.
        /// </summary>
        /// <param name="episodeTitles"></param>
        /// <returns></returns>
        public static IEnumerable<EpisodeTitleDTO> Map(this IEnumerable<EpisodeTitle> episodeTitles)
        {
            IEnumerable<EpisodeTitleDTO> result = episodeTitles?.Select(Map);
            return result;
        }
    }
}
