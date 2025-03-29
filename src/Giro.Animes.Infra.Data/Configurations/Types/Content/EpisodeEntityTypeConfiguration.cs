using Giro.Animes.Domain.Entities;
using Giro.Animes.Domain.Entities.Joint;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Content
{
    internal class EpisodeEntityTypeConfiguration : EntityBaseTypeConfiguration<Episode>
    {
        public override void Configure(EntityTypeBuilder<Episode> builder)
        {
            base.Configure(builder);
            builder.ToTable(Tables.Content.EPISODES, Schemas.CONTENT);

            builder.Property(ep => ep.Number).IsRequired(true).HasDefaultValue(0);
            builder.Property(ep => ep.Duration).IsRequired(true).HasDefaultValue(0);
            builder.Property(ep => ep.AirDate).IsRequired(true);

            builder.HasMany(ep => ep.Titles).WithOne(title => title.Episode).HasForeignKey(ept => ept.EpisodeId).IsRequired(true);
            builder.HasMany(ep => ep.Files).WithOne(file => file.Episode).HasForeignKey(file => file.EpisodeId);
            builder.HasMany(ep => ep.Sinopses).WithOne(sinopses => sinopses.Episode).HasForeignKey(sinopse => sinopse.EpisodeId).IsRequired(true);
            builder.HasMany(ep => ep.SubtitleLanguages).WithMany(lan => lan.Episodes).UsingEntity<EpisodeLanguages>(
            Tables.Content.EPISODE_LANGUAGES, // Nome da tabela de junção
                   join => join.HasOne(join => join.Language)
                  .WithMany()
                  .HasForeignKey(join => join.EpisodeId) // Nome da coluna FK para Description
                  .OnDelete(DeleteBehavior.Cascade),
            join => join.HasOne(join => join.Episode)
                  .WithMany()
                  .HasForeignKey(join => join.LanguageId) // Nome da coluna FK para Genre
                  .OnDelete(DeleteBehavior.Cascade),
            join =>
            {
                join.ToTable(Tables.Content.EPISODE_LANGUAGES, Schemas.CONTENT);
            });
            builder.Navigation(ep => ep.Titles);
            builder.Navigation(ep => ep.Files);
        }
    }
}
