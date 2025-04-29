using Giro.Animes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class MediaEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Media
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {

            builder.Property(media => media.Url).IsRequired().HasMaxLength(500);

            base.Configure(builder);
        }
    }
}
