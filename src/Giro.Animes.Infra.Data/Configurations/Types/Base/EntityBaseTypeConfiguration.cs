using Giro.Animes.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    public class EntityBaseTypeConfiguration<Derivate> : IEntityTypeConfiguration<Derivate> where Derivate : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<Derivate> builder)
        {
            builder.Property(entityBase => entityBase.Id).UseIdentityByDefaultColumn();
            builder.HasKey(entityBase => entityBase.Id);
            builder.Ignore(entityBase => entityBase.IsValid);

            builder.Property(entityBase => entityBase.CreationDate).ValueGeneratedOnAdd().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(entityBase => entityBase.UpdateDate).ValueGeneratedOnAddOrUpdate().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
