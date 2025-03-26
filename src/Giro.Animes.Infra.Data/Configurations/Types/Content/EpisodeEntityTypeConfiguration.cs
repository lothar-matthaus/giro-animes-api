using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class EpisodeEntityTypeConfiguration : EntityBaseTypeConfiguration<Episode>
    {
        public override void Configure(EntityTypeBuilder<Episode> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.EPISODES, Schemas.CONTENT);
            builder.HasMany(ep => ep.Titles).WithOne(title => title.Episode).HasForeignKey(ept => ept.EpisodeId).IsRequired(true);
            builder.HasMany(ep => ep.Files).WithOne(file => file.Episode).HasForeignKey(file => file.EpisodeId);
            builder.Navigation(ep => ep.Titles);
            builder.Navigation(ep => ep.Files);

            builder.Property(ep => ep.Number).IsRequired(true).HasDefaultValue(0);
            builder.Property(ep => ep.Duration).IsRequired(true).HasDefaultValue(0);
        }
    }
}
