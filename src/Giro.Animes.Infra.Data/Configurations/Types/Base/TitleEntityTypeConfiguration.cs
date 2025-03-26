using Giro.Animes.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class TitleEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Title
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            base.Configure(builder);
            builder.Property(title => title.Name).IsRequired(true);
            builder.HasOne(title => title.Language).WithMany().HasForeignKey(title => title.LanguageId);
        }
    }
}
