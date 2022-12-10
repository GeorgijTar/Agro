using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitDefaultBankProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ExpenditureItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeCashFlowId = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditureItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenditureItems_TypeCashFlow_TypeCashFlowId",
                        column: x => x.TypeCashFlowId,
                        principalTable: "TypeCashFlow",
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
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    TypeOperationId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    NdsId = table.Column<int>(type: "int", nullable: false),
                    AmountNds = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TypePaymentId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsOrganizationId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsCounterpartyId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    TypeTransactions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    DateDoc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    NalogTypePayment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOrder", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_TaxPeriod_TaxPeriodId",
                        column: x => x.TaxPeriodId,
                        principalTable: "TaxPeriod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_TypePayment_TypePaymentId",
                        column: x => x.TypePaymentId,
                        principalTable: "TypePayment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentOrder_Types_TypeOperationId",
                        column: x => x.TypeOperationId,
                        principalTable: "Types",
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
                    ExpenditureItemId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_DebitingAccount_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebitingAccount_PaymentOrder_PaymentOrderId",
                        column: x => x.PaymentOrderId,
                        principalTable: "PaymentOrder",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "BasisPayment",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "ТП", "Платежи текущего года" },
                    { 2, "ЗД", "Погашение задолженности, по истекшим налоговым, расчетным (отчетным) периодам, в том числе добровольное" },
                    { 3, "РС", "Погашение рассроченной задолженности" },
                    { 4, "ОТ", "Погашение отсроченной задолженности" },
                    { 5, "РТ", "Погашение реструктурируемой задолженности" },
                    { 6, "ПБ", "Погашение должником задолженности в ходе процедур, применяемых в деле о банкротстве" },
                    { 7, "ИН", "Погашение инвестиционного налогового кредита" },
                    { 8, "ТЛ", "Погашение учредителем (участником) должника, собственником имущества должника - унитарного предприятия или третьим лицом требований к должнику об уплате обязательных платежей в ходе процедур, применяемых в деле о банкротстве" },
                    { 9, "ЗТ", "Погашение текущей задолженности в ходе процедур, применяемых в деле о банкротстве" }
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

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_BankDetailsCounterpartyId",
                table: "DebitingAccount",
                column: "BankDetailsCounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitingAccount_BankDetailsOrganizationId",
                table: "DebitingAccount",
                column: "BankDetailsOrganizationId");

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
                name: "IX_ExpenditureItems_TypeCashFlowId",
                table: "ExpenditureItems",
                column: "TypeCashFlowId");

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
                name: "IX_PaymentOrder_TaxPeriodId",
                table: "PaymentOrder",
                column: "TaxPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_TypeOperationId",
                table: "PaymentOrder",
                column: "TypeOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOrder_TypePaymentId",
                table: "PaymentOrder",
                column: "TypePaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebitingAccount");

            migrationBuilder.DropTable(
                name: "TypeTransactions");

            migrationBuilder.DropTable(
                name: "ExpenditureItems");

            migrationBuilder.DropTable(
                name: "PaymentOrder");

            migrationBuilder.DropTable(
                name: "TypeCashFlow");

            migrationBuilder.DropTable(
                name: "BasisPayment");

            migrationBuilder.DropTable(
                name: "OrderPayment");

            migrationBuilder.DropTable(
                name: "PayerStatus");

            migrationBuilder.DropTable(
                name: "PaymentDestination");

            migrationBuilder.DropTable(
                name: "TaxPeriod");

            migrationBuilder.DropTable(
                name: "TypePayment");
        }
    }
}
