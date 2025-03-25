using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types
{
    internal class TitleEntityTypeConfiguration : EntityBaseTypeConfiguration<Title>
    {
        public override void Configure(EntityTypeBuilder<Title> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Common.TITLES, Schemas.COMMON);
            builder.HasOne(title => title.Language).WithMany(language => language.Titles).HasForeignKey(title => title.LanguageId).IsRequired(true);
        }
    }
}
