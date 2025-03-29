using Giro.Animes.Infra.Data.Configurations.Types.Common;
using Giro.Animes.Infra.Data.Configurations.Types.Content;
using Giro.Animes.Infra.Data.Configurations.Types.Management;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Data.Contexts
{
    public class GiroAnimesReadDbContext : DbContext
    {
        private readonly IApplicationUser _user;
        public GiroAnimesReadDbContext(DbContextOptions<GiroAnimesReadDbContext> options, IServiceProvider serviceProvider) : base(options)
        {
            _user = serviceProvider.GetRequiredService<IApplicationUser>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AvatarEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SettingsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimeScreenshotEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudioEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimeTitleEntityTypeConfiguration(_user));
            modelBuilder.ApplyConfiguration(new CoverEntityTypeConfiguration(_user));
            modelBuilder.ApplyConfiguration(new BiographyEntityTypeConfiguration(_user));
            modelBuilder.ApplyConfiguration(new EpisodeFileEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeTitleEntityTypeConfiguration(_user));
            modelBuilder.ApplyConfiguration(new GenreDescriptionEntityTypeConfiguration(_user));
            modelBuilder.ApplyConfiguration(new GenreTitleEntityTypeConfiguration(_user));
            modelBuilder.ApplyConfiguration(new LogoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnimeSinopseEntityTypeConfiguration(_user));
            modelBuilder.ApplyConfiguration(new RatingEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EpisodeSinopseEntityTypeConfiguration(_user));
            // this.ToSnakeCase(modelBuilder);
        }
    }
}
