using Giro.Animes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class ScreenshotEntityTypeConfiguration<Derivate> : MediaEntityTypeConfiguration<Derivate> where Derivate : Screenshot
    {
        public override void Configure(EntityTypeBuilder<Derivate> builder)
        {
            base.Configure(builder);
        }
    }
}
