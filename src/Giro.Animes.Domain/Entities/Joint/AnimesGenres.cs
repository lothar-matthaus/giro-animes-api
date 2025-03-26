using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities.Joint
{
    /// <summary>
    /// Represents the relationship between an Anime and a Genre.
    /// </summary>
    public class AnimesGenres : EntityBase
    {
        /// <summary>
        /// Gets the identifier of the Anime.
        /// </summary>
        public long AnimeId { get; private set; }

        /// <summary>
        /// Gets or sets the identifier of the Genre.
        /// </summary>
        public long GenreId { get; set; }

        /// <summary>
        /// Gets the Anime associated with this relationship.
        /// </summary>
        public Anime Anime { get; private set; }

        /// <summary>
        /// Gets the Genre associated with this relationship.
        /// </summary>
        public Genre Genre { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimesGenres"/> class.
        /// </summary>
        public AnimesGenres() { }
    }
}
