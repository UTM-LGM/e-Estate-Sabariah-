using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class FieldDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    area = table.Column<int>(type: "int", nullable: false),
                    isMature = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOpenTapping = table.Column<DateTime>(type: "datetime2", nullable: false),
                    yearPlanted = table.Column<int>(type: "int", nullable: false),
                    otherCrop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalTask = table.Column<int>(type: "int", nullable: false),
                    cropCategoryId = table.Column<int>(type: "int", nullable: false),
                    estateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fields_cropCategories_cropCategoryId",
                        column: x => x.cropCategoryId,
                        principalTable: "cropCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fields_estates_estateId",
                        column: x => x.estateId,
                        principalTable: "estates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fieldClones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fieldId = table.Column<int>(type: "int", nullable: false),
                    cloneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fieldClones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fieldClones_clones_cloneId",
                        column: x => x.cloneId,
                        principalTable: "clones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fieldClones_fields_fieldId",
                        column: x => x.fieldId,
                        principalTable: "fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fieldClones_cloneId",
                table: "fieldClones",
                column: "cloneId");

            migrationBuilder.CreateIndex(
                name: "IX_fieldClones_fieldId",
                table: "fieldClones",
                column: "fieldId");

            migrationBuilder.CreateIndex(
                name: "IX_fields_cropCategoryId",
                table: "fields",
                column: "cropCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_fields_estateId",
                table: "fields",
                column: "estateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fieldClones");

            migrationBuilder.DropTable(
                name: "fields");
        }
    }
}
