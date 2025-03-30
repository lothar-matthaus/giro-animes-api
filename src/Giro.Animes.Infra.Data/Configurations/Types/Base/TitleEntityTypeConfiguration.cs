using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    /// <summary>
    /// Configuração de mapeamento de entidade de título de anime no banco de dados
    /// </summary>
    /// <typeparam name="Derivate"></typeparam>
    internal class TitleEntityTypeConfiguration<Derivate> : EntityBaseTypeConfiguration<Derivate> where Derivate : Title
    {
        private readonly IApplicationUser _user;

        /// <summary>
        /// Construtor da classe de configuração de mapeamento de entidade de título de anime
        /// </summary>
        /// <param name="user"></param>
        public TitleEntityTypeConfiguration(IApplicationUser user)
        {
            _user = user;
        }
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            builder.Property(title => title.Name).IsRequired(true);
            builder.HasOne(title => title.Language).WithMany().HasForeignKey(title => title.LanguageId);
            builder.HasQueryFilter(des => _user.Languages.Contains(des.Language.Code));
            base.Configure(builder);
        }
    }
}
