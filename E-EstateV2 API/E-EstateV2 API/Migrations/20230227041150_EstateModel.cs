using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    /// <inheritdoc />
    public partial class EstateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "adddress3",
                table: "companies",
                newName: "address3");

            migrationBuilder.RenameColumn(
                name: "adddress2",
                table: "companies",
                newName: "address2");

            migrationBuilder.RenameColumn(
                name: "adddress1",
                table: "companies",
                newName: "address1");

            migrationBuilder.CreateTable(
                name: "establishments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    establishment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_establishments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "financialYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    financialYear = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financialYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "membershipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membershipType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_towns_states_stateId",
                        column: x => x.stateId,
                        principalTable: "states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    licenseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    managerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    townId = table.Column<int>(type: "int", nullable: false),
                    establishmentId = table.Column<int>(type: "int", nullable: false),
                    financialYearId = table.Column<int>(type: "int", nullable: false),
                    membershipTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estates_companies_companyId",
                        column: x => x.companyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estates_establishments_establishmentId",
                        column: x => x.establishmentId,
                        principalTable: "establishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estates_financialYears_financialYearId",
                        column: x => x.financialYearId,
                        principalTable: "financialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estates_membershipTypes_membershipTypeId",
                        column: x => x.membershipTypeId,
                        principalTable: "membershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estates_towns_townId",
                        column: x => x.townId,
                        principalTable: "towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estates_companyId",
                table: "estates",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_estates_establishmentId",
                table: "estates",
                column: "establishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_estates_financialYearId",
                table: "estates",
                column: "financialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_estates_membershipTypeId",
                table: "estates",
                column: "membershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_estates_townId",
                table: "estates",
                column: "townId");

            migrationBuilder.CreateIndex(
                name: "IX_towns_stateId",
                table: "towns",
                column: "stateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estates");

            migrationBuilder.DropTable(
                name: "establishments");

            migrationBuilder.DropTable(
                name: "financialYears");

            migrationBuilder.DropTable(
                name: "membershipTypes");

            migrationBuilder.DropTable(
                name: "towns");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.RenameColumn(
                name: "address3",
                table: "companies",
                newName: "adddress3");

            migrationBuilder.RenameColumn(
                name: "address2",
                table: "companies",
                newName: "adddress2");

            migrationBuilder.RenameColumn(
                name: "address1",
                table: "companies",
                newName: "adddress1");
        }
    }
}
