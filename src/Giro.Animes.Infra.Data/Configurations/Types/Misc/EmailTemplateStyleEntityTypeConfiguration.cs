using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Configurations.Types.Misc
{
    internal class EmailTemplateStyleEntityTypeConfiguration : EntityBaseTypeConfiguration<EmailTemplateStyle>
    {
        public override void Configure(EntityTypeBuilder<EmailTemplateStyle> builder)
        {
            builder.ToTable(Tables.Misc.EMAIL_TEMPLATE_STYLES, Schemas.MISC);
            builder.Property(style => style.Description).IsRequired();
            builder.Property(style => style.Style).IsRequired();
            base.Configure(builder);
        }
    }
}
