using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Management
{
    internal class UserEntityTypeConfiguration : EntityBaseTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Management.USERS, Schemas.MANAGEMENT);

            builder.Property(user => user.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(user => user.Name).IsUnique();
            builder.Property(user => user.Role).IsRequired();
            builder.Property(user => user.Plan).IsRequired();
            builder.Navigation(user => user.Account).AutoInclude(false);

            builder.HasMany(user => user.Watchlist).WithMany(anime => anime.Users).UsingEntity<Watchlist>(
            Tables.Content.WATCHLIST, // Nome da tabela de junção
            join => join.HasOne(watch => watch.Anime)
                  .WithMany()
                  .HasForeignKey(join => join.AnimeId) // Nome da coluna FK para Anime
                  .OnDelete(DeleteBehavior.Cascade), // Comportamento de exclusão em cascata
            join => join.HasOne(watch => watch.User)
                  .WithMany()
                  .HasForeignKey(join => join.UserId) // Nome da coluna FK para User
                  .OnDelete(DeleteBehavior.Cascade), // Comportamento de exclusão em cascata
            join =>
            {
                join.ToTable(Tables.Content.WATCHLIST, Schemas.CONTENT);
            });
        }
    }
}
