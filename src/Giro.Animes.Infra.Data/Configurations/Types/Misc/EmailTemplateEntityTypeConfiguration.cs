using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Configurations.Types.Misc
{
    public class EmailTemplateEntityTypeConfiguration : EntityBaseTypeConfiguration<EmailTemplate>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.ToTable(Tables.Misc.EMAIL_TEMPLATES, Schemas.MISC);

            builder.Property(template => template.TemplateName).IsRequired().HasMaxLength(255);
            builder.Property(template => template.Subject).IsRequired().HasMaxLength(255);
            builder.Property(template => template.Body).IsRequired();
            builder.Property(template => template.TemplateType).IsRequired();
            builder.Property(template => template.TemplateType).IsRequired().HasDefaultValue(0);

            builder.HasOne(template => template.Language).WithMany().HasForeignKey(template => template.LanguageId).OnDelete(DeleteBehavior.Restrict).IsRequired();

            base.Configure(builder);
        }
    }
}
