using Hazeltek.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public abstract class LegalEntityMap<TEntity>: 
          BusinessEntityMap<TEntity> where TEntity: LegalEntity
    {
        public override void Map(EntityTypeBuilder<TEntity> builder)
        {
            base.Map(builder);
            builder.Property(m => m.ShortName).HasMaxLength(50);
            builder.Property(m => m.WebsiteUrl).HasMaxLength(200);
            builder.Property(m => m.AddressStreet).HasMaxLength(100);
            builder.Property(m => m.AddressTown).HasMaxLength(30);
            builder.Property(m => m.PostalCode).HasMaxLength(20);
            builder.Property(m => m.AddressRaw).HasMaxLength(200);
            builder.HasOne(m => m.AddressState)
                   .WithMany()
                   .HasForeignKey(m => m.AddressStateId)
                   .IsRequired(false);
        }
    }


}