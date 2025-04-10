using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class EpisodeFileEntityTypeConfiguration : MediaEntityTypeConfiguration<EpisodeFile>
    {
        public override void Configure(EntityTypeBuilder<EpisodeFile> builder)
        {
            builder.ToTable(Tables.Content.EPISODE_FILES, Schemas.CONTENT);
            builder.HasOne(file => file.Episode).WithMany(ep => ep.Files).HasForeignKey(file => file.EpisodeId).IsRequired();
            builder.HasOne(file => file.AudioLanguage).WithMany(language => language.EpisodeFileAudio).HasForeignKey(file => file.AudioLanguageId).IsRequired();
            builder.HasOne(file => file.SubtitleLanguage).WithMany(language => language.EpisodeFileSubtitle).HasForeignKey(file => file.SubtitleLanguageId).IsRequired();
            builder.Navigation(file => file.AudioLanguage).AutoInclude();
            builder.Navigation(file => file.SubtitleLanguage).AutoInclude();

            base.Configure(builder);
        }
    }
}
