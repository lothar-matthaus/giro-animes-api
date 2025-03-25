
using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types
{
    internal class GenreEntityTypeConfiguration : EntityBaseTypeConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Common.GENRES, Schemas.COMMON);
            builder.HasMany(genre => genre.Titles).WithMany(title => title.Genres).UsingEntity(entity => entity.ToTable(Tables.Common.TITLE_GENRES, Schemas.COMMON));
            builder.HasMany(genre => genre.Descriptions).WithMany(description => description.Genres).UsingEntity(entity => entity.ToTable(Tables.Common.DESCRIPTION_GENRES, Schemas.COMMON));
        }
    }
}
