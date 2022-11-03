using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitChecCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FounderFl_DataUl_DataUlId",
                table: "FounderFl");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderIn_DataUl_DataUlId",
                table: "FounderIn");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderMoRf_DataUl_DataUlId",
                table: "FounderMoRf");

            migrationBuilder.DropForeignKey(
                name: "FK_FounderUl_DataUl_DataUlId",
                table: "FounderUl");

            migrationBuilder.RenameColumn(
                name: "DataUlId",
                table: "FounderUl",
                newName: "FounderId");

            migrationBuilder.RenameIndex(
                name: "IX_FounderUl_DataUlId",
                table: "FounderUl",
                newName: "IX_FounderUl_FounderId");

            migrationBuilder.RenameColumn(
                name: "DataUlId",
                table: "FounderMoRf",
                newName: "FounderId");

            migrationBuilder.RenameIndex(
                name: "IX_FounderMoRf_DataUlId",
                table: "FounderMoRf",
                newName: "IX_FounderMoRf_FounderId");

            migrationBuilder.RenameColumn(
                name: "DataUlId",
                table: "FounderIn",
                newName: "FounderId");

            migrationBuilder.RenameIndex(
                name: "IX_FounderIn_DataUlId",
                table: "FounderIn",
                newName: "IX_FounderIn_FounderId");

            migrationBuilder.RenameColumn(
                name: "DataUlId",
                table: "FounderFl",
                newName: "FounderId");

            migrationBuilder.RenameIndex(
                name: "IX_FounderFl_DataUlId",
                table: "FounderFl",
                newName: "IX_FounderFl_FounderId");

            migrationBuilder.AlterColumn<string>(
                name: "Ogrn",
                table: "ManagingOrganization",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Inn",
                table: "ManagingOrganization",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ManagingOrganization",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisqualifiedOn",
                table: "Director",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisqualifiedOff",
                table: "Director",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "FounderId",
                table: "DataUl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Founder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founder", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_FounderId",
                table: "DataUl",
                column: "FounderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_Founder_FounderId",
                table: "DataUl",
                column: "FounderId",
                principalTable: "Founder",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_Founder_FounderId",
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

            migrationBuilder.DropTable(
                name: "Founder");

            migrationBuilder.DropIndex(
                name: "IX_DataUl_FounderId",
                table: "DataUl");

            migrationBuilder.DropColumn(
                name: "FounderId",
                table: "DataUl");

            migrationBuilder.RenameColumn(
                name: "FounderId",
                table: "FounderUl",
                newName: "DataUlId");

            migrationBuilder.RenameIndex(
                name: "IX_FounderUl_FounderId",
                table: "FounderUl",
                newName: "IX_FounderUl_DataUlId");

            migrationBuilder.RenameColumn(
                name: "FounderId",
                table: "FounderMoRf",
                newName: "DataUlId");

            migrationBuilder.RenameIndex(
                name: "IX_FounderMoRf_FounderId",
                table: "FounderMoRf",
                newName: "IX_FounderMoRf_DataUlId");

            migrationBuilder.RenameColumn(
                name: "FounderId",
                table: "FounderIn",
                newName: "DataUlId");

            migrationBuilder.RenameIndex(
                name: "IX_FounderIn_FounderId",
                table: "FounderIn",
                newName: "IX_FounderIn_DataUlId");

            migrationBuilder.RenameColumn(
                name: "FounderId",
                table: "FounderFl",
                newName: "DataUlId");

            migrationBuilder.RenameIndex(
                name: "IX_FounderFl_FounderId",
                table: "FounderFl",
                newName: "IX_FounderFl_DataUlId");

            migrationBuilder.UpdateData(
                table: "ManagingOrganization",
                keyColumn: "Ogrn",
                keyValue: null,
                column: "Ogrn",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ogrn",
                table: "ManagingOrganization",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ManagingOrganization",
                keyColumn: "Inn",
                keyValue: null,
                column: "Inn",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Inn",
                table: "ManagingOrganization",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ManagingOrganization",
                keyColumn: "FullName",
                keyValue: null,
                column: "FullName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "ManagingOrganization",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisqualifiedOn",
                table: "Director",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisqualifiedOff",
                table: "Director",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FounderFl_DataUl_DataUlId",
                table: "FounderFl",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderIn_DataUl_DataUlId",
                table: "FounderIn",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderMoRf_DataUl_DataUlId",
                table: "FounderMoRf",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FounderUl_DataUl_DataUlId",
                table: "FounderUl",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");
        }
    }
}
