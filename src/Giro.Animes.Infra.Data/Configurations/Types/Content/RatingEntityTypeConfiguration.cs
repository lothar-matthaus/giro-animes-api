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
            builder.Property(rat => rat.UserId).IsRequired().HasColumnOrder(4);
            builder.Property(rat => rat.AnimeId).IsRequired().HasColumnOrder(5);

            builder.HasOne(rat => rat.User).WithMany(user => user.Ratings).HasForeignKey(rat => rat.UserId);
            builder.HasOne(rat => rat.Anime).WithMany(anime => anime.Ratings).HasForeignKey(rat => rat.AnimeId);
            base.Configure(builder);
        }
    }
}
