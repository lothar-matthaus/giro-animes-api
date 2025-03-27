using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeTitle.
    /// </summary>
    public class EpisodeTitleDTO : TitleDTO<EpisodeTitle>
    {
        /// <summary>
        /// Identificador do episódio ao qual o título pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="EpisodeTitleDTO"/>.
        /// </summary>
        /// <param name="episodeTitle">A entidade EpisodeTitle.</param>
        private EpisodeTitleDTO(EpisodeTitle episodeTitle) : base(episodeTitle)
        {
            EpisodeId = episodeTitle.EpisodeId;
        }

        /// <summary>
        /// Cria uma nova instância da classe <see cref="EpisodeTitleDTO"/> a partir de uma entidade <see cref="EpisodeTitle"/>.
        /// </summary>
        /// <param name="episodeTitle">A entidade EpisodeTitle.</param>
        /// <returns>Uma nova instância de <see cref="EpisodeTitleDTO"/>.</returns>
        public static EpisodeTitleDTO Create(EpisodeTitle episodeTitle) => new EpisodeTitleDTO(episodeTitle);
    }
}