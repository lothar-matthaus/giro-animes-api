using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities.Joint
{
    public class GenreDescription
    {
        public long GenreId { get; private set; }
        public Genre Genre { get; set; }
        public long DescriptionId { get; private set; }
        public Description Description { get; private set; }
        public GenreDescription() { }
    }
}
