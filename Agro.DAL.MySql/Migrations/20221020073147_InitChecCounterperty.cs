using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitChecCounterperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrn_Directors_DirectorId",
                table: "Ogrn");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogrn_Directors_DirectorId1",
                table: "Ogrn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.AddColumn<int>(
                name: "DataIpId",
                table: "Okveds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataUlId",
                table: "Okveds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FounderFlId",
                table: "Ogrn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FounderFlId1",
                table: "Ogrn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataUlId",
                table: "Director",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorizedCapitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedCapitals", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Web = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HolderRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ogrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolderRegisters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LegalAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Locality = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdGar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalAddress", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Likveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likveds", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ManagingOrganization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ogrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Incountry = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InRegNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IndateReg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagingOrganization", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rmsp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cat = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rmsp", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nominal = table.Column<float>(type: "float", nullable: false),
                    Percent = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PayAmount = table.Column<float>(type: "float", nullable: true),
                    ArrearsAmount = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UnscrupulousSupplierRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DatePublication = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateApproval = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ShortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kpp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchaseNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchaseDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContractPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnscrupulousSupplierRecord", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UrStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Email_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kpp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LegalAddressId = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InAddressId = table.Column<int>(type: "int", nullable: true),
                    DivisionsId = table.Column<int>(type: "int", nullable: true),
                    DivisionsId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branchs_Division_DivisionsId",
                        column: x => x.DivisionsId,
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branchs_Division_DivisionsId1",
                        column: x => x.DivisionsId1,
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branchs_LegalAddress_InAddressId",
                        column: x => x.InAddressId,
                        principalTable: "LegalAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Branchs_LegalAddress_LegalAddressId",
                        column: x => x.LegalAddressId,
                        principalTable: "LegalAddress",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FounderPif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManagingOrganizationId = table.Column<int>(type: "int", nullable: true),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderPif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderPif_ManagingOrganization_ManagingOrganizationId",
                        column: x => x.ManagingOrganizationId,
                        principalTable: "ManagingOrganization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FounderPif_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<float>(type: "float", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTax_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DataIp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrnIp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Okpo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReg = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateROgrn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    LikvedId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Locality = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OkvedId = table.Column<int>(type: "int", nullable: false),
                    OkopfId = table.Column<int>(type: "int", nullable: false),
                    OkfsId = table.Column<int>(type: "int", nullable: false),
                    OkogyId = table.Column<int>(type: "int", nullable: false),
                    OkatoId = table.Column<int>(type: "int", nullable: false),
                    OktmoId = table.Column<int>(type: "int", nullable: false),
                    RegFnsId = table.Column<int>(type: "int", nullable: false),
                    RegPfrId = table.Column<int>(type: "int", nullable: false),
                    RegFssId = table.Column<int>(type: "int", nullable: false),
                    DateDischarge = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RmspId = table.Column<int>(type: "int", nullable: true),
                    Unscrupulous = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UnscrupulousSupplierRecordId = table.Column<int>(type: "int", nullable: true),
                    MassManagers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MassFounders = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataIp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataIp_Likveds_LikvedId",
                        column: x => x.LikvedId,
                        principalTable: "Likveds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataIp_Okato_OkatoId",
                        column: x => x.OkatoId,
                        principalTable: "Okato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Okfs_OkfsId",
                        column: x => x.OkfsId,
                        principalTable: "Okfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Okogy_OkogyId",
                        column: x => x.OkogyId,
                        principalTable: "Okogy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Okopf_OkopfId",
                        column: x => x.OkopfId,
                        principalTable: "Okopf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Oktmo_OktmoId",
                        column: x => x.OktmoId,
                        principalTable: "Oktmo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Okveds_OkvedId",
                        column: x => x.OkvedId,
                        principalTable: "Okveds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_RegFns_RegFnsId",
                        column: x => x.RegFnsId,
                        principalTable: "RegFns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_RegFss_RegFssId",
                        column: x => x.RegFssId,
                        principalTable: "RegFss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_RegPfr_RegPfrId",
                        column: x => x.RegPfrId,
                        principalTable: "RegPfr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Rmsp_RmspId",
                        column: x => x.RmspId,
                        principalTable: "Rmsp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataIp_UnscrupulousSupplierRecord_UnscrupulousSupplierRecord~",
                        column: x => x.UnscrupulousSupplierRecordId,
                        principalTable: "UnscrupulousSupplierRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataIp_UrStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "UrStatus",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DataUl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ogrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kpp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Okpo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReg = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateROgrn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ShortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    LikvedId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    LegalAddressId = table.Column<int>(type: "int", nullable: false),
                    OkvedId = table.Column<int>(type: "int", nullable: false),
                    OkopfId = table.Column<int>(type: "int", nullable: false),
                    OkfsId = table.Column<int>(type: "int", nullable: false),
                    OkogyId = table.Column<int>(type: "int", nullable: false),
                    OkatoId = table.Column<int>(type: "int", nullable: false),
                    OktmoId = table.Column<int>(type: "int", nullable: false),
                    RegFnsId = table.Column<int>(type: "int", nullable: false),
                    RegPfrId = table.Column<int>(type: "int", nullable: false),
                    RegFssId = table.Column<int>(type: "int", nullable: false),
                    AuthorizedCapitalId = table.Column<int>(type: "int", nullable: false),
                    ManagingOrganizationId = table.Column<int>(type: "int", nullable: true),
                    HolderRegisterId = table.Column<int>(type: "int", nullable: false),
                    DivisionsId = table.Column<int>(type: "int", nullable: true),
                    DateDischarge = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ContactsId = table.Column<int>(type: "int", nullable: true),
                    TaxId = table.Column<int>(type: "int", nullable: true),
                    RmspId = table.Column<int>(type: "int", nullable: true),
                    Srh = table.Column<int>(type: "int", nullable: false),
                    Unscrupulous = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UnscrupulousSupplierRecordId = table.Column<int>(type: "int", nullable: true),
                    DisqualifiedPersons = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MassManagers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MassFounders = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataUl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataUl_AuthorizedCapitals_AuthorizedCapitalId",
                        column: x => x.AuthorizedCapitalId,
                        principalTable: "AuthorizedCapitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataUl_Division_DivisionsId",
                        column: x => x.DivisionsId,
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataUl_HolderRegisters_HolderRegisterId",
                        column: x => x.HolderRegisterId,
                        principalTable: "HolderRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_LegalAddress_LegalAddressId",
                        column: x => x.LegalAddressId,
                        principalTable: "LegalAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Likveds_LikvedId",
                        column: x => x.LikvedId,
                        principalTable: "Likveds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataUl_ManagingOrganization_ManagingOrganizationId",
                        column: x => x.ManagingOrganizationId,
                        principalTable: "ManagingOrganization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataUl_Okato_OkatoId",
                        column: x => x.OkatoId,
                        principalTable: "Okato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Okfs_OkfsId",
                        column: x => x.OkfsId,
                        principalTable: "Okfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Okogy_OkogyId",
                        column: x => x.OkogyId,
                        principalTable: "Okogy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Okopf_OkopfId",
                        column: x => x.OkopfId,
                        principalTable: "Okopf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Oktmo_OktmoId",
                        column: x => x.OktmoId,
                        principalTable: "Oktmo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Okveds_OkvedId",
                        column: x => x.OkvedId,
                        principalTable: "Okveds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_RegFns_RegFnsId",
                        column: x => x.RegFnsId,
                        principalTable: "RegFns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_RegFss_RegFssId",
                        column: x => x.RegFssId,
                        principalTable: "RegFss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_RegPfr_RegPfrId",
                        column: x => x.RegPfrId,
                        principalTable: "RegPfr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Rmsp_RmspId",
                        column: x => x.RmspId,
                        principalTable: "Rmsp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataUl_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataUl_UnscrupulousSupplierRecord_UnscrupulousSupplierRecord~",
                        column: x => x.UnscrupulousSupplierRecordId,
                        principalTable: "UnscrupulousSupplierRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataUl_UrStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "UrStatus",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ArbitrationCasesRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Guid = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Link = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateInitiation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NameCourt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbitrationCasesRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArbitrationCasesRecords_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckBalances_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckCounterparty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true),
                    DataIpId = table.Column<int>(type: "int", nullable: true),
                    ResultStatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCounterparty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckCounterparty_DataIp_DataIpId",
                        column: x => x.DataIpId,
                        principalTable: "DataIp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CheckCounterparty_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CheckCounterparty_Statuses_ResultStatusId",
                        column: x => x.ResultStatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnforcementProceedingRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameDebtor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressDebtor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateInitiation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumberDoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeDoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDoc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Subject = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bailiff = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressBailiff = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AmountDebt = table.Column<float>(type: "float", nullable: false),
                    RemainingDebt = table.Column<float>(type: "float", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementProceedingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnforcementProceedingRecords_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FounderFl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MassFounder = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ShareId = table.Column<int>(type: "int", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderFl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderFl_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FounderFl_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FounderIn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReg = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShareId = table.Column<int>(type: "int", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderIn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderIn_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FounderIn_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FounderMoRf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShareId = table.Column<int>(type: "int", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderMoRf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderMoRf_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FounderMoRf_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FounderMoRf_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FounderUl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ogrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShareId = table.Column<int>(type: "int", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderUl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderUl_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FounderUl_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LicOrg = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicView = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataIpId = table.Column<int>(type: "int", nullable: true),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licenses_DataIp_DataIpId",
                        column: x => x.DataIpId,
                        principalTable: "DataIp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Licenses_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ul",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ogrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kpp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateLikvid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeRegion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Okved = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataIpId = table.Column<int>(type: "int", nullable: true),
                    DataIpId1 = table.Column<int>(type: "int", nullable: true),
                    DataUlId = table.Column<int>(type: "int", nullable: true),
                    DataUlId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ul", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ul_DataIp_DataIpId",
                        column: x => x.DataIpId,
                        principalTable: "DataIp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ul_DataIp_DataIpId1",
                        column: x => x.DataIpId1,
                        principalTable: "DataIp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ul_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ul_DataUl_DataUlId1",
                        column: x => x.DataUlId1,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlaintiffDefendant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ArbitrationCasesRecordId = table.Column<int>(type: "int", nullable: true),
                    ArbitrationCasesRecordId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaintiffDefendant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaintiffDefendant_ArbitrationCasesRecords_ArbitrationCases~1",
                        column: x => x.ArbitrationCasesRecordId1,
                        principalTable: "ArbitrationCasesRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaintiffDefendant_ArbitrationCasesRecords_ArbitrationCasesR~",
                        column: x => x.ArbitrationCasesRecordId,
                        principalTable: "ArbitrationCasesRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaintiffDefendant_LegalAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "LegalAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Balanceline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LineCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LineAmount = table.Column<int>(type: "int", nullable: false),
                    CheckBalanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balanceline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balanceline_CheckBalances_CheckBalanceId",
                        column: x => x.CheckBalanceId,
                        principalTable: "CheckBalances",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlMo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FounderMoRfId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlMo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlMo_FounderMoRf_FounderMoRfId",
                        column: x => x.FounderMoRfId,
                        principalTable: "FounderMoRf",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UlShort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ogrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataUlId = table.Column<int>(type: "int", nullable: true),
                    DataUlId1 = table.Column<int>(type: "int", nullable: true),
                    FounderMoRfId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlShort", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlShort_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UlShort_DataUl_DataUlId1",
                        column: x => x.DataUlId1,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UlShort_FounderMoRf_FounderMoRfId",
                        column: x => x.FounderMoRfId,
                        principalTable: "FounderMoRf",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "Требует внимания" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "Благонадежен" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "Не благонадежен" });

            migrationBuilder.CreateIndex(
                name: "IX_Okveds_DataIpId",
                table: "Okveds",
                column: "DataIpId");

            migrationBuilder.CreateIndex(
                name: "IX_Okveds_DataUlId",
                table: "Okveds",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrn_FounderFlId",
                table: "Ogrn",
                column: "FounderFlId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrn_FounderFlId1",
                table: "Ogrn",
                column: "FounderFlId1");

            migrationBuilder.CreateIndex(
                name: "IX_Director_DataUlId",
                table: "Director",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrationCasesRecords_DataUlId",
                table: "ArbitrationCasesRecords",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_Balanceline_CheckBalanceId",
                table: "Balanceline",
                column: "CheckBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_DivisionsId",
                table: "Branchs",
                column: "DivisionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_DivisionsId1",
                table: "Branchs",
                column: "DivisionsId1");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_InAddressId",
                table: "Branchs",
                column: "InAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_LegalAddressId",
                table: "Branchs",
                column: "LegalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBalances_DataUlId",
                table: "CheckBalances",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCounterparty_DataIpId",
                table: "CheckCounterparty",
                column: "DataIpId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCounterparty_DataUlId",
                table: "CheckCounterparty",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCounterparty_ResultStatusId",
                table: "CheckCounterparty",
                column: "ResultStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_LikvedId",
                table: "DataIp",
                column: "LikvedId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_OkatoId",
                table: "DataIp",
                column: "OkatoId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_OkfsId",
                table: "DataIp",
                column: "OkfsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_OkogyId",
                table: "DataIp",
                column: "OkogyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_OkopfId",
                table: "DataIp",
                column: "OkopfId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_OktmoId",
                table: "DataIp",
                column: "OktmoId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_OkvedId",
                table: "DataIp",
                column: "OkvedId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_RegFnsId",
                table: "DataIp",
                column: "RegFnsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_RegFssId",
                table: "DataIp",
                column: "RegFssId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_RegionId",
                table: "DataIp",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_RegPfrId",
                table: "DataIp",
                column: "RegPfrId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_RmspId",
                table: "DataIp",
                column: "RmspId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_StatusId",
                table: "DataIp",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DataIp_UnscrupulousSupplierRecordId",
                table: "DataIp",
                column: "UnscrupulousSupplierRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_AuthorizedCapitalId",
                table: "DataUl",
                column: "AuthorizedCapitalId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_ContactsId",
                table: "DataUl",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_DivisionsId",
                table: "DataUl",
                column: "DivisionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_HolderRegisterId",
                table: "DataUl",
                column: "HolderRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_LegalAddressId",
                table: "DataUl",
                column: "LegalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_LikvedId",
                table: "DataUl",
                column: "LikvedId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_ManagingOrganizationId",
                table: "DataUl",
                column: "ManagingOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_OkatoId",
                table: "DataUl",
                column: "OkatoId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_OkfsId",
                table: "DataUl",
                column: "OkfsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_OkogyId",
                table: "DataUl",
                column: "OkogyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_OkopfId",
                table: "DataUl",
                column: "OkopfId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_OktmoId",
                table: "DataUl",
                column: "OktmoId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_OkvedId",
                table: "DataUl",
                column: "OkvedId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_RegFnsId",
                table: "DataUl",
                column: "RegFnsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_RegFssId",
                table: "DataUl",
                column: "RegFssId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_RegionId",
                table: "DataUl",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_RegPfrId",
                table: "DataUl",
                column: "RegPfrId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_RmspId",
                table: "DataUl",
                column: "RmspId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_StatusId",
                table: "DataUl",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_TaxId",
                table: "DataUl",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_UnscrupulousSupplierRecordId",
                table: "DataUl",
                column: "UnscrupulousSupplierRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_ContactsId",
                table: "Email",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementProceedingRecords_DataUlId",
                table: "EnforcementProceedingRecords",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_FlMo_FounderMoRfId",
                table: "FlMo",
                column: "FounderMoRfId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderFl_DataUlId",
                table: "FounderFl",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderFl_ShareId",
                table: "FounderFl",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderIn_DataUlId",
                table: "FounderIn",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderIn_ShareId",
                table: "FounderIn",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderMoRf_DataUlId",
                table: "FounderMoRf",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderMoRf_RegionId",
                table: "FounderMoRf",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderMoRf_ShareId",
                table: "FounderMoRf",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderPif_ManagingOrganizationId",
                table: "FounderPif",
                column: "ManagingOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderPif_ShareId",
                table: "FounderPif",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderUl_DataUlId",
                table: "FounderUl",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderUl_ShareId",
                table: "FounderUl",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_DataIpId",
                table: "Licenses",
                column: "DataIpId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_DataUlId",
                table: "Licenses",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTax_TaxId",
                table: "PaymentTax",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ContactsId",
                table: "Phones",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaintiffDefendant_AddressId",
                table: "PlaintiffDefendant",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaintiffDefendant_ArbitrationCasesRecordId",
                table: "PlaintiffDefendant",
                column: "ArbitrationCasesRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaintiffDefendant_ArbitrationCasesRecordId1",
                table: "PlaintiffDefendant",
                column: "ArbitrationCasesRecordId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ul_DataIpId",
                table: "Ul",
                column: "DataIpId");

            migrationBuilder.CreateIndex(
                name: "IX_Ul_DataIpId1",
                table: "Ul",
                column: "DataIpId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ul_DataUlId",
                table: "Ul",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_Ul_DataUlId1",
                table: "Ul",
                column: "DataUlId1");

            migrationBuilder.CreateIndex(
                name: "IX_UlShort_DataUlId",
                table: "UlShort",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_UlShort_DataUlId1",
                table: "UlShort",
                column: "DataUlId1");

            migrationBuilder.CreateIndex(
                name: "IX_UlShort_FounderMoRfId",
                table: "UlShort",
                column: "FounderMoRfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Director_DataUl_DataUlId",
                table: "Director",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrn_Director_DirectorId",
                table: "Ogrn",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrn_Director_DirectorId1",
                table: "Ogrn",
                column: "DirectorId1",
                principalTable: "Director",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrn_FounderFl_FounderFlId",
                table: "Ogrn",
                column: "FounderFlId",
                principalTable: "FounderFl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrn_FounderFl_FounderFlId1",
                table: "Ogrn",
                column: "FounderFlId1",
                principalTable: "FounderFl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Okveds_DataIp_DataIpId",
                table: "Okveds",
                column: "DataIpId",
                principalTable: "DataIp",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Okveds_DataUl_DataUlId",
                table: "Okveds",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Director_DataUl_DataUlId",
                table: "Director");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogrn_Director_DirectorId",
                table: "Ogrn");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogrn_Director_DirectorId1",
                table: "Ogrn");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogrn_FounderFl_FounderFlId",
                table: "Ogrn");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogrn_FounderFl_FounderFlId1",
                table: "Ogrn");

            migrationBuilder.DropForeignKey(
                name: "FK_Okveds_DataIp_DataIpId",
                table: "Okveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Okveds_DataUl_DataUlId",
                table: "Okveds");

            migrationBuilder.DropTable(
                name: "Balanceline");

            migrationBuilder.DropTable(
                name: "Branchs");

            migrationBuilder.DropTable(
                name: "CheckCounterparty");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "EnforcementProceedingRecords");

            migrationBuilder.DropTable(
                name: "FlMo");

            migrationBuilder.DropTable(
                name: "FounderFl");

            migrationBuilder.DropTable(
                name: "FounderIn");

            migrationBuilder.DropTable(
                name: "FounderPif");

            migrationBuilder.DropTable(
                name: "FounderUl");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "PaymentTax");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "PlaintiffDefendant");

            migrationBuilder.DropTable(
                name: "Ul");

            migrationBuilder.DropTable(
                name: "UlShort");

            migrationBuilder.DropTable(
                name: "CheckBalances");

            migrationBuilder.DropTable(
                name: "ArbitrationCasesRecords");

            migrationBuilder.DropTable(
                name: "DataIp");

            migrationBuilder.DropTable(
                name: "FounderMoRf");

            migrationBuilder.DropTable(
                name: "DataUl");

            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "AuthorizedCapitals");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "HolderRegisters");

            migrationBuilder.DropTable(
                name: "LegalAddress");

            migrationBuilder.DropTable(
                name: "Likveds");

            migrationBuilder.DropTable(
                name: "ManagingOrganization");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Rmsp");

            migrationBuilder.DropTable(
                name: "Tax");

            migrationBuilder.DropTable(
                name: "UnscrupulousSupplierRecord");

            migrationBuilder.DropTable(
                name: "UrStatus");

            migrationBuilder.DropIndex(
                name: "IX_Okveds_DataIpId",
                table: "Okveds");

            migrationBuilder.DropIndex(
                name: "IX_Okveds_DataUlId",
                table: "Okveds");

            migrationBuilder.DropIndex(
                name: "IX_Ogrn_FounderFlId",
                table: "Ogrn");

            migrationBuilder.DropIndex(
                name: "IX_Ogrn_FounderFlId1",
                table: "Ogrn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.DropIndex(
                name: "IX_Director_DataUlId",
                table: "Director");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "DataIpId",
                table: "Okveds");

            migrationBuilder.DropColumn(
                name: "DataUlId",
                table: "Okveds");

            migrationBuilder.DropColumn(
                name: "FounderFlId",
                table: "Ogrn");

            migrationBuilder.DropColumn(
                name: "FounderFlId1",
                table: "Ogrn");

            migrationBuilder.DropColumn(
                name: "DataUlId",
                table: "Director");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrn_Directors_DirectorId",
                table: "Ogrn",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrn_Directors_DirectorId1",
                table: "Ogrn",
                column: "DirectorId1",
                principalTable: "Directors",
                principalColumn: "Id");
        }
    }
}
