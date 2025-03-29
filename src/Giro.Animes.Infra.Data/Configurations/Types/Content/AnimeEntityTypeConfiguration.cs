using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
using Giro.Animes.Domain.Enums;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.HasMany(ani => ani.Sinopses).WithOne(sinopse => sinopse.Anime).HasForeignKey(sinopse => sinopse.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Screenshots).WithOne(screenshot => screenshot.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);

            builder.HasMany(ani => ani.Authors).WithMany(author => author.Works).UsingEntity<Works>(
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
                authorsAnimes.HasQueryFilter(join => join.DeletionDate == null);
            });

            builder.HasMany(ani => ani.Genres).WithMany(gen => gen.Animes).UsingEntity<AnimesGenres>(
            Tables.Content.ANIMES_GENRES, // Nome da tabela de junção
            animesGenres => animesGenres.HasOne(animesGenres => animesGenres.Genre)
                  .WithMany()
                  .HasForeignKey(animesGenres => animesGenres.GenreId) // Nome da coluna FK para Genre
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Cascade),
            animesGenres => animesGenres.HasOne(animesGenres => animesGenres.Anime)
                  .WithMany()
                  .HasForeignKey(animesGenres => animesGenres.AnimeId) // Nome da coluna FK para Description
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Cascade),
            animesGenres =>
            {
                animesGenres.ToTable(Tables.Content.ANIMES_GENRES, Schemas.CONTENT);
                animesGenres.HasQueryFilter(join => join.DeletionDate == null);

            });

            builder.HasMany(ani => ani.Covers).WithOne(cover => cover.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Episodes).WithOne(episode => episode.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Accounts).WithMany(episode => episode.Watchlist);

            builder.Property(ani => ani.Status).HasConversion(status => status.Value, value => AnimeStatus.FromValue(value)).IsRequired(true).HasDefaultValue(AnimeStatus.OnGoing);
        }
    }
}
