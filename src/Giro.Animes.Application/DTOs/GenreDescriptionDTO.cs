using Giro.Animes.Application.DTOs.Base;
using Giro.Animes.Domain.Entities;

namespace Giro.Animes.Application.DTOs
{
    public class GenreDescriptionDTO : DescriptionDTO<GenreDescription>
    {
        /// <summary>
        /// Identificador do gênero a qual a descrição pertence.
        /// </summary>
        public long GenreId { get; private set; }

        /// <summary>
        /// Construtor com parâmetros. Garanta a construção do objeto no métod Create
        /// </summary>
        /// <param name="genreDescription">Entidade de descrição de gênero</param>
        private GenreDescriptionDTO(GenreDescription genreDescription) : base(genreDescription)
        {
        }

        /// <summary>
        /// Metodo que instancia um objeto da classe GenreDescriptionDTO a partir de uma entidade GenreDescription
        /// </summary>
        /// <param name="genreDescription"></param>
        /// <returns></returns>
        public static GenreDescriptionDTO Create(GenreDescription genreDescription) => new GenreDescriptionDTO(genreDescription);
    }
}