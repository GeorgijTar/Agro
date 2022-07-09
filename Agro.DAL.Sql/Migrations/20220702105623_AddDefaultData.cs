using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class AddDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentPlanId = table.Column<int>(type: "int", nullable: true),
                    IsSelect = table.Column<bool>(type: "bit", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_BankDetails_BankDetailsId",
                        column: x => x.BankDetailsId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contracts_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contracts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contracts_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contracts_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateInvoce = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    BankDetailsId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_BankDetails_BankDetailsId",
                        column: x => x.BankDetailsId,
                        principalTable: "BankDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoices_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoices_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoices_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Specifications_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ScanFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
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
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 1, "Раздел I", false, "Внеоборотные активы", null, 5 });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Архивный" });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 2, "01", false, "Основные средства в организации", 1, 5 });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 7, "02", false, "Амортизация ОС", 1, 5 });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 3, "01-1", false, "Основные средства в организации (Недвижимое имущество)", 2, 5 },
                    { 4, "01-2", false, "Основные средства в организации (Движимое имущество)", 2, 5 },
                    { 5, "01-6", false, "Земельные участки", 2, 5 },
                    { 6, "01-4", false, "Выбытие основных спедств", 2, 5 },
                    { 8, "02-1", false, "Амортизация основных средств, являющихся недвижимым имуществом", 7, 5 },
                    { 9, "02-2", false, "Амортизация основных средств, являющихся движимым имуществом", 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlans_ParentPlanId",
                table: "AccountingPlans",
                column: "ParentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlans_StatusId",
                table: "AccountingPlans",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingPlans");

            migrationBuilder.DropTable(
                name: "ScanFiles");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
