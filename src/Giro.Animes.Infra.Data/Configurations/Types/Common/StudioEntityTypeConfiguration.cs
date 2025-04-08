using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Common
{
    internal class StudioEntityTypeConfiguration : EntityBaseTypeConfiguration<Studio>
    {
        public override void Configure(EntityTypeBuilder<Studio> builder)
        {

            builder.ToTable(Tables.Common.STUDIOS, Schemas.COMMON);

            builder.Property(stu => stu.Name).IsRequired(true);
            builder.Property(stu => stu.City).IsRequired(false).HasDefaultValue(null);
            builder.Property(stu => stu.Country).IsRequired(false).HasDefaultValue(null);
            builder.Property(stu => stu.EstablishedDate).IsRequired(true);
            builder.Property(stu => stu.Instagram).IsRequired(false).HasDefaultValue(null);
            builder.Property(stu => stu.Website).IsRequired(false).HasDefaultValue(null);
            builder.Property(stu => stu.Twitter).IsRequired(false).HasDefaultValue(null);

            builder.HasOne(stu => stu.Logo).WithOne(logo => logo.Studio).HasForeignKey<Logo>(logo => logo.StudioId).IsRequired(true);
            builder.HasMany(stu => stu.Animes).WithOne(ani => ani.Studio).HasForeignKey(ani => ani.StudioId);

            builder.Navigation(stu => stu.Logo).AutoInclude();

            base.Configure(builder);
        }
    }
}
