using Hazeltek.Domain;
using Hazeltek.Data.EFx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Hazeltek.UtiliTrak.Data.Mapping
{
    public class CountryMap: EntityMappingConfiguration<Country>
    {
        public override void Map(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Code).IsUnique();
            builder.HasIndex(c => c.Name).IsUnique();
            
            builder.Property(c => c.Code).HasMaxLength(3).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.DateCreated);
            builder.Property(c => c.LastUpdated);
        }
    }

    public class StateMap: EntityMappingConfiguration<State>
    {
        public override void Map(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Code).HasMaxLength(3).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
            builder.HasOne(s => s.Country)
                   .WithMany()
                   .HasForeignKey(s => s.CountryId)
                   .IsRequired();
            builder.Property(s => s.DateCreated);
            builder.Property(s => s.LastUpdated);
        }
    }

    public class LGAMap: EntityMappingConfiguration<LGA>
    {
        public override void Map(EntityTypeBuilder<LGA> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Code).HasMaxLength(3).IsRequired();
            builder.Property(l => l.Name).HasMaxLength(50).IsRequired();
            builder.HasOne(l => l.State)
                   .WithMany()
                   .HasForeignKey(l => l.StateId)
                   .IsRequired();
            builder.Property(l => l.DateCreated);
            builder.Property(l => l.LastUpdated);
        }
    }

}