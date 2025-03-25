
using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
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
            builder.HasMany(genre => genre.Titles).WithMany(title => title.Genres).UsingEntity((join) => join.ToTable(Tables.Common.GENRE_TITLES, Schemas.COMMON));
            builder.HasMany(genre => genre.Descriptions).WithMany(description => description.Genres).UsingEntity<GenreDescription>(
            Tables.Common.GENRE_DESCRIPTIONS, // Nome da tabela de junção
            join => join.HasOne( gd => gd.Description)
                  .WithMany()
                  .HasForeignKey(join => join.DescriptionId) // Nome da coluna FK para Description
                  .OnDelete(DeleteBehavior.Cascade),
            join => join.HasOne( gd => gd.Genre  )
                  .WithMany()
                  .HasForeignKey(join => join.GenreId) // Nome da coluna FK para Genre
                  .OnDelete(DeleteBehavior.Cascade),
            join =>
            {
                join.ToTable(Tables.Common.GENRE_DESCRIPTIONS, Schemas.COMMON);
            });
        }
    }
}
