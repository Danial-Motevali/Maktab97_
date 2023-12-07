using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class v18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Auctions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ParentId",
                table: "Auctions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Auctions_ParentId",
                table: "Auctions",
                column: "ParentId",
                principalTable: "Auctions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Auctions_ParentId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_ParentId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Auctions");
        }
    }
}
