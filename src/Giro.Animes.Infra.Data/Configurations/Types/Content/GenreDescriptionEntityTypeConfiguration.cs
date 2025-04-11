using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class GenreDescriptionEntityTypeConfiguration : DescriptionEntityTypeConfiguration<GenreDescription>
    {
        public override void Configure(EntityTypeBuilder<GenreDescription> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.GENRE_DESCRIPTIONS, Schemas.CONTENT);
            builder.HasOne(desc => desc.Genre).WithMany(gen => gen.Descriptions).HasForeignKey(gen => gen.GenreId).IsRequired();
            builder.HasOne(desc => desc.Language).WithMany(lan => lan.GenreDescriptions).HasForeignKey(title => title.LanguageId).IsRequired();
        }
    }
}
