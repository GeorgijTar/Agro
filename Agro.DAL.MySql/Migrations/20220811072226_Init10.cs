using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Statuses_StatusId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Drivers_DriverId",
                table: "Transports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Statuses_StatusId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_DriverId",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Transports");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Transports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Drivers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_DriverTransport_TransportsId",
                table: "DriverTransport",
                column: "TransportsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Statuses_StatusId",
                table: "Drivers",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Statuses_StatusId",
                table: "Transports",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Statuses_StatusId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Statuses_StatusId",
                table: "Transports");

            migrationBuilder.DropTable(
                name: "DriverTransport");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Transports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Transports",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transports_DriverId",
                table: "Transports",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Statuses_StatusId",
                table: "Drivers",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Drivers_DriverId",
                table: "Transports",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Statuses_StatusId",
                table: "Transports",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
