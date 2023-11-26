using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreInlämning4.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__InventoryBalance__Books_InventoryIDId",
                table: "_InventoryBalance");

            migrationBuilder.RenameColumn(
                name: "InventoryIDId",
                table: "_InventoryBalance",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX__InventoryBalance_InventoryIDId",
                table: "_InventoryBalance",
                newName: "IX__InventoryBalance_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK__InventoryBalance__Books_BookId",
                table: "_InventoryBalance",
                column: "BookId",
                principalTable: "_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__InventoryBalance__Books_BookId",
                table: "_InventoryBalance");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "_InventoryBalance",
                newName: "InventoryIDId");

            migrationBuilder.RenameIndex(
                name: "IX__InventoryBalance_BookId",
                table: "_InventoryBalance",
                newName: "IX__InventoryBalance_InventoryIDId");

            migrationBuilder.AddForeignKey(
                name: "FK__InventoryBalance__Books_InventoryIDId",
                table: "_InventoryBalance",
                column: "InventoryIDId",
                principalTable: "_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
