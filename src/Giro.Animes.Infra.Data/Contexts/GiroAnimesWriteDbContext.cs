using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Common;
using Giro.Animes.Infra.Data.Configurations.Types.Content;
using Giro.Animes.Infra.Data.Configurations.Types.Management;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Contexts
{
    public class GiroAnimesWriteDbContext : DbContext
    {
        public GiroAnimesWriteDbContext(DbContextOptions<GiroAnimesWriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AvatarEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SettingsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimeScreenshotEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimeTitleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CoverEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BiographyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeFileEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeTitleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreDescriptionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreTitleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LogoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimeSinopseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RatingEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeSinopseEntityTypeConfiguration());

            // this.ToSnakeCase(modelBuilder);
        }
    }
}
