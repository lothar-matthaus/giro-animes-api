using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleGenreDTO : BaseSimpleDTO
    {
        public IEnumerable<SimpleGenreTitleDTO> Titles { get; private set; }
        public IEnumerable<SimpleGenreDescriptionDTO> Descriptions { get; private set; }

        /// <summary>
        /// Construtor privado para inicializar SimpleGenreDTO com um título e uma descrição.
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="descriptions"></param>
        /// <param name="id"></param>
        private SimpleGenreDTO(IEnumerable<SimpleGenreTitleDTO> titles, IEnumerable<SimpleGenreDescriptionDTO> descriptions, long? id)
            : base(id)
        {
            Titles = titles;
            Descriptions = descriptions;
        }

        /// <summary>
        /// Cria uma nova instância de SimpleGenreDTO. 
        /// </summary>
        /// <param name="titles"></param>
        /// <param name="descriptions"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SimpleGenreDTO Create(IEnumerable<SimpleGenreTitleDTO> titles, IEnumerable<SimpleGenreDescriptionDTO> descriptions, long? id)
        {
            return new SimpleGenreDTO(titles, descriptions, id);
        }
    }
}
