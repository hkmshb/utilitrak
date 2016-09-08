using Hazeltek.Data.EFx;
using Hazeltek.UtiliTrak.Domain;
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
            builder.Property(m => m.PhoneNo).HasMaxLength(20);
            builder.Property(m => m.Email).HasMaxLength(200);
            builder.Property(m => m.WebUrl).HasMaxLength(200);
            builder.Property(m => m.Address).HasMaxLength(200);
            builder.Property(m => m.IsLocal);
            builder.Property(m => m.DateCreated);
            builder.Property(m => m.LastUpdated);
        }
    }


}