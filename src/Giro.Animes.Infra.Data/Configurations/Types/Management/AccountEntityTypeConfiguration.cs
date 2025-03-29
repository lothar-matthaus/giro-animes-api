using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Management
{
    internal class AccountEntityTypeConfiguration : EntityBaseTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Management.ACCOUNTS, Schemas.MANAGEMENT);

            builder.OwnsOne(account => account.Email, email =>
            {
                email.Property(email => email.Value).HasColumnName(nameof(Account.Email)).HasMaxLength(100).IsRequired(true);
                email.Property(email => email.IsConfirmed).HasColumnName(nameof(Account.Email.IsConfirmed)).IsRequired(true).HasDefaultValue(false);
            });

            builder.OwnsOne(account => account.Password, password =>
            {
                password.Property(password => password.Value).HasColumnName(nameof(Password)).IsRequired(true).HasMaxLength(256);
                password.Property(password => password.Salt).HasColumnName(nameof(Password.Salt)).IsRequired(true).HasMaxLength(256);
                password.Ignore(password => password.PlainTextConfirm);
                password.Ignore(password => password.PlainText);
            });

            builder.Property(account => account.Plan).IsRequired(true).HasConversion(plan => plan.Value, value => AccountPlan.FromValue(value));
            builder.Property(account => account.Status).IsRequired(true).HasConversion(status => status.Value, value => AccountStatus.FromValue(value));
            builder.Navigation(account => account.Settings);

            builder.HasOne(account => account.User).WithOne(user => user.Account).IsRequired(true);
            builder.HasOne(account => account.Avatar).WithOne(avatar => avatar.Account).HasForeignKey<Avatar>(avatar => avatar.AccountId).IsRequired(true);
            builder.HasMany(account => account.Watchlist).WithMany(anime => anime.Accounts).UsingEntity<Watchlist>(
            Tables.Content.WATCHLIST, // Nome da tabela de junção
            join => join.HasOne(watch => watch.Anime)
                  .WithMany()
                  .HasForeignKey(join => join.AnimeId) // Nome da coluna FK para Genre
                  .OnDelete(DeleteBehavior.Cascade),
            join => join.HasOne(watch => watch.Account)
                  .WithMany()
                  .HasForeignKey(join => join.AccountId) // Nome da coluna FK para Description
                  .OnDelete(DeleteBehavior.Cascade),
            join =>
            {
                join.ToTable(Tables.Content.WATCHLIST, Schemas.CONTENT);
            });
        }
    }
}
