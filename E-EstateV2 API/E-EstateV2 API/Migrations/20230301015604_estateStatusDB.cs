using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class estateStatusDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estateStatuses_estates_EstateId",
                table: "estateStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estateStatuses",
                table: "estateStatuses");

            migrationBuilder.RenameTable(
                name: "estateStatuses",
                newName: "estateStatusLog");

            migrationBuilder.RenameIndex(
                name: "IX_estateStatuses_EstateId",
                table: "estateStatusLog",
                newName: "IX_estateStatusLog_EstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estateStatusLog",
                table: "estateStatusLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_estateStatusLog_estates_EstateId",
                table: "estateStatusLog",
                column: "EstateId",
                principalTable: "estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estateStatusLog_estates_EstateId",
                table: "estateStatusLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estateStatusLog",
                table: "estateStatusLog");

            migrationBuilder.RenameTable(
                name: "estateStatusLog",
                newName: "estateStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_estateStatusLog_EstateId",
                table: "estateStatuses",
                newName: "IX_estateStatuses_EstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estateStatuses",
                table: "estateStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_estateStatuses_estates_EstateId",
                table: "estateStatuses",
                column: "EstateId",
                principalTable: "estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
