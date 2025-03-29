using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class TitleEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Title
    {
        private readonly IApplicationUser _user;

        public TitleEntityTypeConfiguration(IApplicationUser user)
        {
            _user = user;
        }
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            base.Configure(builder);
            builder.Property(title => title.Name).IsRequired(true);
            builder.HasOne(title => title.Language).WithMany().HasForeignKey(title => title.LanguageId);
            builder.HasQueryFilter(des => _user.Language.Contains(des.Language.Code));
        }
    }
}
