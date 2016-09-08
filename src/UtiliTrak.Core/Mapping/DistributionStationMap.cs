using Hazeltek.UtiliTrak.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Mapping
{
    public class DistributionStationMap: StationMap<DistributionStation>
    {
        public override void Map(EntityTypeBuilder<DistributionStation> builder)
        {
            base.Map(builder);
            builder.Property(ds => ds.UpriserCount).IsRequired();
            base.MapTimestamps(builder);
        }
    }


}