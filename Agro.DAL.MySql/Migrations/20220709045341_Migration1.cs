using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
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
                    Percent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ndses", x => x.Id);
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
                name: "UnitsOkei",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_UnitsOkei_Statuses_StatusId",
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
                    GroupId = table.Column<int>(type: "int", nullable: false),
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
                    Description = table.Column<string>(type: "varchar(225)", maxLength: 225, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counterparties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counterparties_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "BankDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
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
                    DateInvoce = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                        name: "FK_Invoices_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 13, "ГСМ", "Материальные запасы" }
                });

            migrationBuilder.InsertData(
                table: "Ndses",
                columns: new[] { "Id", "Name", "Percent" },
                values: new object[,]
                {
                    { 1, "Без НДС", 0 },
                    { 2, "0%", 0 },
                    { 3, "10%", 10 },
                    { 4, "20%", 20 }
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
                    { 7, "Архивный" }
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
                    { 9, "Материальные запасы", "Товары" }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 1, "Раздел I", false, "Внеоборотные активы", null, 5 },
                    { 44, "Раздел II", false, "Производственные запасы", null, 5 },
                    { 45, "Раздел III", false, "Затраты на производство", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "UnitsOkei",
                columns: new[] { "Id", "Abbreviation", "Name", "OkeiCode", "StatusId" },
                values: new object[,]
                {
                    { 1, "ч", "Час", "356", 5 },
                    { 2, "мм", "Миллиметр", "003", 5 },
                    { 3, "см", "Сантиметр", "004", 5 },
                    { 4, "м", "Метр", "006", 5 },
                    { 5, "г", "Грамм", "163", 5 },
                    { 6, "кг", "Килограмм", "166", 5 },
                    { 7, "т", "Тонна; метрическая тонна (1000 кг)", "168", 5 },
                    { 8, "м3", "Кубический метр", "113", 5 },
                    { 9, "м2", "Квадратный метр", "055", 5 },
                    { 10, "га", "Гектар", "059", 5 },
                    { 11, "кВт.ч", "Киловатт-час", "245", 5 },
                    { 12, "л.", "Лист", "625", 5 },
                    { 13, "пар", "Пара (2 шт.)", "715", 5 },
                    { 14, "упак", "Упаковка", "778", 5 },
                    { 15, "шт", "Штука", "796", 5 },
                    { 16, "ц", "Центнер (метрический) (100 кг)", "206", 5 }
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
                    { 50, "23", false, "Вспомогательные производства", 45, 5 }
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
                    { 47, "20-1", true, "Основное производство-Растениеводства", 46, 5 },
                    { 48, "20-3", true, "Сортировка сельхоз продукции", 46, 5 },
                    { 51, "23-2", true, "Ремонт зданий, сооружений и сельхоз техники", 50, 5 },
                    { 52, "23-3", true, "Электроснабжение", 50, 5 },
                    { 53, "23-3", true, "Электроснабжение", 50, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 19, "08-3-1", true, "Строительство объектов основных средств (Ангар)", 18, 5 });

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
                name: "IX_BankDetails_StatusId",
                table: "BankDetails",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BankDetailsId",
                table: "Contracts",
                column: "BankDetailsId");

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
                name: "IX_Invoices_BankDetailsId",
                table: "Invoices",
                column: "BankDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CounterpartyId",
                table: "Invoices",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TypeId",
                table: "Invoices",
                column: "TypeId");

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
                name: "IX_UnitsOkei_StatusId",
                table: "UnitsOkei",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingPlans");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ScanFiles");

            migrationBuilder.DropTable(
                name: "Ndses");

            migrationBuilder.DropTable(
                name: "UnitsOkei");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Counterparties");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
