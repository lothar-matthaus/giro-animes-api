using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Common
{
    internal class LanguageEntityTypeConfiguration : EntityBaseTypeConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Common.LANGUAGES, Schemas.COMMON);

            builder.HasMany(language => language.Settings).WithOne(settings => settings.Language).IsRequired(true);

            builder.Property(language => language.Name).IsRequired().HasMaxLength(20).HasColumnOrder(2);
            builder.Property(language => language.Code).IsRequired().HasMaxLength(5).HasColumnOrder(3);
            builder.Property(language => language.NativeName).IsRequired().HasMaxLength(20).HasColumnOrder(4);
        }
    }
}
