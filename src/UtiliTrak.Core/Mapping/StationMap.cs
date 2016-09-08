using Hazeltek.UtiliTrak.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hazeltek.UtiliTrak.Mapping
{
    public abstract class StationMap<TEntity>: 
           NetworkEntityMap<TEntity> where TEntity: Station
    {
        public override void Map(EntityTypeBuilder<TEntity> builder)
        {
            base.Map(builder);
            builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
            builder.Property(s => s.VoltageRatio).IsRequired();
            builder.Property(s => s.IsPublic).IsRequired();
            builder.Property(s => s.AddressStreet).HasMaxLength(100);
            builder.Property(s => s.AddressTown).HasMaxLength(30);
            builder.Property(s => s.PostalCode).HasMaxLength(20);
            builder.Property(s => s.AddressRaw).HasMaxLength(200);

            builder.HasOne(s => s.SourceFeeder)
                   .WithMany()
                   .HasForeignKey(s => s.SourceFeederId);
        }

        protected override void MapTimestamps(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(s => s.DateCommissioned);
            base.MapTimestamps(builder);
        }
    }


}