using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class AvatarEntityTypeConfiguration : MediaEntityTypeConfiguration<Avatar>
    {
        public override void Configure(EntityTypeBuilder<Avatar> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Content.AVATARS, Schemas.CONTENT);
        }
    }
}
