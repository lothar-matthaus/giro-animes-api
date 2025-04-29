using Giro.Animes.Application.Events.Handlers.Base;
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.Events;
using Giro.Animes.Domain.Interfaces.DomainEvents.Base;
using Giro.Animes.Domain.Interfaces.Repositories;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.DTOs;
using Giro.Animes.Infra.Interfaces.Configs;
using Giro.Animes.Infra.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Application.Events.Handlers
{
    public class AccountCreatedDomainEventHandler : DomainEventHandlerBase<AccountCreatedDomainEvent>
    {
        private readonly IApiInfo _apiInfo;
        private readonly ITokenService _tokenService;
        private readonly IEmailTemplateRepository _templateRepository;
        private readonly IEmailService _emailService;

        public AccountCreatedDomainEventHandler(ILogger<AccountCreatedDomainEvent> logger, IApiInfo apiInfo, ITokenService tokenService, IEmailTemplateRepository emailTemplateRepository, IEmailService emailService)
        :base(logger)
        {
            _apiInfo = apiInfo;
            _tokenService = tokenService;
            _templateRepository = emailTemplateRepository;
            _emailService = emailService;

        }
        public override async Task HandleAsync(AccountCreatedDomainEvent domainEvent)
        {
            _logger.LogInformation($"Gerando o token de confirmação de e-mail para o usuário {domainEvent.Username} ({domainEvent.Email})...");
            UserTokenDTO userTokenDTO = await _tokenService.GenerateAccountActivationToken(domainEvent.Username);
            
            _logger.LogInformation($"Token de confirmação de e-mail gerado com sucesso para o usuário {domainEvent.Username} ({domainEvent.Email}).");

            _logger.LogInformation($"Buscando template de boas-vindas para o usuário {domainEvent.Username} ({domainEvent.Email})...");
            EmailTemplate template = await _templateRepository.GetByType(TemplateType.Welcome, domainEvent.LanguageId, CancellationToken.None);

            if(template is null)
            {
                _logger.LogError($"Template '{TemplateType.Welcome.ToString()}' de idioma '{domainEvent.LanguageId}'.");
                return;
            }

            string bodyFormated = template.Body
                .Replace("{username}", domainEvent.Username)
                .Replace("{urlConfirmation}", string.Format("{0}api/v{1}/auth/confirm-email?token={2}", _apiInfo.Host, _apiInfo.Version[0], userTokenDTO.Token))
                .Replace("{urlConfirmation}", string.Format("{0}api/v{1}/auth/confirm-email?token={2}", _apiInfo.Host, _apiInfo.Version[0], userTokenDTO.Token))
                .Replace("{templateStyle}", template.Style.Style)
                .Replace("{currentYear}", DateTime.Now.Year.ToString());

            _logger.LogInformation($"Template de boas-vindas encontrado para o usuário {domainEvent.Username} ({domainEvent.Email}). Enviando e-mail...");
            await _emailService.SendEmailAsync(domainEvent.Email, template.Subject, bodyFormated);
            _logger.LogInformation($"E-mail de boas-vindas enviado com sucesso para o usuário {domainEvent.Username} ({domainEvent.Email}).");

            return;
        }
    }
}
