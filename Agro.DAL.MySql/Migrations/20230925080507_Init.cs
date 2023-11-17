using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountingMethodsNds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingMethodsNds", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressRf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GarId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UnreliabilityDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuthorizedCapitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedCapitals", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BasisPayment",
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
                    table.PrimaryKey("PK_BasisPayment", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CheckBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBalances", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClosedPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosedPeriod", x => x.Id);
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
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviated = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
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
                name: "Founders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeApplication = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
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
                name: "Kbk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReceiptAdministratorCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IncomeTypeCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IncomeSubspeciesCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kosgu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kbk", x => x.Id);
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
                    Ogrn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
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
                name: "Ndses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Percent = table.Column<int>(type: "int", nullable: false),
                    OverPercent = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ndses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Okato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okato", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Okfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okfs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Okogy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okogy", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Okopf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okopf", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Oktmo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oktmo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderPayment",
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
                    table.PrimaryKey("PK_OrderPayment", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PayerStatus",
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
                    table.PrimaryKey("PK_PayerStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentDestination",
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
                    table.PrimaryKey("PK_PaymentDestination", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegFns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodeFns = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameFns = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFns = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegFns", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegFss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateReg = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RegNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeFss = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameFss = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegFss", x => x.Id);
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
                name: "RegPfr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateReg = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RegNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodePfr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NamePfr = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegPfr", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rmsp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                name: "Sittings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LimitAmountInvoice = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sittings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PayAmount = table.Column<float>(type: "float", nullable: true),
                    ArrearsAmount = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaxPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tax1 = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tax2 = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TaxYear = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPeriod", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeCashFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direction = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCashFlow", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeOperationsPay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOperationsPay", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypePayment",
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
                    table.PrimaryKey("PK_TypePayment", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeApplication = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypesCommitments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesCommitments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeTransactions",
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
                    table.PrimaryKey("PK_TypeTransactions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UnitsOkei",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OkeiCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOkei", x => x.Id);
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
                name: "Balanceline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LineCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LineAmount = table.Column<int>(type: "int", nullable: false),
                    AmountPreviousYear = table.Column<int>(type: "int", nullable: true),
                    AmountPrecedingPreviousYear = table.Column<int>(type: "int", nullable: false),
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
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kpp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LegalAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    FounderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderFl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderFl_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
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
                    FounderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderIn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderIn_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
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
                    FounderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderMoRf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderMoRf_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
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
                    ShareId = table.Column<int>(type: "int", nullable: false),
                    FounderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderPif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderPif_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
                        principalColumn: "Id");
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
                    FounderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderUl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FounderUl_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
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
                name: "AccountingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentPlanId = table.Column<int>(type: "int", nullable: true),
                    IsSelect = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingPlans_AccountingPlans_ParentPlanId",
                        column: x => x.ParentPlanId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountingPlans_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    AbbreviatedName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GroupObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupObjects_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvoiceFacturs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceFacturs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceFacturs_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SurnameRp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SurnameDp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SurnameTp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameRp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameDp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameTp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatronymicRp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatronymicDp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatronymicTp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Inn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Snils = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistryInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateDispatch = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistryInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistryInvoices_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    OrderNamber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffList_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StorageLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeApplication = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageLocations_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    CarBrand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrailerNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transports_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypesObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypesObject_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModeNalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TaxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeNalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeNalog_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id");
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
                name: "ExpenditureItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeCashFlowId = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditureItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenditureItems_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenditureItems_TypeCashFlow_TypeCashFlowId",
                        column: x => x.TypeCashFlowId,
                        principalTable: "TypeCashFlow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemsExpenditureOrIncome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeCashFlowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsExpenditureOrIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsExpenditureOrIncome_TypeCashFlow_TypeCashFlowId",
                        column: x => x.TypeCashFlowId,
                        principalTable: "TypeCashFlow",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Counterparties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    TypeDocId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    PayName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kpp = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ogrn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Okpo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActualAddressId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counterparties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counterparties_Addresses_ActualAddressId",
                        column: x => x.ActualAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Counterparties_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Counterparties_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Counterparties_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LandPlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    BalanceValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandPlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandPlots_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LandPlots_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaxKbk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KbkId = table.Column<int>(type: "int", nullable: false),
                    TypeCommitmentId = table.Column<int>(type: "int", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxKbk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxKbk_Kbk_KbkId",
                        column: x => x.KbkId,
                        principalTable: "Kbk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxKbk_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxKbk_TypesCommitments_TypeCommitmentId",
                        column: x => x.TypeCommitmentId,
                        principalTable: "TypesCommitments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    NameMini = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    NdsId = table.Column<int>(type: "int", nullable: true),
                    ArticleNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Ndses_NdsId",
                        column: x => x.NdsId,
                        principalTable: "Ndses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_UnitsOkei_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitsOkei",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tmc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    ArticleNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    PercentageActiveSubstance = table.Column<double>(type: "double", nullable: false),
                    Description = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tmc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tmc_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tmc_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tmc_UnitsOkei_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitsOkei",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ComingTmcCalculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountingPlanId = table.Column<int>(type: "int", nullable: false),
                    AccountingPlanPrepaymentId = table.Column<int>(type: "int", nullable: false),
                    AutoCalculation = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ManualCalculation = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NoCalculation = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComingTmcCalculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComingTmcCalculations_AccountingPlans_AccountingPlanId",
                        column: x => x.AccountingPlanId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingTmcCalculations_AccountingPlans_AccountingPlanPrepayme~",
                        column: x => x.AccountingPlanPrepaymentId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PurposeExpenditures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountingPlanId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeExpenditures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurposeExpenditures_AccountingPlans_AccountingPlanId",
                        column: x => x.AccountingPlanId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurposeExpenditures_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Areal = table.Column<double>(type: "double", nullable: false),
                    ParentFieldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fields_Fields_ParentFieldId",
                        column: x => x.ParentFieldId,
                        principalTable: "Fields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fields_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    TypeDocId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    NameDocument = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Series = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateIssue = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Issuing = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeIssuing = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PeopleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DriverTransport",
                columns: table => new
                {
                    DriversId = table.Column<int>(type: "int", nullable: false),
                    TransportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverTransport", x => new { x.DriversId, x.TransportsId });
                    table.ForeignKey(
                        name: "FK_DriverTransport_Drivers_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverTransport_Transports_TransportsId",
                        column: x => x.TransportsId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WriteOffObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TypeObjectId = table.Column<int>(type: "int", nullable: false),
                    GroupObjectId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InvNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteOffObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WriteOffObjects_GroupObjects_GroupObjectId",
                        column: x => x.GroupObjectId,
                        principalTable: "GroupObjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WriteOffObjects_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WriteOffObjects_TypesObject_TypeObjectId",
                        column: x => x.TypeObjectId,
                        principalTable: "TypesObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypesOperationCash",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeDocId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemExpenditureOrIncomeId = table.Column<int>(type: "int", nullable: true),
                    AccountingPlanId = table.Column<int>(type: "int", nullable: true),
                    IsAccountingPlan = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOperationCash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypesOperationCash_AccountingPlans_AccountingPlanId",
                        column: x => x.AccountingPlanId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TypesOperationCash_ItemsExpenditureOrIncome_ItemExpenditureO~",
                        column: x => x.ItemExpenditureOrIncomeId,
                        principalTable: "ItemsExpenditureOrIncome",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TypesOperationCash_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    YearHarvest = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cultures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cultures_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RulesAccounting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    AccountingPlanId = table.Column<int>(type: "int", nullable: false),
                    AccountingPlanNdsId = table.Column<int>(type: "int", nullable: true),
                    AccountingMethodNdsId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TaxesId = table.Column<int>(type: "int", nullable: true),
                    TmcId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RulesAccounting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RulesAccounting_AccountingMethodsNds_AccountingMethodNdsId",
                        column: x => x.AccountingMethodNdsId,
                        principalTable: "AccountingMethodsNds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RulesAccounting_AccountingPlans_AccountingPlanId",
                        column: x => x.AccountingPlanId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RulesAccounting_AccountingPlans_AccountingPlanNdsId",
                        column: x => x.AccountingPlanNdsId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RulesAccounting_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RulesAccounting_Taxes_TaxesId",
                        column: x => x.TaxesId,
                        principalTable: "Taxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RulesAccounting_Tmc_TmcId",
                        column: x => x.TmcId,
                        principalTable: "Tmc",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComingTmc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    NumberDoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDoc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RegNumber = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsOriginal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComingTmcCalculationsId = table.Column<int>(type: "int", nullable: false),
                    InvoiceFacturId = table.Column<int>(type: "int", nullable: true),
                    IsUpd = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComingTmc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComingTmc_ComingTmcCalculations_ComingTmcCalculationsId",
                        column: x => x.ComingTmcCalculationsId,
                        principalTable: "ComingTmcCalculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingTmc_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingTmc_InvoiceFacturs_InvoiceFacturId",
                        column: x => x.InvoiceFacturId,
                        principalTable: "InvoiceFacturs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComingTmc_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FieldLandPlot",
                columns: table => new
                {
                    FieldsId = table.Column<int>(type: "int", nullable: false),
                    LandPlotsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldLandPlot", x => new { x.FieldsId, x.LandPlotsId });
                    table.ForeignKey(
                        name: "FK_FieldLandPlot_Fields_FieldsId",
                        column: x => x.FieldsId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldLandPlot_LandPlots_LandPlotsId",
                        column: x => x.LandPlotsId,
                        principalTable: "LandPlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComingTmcPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ComingTmcId = table.Column<int>(type: "int", nullable: false),
                    TmcId = table.Column<int>(type: "int", nullable: false),
                    UnitOkeiId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NdsId = table.Column<int>(type: "int", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AccountingAccountId = table.Column<int>(type: "int", nullable: false),
                    AccountingAccountNdsId = table.Column<int>(type: "int", nullable: true),
                    StorageLocationId = table.Column<int>(type: "int", nullable: false),
                    AccountingMethodNdsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComingTmcPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComingTmcPositions_AccountingMethodsNds_AccountingMethodNdsId",
                        column: x => x.AccountingMethodNdsId,
                        principalTable: "AccountingMethodsNds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComingTmcPositions_AccountingPlans_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingTmcPositions_AccountingPlans_AccountingAccountNdsId",
                        column: x => x.AccountingAccountNdsId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComingTmcPositions_ComingTmc_ComingTmcId",
                        column: x => x.ComingTmcId,
                        principalTable: "ComingTmc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingTmcPositions_Ndses_NdsId",
                        column: x => x.NdsId,
                        principalTable: "Ndses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingTmcPositions_StorageLocations_StorageLocationId",
                        column: x => x.StorageLocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingTmcPositions_Tmc_TmcId",
                        column: x => x.TmcId,
                        principalTable: "Tmc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingTmcPositions_UnitsOkei_UnitOkeiId",
                        column: x => x.UnitOkeiId,
                        principalTable: "UnitsOkei",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AccountingPlanRegisters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateReg = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DebitId = table.Column<int>(type: "int", nullable: false),
                    CreditId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ContaDoc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaAction = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaParty = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContaObject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComingTmcId = table.Column<int>(type: "int", nullable: true),
                    DecommissioningTmcId = table.Column<int>(type: "int", nullable: true),
                    DocCashId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingPlanRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingPlanRegisters_AccountingPlans_CreditId",
                        column: x => x.CreditId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountingPlanRegisters_AccountingPlans_DebitId",
                        column: x => x.DebitId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountingPlanRegisters_ComingTmc_ComingTmcId",
                        column: x => x.ComingTmcId,
                        principalTable: "ComingTmc",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdvanceProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NameDoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberDoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDoc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TmcId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NdsId = table.Column<int>(type: "int", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AccountingPlanId = table.Column<int>(type: "int", nullable: false),
                    AccountingPlanNdsId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: true),
                    AdvanceReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvanceProduct_AccountingPlans_AccountingPlanId",
                        column: x => x.AccountingPlanId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvanceProduct_AccountingPlans_AccountingPlanNdsId",
                        column: x => x.AccountingPlanNdsId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvanceProduct_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceProduct_Ndses_NdsId",
                        column: x => x.NdsId,
                        principalTable: "Ndses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvanceProduct_Tmc_TmcId",
                        column: x => x.TmcId,
                        principalTable: "Tmc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdvanceReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Appointment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnnexesDoc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnnexesSheet = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserCreatorId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvanceReport_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_PlaintiffDefendant_ArbitrationCasesRecords_ArbitrationCasesR~",
                        column: x => x.ArbitrationCasesRecordId,
                        principalTable: "ArbitrationCasesRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaintiffDefendant_ArbitrationCasesRecords_ArbitrationCases~1",
                        column: x => x.ArbitrationCasesRecordId1,
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
                name: "BankDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    NameBank = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bs = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Bik = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ks = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMain = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDetails_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankDetails_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankDetails_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsOrgId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_BankDetails_BankDetailsId",
                        column: x => x.BankDetailsId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_BankDetails_BankDetailsOrgId",
                        column: x => x.BankDetailsOrgId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specifications_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateInvoice = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    SpecificationId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NdsId = table.Column<int>(type: "int", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankDetailsOrgId = table.Column<int>(type: "int", nullable: true),
                    RegistryInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_BankDetails_BankDetailsId",
                        column: x => x.BankDetailsId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_BankDetails_BankDetailsOrgId",
                        column: x => x.BankDetailsOrgId,
                        principalTable: "BankDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Ndses_NdsId",
                        column: x => x.NdsId,
                        principalTable: "Ndses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_RegistryInvoices_RegistryInvoiceId",
                        column: x => x.RegistryInvoiceId,
                        principalTable: "RegistryInvoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductsInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NdsId = table.Column<int>(type: "int", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsInvoice_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInvoice_Ndses_NdsId",
                        column: x => x.NdsId,
                        principalTable: "Ndses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInvoice_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScanFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BodyBytes = table.Column<byte[]>(type: "longblob", nullable: false),
                    TotalBytes = table.Column<double>(type: "double", nullable: false),
                    ComingTmcId = table.Column<int>(type: "int", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScanFiles_ComingTmc_ComingTmcId",
                        column: x => x.ComingTmcId,
                        principalTable: "ComingTmc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScanFiles_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScanFiles_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
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
                    ResultStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckCounterparty", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComingFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WeightId = table.Column<int>(type: "int", nullable: false),
                    StorageLocationId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    CultureId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false),
                    VesBrutto = table.Column<double>(type: "double", nullable: false),
                    VesTara = table.Column<double>(type: "double", nullable: false),
                    VesNetto = table.Column<double>(type: "double", nullable: false),
                    VesNettoAcros = table.Column<double>(type: "double", nullable: false),
                    VesNettoTucano = table.Column<double>(type: "double", nullable: false),
                    VesNettoDon = table.Column<double>(type: "double", nullable: false),
                    Humidity = table.Column<double>(type: "double", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComingFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComingFields_Cultures_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cultures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingFields_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingFields_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComingFields_StorageLocations_StorageLocationId",
                        column: x => x.StorageLocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComingFields_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_DataIp_RegPfr_RegPfrId",
                        column: x => x.RegPfrId,
                        principalTable: "RegPfr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataIp_Rmsp_RmspId",
                        column: x => x.RmspId,
                        principalTable: "Rmsp",
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
                    AuthorizedCapitalId = table.Column<int>(type: "int", nullable: true),
                    ManagingOrganizationId = table.Column<int>(type: "int", nullable: true),
                    FounderId = table.Column<int>(type: "int", nullable: true),
                    HolderRegisterId = table.Column<int>(type: "int", nullable: true),
                    DivisionsId = table.Column<int>(type: "int", nullable: true),
                    DateDischarge = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ContactsId = table.Column<int>(type: "int", nullable: true),
                    TaxId = table.Column<int>(type: "int", nullable: true),
                    RmspId = table.Column<int>(type: "int", nullable: true),
                    Srh = table.Column<int>(type: "int", nullable: false),
                    Unscrupulous = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisqualifiedPersons = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MassManagers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MassFounders = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FinancialStatementsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataUl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataUl_AuthorizedCapitals_AuthorizedCapitalId",
                        column: x => x.AuthorizedCapitalId,
                        principalTable: "AuthorizedCapitals",
                        principalColumn: "Id");
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
                        name: "FK_DataUl_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataUl_HolderRegisters_HolderRegisterId",
                        column: x => x.HolderRegisterId,
                        principalTable: "HolderRegisters",
                        principalColumn: "Id");
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
                        name: "FK_DataUl_RegPfr_RegPfrId",
                        column: x => x.RegPfrId,
                        principalTable: "RegPfr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataUl_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
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
                        name: "FK_DataUl_UrStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "UrStatus",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypePosition = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NamePosition = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MassManager = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisqualifiedPerson = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisqualifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DisqualifiedOff = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Director_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
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
                name: "Okveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Version = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataIpId = table.Column<int>(type: "int", nullable: true),
                    DataUlId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Okveds_DataIp_DataIpId",
                        column: x => x.DataIpId,
                        principalTable: "DataIp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Okveds_DataUl_DataUlId",
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

            migrationBuilder.CreateTable(
                name: "UnscrupulousSupplierRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DatePublication = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateApproval = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ShortName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kpp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchaseNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurchaseDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContractPrice = table.Column<int>(type: "int", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnscrupulousSupplierRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnscrupulousSupplierRecord_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ogrn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumberOgrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DirectorId = table.Column<int>(type: "int", nullable: true),
                    DirectorId1 = table.Column<int>(type: "int", nullable: true),
                    FounderFlId = table.Column<int>(type: "int", nullable: true),
                    FounderFlId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogrn_Director_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ogrn_Director_DirectorId1",
                        column: x => x.DirectorId1,
                        principalTable: "Director",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ogrn_FounderFl_FounderFlId",
                        column: x => x.FounderFlId,
                        principalTable: "FounderFl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ogrn_FounderFl_FounderFlId1",
                        column: x => x.FounderFlId1,
                        principalTable: "FounderFl",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LicViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ViewLic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicenseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicViews_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UlId = table.Column<int>(type: "int", nullable: false),
                    CheckBalanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialStatements_CheckBalances_CheckBalanceId",
                        column: x => x.CheckBalanceId,
                        principalTable: "CheckBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialStatements_Ul_UlId",
                        column: x => x.UlId,
                        principalTable: "Ul",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DebitingAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TypeOperationId = table.Column<int>(type: "int", nullable: true),
                    PaymentOrderId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NdsId = table.Column<int>(type: "int", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsOrganizationId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsCounterpartyId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    DebitId = table.Column<int>(type: "int", nullable: true),
                    CreditId = table.Column<int>(type: "int", nullable: true),
                    ExpenditureItemId = table.Column<int>(type: "int", nullable: true),
                    ComingTmcCalculationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitingAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebitingAccount_AccountingPlans_CreditId",
                        column: x => x.CreditId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebitingAccount_AccountingPlans_DebitId",
                        column: x => x.DebitId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebitingAccount_BankDetails_BankDetailsCounterpartyId",
                        column: x => x.BankDetailsCounterpartyId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebitingAccount_BankDetails_BankDetailsOrganizationId",
                        column: x => x.BankDetailsOrganizationId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebitingAccount_ComingTmcCalculations_ComingTmcCalculationsId",
                        column: x => x.ComingTmcCalculationsId,
                        principalTable: "ComingTmcCalculations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebitingAccount_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebitingAccount_ExpenditureItems_ExpenditureItemId",
                        column: x => x.ExpenditureItemId,
                        principalTable: "ExpenditureItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebitingAccount_Ndses_NdsId",
                        column: x => x.NdsId,
                        principalTable: "Ndses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebitingAccount_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebitingAccount_Types_TypeOperationId",
                        column: x => x.TypeOperationId,
                        principalTable: "Types",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DecommissioningTmc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TypeDocId = table.Column<int>(type: "int", nullable: false),
                    DecommissioningStornoId = table.Column<int>(type: "int", nullable: true),
                    PurposeExpenditureId = table.Column<int>(type: "int", nullable: false),
                    WriteOffObjectId = table.Column<int>(type: "int", nullable: false),
                    StorekeeperId = table.Column<int>(type: "int", nullable: false),
                    MolId = table.Column<int>(type: "int", nullable: false),
                    AccountingPlanId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecommissioningTmc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_AccountingPlans_AccountingPlanId",
                        column: x => x.AccountingPlanId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_DecommissioningTmc_DecommissioningStornoId",
                        column: x => x.DecommissioningStornoId,
                        principalTable: "DecommissioningTmc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_PurposeExpenditures_PurposeExpenditureId",
                        column: x => x.PurposeExpenditureId,
                        principalTable: "PurposeExpenditures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_WriteOffObjects_WriteOffObjectId",
                        column: x => x.WriteOffObjectId,
                        principalTable: "WriteOffObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PositionDecommissioningTmc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DecommissioningTmcId = table.Column<int>(type: "int", nullable: false),
                    TmcId = table.Column<int>(type: "int", nullable: false),
                    UnitOkeiId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AccountingPlanId = table.Column<int>(type: "int", nullable: false),
                    StorageLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionDecommissioningTmc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionDecommissioningTmc_AccountingPlans_AccountingPlanId",
                        column: x => x.AccountingPlanId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionDecommissioningTmc_DecommissioningTmc_Decommissionin~",
                        column: x => x.DecommissioningTmcId,
                        principalTable: "DecommissioningTmc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionDecommissioningTmc_StorageLocations_StorageLocationId",
                        column: x => x.StorageLocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionDecommissioningTmc_Tmc_TmcId",
                        column: x => x.TmcId,
                        principalTable: "Tmc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionDecommissioningTmc_UnitsOkei_UnitOkeiId",
                        column: x => x.UnitOkeiId,
                        principalTable: "UnitsOkei",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TmcRegisters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeDocId = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ComingTmcId = table.Column<int>(type: "int", nullable: true),
                    DecommissioningTmcId = table.Column<int>(type: "int", nullable: true),
                    TmcId = table.Column<int>(type: "int", nullable: false),
                    UnitOkeiId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DebitId = table.Column<int>(type: "int", nullable: false),
                    CreditId = table.Column<int>(type: "int", nullable: false),
                    StorageLocationId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmcRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TmcRegisters_AccountingPlans_CreditId",
                        column: x => x.CreditId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmcRegisters_AccountingPlans_DebitId",
                        column: x => x.DebitId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmcRegisters_ComingTmc_ComingTmcId",
                        column: x => x.ComingTmcId,
                        principalTable: "ComingTmc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TmcRegisters_DecommissioningTmc_DecommissioningTmcId",
                        column: x => x.DecommissioningTmcId,
                        principalTable: "DecommissioningTmc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TmcRegisters_StorageLocations_StorageLocationId",
                        column: x => x.StorageLocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmcRegisters_Tmc_TmcId",
                        column: x => x.TmcId,
                        principalTable: "Tmc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmcRegisters_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TmcRegisters_UnitsOkei_UnitOkeiId",
                        column: x => x.UnitOkeiId,
                        principalTable: "UnitsOkei",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    TabNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffListPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StaffListId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffListPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffListPositions_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffListPositions_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffListPositions_StaffList_StaffListId",
                        column: x => x.StaffListId,
                        principalTable: "StaffList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OfficialPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StorageLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialPersons_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficialPersons_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfficialPersons_StorageLocations_StorageLocationId",
                        column: x => x.StorageLocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AbbreviatedName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kpp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ogrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Okpo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OkvedId = table.Column<int>(type: "int", nullable: false),
                    OkopfId = table.Column<int>(type: "int", nullable: true),
                    OkfsId = table.Column<int>(type: "int", nullable: true),
                    OkogyId = table.Column<int>(type: "int", nullable: true),
                    OkatoId = table.Column<int>(type: "int", nullable: true),
                    OktmoId = table.Column<int>(type: "int", nullable: true),
                    RegFnsId = table.Column<int>(type: "int", nullable: true),
                    RegPfrId = table.Column<int>(type: "int", nullable: true),
                    RegFssId = table.Column<int>(type: "int", nullable: true),
                    AddressUrId = table.Column<int>(type: "int", nullable: true),
                    DirectorId = table.Column<int>(type: "int", nullable: true),
                    GeneralAccountantId = table.Column<int>(type: "int", nullable: true),
                    CashierId = table.Column<int>(type: "int", nullable: true),
                    HrId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Addresses_AddressUrId",
                        column: x => x.AddressUrId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Employee_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Employee_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Employee_GeneralAccountantId",
                        column: x => x.GeneralAccountantId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Employee_HrId",
                        column: x => x.HrId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Okato_OkatoId",
                        column: x => x.OkatoId,
                        principalTable: "Okato",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Okfs_OkfsId",
                        column: x => x.OkfsId,
                        principalTable: "Okfs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Okogy_OkogyId",
                        column: x => x.OkogyId,
                        principalTable: "Okogy",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Okopf_OkopfId",
                        column: x => x.OkopfId,
                        principalTable: "Okopf",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Oktmo_OktmoId",
                        column: x => x.OktmoId,
                        principalTable: "Oktmo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Okveds_OkvedId",
                        column: x => x.OkvedId,
                        principalTable: "Okveds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_RegFns_RegFnsId",
                        column: x => x.RegFnsId,
                        principalTable: "RegFns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_RegFss_RegFssId",
                        column: x => x.RegFssId,
                        principalTable: "RegFss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_RegPfr_RegPfrId",
                        column: x => x.RegPfrId,
                        principalTable: "RegPfr",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeigherId = table.Column<int>(type: "int", nullable: true),
                    Terminal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weights_Employee_WeigherId",
                        column: x => x.WeigherId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Weights_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocsCash",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeDocId = table.Column<int>(type: "int", nullable: false),
                    TypeOperationCashId = table.Column<int>(type: "int", nullable: true),
                    ItemExpenditureOrIncomeId = table.Column<int>(type: "int", nullable: true),
                    NdsId = table.Column<int>(type: "int", nullable: true),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    DebitId = table.Column<int>(type: "int", nullable: false),
                    CreditId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: true),
                    CounterpartyId = table.Column<int>(type: "int", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    BankDetailsOrgId = table.Column<int>(type: "int", nullable: true),
                    StorageLocationId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    From = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FoundationDoc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Footing = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApplicationDoc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DirectorId = table.Column<int>(type: "int", nullable: true),
                    GeneralAccountantId = table.Column<int>(type: "int", nullable: true),
                    CashierId = table.Column<int>(type: "int", nullable: true),
                    AdvanceReportId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserCreatorId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocsCash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocsCash_AccountingPlans_CreditId",
                        column: x => x.CreditId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocsCash_AccountingPlans_DebitId",
                        column: x => x.DebitId,
                        principalTable: "AccountingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocsCash_AdvanceReport_AdvanceReportId",
                        column: x => x.AdvanceReportId,
                        principalTable: "AdvanceReport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_BankDetails_BankDetailsOrgId",
                        column: x => x.BankDetailsOrgId,
                        principalTable: "BankDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Employee_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Employee_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Employee_GeneralAccountantId",
                        column: x => x.GeneralAccountantId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_ItemsExpenditureOrIncome_ItemExpenditureOrIncomeId",
                        column: x => x.ItemExpenditureOrIncomeId,
                        principalTable: "ItemsExpenditureOrIncome",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Ndses_NdsId",
                        column: x => x.NdsId,
                        principalTable: "Ndses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocsCash_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocsCash_StorageLocations_StorageLocationId",
                        column: x => x.StorageLocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_TypesOperationCash_TypeOperationCashId",
                        column: x => x.TypeOperationCashId,
                        principalTable: "TypesOperationCash",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocsCash_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocsCash_Users_UserCreatorId",
                        column: x => x.UserCreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeOperationId = table.Column<int>(type: "int", nullable: false),
                    TaxId = table.Column<int>(type: "int", nullable: true),
                    TypeCommitmentId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    NdsId = table.Column<int>(type: "int", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypePaymentId = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsOrganizationId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsCounterpartyId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    TypeTransactionsId = table.Column<int>(type: "int", nullable: false),
                    PaymentTerm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PaymentDestinationCodeId = table.Column<int>(type: "int", nullable: true),
                    OrderPaymentId = table.Column<int>(type: "int", nullable: false),
                    Uip = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BackupField = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurposePayment = table.Column<string>(type: "varchar(210)", maxLength: 210, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentTerms = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeadlineAcceptance = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PayoutCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReceiptBank = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateDebiting = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PayerStatusId = table.Column<int>(type: "int", nullable: true),
                    Kbk = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Oktmo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BasisPaymentId = table.Column<int>(type: "int", nullable: true),
                    TaxPeriodId = table.Column<int>(type: "int", nullable: true),
                    NumberDoc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDoc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NalogTypePayment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdvanceReportId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserCreatorId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_AdvanceReport_AdvanceReportId",
                        column: x => x.AdvanceReportId,
                        principalTable: "AdvanceReport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_BankDetails_BankDetailsCounterpartyId",
                        column: x => x.BankDetailsCounterpartyId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_BankDetails_BankDetailsOrganizationId",
                        column: x => x.BankDetailsOrganizationId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_BasisPayment_BasisPaymentId",
                        column: x => x.BasisPaymentId,
                        principalTable: "BasisPayment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Ndses_NdsId",
                        column: x => x.NdsId,
                        principalTable: "Ndses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_OrderPayment_OrderPaymentId",
                        column: x => x.OrderPaymentId,
                        principalTable: "OrderPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_PayerStatus_PayerStatusId",
                        column: x => x.PayerStatusId,
                        principalTable: "PayerStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_PaymentDestination_PaymentDestinationCodeId",
                        column: x => x.PaymentDestinationCodeId,
                        principalTable: "PaymentDestination",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_TaxPeriod_TaxPeriodId",
                        column: x => x.TaxPeriodId,
                        principalTable: "TaxPeriod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_TypeOperationsPay_TypeOperationId",
                        column: x => x.TypeOperationId,
                        principalTable: "TypeOperationsPay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_TypePayment_TypePaymentId",
                        column: x => x.TypePaymentId,
                        principalTable: "TypePayment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_TypeTransactions_TypeTransactionsId",
                        column: x => x.TypeTransactionsId,
                        principalTable: "TypeTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOrder_TypesCommitments_TypeCommitmentId",
                        column: x => x.TypeCommitmentId,
                        principalTable: "TypesCommitments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Users_UserCreatorId",
                        column: x => x.UserCreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EventHistory = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdvanceReportId = table.Column<int>(type: "int", nullable: true),
                    ComingTmcId = table.Column<int>(type: "int", nullable: true),
                    DecommissioningTmcId = table.Column<int>(type: "int", nullable: true),
                    DocCashId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    PaymentOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_AdvanceReport_AdvanceReportId",
                        column: x => x.AdvanceReportId,
                        principalTable: "AdvanceReport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_History_ComingTmc_ComingTmcId",
                        column: x => x.ComingTmcId,
                        principalTable: "ComingTmc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_History_DecommissioningTmc_DecommissioningTmcId",
                        column: x => x.DecommissioningTmcId,
                        principalTable: "DecommissioningTmc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_History_DocsCash_DocCashId",
                        column: x => x.DocCashId,
                        principalTable: "DocsCash",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_History_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_History_PaymentOrder_PaymentOrderId",
                        column: x => x.PaymentOrderId,
                        principalTable: "PaymentOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_History_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AccountingMethodsNds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Принимать к вачету" },
                    { 2, "Учитывается в стоимости товара" }
                });

            migrationBuilder.InsertData(
                table: "BasisPayment",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "0", "НЕ УКАЗАНО" },
                    { 2, "ТП", "Платежи текущего года" },
                    { 3, "ЗД", "Погашение задолженности, по истекшим налоговым, расчетным (отчетным) периодам, в том числе добровольное" },
                    { 4, "РС", "Погашение рассроченной задолженности" },
                    { 5, "ОТ", "Погашение отсроченной задолженности" },
                    { 6, "РТ", "Погашение реструктурируемой задолженности" },
                    { 7, "ПБ", "Погашение должником задолженности в ходе процедур, применяемых в деле о банкротстве" },
                    { 8, "ИН", "Погашение инвестиционного налогового кредита" },
                    { 9, "ТЛ", "Погашение учредителем (участником) должника, собственником имущества должника - унитарного предприятия или третьим лицом требований к должнику об уплате обязательных платежей в ходе процедур, применяемых в деле о банкротстве" },
                    { 10, "ЗТ", "Погашение текущей задолженности в ходе процедур, применяемых в деле о банкротстве" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Abbreviated", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "RUR", "810", "РОССИЙСКИЙ РУБЛЬ" },
                    { 2, "USD", "840", "ДОЛЛАР США" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[,]
                {
                    { 1, "Покупатели", "Контрагенты" },
                    { 2, "Поставщики", "Контрагенты" },
                    { 3, "Зерновые", "Готовая продукция" },
                    { 4, "Масляничные", "Готовая продукция" },
                    { 5, "Технические", "Готовая продукция" },
                    { 6, "Отходы", "Готовая продукция" },
                    { 7, "Средства защиты растений", "МПЗ" },
                    { 8, "Удобрения", "МПЗ" },
                    { 9, "Семена", "МПЗ" },
                    { 10, "Запасные части", "МПЗ" },
                    { 11, "Материалы", "МПЗ" },
                    { 12, "Малоценные товары, инвентарь", "МПЗ" },
                    { 13, "ГСМ", "МПЗ" },
                    { 14, "Паспорт гражданина РФ", "Удостоверение личности" },
                    { 15, "Загранпаспорт гражданина РФ", "Удостоверение личности" },
                    { 16, "Свидетельство о рождении", "Удостоверение личности" },
                    { 17, "Временное удостоверение личности", "Удостоверение личности" },
                    { 18, "Удостоверение личности военнослужащего РФ (военный билет, паспорт моряка)", "Удостоверение личности" },
                    { 19, "Вид на жительство", "Удостоверение личности" },
                    { 20, "Прочий документ", "Прочие документы" },
                    { 21, "Закупка", "Контракт" },
                    { 22, "Продажа", "Контракт" }
                });

            migrationBuilder.InsertData(
                table: "ItemsExpenditureOrIncome",
                columns: new[] { "Id", "Name", "TypeCashFlowId" },
                values: new object[] { 1, "Пополнение расчетного счета", null });

            migrationBuilder.InsertData(
                table: "Ndses",
                columns: new[] { "Id", "Name", "OverPercent", "Percent" },
                values: new object[,]
                {
                    { 1, "Без НДС", 1m, 0 },
                    { 2, "0%", 1m, 0 },
                    { 3, "10%", 1.1m, 10 },
                    { 4, "20%", 1.2m, 20 }
                });

            migrationBuilder.InsertData(
                table: "OrderPayment",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "1", "Платежи по исполнительным документам (алименты, требования о возмещении вреда, причиненного жизни или здоровью" },
                    { 2, "2", "Платежи по исполнительным документам (оплата труда)" },
                    { 3, "3", "Платежи по оплате труда и платежи по поручениям (требованиям) контролирующих органов" },
                    { 4, "4", "Платежи по прочим исполнительным документам" },
                    { 5, "5", "Прочие платежи (в т.ч. налоги и взносы)" }
                });

            migrationBuilder.InsertData(
                table: "PayerStatus",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "01", "Налогоплательщик (плательщик сборов, страховых взносов и иных платежей, администрируемых налоговыми органами) - юридическое лицо" },
                    { 2, "02", "Налоговый агент" },
                    { 3, "03", "Организация федеральной почтовой связи, составившая распоряжение о переводе денежных средств по каждому платежу физического лица, за исключением уплаты таможенных платежей" },
                    { 4, "04", "Налоговый орган" },
                    { 5, "05", "Федеральная служба судебных приставов и ее территориальные органы" },
                    { 6, "06", "Участник внешнеэкономической деятельности - юридическое лицо, за исключением получателя международного почтового отправления (за исключением платежей, администрируемых налоговыми органами)" },
                    { 7, "07", "Таможенный орган (за исключением платежей, администрируемых налоговыми органами)" },
                    { 8, "08", "Плательщик - юридическое лицо, индивидуальный предприниматель, нотариус, занимающийся частной практикой, адвокат, учредивший адвокатский кабинет, глава крестьянского (фермерского) хозяйства, осуществляющие перевод денежных средств в уплату платежей в бюджетную систему Российской Федерации (за исключением платежей, администрируемых налоговыми и таможенными органами)" },
                    { 9, "13", "Налогоплательщик (плательщик сборов, страховых взносов и иных платежей, администрируемых налоговыми органами) - физическое лицо, индивидуальный предприниматель, нотариус, занимающийся частной практикой, адвокат, учредивший адвокатский кабинет, глава крестьянского (фермерского) хозяйства" },
                    { 10, "15", "Кредитная организация (филиал кредитной организации), платежный агент, организация федеральной почтовой связи, составившие платежное поручение на общую сумму с реестром на перевод денежных средств, принятых от плательщиков - физических лиц" },
                    { 11, "17", "Участник внешнеэкономической деятельности - индивидуальный предприниматель (за исключением платежей, администрируемых налоговыми органами)" },
                    { 12, "19", "Организации и их филиалы (далее - организации), составившие распоряжение о переводе денежных средств, удержанных из заработной платы (дохода) должника - физического лица в счет погашения задолженности по платежам в бюджетную систему Российской Федерации на основании исполнительного документа, направленного в организацию в установленном порядке (за исключением платежей, администрируемых налоговыми и таможенными органами)" },
                    { 13, "20", "Кредитная организация (филиал кредитной организации), платежный агент, составившие распоряжение о переводе денежных средств по каждому платежу физического лица (за исключением платежей, администрируемых налоговыми и таможенными органами)" },
                    { 14, "23", "Фонд социального страхования Российской Федерации (за исключением платежей, администрируемых налоговыми органами)" },
                    { 15, "24", "Плательщик - физическое лицо, осуществляющее перевод денежных средств в уплату сборов, страховых взносов, администрируемых Фондом социального страхования Российской Федерации, и иных платежей в бюджетную систему Российской Федерации (за исключением платежей, администрируемых налоговыми и таможенными органами)" },
                    { 16, "27", "Кредитные организации (филиалы кредитных организаций), составившие распоряжение о переводе денежных средств, перечисленных из бюджетной системы Российской Федерации, не зачисленных получателю и подлежащих возврату в бюджетную систему Российской Федерации" },
                    { 17, "28", "Участник внешнеэкономической деятельности - получатель международного почтового отправления (за исключением платежей, администрируемых налоговыми органами)" },
                    { 18, "29", "Политическая партия, избирательное объединение, инициативная группа по проведению референдума, кандидат, зарегистрированный кандидат или уполномоченный представитель инициативной группы по проведению референдума, инициативная агитационная группа при перечислении денежных средств в бюджетную систему Российской Федерации со специальных избирательных счетов и специальных счетов фондов референдума (за исключением платежей, администрируемых налоговыми органами)" },
                    { 19, "30", "Иностранное лицо, не состоящее на учете в налоговых органах Российской Федерации (при уплате платежей, администрируемых таможенными органами)" }
                });

            migrationBuilder.InsertData(
                table: "PaymentDestination",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "1", "Перевод денежных средств, являющихся заработной платой и (или) иными доходами, в отношении которых статьей 99 Федерального закона от 2 октября 2007 года N 229-ФЗ установлены ограничения размеров удержания" },
                    { 2, "2", "Перевод денежных средств, являющихся доходами, на которые в соответствии с частью 1 статьи 101 Федерального закона от 2 октября 2007 года N 229-ФЗ не может быть обращено взыскание и которые имеют характер периодических выплат, за исключением доходов, к которым в соответствии с частью 2 статьи 101 Федерального закона от 2 октября 2007 года N 229-ФЗ <3> ограничения по обращению взыскания не применяются" },
                    { 3, "3", "Перевод денежных средств, являющихся доходами, к которым в соответствии с частью 2 статьи 101 Федерального закона от 2 октября 2007 года N 229-ФЗ ограничения по обращению взыскания не применяются и которые имеют характер периодических выплат" },
                    { 4, "4", "Перевод денежных средств, являющихся доходами, на которые в соответствии с частью 1 статьи 101 Федерального закона от 2 октября 2007 года N 229-ФЗ не может быть обращено взыскание и которые имеют характер единовременных выплат, за исключением доходов, к которым в соответствии с частью 2 статьи 101 Федерального закона от 2 октября 2007 года N 229-ФЗ ограничения по обращению взыскания не применяются" },
                    { 5, "5", "Перевод денежных средств, являющихся доходами, к которым в соответствии с частью 2 статьи 101 Федерального закона от 2 октября 2007 года N 229-ФЗ ограничения по обращению взыскания не применяются и которые имеют характер единовременных выплат" }
                });

            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "LimitAmountInvoice" },
                values: new object[] { 1, 20000m });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Черновик" },
                    { 2, "Новый" },
                    { 3, "Действующий" },
                    { 4, "Заблокировано" },
                    { 5, "Актуально" },
                    { 6, "Удален" },
                    { 7, "Архивный" },
                    { 8, "Принят" },
                    { 9, "Готов к оплате" },
                    { 10, "Оплачен" },
                    { 11, "Выставлен" },
                    { 12, "Отправлен" },
                    { 13, "Ошибка отправки" },
                    { 14, "Требует внимания" },
                    { 15, "Включен в реестр" },
                    { 16, "Отпаравлен на рассмотрение" },
                    { 17, "Подготовлен" },
                    { 18, "Одобрен" },
                    { 19, "Откланен" },
                    { 20, "Отказан" },
                    { 21, "Отправлено в банк" },
                    { 22, "Исполнено" },
                    { 23, "Зарегистрировано" },
                    { 24, "Введено" },
                    { 25, "Учтено" },
                    { 26, "Проведено" }
                });

            migrationBuilder.InsertData(
                table: "TypeCashFlow",
                columns: new[] { "Id", "Code", "Direction", "Name" },
                values: new object[,]
                {
                    { 1, "4111", true, "Поступления от продажи продукции, товаров, работ и услуг" },
                    { 2, "4112", true, "Поступления от арендных платежей, лицензионных платежей, роялти, комиссионных и иных аналогичных платежей" },
                    { 3, "4113", true, "Поступления от перепродажи финансовых вложений" },
                    { 4, "4119", true, "Прочие поступления от текущих операций" },
                    { 5, "4121", false, "Платежи поставщикам (подрядчикам) за сырье, материалы, работы, услуги" },
                    { 6, "4122", false, "Платежи в связи с оплатой труда работников" },
                    { 7, "4123", false, "Платежи процентов по долговым обязательствам" },
                    { 8, "4124", false, "Платежи налога на прибыль организаций" },
                    { 9, "4129", false, "Прочие платежи по текущим операциям" },
                    { 10, "4211", true, "Поступления от продажи внеоборотных активов (кроме финансовых вложений)" },
                    { 11, "4212", true, "Поступления от продажи акций других организаций (долей участия)" },
                    { 12, "4213", true, "Поступления от возврата предоставленных займов, от продажи долговых ценных бумаг (прав требования денежных средств к другим лицам)" },
                    { 13, "4214", true, "Поступления дивидендов, процентов по долговым финансовым вложениям и аналогичных поступлений от долевого участия в других организациях" },
                    { 14, "4219", true, "Прочие поступления  от инвестиционных операций" },
                    { 15, "4221", false, "Платежи в связи с приобретением, созданием, модернизацией, реконструкцией и подготовкой к использованию внеоборотных активов" },
                    { 16, "4222", false, "Платежи в связи с приобретением акций других организаций (долей участия)" },
                    { 17, "4223", false, "Платежи в связи с приобретением долговых ценных бумаг (прав требования денежных средств к другим лицам), предоставление займов другим лицам" },
                    { 18, "4224", false, "Платежи процентов по долговым обязательствам, включаемым в стоимость инвестиционного актива" },
                    { 19, "4229", false, "Прочие платежи по инвестиционным операциям" },
                    { 20, "4311", true, "Поступления от получения кредитов и займов" },
                    { 21, "4312", true, "Поступления от денежных вкладов собственников (участников)" },
                    { 22, "4313", true, "Поступления от выпуска акций, увеличения долей участия" },
                    { 23, "4314", true, "Поступления от выпуска облигаций, векселей и других долговых ценных бумаг и др." },
                    { 24, "4319", true, "Прочие поступления от финансовых операций" },
                    { 25, "4321", false, "Платежи собственникам (участникам) в связи с выкупом у них акций (долей участия) организации или их выходом из состава участников" },
                    { 26, "4322", false, "Платежи на уплату дивидендов и иных платежей по распределению прибыли в пользу собственников (участников)" },
                    { 27, "4323", false, "Платежи в связи с погашением (выкупом) векселей и других долговых ценных бумаг, возврат кредитов и займов" },
                    { 28, "4329", false, "Прочие платежи по финансовым операциям" }
                });

            migrationBuilder.InsertData(
                table: "TypeOperationsPay",
                columns: new[] { "Id", "IsEnabled", "Name" },
                values: new object[,]
                {
                    { 1, true, "Расчеты с поставщиками" },
                    { 2, true, "Единый налоговый платеж" },
                    { 3, true, "Платежи в ФСС" },
                    { 4, true, "Оплата штрафов ГИБДД" },
                    { 5, true, "Перевод на другой счет организации" },
                    { 6, true, "Перечисление заработной платы работнику" },
                    { 7, true, "Перечисление подотчетному лицу" },
                    { 8, true, "Перечисление сотруднику по договору подряда" },
                    { 9, true, "Возврат покупателю" },
                    { 10, true, "Выдача займа работнику" },
                    { 11, true, "Уплата налогов за сотрудника" },
                    { 12, true, "Прочее платежи" }
                });

            migrationBuilder.InsertData(
                table: "TypePayment",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "0", "" },
                    { 2, "1", "Срочно" },
                    { 3, "2", "Электронно" },
                    { 4, "3", "Почтой" },
                    { 5, "4", "Телеграфом" }
                });

            migrationBuilder.InsertData(
                table: "TypeTransactions",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "01", "Платежное поручение" },
                    { 2, "02", "Платежное требование" },
                    { 3, "06", "Инкассовое поручение" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[,]
                {
                    { 1, "Юридическое лицо", "Контрагенты" },
                    { 2, "Индивидуальный предприниматель", "Контрагенты" },
                    { 3, "Государственный орган", "Контрагенты" },
                    { 4, "Физическое лицо", "Контрагенты" },
                    { 5, "Юридический адрес", "Адреса" },
                    { 6, "Фактический адрес", "Адреса" },
                    { 7, "Почтовый адрес", "Адреса" },
                    { 8, "Выставленные", "Счета" },
                    { 9, "Полученные", "Счета" },
                    { 10, "Удостоверение личности", "Документ" },
                    { 11, "Собственность", "ЗУ" },
                    { 12, "Аренда", "ЗУ" },
                    { 13, "Прочие документы", "Документ" },
                    { 14, "Договор", "Контракт" },
                    { 15, "Контракт", "Контракт" },
                    { 16, "Солглашение", "Контракт" },
                    { 17, "Договор ГПХ", "Контракт" },
                    { 18, "Соглашение", "Спецификация" },
                    { 19, "Спецификация", "Спецификация" },
                    { 20, "Дополнительное соглашение", "Спецификация" },
                    { 21, "Серветут", "Контракт" },
                    { 22, "Договор", "Контракт" },
                    { 23, "Иной документ", "Спецификация" },
                    { 24, "Договор оказания услуг", "Контракт" },
                    { 25, "Приход", "ТМЦ" },
                    { 26, "Расход", "ТМЦ" },
                    { 27, "Списание", "ДокументСписанияТМЦ" },
                    { 28, "Стронирование списания", "ДокументСписанияТМЦ" },
                    { 29, "Ввод остатков", "ТМЦ" },
                    { 30, "Корректировка", "ТМЦ" },
                    { 31, "Приход", "Касса" },
                    { 32, "Расход", "Касса" }
                });

            migrationBuilder.InsertData(
                table: "TypesCommitments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Налог" },
                    { 2, "Пени" },
                    { 3, "Проценты" },
                    { 4, "Штраф" }
                });

            migrationBuilder.InsertData(
                table: "UnitsOkei",
                columns: new[] { "Id", "Abbreviation", "Name", "OkeiCode" },
                values: new object[,]
                {
                    { 1, "ч", "Час", "356" },
                    { 2, "мм", "Миллиметр", "003" },
                    { 3, "см", "Сантиметр", "004" },
                    { 4, "м", "Метр", "006" },
                    { 5, "г", "Грамм", "163" },
                    { 6, "кг", "Килограмм", "166" },
                    { 7, "т", "Тонна; метрическая тонна (1000 кг)", "168" },
                    { 8, "м3", "Кубический метр", "113" },
                    { 9, "м2", "Квадратный метр", "055" },
                    { 10, "га", "Гектар", "059" },
                    { 11, "кВт.ч", "Киловатт-час", "245" },
                    { 12, "л", "Литр", "112" },
                    { 13, "пар", "Пара (2 шт.)", "715" },
                    { 14, "упак", "Упаковка", "778" },
                    { 15, "шт", "Штука", "796" },
                    { 16, "ц", "Центнер (метрический) (100 кг)", "206" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmployeeId", "Login", "Password" },
                values: new object[,]
                {
                    { 1, null, "System", "wE4CqoqhirL5Kt5lIcS5WDDfQObcNA/FGFB6B3msXyo=" },
                    { 2, null, "admin", "2CSU8F1pF7oC96qilonMtES7c/IDgIdssF0fN1N7eJI=" },
                    { 3, null, "я", "byBvg1FJF6iqL6hrtGFWu8oHl/ugFZUo0/LMnPuj6S8=" }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 1, "Раздел I", false, "Внеоборотные активы", null, 5 },
                    { 44, "Раздел II", false, "Производственные запасы", null, 5 },
                    { 45, "Раздел III", false, "Затраты на производство", null, 5 },
                    { 59, "Раздел IV", false, "Готовая продукция и товары", null, 5 },
                    { 66, "Раздел V", false, "Денежные средства", null, 5 },
                    { 77, "Раздел VI", false, "Расчеты", null, 5 },
                    { 106, "Раздел VII", false, "Капитал", null, 5 },
                    { 111, "Раздел VIII", false, "Финансовые результаты", null, 5 },
                    { 124, "Раздел IX", false, "Забалансовые счета", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "ItemsExpenditureOrIncome",
                columns: new[] { "Id", "Name", "TypeCashFlowId" },
                values: new object[,]
                {
                    { 2, "Поступления от покупателей", 1 },
                    { 3, "Розничная выручка", 1 },
                    { 4, "Возврат кредитов и займов", 12 },
                    { 5, "Прочие поступления", 4 },
                    { 6, "Оплата поставщику (подрядчику)", 5 },
                    { 7, "Выплата заработной платы", 6 },
                    { 8, "Выдача кредитов и займов", 17 },
                    { 9, "Выдача под авансовый отчет", 5 },
                    { 10, "Прочие выплаты", 9 }
                });

            migrationBuilder.InsertData(
                table: "TypesOperationCash",
                columns: new[] { "Id", "AccountingPlanId", "IsAccountingPlan", "ItemExpenditureOrIncomeId", "Name", "TypeDocId" },
                values: new object[] { 14, null, false, 1, "Взнос наличными в банк", 32 });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 2, "01", false, "Основные средства в организации", 1, 5 },
                    { 7, "02", false, "Амортизация ОС", 1, 5 },
                    { 11, "03", true, "Доходные вложения в материальные ценности", 1, 5 },
                    { 12, "04", true, "Нематериальные активы", 1, 5 },
                    { 13, "05", true, "Амортизация нематериальных активов", 1, 5 },
                    { 14, "07", true, "Оборудование к установке", 1, 5 },
                    { 15, "08", false, "Вложения во внеоборотные активы", 1, 5 },
                    { 24, "09", true, "Отложенные налоговые активы", 1, 5 },
                    { 25, "10", false, "Материалы", 44, 5 },
                    { 37, "14", false, "Резервы под снижение стоимости материальных ценностей", 44, 5 },
                    { 41, "19", false, "НДС по приобретенным ценностям", 44, 5 },
                    { 46, "20", false, "Основное производство", 45, 5 },
                    { 49, "21", true, "Полуфабрикаты собственного производства", 45, 5 },
                    { 50, "23", false, "Вспомогательные производства", 45, 5 },
                    { 56, "25", false, "Общепроизводственные расходы", 45, 5 },
                    { 58, "26", true, "Общехозяйственные расходы", 45, 5 },
                    { 60, "40", true, "Выпуск продукции (Продукция с поля)", 59, 5 },
                    { 61, "41", false, "Товары", 59, 5 },
                    { 64, "43", false, "Готовая продукция", 59, 5 },
                    { 67, "50", true, "Касса", 66, 5 },
                    { 68, "51", false, "Расчетные счета", 66, 5 },
                    { 72, "52", false, "Валютные счета", 66, 5 },
                    { 74, "55", false, "Специальные счета в банках", 66, 5 },
                    { 76, "57", true, "Переводы в пути", 66, 5 },
                    { 78, "60", false, "Расчеты с поставщиками и подрядчиками", 77, 5 },
                    { 81, "62", false, "Расчеты с покупателями, заказчиками", 77, 5 },
                    { 83, "66", false, "Расчеты по краткосрочным кредитам и займам", 77, 5 },
                    { 84, "67", false, "Расчеты по долгосрочным кредитам и займам", 77, 5 },
                    { 85, "68", false, "Расчеты по налогам и сборам", 77, 5 },
                    { 93, "69", false, "Расчеты по социальному страхованию и обеспечению", 77, 5 },
                    { 99, "70", true, "Расчеты с персоналом по оплате труда", 77, 5 },
                    { 100, "71", true, "Расчеты с подотчетными лицами", 77, 5 },
                    { 101, "73", true, "Расчеты с персоналом по прочим операциям", 77, 5 },
                    { 102, "75", true, "Расчеты с учредителями", 77, 5 },
                    { 103, "76", true, "Расчеты с разными дебиторами и кредиторами", 77, 5 },
                    { 107, "80", true, "Уставный капитал", 106, 5 },
                    { 108, "83", true, "Нераспределенная прибыль (непокрытый убыток)", 106, 5 },
                    { 109, "84", true, "Добавочный капитал", 106, 5 },
                    { 110, "86", true, "Целевое финансирование", 106, 5 },
                    { 112, "90", false, "Продажи", 111, 5 },
                    { 115, "91", false, "Прочие доходы и расходы", 111, 5 },
                    { 119, "94", true, "Недостачи и потери от порчи ценностей", 111, 5 },
                    { 120, "96", false, "Резервы предстоящих расходов", 111, 5 },
                    { 122, "97", true, "Расходы будущих периодов", 111, 5 },
                    { 123, "99", true, "Прибыли и убытки", 111, 5 },
                    { 125, "001", true, "Арендованные основные средства", 124, 5 },
                    { 126, "002", true, "Товарно-материальные ценности, принятые на ответственное хранение", 124, 5 },
                    { 127, "003", true, "Материалы, принятые в переработку", 124, 5 },
                    { 128, "004", true, "Товары, принятые на комиссию", 124, 5 },
                    { 129, "005", true, "Оборудование, принятое для монтажа", 124, 5 },
                    { 130, "006", true, "Бланки строгой отчетности", 124, 5 },
                    { 131, "007", true, "Списанная в убыток задолженность неплатежеспособных дебиторов", 124, 5 },
                    { 132, "008", true, "Обеспечение обязательств и платежей (полученные)", 124, 5 },
                    { 133, "009", true, "Обеспечение обязательств и платежей (выданные)", 124, 5 },
                    { 134, "010", true, "Износ основных средств", 124, 5 },
                    { 135, "011", true, "Основные средства, сданные в аренду", 124, 5 },
                    { 136, "012", true, "Земельные угодья", 124, 5 }
                });

            migrationBuilder.InsertData(
                table: "TypesOperationCash",
                columns: new[] { "Id", "AccountingPlanId", "IsAccountingPlan", "ItemExpenditureOrIncomeId", "Name", "TypeDocId" },
                values: new object[,]
                {
                    { 3, null, true, 3, "Розничная выручка", 31 },
                    { 7, null, true, 5, "Прочий приход", 31 },
                    { 15, null, true, 10, "Прочий расход", 32 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 3, "01-1", true, "Основные средства в организации (Недвижимое имущество)", 2, 5 },
                    { 4, "01-2", true, "Основные средства в организации (Движимое имущество)", 2, 5 },
                    { 5, "01-6", true, "Земельные участки", 2, 5 },
                    { 6, "01-4", true, "Выбытие основных спедств", 2, 5 },
                    { 8, "02-1", true, "Амортизация основных средств, являющихся недвижимым имуществом", 7, 5 },
                    { 9, "02-2", true, "Амортизация основных средств, являющихся движимым имуществом", 7, 5 },
                    { 10, "02-3", true, "Амортизация арендованных основных средств", 7, 5 },
                    { 16, "08-1", true, "Приобретение земельных участков", 15, 5 },
                    { 17, "08-2", true, "Приобретение объектов природопользования", 15, 5 },
                    { 18, "08-3", true, "Строительство объектов основных средств", 15, 5 },
                    { 20, "08-4", true, "Приобретение объектов основных средств", 15, 5 },
                    { 21, "08-5", true, "Приобретение нематериальных активов", 15, 5 },
                    { 22, "08-6", true, "Закладка и выращивание многолетних насаждений", 15, 5 },
                    { 23, "08-7", true, "Выполнение научно-исследовательских, опытно-конструкторских и технологических работ", 15, 5 },
                    { 26, "10-1", true, "Сырье и материалы", 25, 5 },
                    { 27, "10-2", true, "Семена и посадочный материал", 25, 5 },
                    { 28, "10-3", true, "Топливо (ГСМ)", 25, 5 },
                    { 29, "10-4", true, "Покупные полуфабрикаты и комплектующие изделия, конструкции и детали", 25, 5 },
                    { 30, "10-5", true, "Запасные части", 25, 5 },
                    { 31, "10-6", true, "Удобрения, средства защиты растений", 25, 5 },
                    { 32, "10-8", true, "Тара и тарные материалы", 25, 5 },
                    { 33, "10-9", true, "Инвентарь и хозяйственные принадлежности", 25, 5 },
                    { 34, "10-10", true, "Специальная одежда, средства индивидуальной защиты", 25, 5 },
                    { 35, "10-11", true, "Материалы и сырье, переданные в переработку на сторону", 25, 5 },
                    { 36, "10-12", true, "Прочие материалы", 25, 5 },
                    { 38, "14-1", true, "Резервы под снижение стоимости материалов", 37, 5 },
                    { 39, "14-2", true, "Резервы под снижение стоимости товаров", 37, 5 },
                    { 40, "14-3", true, "Резервы под снижение стоимости готовой продукции", 37, 5 },
                    { 42, "19-1", true, "НДС по приобретенным товарно-материальным ценностям, работам, услугам", 41, 5 },
                    { 43, "19-2", true, "НДС по приобретённым продуктам питания", 41, 5 },
                    { 47, "20-1", true, "Основное производство - Растениеводство", 46, 5 },
                    { 48, "20-3", true, "Сортировка сельхоз продукции", 46, 5 },
                    { 51, "23-2", true, "Ремонт зданий, сооружений и сельхоз техники", 50, 5 },
                    { 52, "23-3", true, "Электроснабжение", 50, 5 },
                    { 53, "23-4", true, "Водоснаюжение", 50, 5 },
                    { 54, "23-5", true, "Автотранспорт", 50, 5 },
                    { 55, "23-6", true, "Газоснабжение", 50, 5 },
                    { 57, "25-1", true, "Общепроизводственные расходы - Растениеводства", 56, 5 },
                    { 62, "41-1", true, "Товары на складах", 61, 5 },
                    { 63, "41-2", true, "Товары к продаже", 61, 5 },
                    { 65, "43-1", true, "Готовая продукция - Растениеводства", 64, 5 },
                    { 69, "51-1", true, "Расчетный счет в Россельхозбанке", 68, 5 },
                    { 70, "51-2", true, "Расчетный счет в ОТП", 68, 5 },
                    { 71, "51-3", true, "Расчетный счет в Сбербанке", 68, 5 },
                    { 73, "52-1", true, "Валютные счета внутри страны", 72, 5 },
                    { 75, "55-3", true, "Депозитные счета", 74, 5 },
                    { 79, "60-1", true, "Расчеты с поставщиками и подрядчиками", 78, 5 },
                    { 80, "60-2", true, "Расчеты с поставщиками и подрядчиками по авансам выданным", 78, 5 },
                    { 82, "62-1", true, "Расчеты с покупателями, заказчиками", 81, 5 },
                    { 86, "68-1", true, "НДС с реализованной продукции", 85, 5 },
                    { 87, "68-3", true, "Налог на доходы физических лиц", 85, 5 },
                    { 88, "68-3Д", true, "Налог на доходы физических лиц с дивидендов", 85, 5 },
                    { 89, "68-4", true, "Налог на прибыль организаций", 85, 5 },
                    { 90, "68-5", true, "Транспортный налог с организаций", 85, 5 },
                    { 91, "68-6", true, "Налог на имущество организаций", 85, 5 },
                    { 92, "68-7", true, "Земельный налог с организаций", 85, 5 },
                    { 94, "69-1", false, "Расчеты по социальному страхованию", 93, 5 },
                    { 97, "69-2", true, "Расчеты по пенсионному обеспечению", 93, 5 },
                    { 98, "69-3", true, "Расчеты по обязательному медицинскому страхованию", 93, 5 },
                    { 104, "76АВ", true, "Расчеты с разными дебиторами и кредиторами по авансам полученным", 103, 5 },
                    { 105, "76ВА", true, "Расчеты с разными дебиторами и кредиторами по авансам выданным", 103, 5 },
                    { 113, "90-1", true, "Реализацйия продукции растениеводства", 112, 5 },
                    { 114, "90-3", true, "Реализацйия прочей продукции и ТМЦ", 112, 5 },
                    { 116, "91-1", true, "Прочие доходы", 115, 5 },
                    { 117, "91-2", true, "Прочие расходы", 115, 5 },
                    { 118, "91-9", true, "Сальдо прочих доходов и расходов", 115, 5 },
                    { 121, "96-1", true, "Резерв на оплату отпусков", 120, 5 },
                    { 137, "62-2", true, "Расчеты с покупателями, заказчиками по авансам полученным", 81, 5 },
                    { 138, "50-1", true, "Касса организации", 67, 5 }
                });

            migrationBuilder.InsertData(
                table: "TypesOperationCash",
                columns: new[] { "Id", "AccountingPlanId", "IsAccountingPlan", "ItemExpenditureOrIncomeId", "Name", "TypeDocId" },
                values: new object[,]
                {
                    { 4, 100, true, null, "Возврат от подотчетного лица", 31 },
                    { 5, 101, true, 4, "Возврат займа работником", 31 },
                    { 8, 100, true, 9, "Выдача подотчетному лицу", 32 },
                    { 10, 99, true, 7, "Выплата заработной платы по ведомостям", 32 },
                    { 11, 99, true, 7, "Выплата заработной платы работнику", 32 },
                    { 12, 103, true, 6, "Выплата по договору подряда", 32 },
                    { 13, 101, true, 8, "Выдача займа работнику", 32 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 19, "08-3-1", true, "Строительство объектов основных средств (Ангар)", 18, 5 },
                    { 95, "69-1-1", true, "Расчеты по обязательному социальному страхованию", 94, 5 },
                    { 96, "69-1-2", true, "Расчеты по обязательному социальному страхованию от несчастных случаев", 94, 5 }
                });

            migrationBuilder.InsertData(
                table: "TypesOperationCash",
                columns: new[] { "Id", "AccountingPlanId", "IsAccountingPlan", "ItemExpenditureOrIncomeId", "Name", "TypeDocId" },
                values: new object[,]
                {
                    { 1, 69, false, 1, "Получение наличных в банке", 31 },
                    { 2, 82, true, 2, "Оплата от покупателя", 31 },
                    { 6, 79, true, 5, "Возврат от поставщика", 31 },
                    { 9, 79, true, 6, "Оплата поставщику", 32 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_ComingTmcId",
                table: "AccountingPlanRegisters",
                column: "ComingTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_CreditId",
                table: "AccountingPlanRegisters",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_DebitId",
                table: "AccountingPlanRegisters",
                column: "DebitId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_DecommissioningTmcId",
                table: "AccountingPlanRegisters",
                column: "DecommissioningTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_DocCashId",
                table: "AccountingPlanRegisters",
                column: "DocCashId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlans_ParentPlanId",
                table: "AccountingPlans",
                column: "ParentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlans_StatusId",
                table: "AccountingPlans",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceProduct_AccountingPlanId",
                table: "AdvanceProduct",
                column: "AccountingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceProduct_AccountingPlanNdsId",
                table: "AdvanceProduct",
                column: "AccountingPlanNdsId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceProduct_AdvanceReportId",
                table: "AdvanceProduct",
                column: "AdvanceReportId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceProduct_CounterpartyId",
                table: "AdvanceProduct",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceProduct_NdsId",
                table: "AdvanceProduct",
                column: "NdsId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceProduct_TmcId",
                table: "AdvanceProduct",
                column: "TmcId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceReport_PersonId",
                table: "AdvanceReport",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceReport_StatusId",
                table: "AdvanceReport",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceReport_UserCreatorId",
                table: "AdvanceReport",
                column: "UserCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrationCasesRecords_DataUlId",
                table: "ArbitrationCasesRecords",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_Balanceline_CheckBalanceId",
                table: "Balanceline",
                column: "CheckBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_CounterpartyId",
                table: "BankDetails",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_CurrencyId",
                table: "BankDetails",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_OrganizationId",
                table: "BankDetails",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_StatusId",
                table: "BankDetails",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_DivisionsId",
                table: "Branchs",
                column: "DivisionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_DivisionsId1",
                table: "Branchs",
                column: "DivisionsId1");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCounterparty_DataIpId",
                table: "CheckCounterparty",
                column: "DataIpId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckCounterparty_DataUlId",
                table: "CheckCounterparty",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingFields_CultureId",
                table: "ComingFields",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingFields_DriverId",
                table: "ComingFields",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingFields_FieldId",
                table: "ComingFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingFields_StatusId",
                table: "ComingFields",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingFields_StorageLocationId",
                table: "ComingFields",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingFields_TransportId",
                table: "ComingFields",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingFields_WeightId",
                table: "ComingFields",
                column: "WeightId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmc_ComingTmcCalculationsId",
                table: "ComingTmc",
                column: "ComingTmcCalculationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmc_CounterpartyId",
                table: "ComingTmc",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmc_InvoiceFacturId",
                table: "ComingTmc",
                column: "InvoiceFacturId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmc_StatusId",
                table: "ComingTmc",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcCalculations_AccountingPlanId",
                table: "ComingTmcCalculations",
                column: "AccountingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcCalculations_AccountingPlanPrepaymentId",
                table: "ComingTmcCalculations",
                column: "AccountingPlanPrepaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcPositions_AccountingAccountId",
                table: "ComingTmcPositions",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcPositions_AccountingAccountNdsId",
                table: "ComingTmcPositions",
                column: "AccountingAccountNdsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcPositions_AccountingMethodNdsId",
                table: "ComingTmcPositions",
                column: "AccountingMethodNdsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcPositions_ComingTmcId",
                table: "ComingTmcPositions",
                column: "ComingTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcPositions_NdsId",
                table: "ComingTmcPositions",
                column: "NdsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcPositions_StorageLocationId",
                table: "ComingTmcPositions",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcPositions_TmcId",
                table: "ComingTmcPositions",
                column: "TmcId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingTmcPositions_UnitOkeiId",
                table: "ComingTmcPositions",
                column: "UnitOkeiId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BankDetailsId",
                table: "Contracts",
                column: "BankDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BankDetailsOrgId",
                table: "Contracts",
                column: "BankDetailsOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CounterpartyId",
                table: "Contracts",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_GroupId",
                table: "Contracts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_StatusId",
                table: "Contracts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TypeId",
                table: "Contracts",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparties_ActualAddressId",
                table: "Counterparties",
                column: "ActualAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparties_GroupId",
                table: "Counterparties",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparties_StatusId",
                table: "Counterparties",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparties_TypeDocId",
                table: "Counterparties",
                column: "TypeDocId");

            migrationBuilder.CreateIndex(
                name: "IX_Cultures_ProductId",
                table: "Cultures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cultures_StatusId",
                table: "Cultures",
                column: "StatusId");

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
                name: "IX_DataUl_FinancialStatementsId",
                table: "DataUl",
                column: "FinancialStatementsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_FounderId",
                table: "DataUl",
                column: "FounderId");

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
                name: "IX_DebitingAccount_BankDetailsCounterpartyId",
                table: "DebitingAccount",
                column: "BankDetailsCounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_BankDetailsOrganizationId",
                table: "DebitingAccount",
                column: "BankDetailsOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_ComingTmcCalculationsId",
                table: "DebitingAccount",
                column: "ComingTmcCalculationsId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_CounterpartyId",
                table: "DebitingAccount",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_CreditId",
                table: "DebitingAccount",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_DebitId",
                table: "DebitingAccount",
                column: "DebitId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_ExpenditureItemId",
                table: "DebitingAccount",
                column: "ExpenditureItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_NdsId",
                table: "DebitingAccount",
                column: "NdsId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_OrganizationId",
                table: "DebitingAccount",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_PaymentOrderId",
                table: "DebitingAccount",
                column: "PaymentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_StatusId",
                table: "DebitingAccount",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_TypeOperationId",
                table: "DebitingAccount",
                column: "TypeOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_AccountingPlanId",
                table: "DecommissioningTmc",
                column: "AccountingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_DecommissioningStornoId",
                table: "DecommissioningTmc",
                column: "DecommissioningStornoId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_MolId",
                table: "DecommissioningTmc",
                column: "MolId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_PurposeExpenditureId",
                table: "DecommissioningTmc",
                column: "PurposeExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_StatusId",
                table: "DecommissioningTmc",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_StorekeeperId",
                table: "DecommissioningTmc",
                column: "StorekeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_TypeDocId",
                table: "DecommissioningTmc",
                column: "TypeDocId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_WriteOffObjectId",
                table: "DecommissioningTmc",
                column: "WriteOffObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StatusId",
                table: "Departments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Director_DataUlId",
                table: "Director",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_OrganizationId",
                table: "Divisions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_StatusId",
                table: "Divisions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_AdvanceReportId",
                table: "DocsCash",
                column: "AdvanceReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_BankDetailsOrgId",
                table: "DocsCash",
                column: "BankDetailsOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_CashierId",
                table: "DocsCash",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_ContractId",
                table: "DocsCash",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_CounterpartyId",
                table: "DocsCash",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_CreditId",
                table: "DocsCash",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_DebitId",
                table: "DocsCash",
                column: "DebitId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_DirectorId",
                table: "DocsCash",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_DivisionId",
                table: "DocsCash",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_GeneralAccountantId",
                table: "DocsCash",
                column: "GeneralAccountantId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_InvoiceId",
                table: "DocsCash",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_ItemExpenditureOrIncomeId",
                table: "DocsCash",
                column: "ItemExpenditureOrIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_NdsId",
                table: "DocsCash",
                column: "NdsId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_OrganizationId",
                table: "DocsCash",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_PeopleId",
                table: "DocsCash",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_StatusId",
                table: "DocsCash",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_StorageLocationId",
                table: "DocsCash",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_TypeDocId",
                table: "DocsCash",
                column: "TypeDocId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_TypeOperationCashId",
                table: "DocsCash",
                column: "TypeOperationCashId");

            migrationBuilder.CreateIndex(
                name: "IX_DocsCash_UserCreatorId",
                table: "DocsCash",
                column: "UserCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_GroupId",
                table: "Documents",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PeopleId",
                table: "Documents",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StatusId",
                table: "Documents",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeDocId",
                table: "Documents",
                column: "TypeDocId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_StatusId",
                table: "Drivers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverTransport_TransportsId",
                table: "DriverTransport",
                column: "TransportsId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_ContactsId",
                table: "Email",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DivisionId",
                table: "Employee",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PeopleId",
                table: "Employee",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PostId",
                table: "Employee",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StatusId",
                table: "Employee",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EnforcementProceedingRecords_DataUlId",
                table: "EnforcementProceedingRecords",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenditureItems_StatusId",
                table: "ExpenditureItems",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenditureItems_TypeCashFlowId",
                table: "ExpenditureItems",
                column: "TypeCashFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldLandPlot_LandPlotsId",
                table: "FieldLandPlot",
                column: "LandPlotsId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_DepartmentId",
                table: "Fields",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ParentFieldId",
                table: "Fields",
                column: "ParentFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_StatusId",
                table: "Fields",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialStatements_CheckBalanceId",
                table: "FinancialStatements",
                column: "CheckBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialStatements_UlId",
                table: "FinancialStatements",
                column: "UlId");

            migrationBuilder.CreateIndex(
                name: "IX_FlMo_FounderMoRfId",
                table: "FlMo",
                column: "FounderMoRfId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderFl_FounderId",
                table: "FounderFl",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderFl_ShareId",
                table: "FounderFl",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderIn_FounderId",
                table: "FounderIn",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderIn_ShareId",
                table: "FounderIn",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderMoRf_FounderId",
                table: "FounderMoRf",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderMoRf_RegionId",
                table: "FounderMoRf",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderMoRf_ShareId",
                table: "FounderMoRf",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderPif_FounderId",
                table: "FounderPif",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderPif_ManagingOrganizationId",
                table: "FounderPif",
                column: "ManagingOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderPif_ShareId",
                table: "FounderPif",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderUl_FounderId",
                table: "FounderUl",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_FounderUl_ShareId",
                table: "FounderUl",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupObjects_StatusId",
                table: "GroupObjects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_History_AdvanceReportId",
                table: "History",
                column: "AdvanceReportId");

            migrationBuilder.CreateIndex(
                name: "IX_History_ComingTmcId",
                table: "History",
                column: "ComingTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_History_DecommissioningTmcId",
                table: "History",
                column: "DecommissioningTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_History_DocCashId",
                table: "History",
                column: "DocCashId");

            migrationBuilder.CreateIndex(
                name: "IX_History_InvoiceId",
                table: "History",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_History_PaymentOrderId",
                table: "History",
                column: "PaymentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_History_UserId",
                table: "History",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceFacturs_StatusId",
                table: "InvoiceFacturs",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BankDetailsId",
                table: "Invoices",
                column: "BankDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BankDetailsOrgId",
                table: "Invoices",
                column: "BankDetailsOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ContractId",
                table: "Invoices",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CounterpartyId",
                table: "Invoices",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_NdsId",
                table: "Invoices",
                column: "NdsId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RegistryInvoiceId",
                table: "Invoices",
                column: "RegistryInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SpecificationId",
                table: "Invoices",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TypeId",
                table: "Invoices",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsExpenditureOrIncome_TypeCashFlowId",
                table: "ItemsExpenditureOrIncome",
                column: "TypeCashFlowId");

            migrationBuilder.CreateIndex(
                name: "IX_LandPlots_StatusId",
                table: "LandPlots",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LandPlots_TypeId",
                table: "LandPlots",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_DataIpId",
                table: "Licenses",
                column: "DataIpId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_DataUlId",
                table: "Licenses",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_LicViews_LicenseId",
                table: "LicViews",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeNalog_TaxId",
                table: "ModeNalog",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialPersons_EmployeeId",
                table: "OfficialPersons",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialPersons_StatusId",
                table: "OfficialPersons",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialPersons_StorageLocationId",
                table: "OfficialPersons",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrn_DirectorId",
                table: "Ogrn",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrn_DirectorId1",
                table: "Ogrn",
                column: "DirectorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrn_FounderFlId",
                table: "Ogrn",
                column: "FounderFlId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrn_FounderFlId1",
                table: "Ogrn",
                column: "FounderFlId1");

            migrationBuilder.CreateIndex(
                name: "IX_Okveds_DataIpId",
                table: "Okveds",
                column: "DataIpId");

            migrationBuilder.CreateIndex(
                name: "IX_Okveds_DataUlId",
                table: "Okveds",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_AddressUrId",
                table: "Organizations",
                column: "AddressUrId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CashierId",
                table: "Organizations",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_DirectorId",
                table: "Organizations",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_GeneralAccountantId",
                table: "Organizations",
                column: "GeneralAccountantId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_HrId",
                table: "Organizations",
                column: "HrId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OkatoId",
                table: "Organizations",
                column: "OkatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OkfsId",
                table: "Organizations",
                column: "OkfsId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OkogyId",
                table: "Organizations",
                column: "OkogyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OkopfId",
                table: "Organizations",
                column: "OkopfId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OktmoId",
                table: "Organizations",
                column: "OktmoId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OkvedId",
                table: "Organizations",
                column: "OkvedId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_RegFnsId",
                table: "Organizations",
                column: "RegFnsId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_RegFssId",
                table: "Organizations",
                column: "RegFssId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_RegPfrId",
                table: "Organizations",
                column: "RegPfrId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_AdvanceReportId",
                table: "PaymentOrder",
                column: "AdvanceReportId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_BankDetailsCounterpartyId",
                table: "PaymentOrder",
                column: "BankDetailsCounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_BankDetailsOrganizationId",
                table: "PaymentOrder",
                column: "BankDetailsOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_BasisPaymentId",
                table: "PaymentOrder",
                column: "BasisPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_CounterpartyId",
                table: "PaymentOrder",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_InvoiceId",
                table: "PaymentOrder",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_NdsId",
                table: "PaymentOrder",
                column: "NdsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_OrderPaymentId",
                table: "PaymentOrder",
                column: "OrderPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_OrganizationId",
                table: "PaymentOrder",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_PayerStatusId",
                table: "PaymentOrder",
                column: "PayerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_PaymentDestinationCodeId",
                table: "PaymentOrder",
                column: "PaymentDestinationCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_StatusId",
                table: "PaymentOrder",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_TaxId",
                table: "PaymentOrder",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_TaxPeriodId",
                table: "PaymentOrder",
                column: "TaxPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_TypeCommitmentId",
                table: "PaymentOrder",
                column: "TypeCommitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_TypeOperationId",
                table: "PaymentOrder",
                column: "TypeOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_TypePaymentId",
                table: "PaymentOrder",
                column: "TypePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_TypeTransactionsId",
                table: "PaymentOrder",
                column: "TypeTransactionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_UserCreatorId",
                table: "PaymentOrder",
                column: "UserCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTax_TaxId",
                table: "PaymentTax",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_People_StatusId",
                table: "People",
                column: "StatusId");

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
                name: "IX_PositionDecommissioningTmc_AccountingPlanId",
                table: "PositionDecommissioningTmc",
                column: "AccountingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionDecommissioningTmc_DecommissioningTmcId",
                table: "PositionDecommissioningTmc",
                column: "DecommissioningTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionDecommissioningTmc_StorageLocationId",
                table: "PositionDecommissioningTmc",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionDecommissioningTmc_TmcId",
                table: "PositionDecommissioningTmc",
                column: "TmcId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionDecommissioningTmc_UnitOkeiId",
                table: "PositionDecommissioningTmc",
                column: "UnitOkeiId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_StatusId",
                table: "Post",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NdsId",
                table: "Products",
                column: "NdsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatusId",
                table: "Products",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInvoice_InvoiceId",
                table: "ProductsInvoice",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInvoice_NdsId",
                table: "ProductsInvoice",
                column: "NdsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInvoice_ProductId",
                table: "ProductsInvoice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurposeExpenditures_AccountingPlanId",
                table: "PurposeExpenditures",
                column: "AccountingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PurposeExpenditures_StatusId",
                table: "PurposeExpenditures",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistryInvoices_StatusId",
                table: "RegistryInvoices",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesAccounting_AccountingMethodNdsId",
                table: "RulesAccounting",
                column: "AccountingMethodNdsId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesAccounting_AccountingPlanId",
                table: "RulesAccounting",
                column: "AccountingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesAccounting_AccountingPlanNdsId",
                table: "RulesAccounting",
                column: "AccountingPlanNdsId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesAccounting_StatusId",
                table: "RulesAccounting",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesAccounting_TaxesId",
                table: "RulesAccounting",
                column: "TaxesId");

            migrationBuilder.CreateIndex(
                name: "IX_RulesAccounting_TmcId",
                table: "RulesAccounting",
                column: "TmcId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanFiles_ComingTmcId",
                table: "ScanFiles",
                column: "ComingTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanFiles_ContractId",
                table: "ScanFiles",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanFiles_InvoiceId",
                table: "ScanFiles",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ContractId",
                table: "Specifications",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_TypeId",
                table: "Specifications",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffList_StatusId",
                table: "StaffList",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffListPositions_DivisionId",
                table: "StaffListPositions",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffListPositions_PostId",
                table: "StaffListPositions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffListPositions_StaffListId",
                table: "StaffListPositions",
                column: "StaffListId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageLocations_StatusId",
                table: "StorageLocations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxKbk_KbkId",
                table: "TaxKbk",
                column: "KbkId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxKbk_TaxId",
                table: "TaxKbk",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxKbk_TypeCommitmentId",
                table: "TaxKbk",
                column: "TypeCommitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tmc_GroupId",
                table: "Tmc",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tmc_StatusId",
                table: "Tmc",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tmc_UnitId",
                table: "Tmc",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_ComingTmcId",
                table: "TmcRegisters",
                column: "ComingTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_CreditId",
                table: "TmcRegisters",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_DebitId",
                table: "TmcRegisters",
                column: "DebitId");

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_DecommissioningTmcId",
                table: "TmcRegisters",
                column: "DecommissioningTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_StorageLocationId",
                table: "TmcRegisters",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_TmcId",
                table: "TmcRegisters",
                column: "TmcId");

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_TypeDocId",
                table: "TmcRegisters",
                column: "TypeDocId");

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_UnitOkeiId",
                table: "TmcRegisters",
                column: "UnitOkeiId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_StatusId",
                table: "Transports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesObject_StatusId",
                table: "TypesObject",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOperationCash_AccountingPlanId",
                table: "TypesOperationCash",
                column: "AccountingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOperationCash_ItemExpenditureOrIncomeId",
                table: "TypesOperationCash",
                column: "ItemExpenditureOrIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOperationCash_TypeDocId",
                table: "TypesOperationCash",
                column: "TypeDocId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UnscrupulousSupplierRecord_DataUlId",
                table: "UnscrupulousSupplierRecord",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Weights_StatusId",
                table: "Weights",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Weights_WeigherId",
                table: "Weights",
                column: "WeigherId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffObjects_GroupObjectId",
                table: "WriteOffObjects",
                column: "GroupObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffObjects_StatusId",
                table: "WriteOffObjects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffObjects_TypeObjectId",
                table: "WriteOffObjects",
                column: "TypeObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_DecommissioningTmc_DecommissioningTm~",
                table: "AccountingPlanRegisters",
                column: "DecommissioningTmcId",
                principalTable: "DecommissioningTmc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_DocsCash_DocCashId",
                table: "AccountingPlanRegisters",
                column: "DocCashId",
                principalTable: "DocsCash",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceProduct_AdvanceReport_AdvanceReportId",
                table: "AdvanceProduct",
                column: "AdvanceReportId",
                principalTable: "AdvanceReport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceReport_Employee_PersonId",
                table: "AdvanceReport",
                column: "PersonId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvanceReport_Users_UserCreatorId",
                table: "AdvanceReport",
                column: "UserCreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArbitrationCasesRecords_DataUl_DataUlId",
                table: "ArbitrationCasesRecords",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDetails_Organizations_OrganizationId",
                table: "BankDetails",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCounterparty_DataIp_DataIpId",
                table: "CheckCounterparty",
                column: "DataIpId",
                principalTable: "DataIp",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCounterparty_DataUl_DataUlId",
                table: "CheckCounterparty",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComingFields_Weights_WeightId",
                table: "ComingFields",
                column: "WeightId",
                principalTable: "Weights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataIp_Okveds_OkvedId",
                table: "DataIp",
                column: "OkvedId",
                principalTable: "Okveds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataIp_UnscrupulousSupplierRecord_UnscrupulousSupplierRecord~",
                table: "DataIp",
                column: "UnscrupulousSupplierRecordId",
                principalTable: "UnscrupulousSupplierRecord",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_FinancialStatements_FinancialStatementsId",
                table: "DataUl",
                column: "FinancialStatementsId",
                principalTable: "FinancialStatements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_Okveds_OkvedId",
                table: "DataUl",
                column: "OkvedId",
                principalTable: "Okveds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitingAccount_Organizations_OrganizationId",
                table: "DebitingAccount",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitingAccount_PaymentOrder_PaymentOrderId",
                table: "DebitingAccount",
                column: "PaymentOrderId",
                principalTable: "PaymentOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DecommissioningTmc_Employee_MolId",
                table: "DecommissioningTmc",
                column: "MolId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DecommissioningTmc_Employee_StorekeeperId",
                table: "DecommissioningTmc",
                column: "StorekeeperId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Organizations_OrganizationId",
                table: "Divisions",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Statuses_StatusId",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Statuses_StatusId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Statuses_StatusId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Statuses_StatusId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Employee_CashierId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Employee_DirectorId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Employee_GeneralAccountantId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Employee_HrId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Okveds_DataUl_DataUlId",
                table: "Okveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Ul_DataUl_DataUlId",
                table: "Ul");

            migrationBuilder.DropForeignKey(
                name: "FK_Ul_DataUl_DataUlId1",
                table: "Ul");

            migrationBuilder.DropForeignKey(
                name: "FK_UnscrupulousSupplierRecord_DataUl_DataUlId",
                table: "UnscrupulousSupplierRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Okveds_DataIp_DataIpId",
                table: "Okveds");

            migrationBuilder.DropTable(
                name: "AccountingPlanRegisters");

            migrationBuilder.DropTable(
                name: "AdvanceProduct");

            migrationBuilder.DropTable(
                name: "Balanceline");

            migrationBuilder.DropTable(
                name: "Branchs");

            migrationBuilder.DropTable(
                name: "CheckCounterparty");

            migrationBuilder.DropTable(
                name: "ClosedPeriod");

            migrationBuilder.DropTable(
                name: "ComingFields");

            migrationBuilder.DropTable(
                name: "ComingTmcPositions");

            migrationBuilder.DropTable(
                name: "DebitingAccount");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DriverTransport");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "EnforcementProceedingRecords");

            migrationBuilder.DropTable(
                name: "FieldLandPlot");

            migrationBuilder.DropTable(
                name: "FlMo");

            migrationBuilder.DropTable(
                name: "FounderIn");

            migrationBuilder.DropTable(
                name: "FounderPif");

            migrationBuilder.DropTable(
                name: "FounderUl");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "LicViews");

            migrationBuilder.DropTable(
                name: "ModeNalog");

            migrationBuilder.DropTable(
                name: "OfficialPersons");

            migrationBuilder.DropTable(
                name: "Ogrn");

            migrationBuilder.DropTable(
                name: "PaymentTax");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "PlaintiffDefendant");

            migrationBuilder.DropTable(
                name: "PositionDecommissioningTmc");

            migrationBuilder.DropTable(
                name: "ProductsInvoice");

            migrationBuilder.DropTable(
                name: "RulesAccounting");

            migrationBuilder.DropTable(
                name: "ScanFiles");

            migrationBuilder.DropTable(
                name: "Sittings");

            migrationBuilder.DropTable(
                name: "StaffListPositions");

            migrationBuilder.DropTable(
                name: "TaxKbk");

            migrationBuilder.DropTable(
                name: "TmcRegisters");

            migrationBuilder.DropTable(
                name: "UlShort");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "ExpenditureItems");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "LandPlots");

            migrationBuilder.DropTable(
                name: "DocsCash");

            migrationBuilder.DropTable(
                name: "PaymentOrder");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "FounderFl");

            migrationBuilder.DropTable(
                name: "ArbitrationCasesRecords");

            migrationBuilder.DropTable(
                name: "AccountingMethodsNds");

            migrationBuilder.DropTable(
                name: "StaffList");

            migrationBuilder.DropTable(
                name: "Kbk");

            migrationBuilder.DropTable(
                name: "ComingTmc");

            migrationBuilder.DropTable(
                name: "DecommissioningTmc");

            migrationBuilder.DropTable(
                name: "Tmc");

            migrationBuilder.DropTable(
                name: "FounderMoRf");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "StorageLocations");

            migrationBuilder.DropTable(
                name: "TypesOperationCash");

            migrationBuilder.DropTable(
                name: "AdvanceReport");

            migrationBuilder.DropTable(
                name: "BasisPayment");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OrderPayment");

            migrationBuilder.DropTable(
                name: "PayerStatus");

            migrationBuilder.DropTable(
                name: "PaymentDestination");

            migrationBuilder.DropTable(
                name: "TaxPeriod");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "TypeOperationsPay");

            migrationBuilder.DropTable(
                name: "TypePayment");

            migrationBuilder.DropTable(
                name: "TypeTransactions");

            migrationBuilder.DropTable(
                name: "TypesCommitments");

            migrationBuilder.DropTable(
                name: "ComingTmcCalculations");

            migrationBuilder.DropTable(
                name: "InvoiceFacturs");

            migrationBuilder.DropTable(
                name: "PurposeExpenditures");

            migrationBuilder.DropTable(
                name: "WriteOffObjects");

            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "UnitsOkei");

            migrationBuilder.DropTable(
                name: "ItemsExpenditureOrIncome");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ndses");

            migrationBuilder.DropTable(
                name: "RegistryInvoices");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "AccountingPlans");

            migrationBuilder.DropTable(
                name: "GroupObjects");

            migrationBuilder.DropTable(
                name: "TypesObject");

            migrationBuilder.DropTable(
                name: "TypeCashFlow");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Counterparties");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "DataUl");

            migrationBuilder.DropTable(
                name: "AuthorizedCapitals");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "FinancialStatements");

            migrationBuilder.DropTable(
                name: "Founders");

            migrationBuilder.DropTable(
                name: "HolderRegisters");

            migrationBuilder.DropTable(
                name: "LegalAddress");

            migrationBuilder.DropTable(
                name: "ManagingOrganization");

            migrationBuilder.DropTable(
                name: "Tax");

            migrationBuilder.DropTable(
                name: "CheckBalances");

            migrationBuilder.DropTable(
                name: "Ul");

            migrationBuilder.DropTable(
                name: "DataIp");

            migrationBuilder.DropTable(
                name: "Likveds");

            migrationBuilder.DropTable(
                name: "Okato");

            migrationBuilder.DropTable(
                name: "Okfs");

            migrationBuilder.DropTable(
                name: "Okogy");

            migrationBuilder.DropTable(
                name: "Okopf");

            migrationBuilder.DropTable(
                name: "Oktmo");

            migrationBuilder.DropTable(
                name: "Okveds");

            migrationBuilder.DropTable(
                name: "RegFns");

            migrationBuilder.DropTable(
                name: "RegFss");

            migrationBuilder.DropTable(
                name: "RegPfr");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Rmsp");

            migrationBuilder.DropTable(
                name: "UnscrupulousSupplierRecord");

            migrationBuilder.DropTable(
                name: "UrStatus");
        }
    }
}
