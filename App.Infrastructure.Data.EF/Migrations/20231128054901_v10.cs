using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Wages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wages_InventoryId",
                table: "Wages",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wages_Inventory_InventoryId",
                table: "Wages",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wages_Inventory_InventoryId",
                table: "Wages");

            migrationBuilder.DropIndex(
                name: "IX_Wages_InventoryId",
                table: "Wages");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Wages");
        }
    }
}
