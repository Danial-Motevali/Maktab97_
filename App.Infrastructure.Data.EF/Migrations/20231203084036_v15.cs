using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Seller_SellerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOreder_Products",
                table: "ProductOreder");

            migrationBuilder.DropIndex(
                name: "IX_orders_SellerId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductOreder",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOreder_ProductId",
                table: "ProductOreder",
                newName: "IX_ProductOreder_InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOreder_Products",
                table: "ProductOreder",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOreder_Products",
                table: "ProductOreder");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "ProductOreder",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOreder_InventoryId",
                table: "ProductOreder",
                newName: "IX_ProductOreder_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_SellerId",
                table: "orders",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Seller_SellerId",
                table: "orders",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOreder_Products",
                table: "ProductOreder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
