﻿using Giro.Animes.Domain.Entities;
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

            builder.HasOne(settings => settings.Account).WithOne(acc => acc.Settings).HasForeignKey<Settings>(set => set.AccountId).IsRequired(true);
            builder.HasOne(settings => settings.InterfaceLanguage).WithMany(language => language.Settings).HasForeignKey(settings => settings.InterfaceLanguageId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(settings => settings.AudioLanguages).WithMany(lan => lan.SettingsAnimeAudio).UsingEntity<SettingsAnimeAudioLanguage>(
                Tables.Content.SETTINGS_ANIME_AUDIO_LANGUAGES, join =>
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
                join.ToTable(Tables.Content.SETTINGS_ANIME_AUDIO_LANGUAGES, Schemas.CONTENT);
            });

            builder.HasMany(settings => settings.SubtitleLanguages).WithMany(lan => lan.SettingsAnimeSubtitle).UsingEntity<SettingsAnimeSubtitleLanguage>(
                Tables.Content.SETTINGS_ANIME_SUBTITLE_LANGUAGES, join =>
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
                join.ToTable(Tables.Content.SETTINGS_ANIME_SUBTITLE_LANGUAGES, Schemas.CONTENT);
            });

            builder.Navigation(settings => settings.AudioLanguages).AutoInclude();
            builder.Navigation(settings => settings.SubtitleLanguages).AutoInclude();
            builder.Navigation(settings => settings.InterfaceLanguage).AutoInclude();
        }
    }
}
