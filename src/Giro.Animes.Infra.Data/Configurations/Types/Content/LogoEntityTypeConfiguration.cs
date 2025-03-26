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

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class LogoEntityTypeConfiguration : MediaEntityTypeConfiguration<Logo>
    {
        public override void Configure(EntityTypeBuilder<Logo> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.LOGOS, Schemas.CONTENT);
            builder.HasOne(logo => logo.Studio).WithOne(stu => stu.Logo).HasForeignKey<Logo>(logo => logo.StudioId).IsRequired();
        }
    }
}
