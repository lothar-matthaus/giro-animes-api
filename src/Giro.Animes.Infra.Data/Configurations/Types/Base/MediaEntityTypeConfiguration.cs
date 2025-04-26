using Giro.Animes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class MediaEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Media
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {

            builder.Property(med => med.Path).IsRequired(true);
            builder.Property(med => med.FileName).IsRequired(true);
            builder.Property(med => med.Extension).IsRequired(true);
            builder.Ignore(builder => builder.File);
            builder.Ignore(builder => builder.DownloadUrl);

            base.Configure(builder);
        }
    }
}
