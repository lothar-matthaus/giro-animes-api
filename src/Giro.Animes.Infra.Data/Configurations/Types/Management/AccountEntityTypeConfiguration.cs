using Giro.Animes.Domain.Entities;
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
            });

            builder.HasOne(account => account.Settings).WithOne().HasForeignKey<Settings>(set => set.AccountId).IsRequired(true);


            builder.OwnsOne(account => account.Password, password =>
            {
                password.Property(password => password.Value).HasColumnName(nameof(Password)).IsRequired(true).HasMaxLength(256);
                password.Property(password => password.Salt).HasColumnName(nameof(Password.Salt)).IsRequired(true).HasMaxLength(256);
                password.Ignore(password => password.PlainTextConfirm);
                password.Ignore(password => password.PlainText);
            });

            builder.HasOne(account => account.User).WithOne(user => user.Account).HasForeignKey<User>(user => user.AccountId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(account => account.Status).IsRequired(true);
            builder.Property(account => account.IsConfirmed).IsRequired(true).HasDefaultValue(false);

            builder.Navigation(account => account.Settings).AutoInclude();
            builder.Navigation(account => account.User).AutoInclude();
        }
    }
}
