using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "costDirectCosts");

            migrationBuilder.DropTable(
                name: "costIndirectCosts");

            migrationBuilder.DropTable(
                name: "directCosts");

            migrationBuilder.DropTable(
                name: "typeCategories");

            migrationBuilder.DropTable(
                name: "costs");

            migrationBuilder.DropTable(
                name: "indirectCosts");

            migrationBuilder.DropTable(
                name: "costCategories");

            migrationBuilder.DropTable(
                name: "itemCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "costCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isMature = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "costs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estateId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_costs_estates_estateId",
                        column: x => x.estateId,
                        principalTable: "estates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "typeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    costCategoryId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    typeCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_typeCategories_costCategories_costCategoryId",
                        column: x => x.costCategoryId,
                        principalTable: "costCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "directCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemCategoryId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_directCosts_itemCategories_itemCategoryId",
                        column: x => x.itemCategoryId,
                        principalTable: "itemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "indirectCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemCategoryId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_indirectCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_indirectCosts_itemCategories_itemCategoryId",
                        column: x => x.itemCategoryId,
                        principalTable: "itemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "costDirectCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    costId = table.Column<int>(type: "int", nullable: false),
                    directCostId = table.Column<int>(type: "int", nullable: false),
                    typeCategoryId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costDirectCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_costDirectCosts_costs_costId",
                        column: x => x.costId,
                        principalTable: "costs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_costDirectCosts_directCosts_directCostId",
                        column: x => x.directCostId,
                        principalTable: "directCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_costDirectCosts_typeCategories_typeCategoryId",
                        column: x => x.typeCategoryId,
                        principalTable: "typeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "costIndirectCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    costId = table.Column<int>(type: "int", nullable: false),
                    indirectCostId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costIndirectCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_costIndirectCosts_costs_costId",
                        column: x => x.costId,
                        principalTable: "costs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_costIndirectCosts_indirectCosts_indirectCostId",
                        column: x => x.indirectCostId,
                        principalTable: "indirectCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_costDirectCosts_costId",
                table: "costDirectCosts",
                column: "costId");

            migrationBuilder.CreateIndex(
                name: "IX_costDirectCosts_directCostId",
                table: "costDirectCosts",
                column: "directCostId");

            migrationBuilder.CreateIndex(
                name: "IX_costDirectCosts_typeCategoryId",
                table: "costDirectCosts",
                column: "typeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_costIndirectCosts_costId",
                table: "costIndirectCosts",
                column: "costId");

            migrationBuilder.CreateIndex(
                name: "IX_costIndirectCosts_indirectCostId",
                table: "costIndirectCosts",
                column: "indirectCostId");

            migrationBuilder.CreateIndex(
                name: "IX_costs_estateId",
                table: "costs",
                column: "estateId");

            migrationBuilder.CreateIndex(
                name: "IX_directCosts_itemCategoryId",
                table: "directCosts",
                column: "itemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_indirectCosts_itemCategoryId",
                table: "indirectCosts",
                column: "itemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_typeCategories_costCategoryId",
                table: "typeCategories",
                column: "costCategoryId");
        }
    }
}
