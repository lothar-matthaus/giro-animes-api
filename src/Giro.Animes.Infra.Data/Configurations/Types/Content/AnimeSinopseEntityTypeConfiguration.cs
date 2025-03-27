using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class AnimeSinopseEntityTypeConfiguration : DescriptionEntityTypeConfiguration<AnimeSinopse>
    {
        public override void Configure(EntityTypeBuilder<AnimeSinopse> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.SINOPSES, Schemas.CONTENT);
            builder.HasOne(sin => sin.Anime).WithMany(ani => ani.Sinopses).HasForeignKey(sin => sin.AnimeId).IsRequired();
            builder.Property(sin => sin.AnimeId).HasColumnOrder(3).IsRequired();
            builder.HasOne(sin => sin.Language).WithMany(lan => lan.AnimeSinopses).HasForeignKey(sin => sin.LanguageId).IsRequired();
            builder.Property(sin => sin.LanguageId).HasColumnOrder(4).IsRequired();
        }
    }
}
