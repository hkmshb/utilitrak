using Hazeltek.UtiliTrak.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Mapping
{
    public class PowerStationMap: StationMap<PowerStation>
    {
        public override void Map(EntityTypeBuilder<PowerStation> builder)
        {
            base.Map(builder);
            builder.Property(s => s.RadioNo).HasMaxLength(20);
            builder.Property(s => s.PhoneNo).HasMaxLength(20);
            base.MapTimestamps(builder);
        }
    }


}