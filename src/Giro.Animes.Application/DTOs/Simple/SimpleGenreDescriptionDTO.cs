using Giro.Animes.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.DTOs.Simple
{
    public class SimpleGenreDescriptionDTO : SimpleDescriptionDTO
    {
        /// <summary>
        /// Identificador do gênero.
        /// </summary>
        public long GenreId { get; private set; }

        /// <summary>
        /// Private constructor to initialize SimpleGenreDescriptionDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="genreId"></param>
        private SimpleGenreDescriptionDTO(long? id, string description, SimpleLanguageDTO language, long genreId) : base(description, language, id)
        {
            GenreId = genreId;
        }

        /// <summary>
        /// Creates a new instance of SimpleGenreDescriptionDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public static SimpleGenreDescriptionDTO Create(long? id, string description, SimpleLanguageDTO language, long genreId)
        {
            return new SimpleGenreDescriptionDTO(id, description, language, genreId);
        }
    }
}
