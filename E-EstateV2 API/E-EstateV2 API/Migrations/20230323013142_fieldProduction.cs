using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class fieldProduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fieldProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    monthYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cuplump = table.Column<int>(type: "int", nullable: false),
                    cuplumpDRC = table.Column<int>(type: "int", nullable: false),
                    latex = table.Column<int>(type: "int", nullable: false),
                    latexDRC = table.Column<int>(type: "int", nullable: false),
                    noTaskTap = table.Column<int>(type: "int", nullable: false),
                    noTaskUntap = table.Column<int>(type: "int", nullable: false),
                    fieldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fieldProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fieldProductions_fields_fieldId",
                        column: x => x.fieldId,
                        principalTable: "fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fieldProductions_fieldId",
                table: "fieldProductions",
                column: "fieldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fieldProductions");
        }
    }
}
