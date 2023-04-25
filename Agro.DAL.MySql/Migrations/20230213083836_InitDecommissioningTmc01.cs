using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitDecommissioningTmc01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecommissioningTmcId",
                table: "TmcRegisters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecommissioningTmcId",
                table: "History",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecommissioningTmcId",
                table: "AccountingPlanRegisters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurposeExpenditures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RulesAccountingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeExpenditures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurposeExpenditures_RulesAccounting_RulesAccountingId",
                        column: x => x.RulesAccountingId,
                        principalTable: "RulesAccounting",
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
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InvNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteOffObjects", x => x.Id);
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
                    PurposeExpenditure = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WriteOffObjectId = table.Column<int>(type: "int", nullable: false),
                    StorekeeperId = table.Column<int>(type: "int", nullable: false),
                    MolId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecommissioningTmc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_DecommissioningTmc_DecommissioningStornoId",
                        column: x => x.DecommissioningStornoId,
                        principalTable: "DecommissioningTmc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_Employee_MolId",
                        column: x => x.MolId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecommissioningTmc_Employee_StorekeeperId",
                        column: x => x.StorekeeperId,
                        principalTable: "Employee",
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

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 27, "Списание", "ДокументСписанияТМЦ" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 28, "Стронирование списания", "ДокументСписанияТМЦ" });

            migrationBuilder.CreateIndex(
                name: "IX_TmcRegisters_DecommissioningTmcId",
                table: "TmcRegisters",
                column: "DecommissioningTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_History_DecommissioningTmcId",
                table: "History",
                column: "DecommissioningTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_DecommissioningTmcId",
                table: "AccountingPlanRegisters",
                column: "DecommissioningTmcId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_DecommissioningStornoId",
                table: "DecommissioningTmc",
                column: "DecommissioningStornoId");

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_MolId",
                table: "DecommissioningTmc",
                column: "MolId");

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
                name: "IX_PurposeExpenditures_RulesAccountingId",
                table: "PurposeExpenditures",
                column: "RulesAccountingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_DecommissioningTmc_DecommissioningTm~",
                table: "AccountingPlanRegisters",
                column: "DecommissioningTmcId",
                principalTable: "DecommissioningTmc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_History_DecommissioningTmc_DecommissioningTmcId",
                table: "History",
                column: "DecommissioningTmcId",
                principalTable: "DecommissioningTmc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TmcRegisters_DecommissioningTmc_DecommissioningTmcId",
                table: "TmcRegisters",
                column: "DecommissioningTmcId",
                principalTable: "DecommissioningTmc",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingPlanRegisters_DecommissioningTmc_DecommissioningTm~",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_History_DecommissioningTmc_DecommissioningTmcId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_TmcRegisters_DecommissioningTmc_DecommissioningTmcId",
                table: "TmcRegisters");

            migrationBuilder.DropTable(
                name: "PositionDecommissioningTmc");

            migrationBuilder.DropTable(
                name: "PurposeExpenditures");

            migrationBuilder.DropTable(
                name: "DecommissioningTmc");

            migrationBuilder.DropTable(
                name: "WriteOffObjects");

            migrationBuilder.DropIndex(
                name: "IX_TmcRegisters_DecommissioningTmcId",
                table: "TmcRegisters");

            migrationBuilder.DropIndex(
                name: "IX_History_DecommissioningTmcId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_AccountingPlanRegisters_DecommissioningTmcId",
                table: "AccountingPlanRegisters");

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DropColumn(
                name: "DecommissioningTmcId",
                table: "TmcRegisters");

            migrationBuilder.DropColumn(
                name: "DecommissioningTmcId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "DecommissioningTmcId",
                table: "AccountingPlanRegisters");
        }
    }
}
