using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
using Giro.Animes.Domain.Enums;
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

            builder.Property(settings => settings.Theme).IsRequired(true).HasConversion(theme => theme.Value, value => UserTheme.FromValue(value)).HasDefaultValue(UserTheme.Light);
            builder.Property(settings => settings.EnableApplicationNotifications).IsRequired().HasDefaultValue(true).HasDefaultValue(true);
            builder.Property(settings => settings.EnableEmailNotifications).IsRequired().HasDefaultValue(false).HasDefaultValue(false);

            builder.HasOne(settings => settings.Account).WithOne(acc => acc.Settings).HasForeignKey<Settings>(set => set.AccountId).IsRequired(true);
            builder.HasOne(settings => settings.InterfaceLanguage).WithMany(language => language.Settings).HasForeignKey(settings => settings.InterfaceLanguageId).IsRequired(true);
            builder.HasMany(settings => settings.AnimeLanguages).WithMany(lan => lan.SettingsAnimes).UsingEntity<SettingsAnimesLanguage>(
                Tables.Content.SETTINGS_ANIME_LANGUAGES, join =>
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
                join.ToTable(Tables.Content.SETTINGS_ANIME_LANGUAGES, Schemas.CONTENT);
            });
        }
    }
}
