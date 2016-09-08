using Hazeltek.Data.EFx;
using Hazeltek.UtiliTrak.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Mapping
{
    public abstract class NetworkEntityMap<TEntity>: 
           EntityMappingConfiguration<TEntity> where TEntity: NetworkEntity
    {
        public override void Map(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(ne => ne.Id);
            builder.Property(ne => ne.Code).HasMaxLength(20).IsRequired();
            builder.Property(ne => ne.AltCode).HasMaxLength(30);
        }

        protected virtual void MapTimestamps(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(ne => ne.DateCreated);
            builder.Property(ne => ne.LastUpdated);
        }
    }


}