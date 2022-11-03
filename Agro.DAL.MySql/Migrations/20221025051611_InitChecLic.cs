using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitChecLic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_Founder_FounderId",
                table: "DataUl");

            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_HolderRegisters_HolderRegisterId",
                table: "DataUl");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderFl_Founder_FounderId",
                table: "FounderFl");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderIn_Founder_FounderId",
                table: "FounderIn");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderMoRf_Founder_FounderId",
                table: "FounderMoRf");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderUl_Founder_FounderId",
                table: "FounderUl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Founder",
                table: "Founder");

            migrationBuilder.DropColumn(
                name: "LicView",
                table: "Licenses");

            migrationBuilder.RenameTable(
                name: "Founder",
                newName: "Founders");

            migrationBuilder.AddColumn<int>(
                name: "FounderId",
                table: "FounderPif",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HolderRegisterId",
                table: "DataUl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Founders",
                table: "Founders",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_FounderPif_FounderId",
                table: "FounderPif",
                column: "FounderId");

            migrationBuilder.CreateIndex(
                name: "IX_LicViews_LicenseId",
                table: "LicViews",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_Founders_FounderId",
                table: "DataUl",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_HolderRegisters_HolderRegisterId",
                table: "DataUl",
                column: "HolderRegisterId",
                principalTable: "HolderRegisters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderFl_Founders_FounderId",
                table: "FounderFl",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderIn_Founders_FounderId",
                table: "FounderIn",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderMoRf_Founders_FounderId",
                table: "FounderMoRf",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderPif_Founders_FounderId",
                table: "FounderPif",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderUl_Founders_FounderId",
                table: "FounderUl",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_Founders_FounderId",
                table: "DataUl");

            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_HolderRegisters_HolderRegisterId",
                table: "DataUl");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderFl_Founders_FounderId",
                table: "FounderFl");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderIn_Founders_FounderId",
                table: "FounderIn");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderMoRf_Founders_FounderId",
                table: "FounderMoRf");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderPif_Founders_FounderId",
                table: "FounderPif");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderUl_Founders_FounderId",
                table: "FounderUl");

            migrationBuilder.DropTable(
                name: "LicViews");

            migrationBuilder.DropIndex(
                name: "IX_FounderPif_FounderId",
                table: "FounderPif");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Founders",
                table: "Founders");

            migrationBuilder.DropColumn(
                name: "FounderId",
                table: "FounderPif");

            migrationBuilder.RenameTable(
                name: "Founders",
                newName: "Founder");

            migrationBuilder.AddColumn<string>(
                name: "LicView",
                table: "Licenses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "HolderRegisterId",
                table: "DataUl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Founder",
                table: "Founder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_Founder_FounderId",
                table: "DataUl",
                column: "FounderId",
                principalTable: "Founder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_HolderRegisters_HolderRegisterId",
                table: "DataUl",
                column: "HolderRegisterId",
                principalTable: "HolderRegisters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FounderFl_Founder_FounderId",
                table: "FounderFl",
                column: "FounderId",
                principalTable: "Founder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderIn_Founder_FounderId",
                table: "FounderIn",
                column: "FounderId",
                principalTable: "Founder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderMoRf_Founder_FounderId",
                table: "FounderMoRf",
                column: "FounderId",
                principalTable: "Founder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderUl_Founder_FounderId",
                table: "FounderUl",
                column: "FounderId",
                principalTable: "Founder",
                principalColumn: "Id");
        }
    }
}
