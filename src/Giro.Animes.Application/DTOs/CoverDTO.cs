using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Cover.
    /// </summary>
    public class CoverDTO : MediaDTO<Cover>
    {
        /// <summary>
        /// Obtém ou define o identificador do anime ao qual a capa pertence.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Obtém ou define o idioma da capa.
        /// </summary>
        public LanguageDTO Language { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="CoverDTO"/>.
        /// </summary>
        /// <param name="cover">A entidade Cover.</param>
        private CoverDTO(Cover cover) : base(cover)
        {
            AnimeId = cover.AnimeId;
            Language = LanguageDTO.Create(cover.Language);
        }

        /// <summary>
        /// Cria uma nova instância da classe <see cref="CoverDTO"/> a partir de uma entidade <see cref="Cover"/>.
        /// </summary>
        /// <param name="cover">A entidade Cover.</param>
        /// <returns>Uma nova instância de <see cref="CoverDTO"/>.</returns>
        public static CoverDTO Create(Cover cover) => new CoverDTO(cover);
    }
}