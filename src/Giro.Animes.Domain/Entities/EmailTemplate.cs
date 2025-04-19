using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class EmailTemplate : EntityBase
    {
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string TemplateType { get; private set; }
        public string TemplateName { get; private set; }
        public string TemplateDescription { get; private set; }

        public long LanguageId { get; private set; }
        public Language Language { get; private set; }

        /// <summary>
        /// Construtor privado com parâmetros. Garanta a construção do objeto através do método de Create.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="templateType"></param>
        /// <param name="templateName"></param>
        /// <param name="templateDescription"></param>
        private EmailTemplate (string subject, string body, string templateType, string templateName, string templateDescription, Language language)
        {
            Subject = subject;
            Body = body;
            TemplateType = templateType;
            TemplateName = templateName;
            TemplateDescription = templateDescription;
            Language = language;
        }

        /// <summary>
        /// Método de criação do objeto EmailTemplate.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="templateType"></param>
        /// <param name="templateName"></param>
        /// <param name="templateDescription"></param>
        /// <returns></returns>
        public static EmailTemplate Create(string subject, string body, string templateType, string templateName, string templateDescription, Language language)
        {
            return new EmailTemplate(subject, body, templateType, templateName, templateDescription, language);
        }
    }
}
