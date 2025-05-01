using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Application.DTOs.Simple;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class EpisodeFileMapper
    {
        public static DetailedEpisodeFileDTO Map(this EpisodeFile episodeFile)
        {
            DetailedEpisodeFileDTO episodeFileDTO = DetailedEpisodeFileDTO.Create(
                episodeFile.Id,
                episodeFile.Url,
                episodeFile.EpisodeId,
                episodeFile.AudioLanguage.Map(),
                episodeFile.SubtitleLanguage.Map(),
                episodeFile.CreationDate,
                episodeFile.UpdateDate
            );

            return episodeFileDTO;
        }

        public static IEnumerable<DetailedEpisodeFileDTO> Map(this IEnumerable<EpisodeFile> episodeFiles)
        {
            IEnumerable<DetailedEpisodeFileDTO> episodeFilesDTO = episodeFiles.Select(s => s.Map());
            return episodeFilesDTO;
        }

        /// <summary>
        /// Método de extensão para mapear uma coleção de arquivos de episódios para uma coleção de DTOs simples.
        /// </summary>
        /// <param name="episodeFiles"></param>
        /// <returns></returns>
        public static IEnumerable<SimpleEpisodeFileDTO> MapSimple(this ICollection<EpisodeFile> episodeFiles)
        {
            IEnumerable<SimpleEpisodeFileDTO> episodeFilesDTO = episodeFiles.Select(s => s.MapSimple());
            return episodeFilesDTO;
        }

        /// <summary>
        /// Método de extensão para mapear um arquivo de episódio para um DTO simples.
        /// </summary>
        /// <param name="episodeFile"></param>
        /// <returns></returns>
        public static SimpleEpisodeFileDTO MapSimple(this EpisodeFile episodeFile)
        {
            SimpleEpisodeFileDTO simpleEpisodeFileDTO = SimpleEpisodeFileDTO.Create(
                episodeFile.Id,
                episodeFile.Url,
                episodeFile.EpisodeId,
                episodeFile.AudioLanguage.MapSimple(),
                episodeFile.SubtitleLanguage.MapSimple()
            );
            return simpleEpisodeFileDTO;
        }
    }
}
