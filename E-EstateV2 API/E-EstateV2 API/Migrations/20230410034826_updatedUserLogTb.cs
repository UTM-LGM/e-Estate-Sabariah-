using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class updatedUserLogTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "userActivityLogs",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "buttonName",
                table: "userActivityLogs",
                newName: "url");

            migrationBuilder.AddColumn<string>(
                name: "body",
                table: "userActivityLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "method",
                table: "userActivityLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "userActivityLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "body",
                table: "userActivityLogs");

            migrationBuilder.DropColumn(
                name: "method",
                table: "userActivityLogs");

            migrationBuilder.DropColumn(
                name: "role",
                table: "userActivityLogs");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "userActivityLogs",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "userActivityLogs",
                newName: "buttonName");
        }
    }
}
