using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDirectCostDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_directCosts_typeCategories_typeCategoryId",
                table: "directCosts");

            migrationBuilder.DropIndex(
                name: "IX_directCosts_typeCategoryId",
                table: "directCosts");

            migrationBuilder.DropColumn(
                name: "typeCategoryId",
                table: "directCosts");

            migrationBuilder.AddColumn<int>(
                name: "typeCategoryId",
                table: "costDirectCosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_costDirectCosts_typeCategoryId",
                table: "costDirectCosts",
                column: "typeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_costDirectCosts_typeCategories_typeCategoryId",
                table: "costDirectCosts",
                column: "typeCategoryId",
                principalTable: "typeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_costDirectCosts_typeCategories_typeCategoryId",
                table: "costDirectCosts");

            migrationBuilder.DropIndex(
                name: "IX_costDirectCosts_typeCategoryId",
                table: "costDirectCosts");

            migrationBuilder.DropColumn(
                name: "typeCategoryId",
                table: "costDirectCosts");

            migrationBuilder.AddColumn<int>(
                name: "typeCategoryId",
                table: "directCosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_directCosts_typeCategoryId",
                table: "directCosts",
                column: "typeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_directCosts_typeCategories_typeCategoryId",
                table: "directCosts",
                column: "typeCategoryId",
                principalTable: "typeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
