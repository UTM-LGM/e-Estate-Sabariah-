using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class costDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "costs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isMature = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    costTypeId = table.Column<int>(type: "int", nullable: false),
                    costCategoryId = table.Column<int>(type: "int", nullable: false),
                    costSubcategory1Id = table.Column<int>(type: "int", nullable: false),
                    costSubcategory2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_costs_costCategories_costCategoryId",
                        column: x => x.costCategoryId,
                        principalTable: "costCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_costs_costSubcategories1_costSubcategory1Id",
                        column: x => x.costSubcategory1Id,
                        principalTable: "costSubcategories1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_costs_costSubcategories2_costSubcategory2Id",
                        column: x => x.costSubcategory2Id,
                        principalTable: "costSubcategories2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_costs_costTypes_costTypeId",
                        column: x => x.costTypeId,
                        principalTable: "costTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_costs_costCategoryId",
                table: "costs",
                column: "costCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_costs_costSubcategory1Id",
                table: "costs",
                column: "costSubcategory1Id");

            migrationBuilder.CreateIndex(
                name: "IX_costs_costSubcategory2Id",
                table: "costs",
                column: "costSubcategory2Id");

            migrationBuilder.CreateIndex(
                name: "IX_costs_costTypeId",
                table: "costs",
                column: "costTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "costs");
        }
    }
}
