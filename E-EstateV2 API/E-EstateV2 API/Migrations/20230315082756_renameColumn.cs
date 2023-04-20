using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class renameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "costCategory2",
                table: "costSubcategories2",
                newName: "costSubcategory2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "costSubcategory2",
                table: "costSubcategories2",
                newName: "costCategory2");
        }
    }
}
