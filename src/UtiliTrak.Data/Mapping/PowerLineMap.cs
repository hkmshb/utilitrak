using Hazeltek.UtiliTrak.Data.Domain.Network;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public class PowerLineMap: NetworkEntityMap<PowerLine>
    {
        public override void Map(EntityTypeBuilder<PowerLine> builder)
        {
            base.Map(builder);
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Voltage).IsRequired();
            builder.Property(p => p.LineLength).HasDefaultValue(0);
            builder.Property(p => p.PoleCount).HasDefaultValue(0);
            builder.HasOne(p => p.SourceStation)
                   .WithMany()
                   .HasForeignKey(p => p.SourceStationId)
                   .IsRequired(false);
            builder.HasDiscriminator<int>("Type")
                   .HasValue<Feeder>((int)PowerLineType.Feeder)
                   .HasValue<Upriser>((int)PowerLineType.Upriser);
            builder.Property(p => p.DateCommissioned);
            base.MapTimestamps(builder);
        }
    }


}