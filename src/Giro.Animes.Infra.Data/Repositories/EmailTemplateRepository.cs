using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using Giro.Animes.Infra.Data.Contexts;
using Giro.Animes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Repositories
{
    public class EmailTemplateRepository : BaseRepository<EmailTemplate, GiroAnimesDbContext>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(GiroAnimesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<EmailTemplate> GetByType(TemplateType type, long languageId, CancellationToken cancellationToken)
        {
           return await _dbSet.Where(_dbSet => _dbSet.Type == type && _dbSet.LanguageId == languageId).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
