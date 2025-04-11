using Giro.Animes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class DescriptionEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Description
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            builder.Property(des => des.Text).IsRequired(true).HasColumnName(nameof(Description));
            builder.Navigation(des => des.Language).AutoInclude();

            base.Configure(builder);
        }
    }
}
