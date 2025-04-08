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

            builder.Property(ani => ani.Status).IsRequired().HasDefaultValue(AnimeStatus.ToBeReleased);

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
            });

            builder.HasMany(ani => ani.Covers).WithOne(cover => cover.Anime).HasForeignKey(title => title.AnimeId).IsRequired(true);
            builder.HasMany(ani => ani.Episodes).WithOne(episode => episode.Anime).HasForeignKey(title => title.AnimeId).IsRequired(false);

            builder.Navigation(ani => ani.Titles).AutoInclude();
            builder.Navigation(ani => ani.Sinopses).AutoInclude();
            builder.Navigation(ani => ani.Screenshots).AutoInclude();
            builder.Navigation(ani => ani.Authors).AutoInclude();
            builder.Navigation(ani => ani.Genres).AutoInclude();
            builder.Navigation(ani => ani.Covers).AutoInclude();
            builder.Navigation(ani => ani.Episodes).AutoInclude();
            builder.Navigation(ani => ani.Studio).AutoInclude();
            builder.Navigation(ani => ani.Ratings).AutoInclude();

        }
    }
}
