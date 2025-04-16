using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Management
{
    internal class SettingsEntityTypeConfiguration : EntityBaseTypeConfiguration<Settings>
    {
        public override void Configure(EntityTypeBuilder<Settings> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Management.SETTINGS, Schemas.MANAGEMENT);

            builder.Property(settings => settings.Theme).IsRequired(true);
            builder.Property(settings => settings.EnableApplicationNotifications).IsRequired().HasDefaultValue(true).HasDefaultValue(true);
            builder.Property(settings => settings.EnableEmailNotifications).IsRequired().HasDefaultValue(false);

            builder.HasOne(settings => settings.InterfaceLanguage).WithMany().HasForeignKey(settings => settings.InterfaceLanguageId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(settings => settings.AudioLanguages).WithMany().UsingEntity<SettingsAnimeAudioLanguage>(
                Tables.Management.SETTINGS_ANIME_AUDIO_LANGUAGES, join =>
            join.HasOne(join => join.Language)
                  .WithMany()
                  .HasForeignKey(join => join.LanguageId) // Nome da coluna FK para Description
                  .OnDelete(DeleteBehavior.Cascade),
            join => join.HasOne(join => join.Settings)
                 .WithMany()
                 .HasForeignKey(join => join.SettingsId) // Nome da coluna FK para Genre
                 .OnDelete(DeleteBehavior.Cascade),
            join =>
            {
                join.ToTable(Tables.Management.SETTINGS_ANIME_AUDIO_LANGUAGES, Schemas.MANAGEMENT);
            });

            builder.HasMany(settings => settings.SubtitleLanguages).WithMany().UsingEntity<SettingsAnimeSubtitleLanguage>(
                Tables.Management.SETTINGS_ANIME_SUBTITLE_LANGUAGES, join =>
            join.HasOne(join => join.Language)
                  .WithMany()
                  .HasForeignKey(join => join.LanguageId) // Nome da coluna FK para Description
                  .OnDelete(DeleteBehavior.Cascade),
            join => join.HasOne(join => join.Settings)
                 .WithMany()
                 .HasForeignKey(join => join.SettingsId) // Nome da coluna FK para Genre
                 .OnDelete(DeleteBehavior.Cascade),
            join =>
            {
                join.ToTable(Tables.Management.SETTINGS_ANIME_SUBTITLE_LANGUAGES, Schemas.MANAGEMENT);
            });

            builder.Navigation(settings => settings.InterfaceLanguage).AutoInclude(false);
            builder.Navigation(settings => settings.AudioLanguages).AutoInclude();
            builder.Navigation(settings => settings.SubtitleLanguages).AutoInclude();
        }
    }
}
