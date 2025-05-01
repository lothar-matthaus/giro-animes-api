using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class BannerEntityTypeConfiguration : MediaEntityTypeConfiguration<Banner>
    {
        public override void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable(Tables.Content.BANNERS, Schemas.CONTENT);
            base.Configure(builder);
        }
    }
}
