using Giro.Animes.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giro.Animes.Infra.Data.Configurations.Types.Base
{
    internal class EntityBaseTypeConfiguration<Derivate> : IEntityTypeConfiguration<Derivate> where Derivate : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<Derivate> builder)
        {
            builder.HasKey(entityBase => entityBase.Id);
            builder.Property(entityBase => entityBase.Id).HasColumnOrder(1).IsRequired();
            builder.Ignore(entityBase => entityBase.IsValid);

            builder.Property(entityBase => entityBase.CreationDate).ValueGeneratedOnAdd().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(entityBase => entityBase.UpdateDate).ValueGeneratedOnAddOrUpdate().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
