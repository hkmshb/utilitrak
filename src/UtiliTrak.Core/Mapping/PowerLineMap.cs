using Hazeltek.UtiliTrak.Domain.Network;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Mapping
{
    public class PowerLineMap: NetworkEntityMap<PowerLine>
    {
        public override void Map(EntityTypeBuilder<PowerLine> builder)
        {
            base.Map(builder);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Voltage).IsRequired();
            builder.Property(p => p.LineLength);
            builder.Property(p => p.PoleCount);
            builder.HasOne(p => p.SourceStation)
                   .WithMany()
                   .HasForeignKey(p => p.SourceStationId)
                   .IsRequired();
            builder.HasDiscriminator<int>("Type")
                   .HasValue<Feeder>((int)PowerLineType.Feeder)
                   .HasValue<Upriser>((int)PowerLineType.Upriser);
            builder.Property(p => p.DateCommissioned);
            base.MapTimestamps(builder);
        }
    }


}