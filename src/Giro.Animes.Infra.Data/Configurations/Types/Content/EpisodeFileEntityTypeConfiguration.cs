using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class EpisodeFileEntityTypeConfiguration : MediaEntityTypeConfiguration<EpisodeFile>
    {
        public override void Configure(EntityTypeBuilder<EpisodeFile> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.EPISODE_FILES, Schemas.CONTENT);
            builder.HasOne(file => file.Episode).WithMany(ep => ep.Files).HasForeignKey(file => file.EpisodeId).IsRequired();
        }
    }
}
