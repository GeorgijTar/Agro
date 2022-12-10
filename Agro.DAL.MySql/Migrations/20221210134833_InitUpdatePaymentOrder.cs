using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitUpdatePaymentOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOrder_Types_TypeOperationId",
                table: "PaymentOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOrder_TypeOperationsPay_TypeOperationId",
                table: "PaymentOrder",
                column: "TypeOperationId",
                principalTable: "TypeOperationsPay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOrder_TypeOperationsPay_TypeOperationId",
                table: "PaymentOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOrder_Types_TypeOperationId",
                table: "PaymentOrder",
                column: "TypeOperationId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
