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
    internal class ScreenshotEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Screenshot
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            base.Configure(builder);

            builder.Property(scr => scr.FileName).IsRequired(true);
            builder.Property(scr => scr.Extension).IsRequired(true);
            builder.Property(scr => scr.Url).IsRequired(true);
            
        }
    }
}
