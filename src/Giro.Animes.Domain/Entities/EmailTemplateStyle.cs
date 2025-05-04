using Giro.Animes.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Domain.Entities
{
    public class EmailTemplateStyle : EntityBase
    {
        /// <summary>
        /// Descrição do estilo do template de e-mail.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Estilo do template de e-mail.
        /// </summary>
        public string Style { get; private set; }

        public EmailTemplateStyle() { }

        /// <summary>
        /// Construtor privado com parâmetros. Garante a construção através do método Create.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="style"></param>
        private EmailTemplateStyle(string description, string style)
        {
            Description = description;
            Style = style;
        }

        /// <summary>
        /// Método estático para criar uma instância de EmailTemplateStyle.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static EmailTemplateStyle Create(string description, string style)
        {
            return new EmailTemplateStyle(description, style);
        }
    }
}
