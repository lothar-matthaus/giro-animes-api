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
    internal class SeasonSinopseEntityTypeConfiguration : DescriptionEntityTypeConfiguration<SeasonSinopse>
    {
        public override void Configure(EntityTypeBuilder<SeasonSinopse> builder)
        {
            builder.ToTable(Tables.Content.SEASON_SINOPSES, Schemas.CONTENT);
            builder.HasOne(sinopse => sinopse.Language).WithMany().HasForeignKey(sinopse => sinopse.LanguageId).OnDelete(DeleteBehavior.NoAction).IsRequired(true);
            base.Configure(builder);
        }
    }
}
