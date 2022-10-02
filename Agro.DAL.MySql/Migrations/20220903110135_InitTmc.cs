using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitTmc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "RulesAccounting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AccountingPlanId = table.Column<int>(type: "int", nullable: false),
                    AccountingPlanNdsId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TmcId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RulesAccounting", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RulesAccounting_Tmc_TmcId",
                        column: x => x.TmcId,
                        principalTable: "Tmc",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_RulesAccounting_TmcId",
                table: "RulesAccounting",
                column: "TmcId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RulesAccounting");

            migrationBuilder.DropTable(
                name: "Tmc");
        }
    }
}
