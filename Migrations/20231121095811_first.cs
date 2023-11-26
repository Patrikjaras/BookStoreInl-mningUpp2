using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreInlämning4.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AuthorIDId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    StoreIDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Books__Authors_AuthorIDId",
                        column: x => x.AuthorIDId,
                        principalTable: "_Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Books__Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "_Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Books__Stores_StoreIDId",
                        column: x => x.StoreIDId,
                        principalTable: "_Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_InventoryBalance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreIDId = table.Column<int>(type: "int", nullable: false),
                    InventoryIDId = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockBalance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InventoryBalance", x => x.ID);
                    table.ForeignKey(
                        name: "FK__InventoryBalance__Books_InventoryIDId",
                        column: x => x.InventoryIDId,
                        principalTable: "_Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__InventoryBalance__Stores_StoreIDId",
                        column: x => x.StoreIDId,
                        principalTable: "_Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__Books_AuthorIDId",
                table: "_Books",
                column: "AuthorIDId");

            migrationBuilder.CreateIndex(
                name: "IX__Books_CategoryId",
                table: "_Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX__Books_StoreIDId",
                table: "_Books",
                column: "StoreIDId");

            migrationBuilder.CreateIndex(
                name: "IX__InventoryBalance_InventoryIDId",
                table: "_InventoryBalance",
                column: "InventoryIDId");

            migrationBuilder.CreateIndex(
                name: "IX__InventoryBalance_StoreIDId",
                table: "_InventoryBalance",
                column: "StoreIDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_InventoryBalance");

            migrationBuilder.DropTable(
                name: "_Books");

            migrationBuilder.DropTable(
                name: "_Authors");

            migrationBuilder.DropTable(
                name: "_Categories");

            migrationBuilder.DropTable(
                name: "_Stores");
        }
    }
}
