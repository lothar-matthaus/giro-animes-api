﻿using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class AnimeTitleEntityTypeConfiguration : TitleEntityTypeConfiguration<AnimeTitle>
    {
        public AnimeTitleEntityTypeConfiguration(IApplicationUser user) : base(user)
        {
        }

        public override void Configure(EntityTypeBuilder<AnimeTitle> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Content.ANIME_TITLES, Schemas.CONTENT);
        }
    }
}
