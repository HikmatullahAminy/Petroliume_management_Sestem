using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class setRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseSalles_purchases_StoreId",
                table: "PurchaseSalles");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseSalles_StoreId",
                table: "PurchaseSalles");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "PurchaseSalles");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseSalles_PurchaseId",
                table: "PurchaseSalles",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseSalles_purchases_PurchaseId",
                table: "PurchaseSalles",
                column: "PurchaseId",
                principalTable: "purchases",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseSalles_purchases_PurchaseId",
                table: "PurchaseSalles");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseSalles_PurchaseId",
                table: "PurchaseSalles");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "PurchaseSalles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseSalles_StoreId",
                table: "PurchaseSalles",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseSalles_purchases_StoreId",
                table: "PurchaseSalles",
                column: "StoreId",
                principalTable: "purchases",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
