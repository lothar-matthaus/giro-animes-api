using Giro.Animes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class MediaEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Media
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {

            builder.Property(med => med.Url).IsRequired(true);
            builder.Property(med => med.FileName).IsRequired(true);
            builder.Property(med => med.Extension).IsRequired(true);
            builder.Ignore(builder => builder.File);

            base.Configure(builder);
        }
    }
}
