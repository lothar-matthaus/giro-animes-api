using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Interfaces.Repositories
{
    public interface IEmailTemplateRepository : IBaseRepository<EmailTemplate>
    {
        /// <summary>
        /// Busca um template de e-mail pelo tipo e idioma.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="languageId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EmailTemplate> GetByType(TemplateType type, long languageId, CancellationToken cancellationToken);
    }
}
