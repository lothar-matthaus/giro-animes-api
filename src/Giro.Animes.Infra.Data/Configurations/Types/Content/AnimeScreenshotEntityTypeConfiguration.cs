﻿using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class AnimeScreenshotEntityTypeConfiguration : ScreenshotEntityTypeConfiguration<Screenshot>
    {
        public override void Configure(EntityTypeBuilder<Screenshot> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Content.ANIME_SCREENSHOTS, Schemas.CONTENT);
        }
    }
}
