
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

namespace Giro.Animes.Infra.Data.Configurations.Types.Common
{
    internal class BiographyEntityTypeConfiguration : DescriptionEntityTypeConfiguration<Biography>
    {
        public override void Configure(EntityTypeBuilder<Biography> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Common.BIOGRAPHIES, Schemas.COMMON);
            builder.HasOne(bio => bio.Author).WithMany(aut => aut.Biographies).HasForeignKey(bio => bio.AuthorId).IsRequired(true);
        }
    }
}
