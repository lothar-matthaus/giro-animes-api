using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Enums;
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

            builder.Property(user => user.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(user => user.Name).IsUnique();
            builder.Property(user => user.Status).IsRequired().HasConversion(status => status.Value, value => UserStatus.FromValue(value));
            builder.Property(user => user.Role).IsRequired().HasConversion(role => role.Value, value => UserRole.FromValue(value));
            builder.Property(user => user.Plan).IsRequired().HasConversion(plan => plan.Value, value => UserPlan.FromValue(value));
            builder.HasOne(user => user.Account).WithOne(account => account.User).HasForeignKey<User>(user => user.AccountId).OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}
