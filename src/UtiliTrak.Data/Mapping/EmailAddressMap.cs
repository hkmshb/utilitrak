using Hazeltek.Domain;
using Hazeltek.Data.EFx;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public class EmailAddressMap: EntityMappingConfiguration<EmailAddress>
    {
        public override void Map(EntityTypeBuilder<EmailAddress> builder)
        {
            builder.Property(p => p.Address)
                   .HasColumnName("Email")
                   .HasMaxLength(50);
        }
    }



}