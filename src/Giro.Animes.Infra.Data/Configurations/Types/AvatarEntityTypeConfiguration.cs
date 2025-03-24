using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types
{
    internal class AvatarEntityTypeConfiguration : EntityBaseTypeConfiguration<Avatar>
    {
        public override void Configure(EntityTypeBuilder<Avatar> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Content.AVATARS, Schemas.CONTENT);

            builder.HasOne(builder => builder.Account).WithOne(account => account.Avatar).IsRequired(true);
            builder.Navigation(builder => builder.Account);

            builder.Property(avatar => avatar.Url).IsRequired().HasColumnOrder(2);
            builder.Property(avatar => avatar.Extension).IsRequired().HasMaxLength(20).HasColumnOrder(3);
        }
    }
}
