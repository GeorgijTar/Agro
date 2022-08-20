using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
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
                name: "Okveds",
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
                    table.PrimaryKey("PK_Okveds", x => x.Id);
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
                    DateReg = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
                name: "Post",
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
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReestrInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReestr = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AmountReestr = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReestrInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReestrInvoice_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    StatusId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Counterparties_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TypeDocId = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateIssue = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Issuing = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeIssuing = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
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
                    NameMini = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_UnitsOkei_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitsOkei",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffList_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffList_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Inn = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Snils = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdentityDocumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Documents_IdentityDocumentId",
                        column: x => x.IdentityDocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_People_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TabNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Bik = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ks = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                        name: "FK_BankDetails_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
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
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NdsId = table.Column<int>(type: "int", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankDetailsOrgId = table.Column<int>(type: "int", nullable: true),
                    ReestrInvoiceId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Invoices_ReestrInvoice_ReestrInvoiceId",
                        column: x => x.ReestrInvoiceId,
                        principalTable: "ReestrInvoice",
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
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EventHistory = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_History_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    SpecificationContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanFiles", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_ScanFiles_Specifications_SpecificationContractId",
                        column: x => x.SpecificationContractId,
                        principalTable: "Specifications",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    { 7, "Средства защиты растений", "Материальные запасы" },
                    { 8, "Удобрения", "Материальные запасы" },
                    { 9, "Семена", "Материальные запасы" },
                    { 10, "Запасные части", "Материальные запасы" },
                    { 11, "Материалы", "Материальные запасы" },
                    { 12, "Малоценные товары, инвентарь", "Материальные запасы" },
                    { 13, "ГСМ", "Материальные запасы" },
                    { 14, "Паспорт гражданина РФ", "УЛ" },
                    { 15, "Загранпаспорт гражданина РФ", "УЛ" },
                    { 16, "Свидетельство о рождении", "УЛ" },
                    { 17, "Временное удостоверение личности", "УЛ" },
                    { 18, "Удостоверение личности военнослужащего РФ (военный билет, паспорт моряка)", "УЛ" },
                    { 19, "Вид на жительство", "УЛ" }
                });

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
                    { 8, "Принят к оплате" },
                    { 9, "Готов к оплате" },
                    { 10, "Оплачен" },
                    { 11, "Выставлен" },
                    { 12, "Отправлен" },
                    { 13, "Ошибка отправки" }
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
                    { 8, "Готовая продукция", "Товары" },
                    { 9, "Материальные запасы", "Товары" },
                    { 10, "Выставленные", "Счета" },
                    { 11, "Полученные", "Счета" },
                    { 12, "Удостоверение личности", "УЛ" }
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
                    { 12, "л.", "Лист", "625" },
                    { 13, "пар", "Пара (2 шт.)", "715" },
                    { 14, "упак", "Упаковка", "778" },
                    { 15, "шт", "Штука", "796" },
                    { 16, "ц", "Центнер (метрический) (100 кг)", "206" }
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
                    { 137, "62-2", true, "Расчеты с покупателями, заказчиками по авансам полученным", 81, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 19, "08-3-1", true, "Строительство объектов основных средств (Ангар)", 18, 5 });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 95, "69-1-1", true, "Расчеты по обязательному социальному страхованию", 94, 5 });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 96, "69-1-2", true, "Расчеты по обязательному социальному страхованию от несчастных случаев", 94, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlans_ParentPlanId",
                table: "AccountingPlans",
                column: "ParentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlans_StatusId",
                table: "AccountingPlans",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_CounterpartyId",
                table: "BankDetails",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_OrganizationId",
                table: "BankDetails",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_StatusId",
                table: "BankDetails",
                column: "StatusId");

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
                name: "NameIndex",
                table: "Counterparties",
                column: "Inn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StatusId",
                table: "Documents",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeDocId",
                table: "Documents",
                column: "TypeDocId");

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
                name: "IX_History_InvoiceId",
                table: "History",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_History_UserId",
                table: "History",
                column: "UserId");

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
                name: "IX_Invoices_ReestrInvoiceId",
                table: "Invoices",
                column: "ReestrInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TypeId",
                table: "Invoices",
                column: "TypeId");

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
                name: "IX_People_IdentityDocumentId",
                table: "People",
                column: "IdentityDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_People_StatusId",
                table: "People",
                column: "StatusId");

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
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

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
                name: "IX_ReestrInvoice_StatusId",
                table: "ReestrInvoice",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanFiles_ContractId",
                table: "ScanFiles",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanFiles_InvoiceId",
                table: "ScanFiles",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanFiles_SpecificationContractId",
                table: "ScanFiles",
                column: "SpecificationContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ContractId",
                table: "Specifications",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_TypeId",
                table: "Specifications",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffList_PostId",
                table: "StaffList",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffList_StatusId",
                table: "StaffList",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingPlans");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "ProductsInvoice");

            migrationBuilder.DropTable(
                name: "ScanFiles");

            migrationBuilder.DropTable(
                name: "StaffList");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "UnitsOkei");

            migrationBuilder.DropTable(
                name: "Ndses");

            migrationBuilder.DropTable(
                name: "ReestrInvoice");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Counterparties");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Employee");

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
                name: "People");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
