using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Interfaces.Services
{
    public interface IAnimeDomainService : IDomainService
    {
        Task<Anime> CreateNewAnime(Anime anime);
        Task<bool> DeleteAnime(Anime anime);
    }
}
