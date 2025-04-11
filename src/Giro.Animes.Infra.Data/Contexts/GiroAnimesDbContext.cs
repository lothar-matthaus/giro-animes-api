using Giro.Animes.Domain.Entities.Audit;
using Giro.Animes.Infra.Data.Configurations.Types.Common;
using Giro.Animes.Infra.Data.Configurations.Types.Content;
using Giro.Animes.Infra.Data.Configurations.Types.Management;
using Giro.Animes.Infra.Data.Configurations.Types.Misc;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace Giro.Animes.Infra.Data.Contexts
{
    public class GiroAnimesDbContext : DbContext
    {
        private readonly IApplicationUser _user;

        public GiroAnimesDbContext(DbContextOptions<GiroAnimesDbContext> options, IApplicationUser applicationUser) : base(options)
        {
            _user = applicationUser;
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Audit();
            return await base.SaveChangesAsync(cancellationToken);
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
            modelBuilder.ApplyConfiguration(new AuditLogEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionEntityTypeConfiguration());
        }

        private void Audit()
        {
            IList<AuditLog> auditEntries = new List<AuditLog>();

            foreach (EntityEntry entry in ChangeTracker.Entries()
                         .Where(e => e.State == EntityState.Modified ||
                                     e.State == EntityState.Deleted))
            {
                // Aqui você pode montar os dados que deseja registrar

                if (entry.State == EntityState.Deleted)
                {
                    var auditEntry = AuditLog.Create(
                        entry.Entity.GetType().Name,
                        entry.State.ToString(),
                        _user.Id,
                        JsonSerializer.Serialize(entry.Entity));

                    auditEntries.Add(auditEntry);
                }
            }

            this.AddRange(auditEntries);
        }
    }
}
