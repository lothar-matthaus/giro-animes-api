using Giro.Animes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class MediaEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Media
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            base.Configure(builder);

            builder.Property(med => med.FileName).IsRequired(true);
            builder.Property(med => med.Extension).IsRequired(true);
            builder.Property(med => med.Url).IsRequired(true);
        }
    }
}
