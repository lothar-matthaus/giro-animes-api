using Giro.Animes.Application.Constants;
using Giro.Animes.Application.Events.Handlers.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Events;
using Giro.Animes.Domain.Interfaces.DomainEvents.Base;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Infra.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Events.Handlers
{
    public class AccountConfirmedDomainEventHandler : DomainEventHandlerBase<AccountConfirmedDomainEvent>
    {
        private readonly IEmailTemplateRepository _templateRepository;
        private readonly IEmailService _emailService;
        public AccountConfirmedDomainEventHandler(ILogger<AccountConfirmedDomainEvent> logger, IEmailTemplateRepository emailTemplateRepository, IEmailService emailService) : base(logger)
        {
            _templateRepository = emailTemplateRepository;
            _emailService = emailService;
        }

        public override async Task HandleAsync(AccountConfirmedDomainEvent domainEvent)
        {
            _logger.LogInformation($"Buscando template de e-mail para o evento de confirmação de conta do usuário {domainEvent.Username}.");
            EmailTemplate template = await _templateRepository.GetByType(TemplateType.AccountConfirmed, domainEvent.LanguageId, CancellationToken.None);

            if(template == null)
            {
                _logger.LogError($"Template de e-mail '{TemplateType.AccountConfirmed.ToString()}' de idioma '{domainEvent.LanguageId}' não encontrado.");
                return;
            }

            _logger.LogInformation($"Template de e-mail encontrado para o evento de confirmação de conta do usuário {domainEvent.Username}. Enviando e-mail.");

            string bodyFormatted = template.Body.Replace(Templates.USERNAME, domainEvent.Username).Replace(Templates.CURRENT_YEAR, DateTime.Now.Year.ToString()).Replace(Templates.TEMPLATE_STYLE, template.Style.Style);
            await _emailService.SendEmailAsync(domainEvent.Email, template.Subject, bodyFormatted);

            _logger.LogInformation($"E-mail enviado com sucesso para o usuário {domainEvent.Username}.");   

            return;
        }
    }
}
