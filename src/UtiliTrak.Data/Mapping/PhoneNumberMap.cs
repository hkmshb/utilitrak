using Hazeltek.Domain;
using Hazeltek.Data.EFx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public class PhoneNumberMap: EntityMappingConfiguration<PhoneNumber>
    {
        public override void Map(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.Property(p => p.Number).HasMaxLength(15);
            builder.Property(p => p.Extension).HasMaxLength(5);
        }
    }



}