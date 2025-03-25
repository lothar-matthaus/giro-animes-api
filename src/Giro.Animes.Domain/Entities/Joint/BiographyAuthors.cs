using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities.Joint
{
    public class BiographyAuthors
    {
        public long DescriptionId { get; private set; }
        public Description Description { get; private set; }
        public long AuthorId { get; private set; }
        public Author Author { get; private set; }

        public BiographyAuthors() { }
    }
}
