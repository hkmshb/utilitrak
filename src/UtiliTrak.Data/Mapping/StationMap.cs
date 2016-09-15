using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hazeltek.UtiliTrak.Data.Domain.Network;


namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public class StationMap: NetworkEntityMap<Station>
    {
        public override void Map(EntityTypeBuilder<Station> builder)
        {
            base.Map(builder);
            builder.HasAlternateKey(s => s.Name);
            builder.Property(s => s.Name).HasMaxLength(100).IsRequired();       
            builder.Property(s => s.VoltageRatio).IsRequired();
            builder.Property(s => s.IsPublic).IsRequired().HasDefaultValue(true);
            builder.Property(s => s.AddressStreet).HasMaxLength(100);
            builder.Property(s => s.AddressTown).HasMaxLength(30);
            builder.Property(s => s.PostalCode).HasMaxLength(20);
            builder.Property(s => s.AddressRaw).HasMaxLength(200);
            builder.HasOne(m => m.AddressState)
                   .WithMany()
                   .HasForeignKey(m => m.AddressStateId)
                   .IsRequired(false);
            builder.HasOne(s => s.SourcePowerLine)
                   .WithMany()
                   .HasForeignKey(s => s.SourcePowerLineId)
                   .IsRequired(false);
            builder.HasDiscriminator<int>("Type")
                   .HasValue<TransmissionStation>((int)StationType.Transmission)
                   .HasValue<InjectionSubstation>((int)StationType.Injection)
                   .HasValue<DistributionSubstation>((int)StationType.Distribution);
            builder.Property(s => s.DateCommissioned);
            base.MapTimestamps(builder);
        }
    }


}