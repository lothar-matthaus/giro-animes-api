using Giro.Animes.Application.DTOs.Detailed;
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
    }
}
