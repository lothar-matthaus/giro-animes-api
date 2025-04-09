using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs.Detailed
{
    /// <summary>
    /// Objeto de Transferência de Dados para a entidade Language.
    /// </summary>
    public class DetailedLanguageDTO : BaseDTO
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
        /// Inicializa uma nova instância da classe <see cref="DetailedLanguageDTO"/>.
        /// </summary>
        /// <param name="language">A entidade Language.</param>
        private DetailedLanguageDTO(long? id, DateTime creationDate, DateTime updateDate, string name, string code, string nativeName) : base(id, creationDate, updateDate)
        {
            Name = name;
            Code = code;
            NativeName = nativeName;
        }

        /// <summary>
        /// Cria uma nova instância da classe <see cref="DetailedLanguageDTO"/> a partir de uma entidade <see cref="Language"/>.
        /// </summary>
        /// <param name="language">A entidade Language.</param>
        /// <returns>Uma nova instância de <see cref="DetailedLanguageDTO"/>.</returns>
        public static DetailedLanguageDTO Create(long? id, DateTime creationDate, DateTime updateDate, string name, string code, string nativeName)
            => new DetailedLanguageDTO(id, creationDate, updateDate, name, code, nativeName);
    }
}
