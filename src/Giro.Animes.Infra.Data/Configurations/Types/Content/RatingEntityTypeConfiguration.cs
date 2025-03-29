using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class RatingEntityTypeConfiguration : EntityBaseTypeConfiguration<Rating>
    {
        public override void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable(Tables.Content.RATINGS, Schemas.CONTENT);
            builder.Property(rat => rat.Rate).HasMaxLength(5).IsRequired().HasColumnOrder(2);

            builder.HasOne(rat => rat.User).WithMany(user => user.Ratings).HasForeignKey(rat => rat.UserId);
            builder.Property(rat => rat.UserId).IsRequired().HasColumnOrder(3);
            builder.HasOne(rat => rat.Anime).WithMany(anime => anime.Ratings).HasForeignKey(rat => rat.AnimeId);
            builder.Property(rat => rat.UserId).IsRequired().HasColumnOrder(4);
            base.Configure(builder);
        }
    }
}
