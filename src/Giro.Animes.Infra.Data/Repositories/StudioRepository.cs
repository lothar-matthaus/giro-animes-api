﻿using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;

namespace Giro.Animes.Infra.Data.Repositories
{
    public class StudioRepository : BaseRepository<Studio, GiroAnimesDbContext>, IStudioRepository
    {
        public StudioRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
