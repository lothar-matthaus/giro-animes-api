using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types.Common;
using Giro.Animes.Infra.Data.Configurations.Types.Content;
using Giro.Animes.Infra.Data.Configurations.Types.Management;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Contexts
{
    public class GiroAnimesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public GiroAnimesDbContext(DbContextOptions<GiroAnimesDbContext> options) : base(options)
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
            modelBuilder.ApplyConfiguration(new SinopseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RatingEntityTypeConfiguration());


            // this.ToSnakeCase(modelBuilder);
        }
    }
}
