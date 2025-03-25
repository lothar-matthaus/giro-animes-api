using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types
{
    internal class DescriptionEntityTypeConfiguration : EntityBaseTypeConfiguration<Description>
    {
        public override void Configure(EntityTypeBuilder<Description> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Common.DESCRIPTIONS, Schemas.COMMON);
            builder.Property(description => description.Text).HasColumnType("VARCHAR(1000)").IsRequired();
        }
    }
}
