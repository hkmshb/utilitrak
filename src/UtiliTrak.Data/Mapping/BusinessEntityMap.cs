using Hazeltek.Domain;
using Hazeltek.Data.EFx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public abstract class BusinessEntityMap<TEntity>: 
          EntityMappingConfiguration<TEntity> where TEntity: BusinessEntity
    {
        public override void Map(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasAlternateKey(m => m.Name);
            
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
            builder.HasMany(m => m.ContactDetails)
                   .WithOne()
                   .HasForeignKey(m => m.BusinessEntityId)
                   .IsRequired();
        }

        protected virtual void MapTimestamps(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(ne => ne.DateCreated);
            builder.Property(ne => ne.LastUpdated);
        }
    }


}