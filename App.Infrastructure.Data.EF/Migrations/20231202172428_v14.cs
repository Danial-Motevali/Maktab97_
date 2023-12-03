using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Seller_SellerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_SellerId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "orders");
        }
    }
}
