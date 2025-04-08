using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class CoverEntityTypeConfiguration : MediaEntityTypeConfiguration<Cover>
    {
        private readonly IApplicationUser _user;

        public CoverEntityTypeConfiguration(IApplicationUser user)
        {
            _user = user;
        }
        public override void Configure(EntityTypeBuilder<Cover> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.COVERS, Schemas.CONTENT);
            builder.HasOne(cover => cover.Anime).WithMany(x => x.Covers).HasForeignKey(cover => cover.AnimeId).IsRequired();
            builder.HasOne(cover => cover.Language).WithMany(lan => lan.Covers).HasForeignKey(cover => cover.LanguageId).IsRequired();
            builder.HasQueryFilter(cover => cover.Language.Id == cover.Language.Settings.FirstOrDefault(setting => setting.Account.User.Id == _user.Id).InterfaceLanguageId);
        }
    }
}
