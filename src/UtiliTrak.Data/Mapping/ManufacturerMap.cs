using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public partial class ManufacturerMap: LegalEntityMap<Manufacturer>
    {
        public override void Map(EntityTypeBuilder<Manufacturer> builder)
        {
            base.Map(builder);
            builder.Property(m => m.IsLocal).IsRequired()
                   .HasDefaultValue(false);
            base.MapTimestamps(builder);
        }
    }


}