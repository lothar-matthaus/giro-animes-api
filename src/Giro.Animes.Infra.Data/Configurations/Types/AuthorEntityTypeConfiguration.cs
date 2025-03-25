using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types
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

            builder.HasMany(author => author.Biographies).WithMany(description => description.Authors).UsingEntity<BiographyAuthors>(
            Tables.Common.BIOGRAPHY_AUTHORS, // Nome da tabela de junção
            join => join.HasOne(ba => ba.Description)
                  .WithMany()
                  .HasForeignKey(join => join.DescriptionId) // Nome da coluna FK para Description
                  .OnDelete(DeleteBehavior.Cascade),
            join => join.HasOne(ba => ba.Author)
                  .WithMany()
                  .HasForeignKey(join => join.AuthorId) // Nome da coluna FK para Genre
                  .OnDelete(DeleteBehavior.Cascade),
            join =>
            {
                join.ToTable(Tables.Common.BIOGRAPHY_AUTHORS, Schemas.COMMON);
            });
        }
    }
}
