using Giro.Animes.Infra.Interfaces.Configs;
using Giro.Animes.Infra.Interfaces.Services;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISmtpConfig _settings;
        private readonly SmtpClient _smtpClient;

        public EmailService(ISmtpConfig config)
        {
            _settings = config;
            _smtpClient = ConfigureClient();
        }

        /// <summary>
        /// Configura o cliente SMTP.
        /// </summary>
        /// <returns></returns>
        private SmtpClient ConfigureClient()
        {
            var smtpClient = new SmtpClient();
            smtpClient.Connect(_settings.Host, _settings.Port, _settings.EnableSsl);

            if (smtpClient.IsEncrypted)
                smtpClient.Authenticate(_settings.UserName, _settings.Password);

            return smtpClient;
        }

        /// <summary>
        /// Envia um e-mail de forma assincrona.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isHtml"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_settings.FromEmail));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;

            BodyBuilder builder = new BodyBuilder { HtmlBody = body };
            message.Body = builder.ToMessageBody();

            await _smtpClient.SendAsync(message);
            await _smtpClient.DisconnectAsync(true);
        }
    }
}
