using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hazeltek.Data.EFx;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public abstract class NetworkEntityMap<TEntity>: 
           EntityMappingConfiguration<TEntity> where TEntity: NetworkEntity
    {
        public override void Map(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(ne => ne.Id);
            builder.HasIndex(ne => ne.Code).IsUnique();
            
            builder.Property(ne => ne.Code).HasMaxLength(20).IsRequired();
            builder.Property(ne => ne.AltCode).HasMaxLength(30);
            builder.Property(ne => ne.Deleted).HasDefaultValue(false);
        }

        protected virtual void MapTimestamps(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(ne => ne.DateCreated);
            builder.Property(ne => ne.LastUpdated);
        }
    }


}