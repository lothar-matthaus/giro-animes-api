﻿using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Management
{
    internal class PermissionEntityTypeConfiguration : EntityBaseTypeConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(Tables.Management.PERMISSIONS, Schemas.MANAGEMENT);

            builder.Property(p => p.Resource).IsRequired();
            builder.Property(p => p.Action).IsRequired();
            builder.Property(p => p.IsDefault).IsRequired();
            builder.Property(p => p.IsGuest).IsRequired();

            base.Configure(builder);
        }
    }
}
