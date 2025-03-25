
using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class Episode : EntityBase
    {
        public ICollection<Title> Titles { get; private set; }
        public int Number { get; private set; }
        public int Duration { get; private set; }

        public Episode() { }
    }
}
