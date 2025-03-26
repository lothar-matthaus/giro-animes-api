using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Common
{
    internal class GenreEntityTypeConfiguration : EntityBaseTypeConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Common.GENRES, Schemas.COMMON);
            builder.HasMany(gen => gen.Titles).WithOne(title => title.Genre);
            builder.HasMany(gen => gen.Descriptions).WithOne(description => description.Genre);
        }
    }
}
