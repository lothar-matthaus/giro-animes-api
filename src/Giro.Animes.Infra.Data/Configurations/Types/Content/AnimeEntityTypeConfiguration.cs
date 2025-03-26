using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class AnimeEntityTypeConfiguration : EntityBaseTypeConfiguration<Anime>
    {
        public override void Configure(EntityTypeBuilder<Anime> builder)
        {
            base.Configure(builder);

            builder.ToTable(Tables.Content.ANIMES, Schemas.CONTENT);
            builder.HasOne(ani => ani.Studio).WithMany(studio => studio.Animes).HasForeignKey(anime => anime.StudioId).IsRequired();
            builder.HasMany(ani => ani.Titles).WithOne(title => title.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Sinopses).WithOne(sinopse => sinopse.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Screenshots).WithOne(screenshot => screenshot.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Authors).WithMany(author => author.Animes).UsingEntity<Works>(
            Tables.Content.AUTHOR_WORKS, // Nome da tabela de junção
            authorsAnimes => authorsAnimes.HasOne(authorsAnimes => authorsAnimes.Author)
                  .WithMany()
                  .HasForeignKey(authorsAnimes => authorsAnimes.AuthorId) // Nome da coluna FK para Genre
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Cascade),
            authorsAnimes => authorsAnimes.HasOne(authorsAnimes => authorsAnimes.Anime)
                  .WithMany()
                  .HasForeignKey(authorsAnimes => authorsAnimes.AnimeId) // Nome da coluna FK para Description
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Cascade),
            authorsAnimes =>
            {
                authorsAnimes.ToTable(Tables.Content.AUTHOR_WORKS, Schemas.CONTENT);
            });
            builder.HasMany(ani => ani.Covers).WithOne(cover => cover.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Episodes).WithOne(episode => episode.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Accounts).WithMany(episode => episode.Watchlist);

            builder.Property(ani => ani.Status).HasConversion(status => status.Value, value => AnimeStatus.FromValue(value)).IsRequired(true).HasDefaultValue(AnimeStatus.OnGoing);
        }
    }
}
