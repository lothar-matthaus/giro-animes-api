using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade AnimeScreenshot.
    /// </summary>
    public class AnimeScreenshotDTO : MediaDTO<AnimeScreenshot>
    {
        /// <summary>
        /// Obtém ou define o identificador do anime ao qual a captura de tela pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="AnimeScreenshotDTO"/>.
        /// </summary>
        /// <param name="animeScreenshot">A entidade AnimeScreenshot.</param>
        private AnimeScreenshotDTO(AnimeScreenshot animeScreenshot) : base(animeScreenshot)
        {
            AnimeId = animeScreenshot.AnimeId;
        }

        /// <summary>
        /// Cria uma nova instância da classe <see cref="AnimeScreenshotDTO"/> a partir de uma entidade <see cref="AnimeScreenshot"/>.
        /// </summary>
        /// <param name="animeScreenshot">A entidade AnimeScreenshot.</param>
        /// <returns>Uma nova instância de <see cref="AnimeScreenshotDTO"/>.</returns>
        public static AnimeScreenshotDTO Create(AnimeScreenshot animeScreenshot) => new AnimeScreenshotDTO(animeScreenshot);
    }
}