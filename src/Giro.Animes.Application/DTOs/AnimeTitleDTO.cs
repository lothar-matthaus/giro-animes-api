using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    public class AnimeTitleDTO : TitleDTO<AnimeTitle>
    {
        /// <summary>
        /// Identificador do anime ao qual o título pertence
        /// </summary>
        public long AnimeId { get; private set; }

        private AnimeTitleDTO(AnimeTitle animeTitle) : base(animeTitle)
        {
            AnimeId = animeTitle.AnimeId;
        }

        /// <summary>
        /// Método estático para criar um objeto AnimeTitleDTO com validações de propriedades e retorno do objeto
        /// </summary>
        /// <param name="animeTitle">Objeto AnimeTitle</param>
        /// <returns>Uma nova instância de AnimeTitleDTO</returns>
        public static AnimeTitleDTO Create(AnimeTitle animeTitle) => new AnimeTitleDTO(animeTitle);
    }
}