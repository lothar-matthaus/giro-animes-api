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
    internal class CoverEntityTypeConfiguration : MediaEntityTypeConfiguration<Cover>
    {
        public override void Configure(EntityTypeBuilder<Cover> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.COVERS, Schemas.CONTENT);
            builder.HasOne(cover => cover.Anime).WithMany(x => x.Covers).HasForeignKey(cover => cover.AnimeId).IsRequired();
            builder.HasOne(cover => cover.Language).WithMany(lan => lan.Covers).HasForeignKey(cover => cover.LanguageId).IsRequired();
        }
    }
}
