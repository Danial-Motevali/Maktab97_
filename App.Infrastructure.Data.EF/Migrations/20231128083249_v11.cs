using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyer_Carts_CartId",
                table: "Buyer");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Carts_CartId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_CartId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Buyer_CartId",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Buyer");

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_BuyerId",
                table: "Carts",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_InventoryId",
                table: "Carts",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Buyer_BuyerId",
                table: "Carts",
                column: "BuyerId",
                principalTable: "Buyer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Inventory_InventoryId",
                table: "Carts",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Buyer_BuyerId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Inventory_InventoryId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_BuyerId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_InventoryId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Inventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Buyer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CartId",
                table: "Inventory",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyer_CartId",
                table: "Buyer",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyer_Carts_CartId",
                table: "Buyer",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Carts_CartId",
                table: "Inventory",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
