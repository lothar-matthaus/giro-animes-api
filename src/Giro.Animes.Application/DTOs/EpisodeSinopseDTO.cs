using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade EpisodeSinopse.
    /// </summary>
    public class EpisodeSinopseDTO : BaseDTO<EpisodeSinopse>
    {
        /// <summary>
        /// Texto da descrição do episódio.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Identificador do episódio ao qual a descrição pertence.
        /// </summary>
        public long EpisodeId { get; private set; }

        /// <summary>
        /// Idioma da descrição.
        /// </summary>
        public LanguageDTO Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create.
        /// </summary>
        /// <param name="episodeSinopse">Instância da entidade EpisodeSinopse.</param>
        private EpisodeSinopseDTO(EpisodeSinopse episodeSinopse) : base(episodeSinopse)
        {
            Text = episodeSinopse.Text;
            EpisodeId = episodeSinopse.EpisodeId;
            Language = LanguageDTO.Create(episodeSinopse.Language);
        }

        /// <summary>
        /// Método estático para criar um objeto EpisodeSinopseDTO com validações de propriedades e retorno do objeto.
        /// </summary>
        /// <param name="episodeSinopse">Instância da entidade EpisodeSinopse.</param>
        /// <returns>Uma nova instância de EpisodeSinopseDTO.</returns>
        public static EpisodeSinopseDTO Create(EpisodeSinopse episodeSinopse) => new EpisodeSinopseDTO(episodeSinopse);
    }
}