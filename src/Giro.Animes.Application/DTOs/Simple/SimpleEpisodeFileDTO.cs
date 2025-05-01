using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleEpisodeFileDTO : SimpleMediaDTO
    {
        /// <summary>
        /// Identificador do episódio ao qual o arquivo pertence.
        /// </summary>
        public long EpísodeId { get; private set; }

        /// <summary>
        /// Identificador do idioma de áudio do arquivo.
        /// </summary>
        public SimpleLanguageDTO AudioLanguage { get; private set; }

        /// <summary>
        /// Identificador do idioma da legenda do arquivo.
        /// </summary>
        public SimpleLanguageDTO SubtitleLanguage { get; private set; }

        /// <summary>
        /// Construtor privado. Garante que o objeto só pode ser criado através do método de fábrica.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="episodeId"></param>
        /// <param name="audioLanguage"></param>
        /// <param name="subtitleLanguage"></param>
        private SimpleEpisodeFileDTO(long? id, string url, long episodeId, SimpleLanguageDTO audioLanguage, SimpleLanguageDTO subtitleLanguage) : base(url, id)
        {
            EpísodeId = episodeId;
            AudioLanguage = audioLanguage;
            SubtitleLanguage = subtitleLanguage;
        }

        /// <summary>
        /// Método de fábrica para criar uma nova instância de SimpleEpisodeFileDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="episodeId"></param>
        /// <param name="audioLanguage"></param>
        /// <param name="subtitleLanguage"></param>
        /// <returns></returns>
        public static SimpleEpisodeFileDTO Create(long? id, string url, long episodeId, SimpleLanguageDTO audioLanguage, SimpleLanguageDTO subtitleLanguage)
        {
            return new SimpleEpisodeFileDTO(id, url, episodeId, audioLanguage, subtitleLanguage);
        }
    }
}
