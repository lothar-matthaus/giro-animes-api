using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Language.
    /// </summary>
    public class LanguageDTO : BaseDTO
    {
        /// <summary>
        /// Obtém ou define o nome do idioma.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Obtém ou define o código do idioma.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Obtém ou define o nome nativo do idioma.
        /// </summary>
        public string NativeName { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="LanguageDTO"/>.
        /// </summary>
        /// <param name="language">A entidade Language.</param>
        private LanguageDTO(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, string name, string code, string nativeName) : base(id, creationDate, updateDate, deletionDate)
        {
            Name = name;
            Code = code;
            NativeName = nativeName;
        }

        /// <summary>
        /// Cria uma nova instância da classe <see cref="LanguageDTO"/> a partir de uma entidade <see cref="Language"/>.
        /// </summary>
        /// <param name="language">A entidade Language.</param>
        /// <returns>Uma nova instância de <see cref="LanguageDTO"/>.</returns>
        public static LanguageDTO Create(long? id, DateTime creationDate, DateTime updateDate, DateTime? deletionDate, string name, string code, string nativeName)
            => new LanguageDTO(id, creationDate, updateDate, deletionDate, name, code, nativeName);
    }
}
