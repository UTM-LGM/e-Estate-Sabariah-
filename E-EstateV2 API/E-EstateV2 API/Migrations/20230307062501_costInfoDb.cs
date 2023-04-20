using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class costInfoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_indirectCosts_typeCategories_typeCategoryId",
                table: "indirectCosts");

            migrationBuilder.RenameColumn(
                name: "typeCategoryId",
                table: "indirectCosts",
                newName: "itemCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_indirectCosts_typeCategoryId",
                table: "indirectCosts",
                newName: "IX_indirectCosts_itemCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_indirectCosts_itemCategories_itemCategoryId",
                table: "indirectCosts",
                column: "itemCategoryId",
                principalTable: "itemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_indirectCosts_itemCategories_itemCategoryId",
                table: "indirectCosts");

            migrationBuilder.RenameColumn(
                name: "itemCategoryId",
                table: "indirectCosts",
                newName: "typeCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_indirectCosts_itemCategoryId",
                table: "indirectCosts",
                newName: "IX_indirectCosts_typeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_indirectCosts_typeCategories_typeCategoryId",
                table: "indirectCosts",
                column: "typeCategoryId",
                principalTable: "typeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
