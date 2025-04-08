using Giro.Animes.Application.DTOs;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.Mappers
{
    internal static class EpisodeFileMapper
    {
        public static EpisodeFileDTO Map(this EpisodeFile episodeFile)
        {
            EpisodeFileDTO episodeFileDTO = EpisodeFileDTO.Create(
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

        public static IEnumerable<EpisodeFileDTO> Map(this IEnumerable<EpisodeFile> episodeFiles)
        {
            IEnumerable<EpisodeFileDTO> episodeFilesDTO = episodeFiles.Select(s => s.Map());
            return episodeFilesDTO;
        }
    }
}
