using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class DescriptionEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Description
    {
        protected readonly IApplicationUser _user;

        public DescriptionEntityTypeConfiguration(IApplicationUser user)
        {
            _user = user;
        }
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            builder.Property(des => des.Text).IsRequired(true).HasColumnName(nameof(Description));
            builder.HasQueryFilter(builder => builder.LanguageId == builder.Language.Settings.FirstOrDefault(set => set.Account.User.Id == _user.Id).InterfaceLanguageId);
            builder.Navigation(des => des.Language).AutoInclude();

            base.Configure(builder);
        }
    }
}
