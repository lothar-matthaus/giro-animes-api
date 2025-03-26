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
    internal class DescriptionEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Description
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            base.Configure(builder);

            builder.Property(des => des.Text).IsRequired(true).HasColumnName(nameof(Description)).HasColumnOrder(2);
        }
    }
}
