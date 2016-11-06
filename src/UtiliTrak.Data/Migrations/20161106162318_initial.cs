using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UtiliTrak.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LGA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LGA_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AddressRaw = table.Column<string>(maxLength: 200, nullable: true),
                    AddressStateId = table.Column<int>(nullable: true),
                    AddressStreet = table.Column<string>(maxLength: 100, nullable: true),
                    AddressTown = table.Column<string>(maxLength: 30, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    IsLocal = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    ShortName = table.Column<string>(maxLength: 50, nullable: true),
                    WebsiteUrl = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturer_State_AddressStateId",
                        column: x => x.AddressStateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AddressRaw = table.Column<string>(maxLength: 200, nullable: true),
                    AddressStateId = table.Column<int>(nullable: true),
                    AddressStreet = table.Column<string>(maxLength: 100, nullable: true),
                    AddressTown = table.Column<string>(maxLength: 30, nullable: true),
                    AltCode = table.Column<string>(maxLength: 20, nullable: true),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ParentOfficeId = table.Column<int>(nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    RegionalOfficeId = table.Column<int>(nullable: true),
                    ShortName = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<char>(nullable: false),
                    WebsiteUrl = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_State_AddressStateId",
                        column: x => x.AddressStateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_Office_ParentOfficeId",
                        column: x => x.ParentOfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_Office_RegionalOfficeId",
                        column: x => x.RegionalOfficeId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    BusinessEntityId = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: true),
                    Type = table.Column<char>(nullable: false),
                    Usage = table.Column<string>(maxLength: 40, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Number = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDetail_Office_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactDetail_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AddressRaw = table.Column<string>(maxLength: 200, nullable: true),
                    AddressStateId = table.Column<int>(nullable: true),
                    AddressStreet = table.Column<string>(maxLength: 100, nullable: true),
                    AddressTown = table.Column<string>(maxLength: 30, nullable: true),
                    AltCode = table.Column<string>(maxLength: 30, nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    DateCommissioned = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    IsPublic = table.Column<bool>(nullable: false, defaultValue: true)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    SourcePowerLineId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    VoltageRatio = table.Column<int>(nullable: false),
                    UpriserCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_State_AddressStateId",
                        column: x => x.AddressStateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AltCode = table.Column<string>(maxLength: 30, nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    DateCommissioned = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    LineLength = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PoleCount = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    SourceStationId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Voltage = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerLine_Station_SourceStationId",
                        column: x => x.SourceStationId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetail_BusinessEntityId",
                table: "ContactDetail",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetail_ManufacturerId",
                table: "ContactDetail",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Code",
                table: "Country",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LGA_StateId",
                table: "LGA",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_AddressStateId",
                table: "Manufacturer",
                column: "AddressStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_Name",
                table: "Manufacturer",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerLine_Code",
                table: "PowerLine",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerLine_Name",
                table: "PowerLine",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerLine_SourceStationId",
                table: "PowerLine",
                column: "SourceStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_AddressStateId",
                table: "Station",
                column: "AddressStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_Code",
                table: "Station",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Station_Name",
                table: "Station",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Station_SourcePowerLineId",
                table: "Station",
                column: "SourcePowerLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_AddressStateId",
                table: "Office",
                column: "AddressStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_Name",
                table: "Office",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Office_ParentOfficeId",
                table: "Office",
                column: "ParentOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_RegionalOfficeId",
                table: "Office",
                column: "RegionalOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Station_PowerLine_SourcePowerLineId",
                table: "Station",
                column: "SourcePowerLineId",
                principalTable: "PowerLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Station_State_AddressStateId",
                table: "Station");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerLine_Station_SourceStationId",
                table: "PowerLine");

            migrationBuilder.DropTable(
                name: "ContactDetail");

            migrationBuilder.DropTable(
                name: "LGA");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "PowerLine");
        }
    }
}
