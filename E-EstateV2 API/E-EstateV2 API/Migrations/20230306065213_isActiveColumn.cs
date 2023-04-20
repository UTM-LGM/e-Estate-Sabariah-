using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class isActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "estateStatusLog");

            migrationBuilder.DropColumn(
                name: "status",
                table: "estates");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "towns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "states",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "membershipTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "financialYears",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "estateStatusLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "estates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "establishments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "cropCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "cloneCode",
                table: "clones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "clones",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "towns");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "states");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "membershipTypes");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "financialYears");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "estateStatusLog");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "estates");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "establishments");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "cropCategories");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "cloneCode",
                table: "clones");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "clones");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "estateStatusLog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "estates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
