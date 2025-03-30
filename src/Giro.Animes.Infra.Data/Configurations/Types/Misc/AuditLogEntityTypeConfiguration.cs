using Giro.Animes.Domain.Entities.Audit;
using Giro.Animes.Infra.Data.Configurations.Types.Base;
using Giro.Animes.Infra.Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Giro.Animes.Infra.Data.Configurations.Types.Misc
{
    internal class AuditLogEntityTypeConfiguration : EntityBaseTypeConfiguration<AuditLog>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable(Tables.Misc.AUDIT_LOGS, Schemas.MISC);
            builder.Property(x => x.Log).IsRequired();

            base.Configure(builder);
        }
    }
}
