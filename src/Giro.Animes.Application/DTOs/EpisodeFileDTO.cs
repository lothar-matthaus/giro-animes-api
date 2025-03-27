using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeFile.
    /// </summary>
    public class EpisodeFileDTO : BaseDTO<EpisodeFile>
    {
        /// <summary>
        /// URL do arquivo.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Nome do arquivo.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Extensão do arquivo.
        /// </summary>
        public string Extension { get; private set; }

        /// <summary>
        /// Identificador do episódio ao qual o arquivo pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Idioma do arquivo.
        /// </summary>
        public LanguageDTO Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="episodeFile">Instância da entidade EpisodeFile.</param>
        private EpisodeFileDTO(EpisodeFile episodeFile) : base(episodeFile)
        {
            Url = episodeFile.Url;
            FileName = episodeFile.FileName;
            Extension = episodeFile.Extension;
            EpisodeId = episodeFile.EpisodeId;
            Language = LanguageDTO.Create(episodeFile.Language);
        }

        /// <summary>
        /// Método estático para criar um objeto EpisodeFileDTO com validações de propriedades e retorno do objeto.
        /// </summary>
        /// <param name="episodeFile">Instância da entidade EpisodeFile.</param>
        /// <returns>Uma nova instância de EpisodeFileDTO.</returns>
        public static EpisodeFileDTO Create(EpisodeFile episodeFile) => new EpisodeFileDTO(episodeFile);
    }
}