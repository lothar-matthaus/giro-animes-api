using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class EpisodeSinopseEntityTypeConfiguration : DescriptionEntityTypeConfiguration<EpisodeSinopse>
    {
        public override void Configure(EntityTypeBuilder<EpisodeSinopse> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.EPISODE_SINOPSES, Schemas.CONTENT);

            builder.HasOne(sin => sin.Episode).WithMany(epi => epi.Sinopses).HasForeignKey(sin => sin.EpisodeId);
            builder.HasOne(sin => sin.Language).WithMany(epi => epi.EpisodeSinopses).HasForeignKey(sin => sin.EpisodeId);
        }
    }
}
