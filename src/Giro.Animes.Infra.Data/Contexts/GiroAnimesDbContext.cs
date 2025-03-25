using Giro.Animes.Domain.Entities;
using Giro.Animes.Infra.Data.Configurations.Types;
using Giro.Animes.Infra.Data.Extensions;
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
        public DbSet<Title> Titles { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Author> Authors { get; set; }

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
            modelBuilder.ApplyConfiguration(new DescriptionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TitleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());

            // this.ToSnakeCase(modelBuilder);
        }
    }
}
