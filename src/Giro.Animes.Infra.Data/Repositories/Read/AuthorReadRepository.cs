using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories.Read;
using Giro.Animes.Domain.Interfaces.Repositories.Read.Base;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Read.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Repositories.Read
{
    internal class AuthorReadRepository : ReadRepositoryBase<Author>, IAuthorReadRepository
    {
        public AuthorReadRepository(GiroAnimesReadDbContext dbContext) : base(dbContext)
        {
        }
    }
}
