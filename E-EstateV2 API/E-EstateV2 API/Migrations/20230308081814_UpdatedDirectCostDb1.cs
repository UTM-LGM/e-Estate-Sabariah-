using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDirectCostDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "itemCategories");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "indirectCosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "directCosts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "indirectCosts");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "directCosts");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "itemCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
