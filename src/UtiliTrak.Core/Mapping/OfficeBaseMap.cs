using Hazeltek.UtiliTrak.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Mapping
{
    public partial class OfficeBaseMap: LegalEntityMap<OfficeBase>
    {
        public override void Map(EntityTypeBuilder<OfficeBase> builder)
        {
            base.Map(builder);
            builder.ToTable("Office");
            builder.Property(o => o.Code).HasMaxLength(10);
            builder.Property(o => o.AltCode).HasMaxLength(20);
            builder.HasDiscriminator<char>("Type")
                   .HasValue<RegionalOffice>('R')
                   .HasValue<BusinessOffice>('B');
            builder.HasOne(o => o.ParentOffice)
                   .WithMany()
                   .HasForeignKey(o => o.ParentOfficeId);
            base.MapTimestamps(builder);
        }
    }


}