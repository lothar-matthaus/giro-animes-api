using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Domain.ValueObjects;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types
{
    internal class AccountEntityTypeConfiguration : EntityBaseTypeConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Management.ACCOUNTS, Schemas.MANAGEMENT);
            builder.HasOne(account => account.User).WithOne(user => user.Account).IsRequired(true);
            builder.HasOne(account => account.Avatar).WithOne(avatar => avatar.Account).HasForeignKey<Avatar>(avatar => avatar.AccountId).IsRequired(true);

            builder.OwnsOne(account => account.Email, email =>
            {
                email.Property(email => email.Value).HasColumnName(nameof(Account.Email)).HasMaxLength(100).IsRequired(true);
                email.Property(email => email.IsConfirmed).HasColumnName(nameof(Account.Email.IsConfirmed)).IsRequired(true).HasDefaultValue(false);
            });

            builder.OwnsOne(account => account.Password, password =>
            {
                password.Property(password => password.Value).IsRequired().HasMaxLength(256);
                password.Property(password => password.Salt).IsRequired().HasMaxLength(256);
                password.Ignore(password => password.PlainTextConfirm);
                password.Ignore(password => password.PlainText);
            });

            builder.Property(account => account.Status).IsRequired(true).HasConversion(status => status.Value, value => AccountStatus.FromValue(value));
            builder.Property(account => account.Plan).IsRequired(true).HasConversion(plan => plan.Value, value => AccountPlan.FromValue(value));
        }
    }
}
