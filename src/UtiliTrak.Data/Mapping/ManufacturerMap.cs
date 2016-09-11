using Hazeltek.UtiliTrak.Data.Domain.Network;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public partial class ManufacturerMap: LegalEntityMap<Manufacturer>
    {
        public override void Map(EntityTypeBuilder<Manufacturer> builder)
        {
            base.Map(builder);
            builder.Property(m => m.IsLocal);
            base.MapTimestamps(builder);
        }
    }


}