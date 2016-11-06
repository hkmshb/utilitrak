using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Hazeltek.UtiliTrak.Data;

namespace UtiliTrak.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20161106162318_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Hazeltek.Domain.ContactDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BusinessEntityId");

                    b.Property<bool>("IsDefault");

                    b.Property<int?>("ManufacturerId");

                    b.Property<char>("Type");

                    b.Property<string>("Usage")
                        .HasAnnotation("MaxLength", 40);

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("ContactDetail");

                    b.HasDiscriminator<char>("Type");
                });

            modelBuilder.Entity("Hazeltek.Domain.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Hazeltek.Domain.LGA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("LGA");
                });

            modelBuilder.Entity("Hazeltek.Domain.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3);

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressRaw")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int?>("AddressStateId");

                    b.Property<string>("AddressStreet")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("AddressTown")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsLocal")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("ShortName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("WebsiteUrl")
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("Id");

                    b.HasIndex("AddressStateId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.PowerLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AltCode")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime?>("DateCommissioned");

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<int>("LineLength")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("PoleCount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int?>("SourceStationId");

                    b.Property<int>("Type");

                    b.Property<int>("Voltage");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SourceStationId");

                    b.ToTable("PowerLine");

                    b.HasDiscriminator<int>("Type");
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressRaw")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int?>("AddressStateId");

                    b.Property<string>("AddressStreet")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("AddressTown")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("AltCode")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime?>("DateCommissioned");

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsPublic")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int?>("SourcePowerLineId");

                    b.Property<int>("Type");

                    b.Property<int>("VoltageRatio");

                    b.HasKey("Id");

                    b.HasIndex("AddressStateId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SourcePowerLineId");

                    b.ToTable("Station");

                    b.HasDiscriminator<int>("Type");
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.OfficeBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressRaw")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int?>("AddressStateId");

                    b.Property<string>("AddressStreet")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("AddressTown")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("AltCode")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Code")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int?>("ParentOfficeId");

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int?>("RegionalOfficeId");

                    b.Property<string>("ShortName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<char>("Type");

                    b.Property<string>("WebsiteUrl")
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("Id");

                    b.HasIndex("AddressStateId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentOfficeId");

                    b.HasIndex("RegionalOfficeId");

                    b.ToTable("Office");

                    b.HasDiscriminator<char>("Type");
                });

            modelBuilder.Entity("Hazeltek.Domain.EmailAddress", b =>
                {
                    b.HasBaseType("Hazeltek.Domain.ContactDetail");

                    b.Property<string>("Address")
                        .HasColumnName("Email")
                        .HasAnnotation("MaxLength", 50);

                    b.ToTable("EmailAddress");

                    b.HasDiscriminator().HasValue('E');
                });

            modelBuilder.Entity("Hazeltek.Domain.PhoneNumber", b =>
                {
                    b.HasBaseType("Hazeltek.Domain.ContactDetail");

                    b.Property<string>("Extension")
                        .HasAnnotation("MaxLength", 5);

                    b.Property<string>("Number")
                        .HasAnnotation("MaxLength", 15);

                    b.ToTable("PhoneNumber");

                    b.HasDiscriminator().HasValue('P');
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.Feeder", b =>
                {
                    b.HasBaseType("Hazeltek.UtiliTrak.Data.Domain.Network.PowerLine");

                    b.Property<bool>("IsPublic");

                    b.ToTable("Feeder");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.Upriser", b =>
                {
                    b.HasBaseType("Hazeltek.UtiliTrak.Data.Domain.Network.PowerLine");


                    b.ToTable("Upriser");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.DistributionSubstation", b =>
                {
                    b.HasBaseType("Hazeltek.UtiliTrak.Data.Domain.Network.Station");

                    b.Property<int>("UpriserCount");

                    b.ToTable("DistributionSubstation");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.InjectionSubstation", b =>
                {
                    b.HasBaseType("Hazeltek.UtiliTrak.Data.Domain.Network.Station");


                    b.ToTable("InjectionSubstation");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.TransmissionStation", b =>
                {
                    b.HasBaseType("Hazeltek.UtiliTrak.Data.Domain.Network.Station");


                    b.ToTable("TransmissionStation");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.BusinessOffice", b =>
                {
                    b.HasBaseType("Hazeltek.UtiliTrak.Data.Domain.OfficeBase");


                    b.ToTable("BusinessOffice");

                    b.HasDiscriminator().HasValue('B');
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.RegionalOffice", b =>
                {
                    b.HasBaseType("Hazeltek.UtiliTrak.Data.Domain.OfficeBase");


                    b.ToTable("RegionalOffice");

                    b.HasDiscriminator().HasValue('R');
                });

            modelBuilder.Entity("Hazeltek.Domain.ContactDetail", b =>
                {
                    b.HasOne("Hazeltek.UtiliTrak.Data.Domain.OfficeBase")
                        .WithMany("ContactDetails")
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hazeltek.UtiliTrak.Data.Domain.Network.Manufacturer")
                        .WithMany("ContactDetails")
                        .HasForeignKey("ManufacturerId");
                });

            modelBuilder.Entity("Hazeltek.Domain.LGA", b =>
                {
                    b.HasOne("Hazeltek.Domain.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hazeltek.Domain.State", b =>
                {
                    b.HasOne("Hazeltek.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.Manufacturer", b =>
                {
                    b.HasOne("Hazeltek.Domain.State", "AddressState")
                        .WithMany()
                        .HasForeignKey("AddressStateId");
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.PowerLine", b =>
                {
                    b.HasOne("Hazeltek.UtiliTrak.Data.Domain.Network.Station", "SourceStation")
                        .WithMany()
                        .HasForeignKey("SourceStationId");
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.Network.Station", b =>
                {
                    b.HasOne("Hazeltek.Domain.State", "AddressState")
                        .WithMany()
                        .HasForeignKey("AddressStateId");

                    b.HasOne("Hazeltek.UtiliTrak.Data.Domain.Network.PowerLine", "SourcePowerLine")
                        .WithMany()
                        .HasForeignKey("SourcePowerLineId");
                });

            modelBuilder.Entity("Hazeltek.UtiliTrak.Data.Domain.OfficeBase", b =>
                {
                    b.HasOne("Hazeltek.Domain.State", "AddressState")
                        .WithMany()
                        .HasForeignKey("AddressStateId");

                    b.HasOne("Hazeltek.UtiliTrak.Data.Domain.RegionalOffice", "ParentOffice")
                        .WithMany()
                        .HasForeignKey("ParentOfficeId");

                    b.HasOne("Hazeltek.UtiliTrak.Data.Domain.RegionalOffice")
                        .WithMany("SubOffices")
                        .HasForeignKey("RegionalOfficeId");
                });
        }
    }
}
