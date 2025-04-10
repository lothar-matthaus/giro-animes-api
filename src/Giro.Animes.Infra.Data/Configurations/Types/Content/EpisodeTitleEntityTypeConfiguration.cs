using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class EpisodeTitleEntityTypeConfiguration : TitleEntityTypeConfiguration<EpisodeTitle>
    {
        public override void Configure(EntityTypeBuilder<EpisodeTitle> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Content.EPISODE_TITLES, Schemas.CONTENT);
            builder.HasOne(title => title.Episode).WithMany(ep => ep.Titles).HasForeignKey(title => title.EpisodeId).IsRequired();
            builder.HasOne(title => title.Language).WithMany(lan => lan.EpisodeTitles).HasForeignKey(title => title.LanguageId).IsRequired();
        }
    }
}
