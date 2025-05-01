using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class SeasonEntityTypeConfiguration : EntityBaseTypeConfiguration<Season>
    {
        public override void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.ToTable(Tables.Content.SEASONS, Schemas.CONTENT);
            builder.Property(season => season.Number).IsRequired(true);
            builder.Property(season => season.ReleaseDate).IsRequired(true);
            builder.Property(season => season.Status).IsRequired(true);

            builder.HasOne(season => season.Trailer).WithOne().HasForeignKey<Trailer>(trailer => trailer.SeasonId).IsRequired(false);

            builder.HasMany(season => season.Sinopses)
                .WithOne(seasonSinopse => seasonSinopse.Season)
                .HasForeignKey(seasonSinopse => seasonSinopse.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(season => season.Episodes).WithOne(episode => episode.Season)
                .HasForeignKey(episode => episode.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
