﻿using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Read.Base;
using Giro.Animes.Domain.Interfaces.Repositories.Write.Base;
using Giro.Animes.Domain.Interfaces.Services.Base;

namespace Giro.Animes.Domain.Services.Base
{
    public class DomainServiceBase<TWriteRepository, TReadRepository, TEntity> : IDomainServiceBase
        where TWriteRepository : IWriteBaseRepository<TEntity>
        where TReadRepository : IReadBaseRepository<TEntity>
        where TEntity : EntityBase,
        new()
    {
        protected readonly TWriteRepository _writeRepository;
        protected readonly TReadRepository _readRepository;

        public DomainServiceBase(TWriteRepository writeRepository, TReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
    }
}
