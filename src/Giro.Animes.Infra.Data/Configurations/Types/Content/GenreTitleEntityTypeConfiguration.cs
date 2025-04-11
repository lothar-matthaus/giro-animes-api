using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class GenreTitleEntityTypeConfiguration : TitleEntityTypeConfiguration<GenreTitle>
    {
        public override void Configure(EntityTypeBuilder<GenreTitle> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.GENRE_TITLES, Schemas.CONTENT);
            builder.HasOne(title => title.Language).WithMany(lan => lan.GenreTitles).HasForeignKey(title => title.LanguageId).IsRequired();
            builder.HasOne(title => title.Genre).WithMany(gen => gen.Titles).HasForeignKey(title => title.GenreId);
        }
    }
}
