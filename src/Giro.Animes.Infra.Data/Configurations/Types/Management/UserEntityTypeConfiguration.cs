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
            builder.HasOne(user => user.Avatar).WithOne(Avatar => Avatar.User).HasForeignKey<Avatar>(avatar => avatar.UserId).OnDelete(DeleteBehavior.Cascade);

            // Configuração de relacionamento entre User e Animes favoritos
            builder.HasMany(user => user.Permissions).WithMany().UsingEntity<UserPermission>(
            Tables.Management.USER_PERMISSIONS, // Nome da tabela de junção
            join => join.HasOne(watch => watch.Permission)
                  .WithMany()
                  .HasForeignKey(join => join.PermissionId)
                  .OnDelete(DeleteBehavior.Cascade),
            join => join.HasOne(watch => watch.User)
                  .WithMany()
                  .HasForeignKey(join => join.UserId)
                  .OnDelete(DeleteBehavior.Cascade),
            join =>
            {
                join.ToTable(Tables.Management.USER_PERMISSIONS, Schemas.MANAGEMENT);
            });

            // Configuração de relacionamento entre User e Animes favoritos
            builder.HasMany(user => user.Watchlist).WithMany(anime => anime.Users).UsingEntity<Watchlist>(
            Tables.Content.WATCHLIST, // Nome da tabela de junção
            join => join.HasOne(watch => watch.Anime)
                  .WithMany()
                  .HasForeignKey(join => join.AnimeId)
                  .OnDelete(DeleteBehavior.Cascade),
            join => join.HasOne(watch => watch.User)
                  .WithMany()
                  .HasForeignKey(join => join.UserId)
                  .OnDelete(DeleteBehavior.Cascade),
            join =>
            {
                join.ToTable(Tables.Content.WATCHLIST, Schemas.CONTENT);
            });

            builder.Ignore(user => user.Account);
            builder.Navigation(user => user.Permissions).AutoInclude();
        }
    }
}
