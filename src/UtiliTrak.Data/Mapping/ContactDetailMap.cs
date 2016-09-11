using Hazeltek.Domain;
using Hazeltek.Data.EFx;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public class ContactDetailMap: EntityMappingConfiguration<ContactDetail>
    {
        public override void Map(EntityTypeBuilder<ContactDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Usage).HasMaxLength(40);
            builder.Property(c => c.IsDefault).IsRequired();
            builder.HasDiscriminator<char>("Type")
                   .HasValue<EmailAddress>('E')
                   .HasValue<PhoneNumber>('P');
        }
    }



}