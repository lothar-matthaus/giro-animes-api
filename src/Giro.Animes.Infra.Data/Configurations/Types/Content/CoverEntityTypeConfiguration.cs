using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class CoverEntityTypeConfiguration : MediaEntityTypeConfiguration<Cover>
    {
        public override void Configure(EntityTypeBuilder<Cover> builder)
        {
            builder.ToTable(Tables.Content.COVERS, Schemas.CONTENT);
            base.Configure(builder);
        }
    }
}
