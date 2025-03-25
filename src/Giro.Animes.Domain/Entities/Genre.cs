using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities
{
    public class Genre : EntityBase
    {
        /// <summary>
        /// Nome do gênero do anime 
        /// </summary>
        public ICollection<Title> Titles { get; private set; }

        /// <summary>
        /// Descrição do gênero do anime 
        /// </summary>
        public ICollection<Description> Descriptions { get; private set; }

        /// <summary>
        /// Construtor padrão 
        /// </summary>
        public Genre()
        {
        }

        /// <summary>
        /// Construtor com parâmetros para garantir a construção do objeto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        private Genre(ICollection<Title> names, ICollection<Description> descriptions)
        {
            Titles = names;
            Descriptions = descriptions;
        }

        /// <summary>
        /// Cria uma instância de Genre. Utilize este método para garantir a construção do objeto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static Genre Create(ICollection<Title> names, ICollection<Description> descriptions) => new Genre(names, descriptions);
    }
}
