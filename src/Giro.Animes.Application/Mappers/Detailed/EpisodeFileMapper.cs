using Giro.Animes.Application.DTOs.Detailed;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers.Detailed
{
    internal static class EpisodeFileMapper
    {
        public static DetailedEpisodeFileDTO Map(this EpisodeFile episodeFile)
        {
            DetailedEpisodeFileDTO episodeFileDTO = DetailedEpisodeFileDTO.Create(
                episodeFile.Id,
                episodeFile.CreationDate,
                episodeFile.UpdateDate,
                episodeFile.Url,
                episodeFile.FileName,
                episodeFile.Extension,
                episodeFile.EpisodeId,
                episodeFile.AudioLanguage.Map(),
                episodeFile.SubtitleLanguage.Map()
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
