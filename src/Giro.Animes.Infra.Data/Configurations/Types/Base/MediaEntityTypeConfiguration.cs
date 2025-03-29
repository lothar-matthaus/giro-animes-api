using Giro.Animes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class MediaEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Media
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            base.Configure(builder);

            builder.Property(med => med.Url).IsRequired(true).HasColumnOrder(2);
            builder.Property(med => med.FileName).IsRequired(true).HasColumnOrder(3);
            builder.Property(med => med.Extension).IsRequired(true).HasColumnOrder(4);
        }
    }
}
