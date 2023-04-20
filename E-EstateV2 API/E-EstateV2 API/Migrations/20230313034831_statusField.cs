using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class statusField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "fields");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "fields",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "fields");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "fields",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
