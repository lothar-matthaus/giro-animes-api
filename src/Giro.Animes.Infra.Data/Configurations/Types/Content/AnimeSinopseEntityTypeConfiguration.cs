﻿using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class AnimeSinopseEntityTypeConfiguration : DescriptionEntityTypeConfiguration<AnimeSinopse>
    {
        public AnimeSinopseEntityTypeConfiguration(IApplicationUser user) : base(user)
        {
        }

        public override void Configure(EntityTypeBuilder<AnimeSinopse> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.SINOPSES, Schemas.CONTENT);
            builder.HasOne(sin => sin.Language).WithMany(lan => lan.AnimeSinopses).HasForeignKey(sin => sin.LanguageId).IsRequired();
        }
    }
}
