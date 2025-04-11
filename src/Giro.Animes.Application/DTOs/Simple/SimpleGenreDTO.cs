using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleGenreDTO : BaseSimpleDTO
    {
        public IEnumerable<SimpleGenreTitleDTO> Titles { get; private set; }

        /// <summary>
        /// Construtor privado para inicializar SimpleGenreDTO com um título e uma descrição.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="id"></param>
        private SimpleGenreDTO(IEnumerable<SimpleGenreTitleDTO> titles, long? id)
            : base(id)
        {
            Titles = titles;
        }

        /// <summary>
        /// Cria uma nova instância de SimpleGenreDTO. 
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleGenreDTO Create(IEnumerable<SimpleGenreTitleDTO> titles, long? id)
        {
            return new SimpleGenreDTO(titles, id);
        }
    }
}
