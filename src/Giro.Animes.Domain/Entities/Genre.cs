using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities
{
    public class Genre : EntityBase
    {
        /// <summary>
        /// Nome do gênero do anime 
        /// </summary>
        public ICollection<GenreTitle> Titles { get; private set; }

        /// <summary>
        /// Descrição do gênero do anime 
        /// </summary>
        public ICollection<GenreDescription> Descriptions { get; private set; }

        /// <summary>
        /// Animes a qual o gênero pertence
        /// </summary>
        public ICollection<Anime> Animes { get; private set; }

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
        private Genre(ICollection<GenreTitle> names, ICollection<GenreDescription> descriptions)
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
        public static Genre Create(ICollection<GenreTitle> names, ICollection<GenreDescription> descriptions) => new Genre(names, descriptions);
    }
}
