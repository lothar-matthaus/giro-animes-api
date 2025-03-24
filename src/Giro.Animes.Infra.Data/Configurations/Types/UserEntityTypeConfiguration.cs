using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types
{
    internal class UserEntityTypeConfiguration : EntityBaseTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Management.USERS, Schemas.MANAGEMENT);
            builder.HasOne(user => user.Account).WithOne(account => account.User).HasForeignKey<Account>(account => account.UserId).IsRequired(true);
            builder.HasOne(user => user.Settings).WithOne(settings => settings.User).HasForeignKey<Settings>(settings => settings.UserId).IsRequired(true);
            builder.Navigation(user => user.Account);

            builder.Property(user => user.Name).IsRequired().HasMaxLength(20).HasColumnOrder(2);
            builder.Property(user => user.Status).IsRequired().HasConversion(status => status.Value, value => UserStatus.FromValue(value)).HasColumnOrder(3);
            builder.Property(user => user.Role).IsRequired().HasConversion(role => role.Value, value => UserRole.FromValue(value)).HasColumnOrder(4);
            builder.Ignore(user => user.Settings);
        }
    }
}
