using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class EmailTemplate : EntityBase
    {
        /// <summary>
        /// Assunto do template de e-mail.
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// Corpo do template de e-mail.
        /// </summary>
        public string Body { get; private set; }

        /// <summary>
        /// Tipo do template de e-mail.
        /// </summary>
        public TemplateType Type { get; private set; }

        /// <summary>
        /// Nome do template de e-mail.
        /// </summary>
        public string TemplateName { get; private set; }

        /// <summary>
        /// Descrição do template de e-mail.
        /// </summary>
        public string TemplateDescription { get; private set; }

        /// <summary>
        /// Identificador do idioma do template de e-mail.
        /// </summary>
        public long LanguageId { get; private set; }

        /// <summary>
        /// Representa o idioma do template de e-mail.
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        /// Identificador do estilo do template de e-mail.
        /// </summary>
        public long StyleId { get; private set; }

        /// <summary>
        /// Representa o estilo do template de e-mail.
        /// </summary>
        public EmailTemplateStyle Style { get; private set; }

        /// <summary>
        /// Construtor padrão sem parâmetros. Necessário para o Entity Framework.
        /// </summary>
        public EmailTemplate()
        {

        }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção através do método Create.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <param name="templateName"></param>
        /// <param name="templateDescription"></param>
        /// <param name="language"></param>
        private EmailTemplate(string subject, string body, TemplateType type, string templateName, string templateDescription, Language language, EmailTemplateStyle style)
        {
            Subject = subject;
            Body = body;
            Type = type;
            TemplateName = templateName;
            TemplateDescription = templateDescription;
            Language = language;
            Style = style;
        }

        /// <summary>
        /// Método de validação do template de e-mail.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <param name="templateName"></param>
        /// <param name="templateDescription"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static EmailTemplate Create(string subject, string body, TemplateType type, string templateName, string templateDescription, Language language, EmailTemplateStyle style)
        {
            return new EmailTemplate(subject, body, type, templateName, templateDescription, language, style);
        }
    }
}
