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
    internal class TrailerEntityTypeConfiguration : MediaEntityTypeConfiguration<Trailer>
    {
        public override void Configure(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable(Tables.Content.TRAILERS, Schemas.CONTENT);
            base.Configure(builder);
        }
    }
}
