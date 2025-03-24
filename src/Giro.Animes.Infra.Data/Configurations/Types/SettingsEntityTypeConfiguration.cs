using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types
{
    internal class SettingsEntityTypeConfiguration : EntityBaseTypeConfiguration<Settings>
    {
        public override void Configure(EntityTypeBuilder<Settings> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Common.SETTINGS, Schemas.COMMON);
            builder.HasOne(settings => settings.User).WithOne(user => user.Settings).IsRequired(true);
            builder.HasOne(settings => settings.Language).WithMany(language => language.Settings).HasForeignKey(settings => settings.LanguageId).IsRequired(true);
            builder.Navigation(settings => settings.Language);
            builder.Navigation(settings => settings.User);

            builder.Property(settings => settings.Theme).IsRequired(true).HasConversion(theme => theme.Value, value => UserTheme.FromValue(value)).HasDefaultValue(UserTheme.Light);
            builder.Property(settings => settings.EnableApplicationNotifications).IsRequired().HasDefaultValue(true).HasDefaultValue(true);
            builder.Property(settings => settings.EnableEmailNotifications).IsRequired().HasDefaultValue(false).HasDefaultValue(false);
        }
    }
}
