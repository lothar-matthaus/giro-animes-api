﻿using Giro.Animes.Domain.Entities.Audit;
using Giro.Animes.Infra.Data.Configurations.Types.Common;
using Giro.Animes.Infra.Data.Configurations.Types.Content;
using Giro.Animes.Infra.Data.Configurations.Types.Management;
using Giro.Animes.Infra.Data.Configurations.Types.Misc;
using Giro.Animes.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Giro.Animes.Infra.Data.Contexts
{
    public class GiroAnimesDbContext : DbContext
    {
        private readonly IApplicationUser _user;

        public GiroAnimesDbContext(DbContextOptions<GiroAnimesDbContext> options, IServiceProvider serviceProvider) : base(options)
        {
            _user = serviceProvider.GetRequiredService<IApplicationUser>();
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Audit();
            int key = await base.SaveChangesAsync(cancellationToken);
            return key;
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
            modelBuilder.ApplyConfiguration(new AuditLogEntityTypeConfiguration());

            // this.ToSnakeCase(modelBuilder);
        }

        private void Audit()
        {
            IList<AuditLog> auditEntries = new List<AuditLog>();

            foreach (EntityEntry entry in ChangeTracker.Entries()
                         .Where(e => e.State == EntityState.Modified ||
                                     e.State == EntityState.Deleted))
            {
                // Aqui você pode montar os dados que deseja registrar
                var auditEntry = AuditLog.Create(

                    entry.Entity.GetType().Name,
                    entry.State.ToString(),
                    _user.Id, // Você pode obter isso via DI ou HttpContext
                    (entry.State != EntityState.Deleted || entry.State != EntityState.Modified) ? null : JsonSerializer.Serialize(entry.CurrentValues.ToObject())
             );

                auditEntries.Add(auditEntry);
            }

            this.AddRange(auditEntries);
        }
    }
}
