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

            builder.Property(language => language.Name).IsRequired().HasMaxLength(50);
            builder.Property(language => language.Code).IsRequired().HasMaxLength(5);
            builder.Property(language => language.NativeName).IsRequired().HasMaxLength(50);

            builder.Ignore(language => language.AnimeSinopses);
            builder.Ignore(language => language.GenreTitles);
            builder.Ignore(language => language.GenreDescriptions);
            builder.Ignore(language => language.EpisodeTitles);
            builder.Ignore(language => language.EpisodeSinopses);
            builder.Ignore(language => language.Covers);
        }
    }
}
