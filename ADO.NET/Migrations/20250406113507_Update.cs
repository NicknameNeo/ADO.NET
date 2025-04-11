using Microsoft.EntityFrameworkCore.Migrations;

namespace ADO.NET.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashierMedicine_Cashier_CashierId",
                table: "CashierMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Cashier_CashierId",
                table: "Medicine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cashier",
                table: "Cashier");

            migrationBuilder.RenameTable(
                name: "Cashier",
                newName: "Cashiers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cashiers",
                table: "Cashiers",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_Barcode",
                table: "Medicine",
                column: "Barcode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CashierMedicine_Cashiers_CashierId",
                table: "CashierMedicine",
                column: "CashierId",
                principalTable: "Cashiers",
                principalColumn: "CashierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Cashiers_CashierId",
                table: "Medicine",
                column: "CashierId",
                principalTable: "Cashiers",
                principalColumn: "CashierId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashierMedicine_Cashiers_CashierId",
                table: "CashierMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Cashiers_CashierId",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_Barcode",
                table: "Medicine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cashiers",
                table: "Cashiers");

            migrationBuilder.RenameTable(
                name: "Cashiers",
                newName: "Cashier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cashier",
                table: "Cashier",
                column: "CashierId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashierMedicine_Cashier_CashierId",
                table: "CashierMedicine",
                column: "CashierId",
                principalTable: "Cashier",
                principalColumn: "CashierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Cashier_CashierId",
                table: "Medicine",
                column: "CashierId",
                principalTable: "Cashier",
                principalColumn: "CashierId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
