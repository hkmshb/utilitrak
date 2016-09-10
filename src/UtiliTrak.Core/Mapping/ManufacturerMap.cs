using Hazeltek.Data.EFx;
using Hazeltek.UtiliTrak.Domain.Network;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Mapping
{
    public partial class ManufacturerMap: EntityMappingConfiguration<Manufacturer>
    {
        public override void Map(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
            builder.Property(m => m.ShortName).HasMaxLength(50);
            builder.Property(m => m.WebsiteUrl).HasMaxLength(200);
            builder.Property(m => m.AddressStreet).HasMaxLength(100);
            builder.Property(m => m.AddressTown).HasMaxLength(30);
            builder.Property(m => m.PostalCode).HasMaxLength(20);
            builder.Property(m => m.AddressRaw).HasMaxLength(200);
            builder.HasOne(m => m.AddressState)
                   .WithMany()
                   .HasForeignKey(m => m.AddressStateId);
            builder.Property(m => m.IsLocal);
            builder.Property(m => m.DateCreated);
            builder.Property(m => m.LastUpdated);
        }
    }


}