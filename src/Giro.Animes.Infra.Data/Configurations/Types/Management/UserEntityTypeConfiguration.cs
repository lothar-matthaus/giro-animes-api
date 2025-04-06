using Giro.Animes.Domain.Entities;
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
        }
    }
}
