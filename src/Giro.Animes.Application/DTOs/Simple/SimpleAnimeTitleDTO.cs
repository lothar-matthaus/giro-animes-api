using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleAnimeTitleDTO : SimpleTitleDTO
    {
        /// <summary>
        /// The unique identifier for the anime.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Construtor privado. Garante que a classe só pode ser instanciada através do método Create.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="animeId"></param>
        private SimpleAnimeTitleDTO(long id, string name, SimpleLanguageDTO language, long animeId) : base(name, language, id)
        {
            AnimeId = animeId;
        }

        /// <summary>
        /// Cria uma nova instância de SimpleAnimeTitleDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="animeId"></param>
        /// <returns></returns>
        public static SimpleAnimeTitleDTO Create(long id, string name, SimpleLanguageDTO language, long animeId)
        {
            return new SimpleAnimeTitleDTO(id, name, language, animeId);
        }
    }
}
