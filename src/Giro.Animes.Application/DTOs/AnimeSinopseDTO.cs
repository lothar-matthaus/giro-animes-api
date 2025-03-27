using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    public class AnimeSinopseDTO : BaseDTO<AnimeSinopse>
    {
        /// <summary>  
        /// Texto da descrição do anime  
        /// </summary>  
        public string Text { get; private set; }

        /// <summary>  
        /// Identificador do anime ao qual a descrição pertence  
        /// </summary>  
        public long AnimeId { get; private set; }

        /// <summary>  
        /// Idioma da descrição  
        /// </summary>  
        public LanguageDTO Language { get; private set; }

        /// <summary>  
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create  
        /// </summary>  
        /// <param name="animeSinopse">Instância da entidade AnimeSinopse</param>  
        private AnimeSinopseDTO(AnimeSinopse animeSinopse) : base(animeSinopse)
        {
            Text = animeSinopse.Text;
            AnimeId = animeSinopse.AnimeId;
            Language = LanguageDTO.Create(animeSinopse.Language);
        }

        /// <summary>  
        /// Método estático para criar um objeto AnimeSinopseDTO com validações de propriedades e retorno do objeto  
        /// </summary>  
        /// <param name="animeSinopse">Instância da entidade AnimeSinopse</param>  
        /// <returns>Uma nova instância de AnimeSinopseDTO</returns>  
        public static AnimeSinopseDTO Create(AnimeSinopse animeSinopse) => new AnimeSinopseDTO(animeSinopse);
    }
}