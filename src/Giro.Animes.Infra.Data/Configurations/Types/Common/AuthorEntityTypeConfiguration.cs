using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Common
{
    internal class AuthorEntityTypeConfiguration : EntityBaseTypeConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Common.AUTHORS, Schemas.COMMON);

            builder.Property(author => author.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(author => author.PenName).IsRequired(false).HasMaxLength(30);
            builder.Property(author => author.Website).IsRequired(false).HasDefaultValue(null);
            builder.Property(author => author.Instagram).IsRequired(false).HasDefaultValue(null);
            builder.Property(author => author.Twitter).IsRequired(false).HasDefaultValue(null);
            builder.Property(author => author.BirthDate).IsRequired(false).HasDefaultValue(null);
            builder.Property(author => author.DeathDate).IsRequired(false).HasDefaultValue(null);

            builder.Navigation(author => author.Biographies).AutoInclude();
        }
    }
}
