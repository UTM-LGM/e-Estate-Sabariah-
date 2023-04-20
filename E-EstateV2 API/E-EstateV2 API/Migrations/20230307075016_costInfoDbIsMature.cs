using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class costInfoDbIsMature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMature",
                table: "directCosts");

            migrationBuilder.AddColumn<bool>(
                name: "isMature",
                table: "costCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMature",
                table: "costCategories");

            migrationBuilder.AddColumn<bool>(
                name: "isMature",
                table: "directCosts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
