
using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Common
{
    internal class BiographyEntityTypeConfiguration : DescriptionEntityTypeConfiguration<Biography>
    {
        public BiographyEntityTypeConfiguration(IApplicationUser user) : base(user)
        {
        }

        public override void Configure(EntityTypeBuilder<Biography> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Common.BIOGRAPHIES, Schemas.COMMON);
            builder.HasOne(bio => bio.Author).WithMany(aut => aut.Biographies).HasForeignKey(bio => bio.AuthorId).IsRequired(true);
            builder.HasOne(bio => bio.Language).WithMany(aut => aut.Biographies).HasForeignKey(bio => bio.LanguageId).IsRequired(true);
            builder.Navigation(bio => bio.Language).AutoInclude();
            builder.HasQueryFilter(des => _user.Language.Contains(des.Language.Code));
        }
    }
}
