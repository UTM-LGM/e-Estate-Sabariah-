using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class estateIdCostAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estateId",
                table: "costAmounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_costAmounts_estateId",
                table: "costAmounts",
                column: "estateId");

            migrationBuilder.AddForeignKey(
                name: "FK_costAmounts_estates_estateId",
                table: "costAmounts",
                column: "estateId",
                principalTable: "estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_costAmounts_estates_estateId",
                table: "costAmounts");

            migrationBuilder.DropIndex(
                name: "IX_costAmounts_estateId",
                table: "costAmounts");

            migrationBuilder.DropColumn(
                name: "estateId",
                table: "costAmounts");
        }
    }
}
