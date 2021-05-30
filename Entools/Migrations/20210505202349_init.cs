using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D1Sketch1 = table.Column<float>(type: "real", nullable: false),
                    D2Sketch1 = table.Column<float>(type: "real", nullable: false),
                    D1BossExtrude1 = table.Column<float>(type: "real", nullable: false),
                    D1Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D3Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D5Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D6Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D7Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D9Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D10Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D11Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D12Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D8Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D14Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D15Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D13Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D4Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D16Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D18Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D19Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D17Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D20Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D21Sketch2 = table.Column<float>(type: "real", nullable: false),
                    D1BossExtrude2 = table.Column<float>(type: "real", nullable: false),
                    D1Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D2Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D3Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D4Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D5Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D6Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D7Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D8Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D9Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D10Sketch3 = table.Column<float>(type: "real", nullable: false),
                    D1CutExtrude1 = table.Column<float>(type: "real", nullable: false),
                    D2Sketch4 = table.Column<float>(type: "real", nullable: false),
                    D3Sketch4 = table.Column<float>(type: "real", nullable: false),
                    D1CutExtrude2 = table.Column<float>(type: "real", nullable: false),
                    D1Sketch5 = table.Column<float>(type: "real", nullable: false),
                    D2Sketch5 = table.Column<float>(type: "real", nullable: false),
                    D3Sketch5 = table.Column<float>(type: "real", nullable: false),
                    D1CutExtrude3 = table.Column<float>(type: "real", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    Operationid = table.Column<int>(type: "int", nullable: false),
                    OperatonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolOperations_Operations_OperatonId",
                        column: x => x.OperatonId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToolOperations_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    VersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartVersions_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartVersions_Versions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VersionOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VersionId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VersionOperations_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VersionOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VersionOperations_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VersionOperations_Versions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartVersions_PartId",
                table: "PartVersions",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartVersions_VersionId",
                table: "PartVersions",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolOperations_OperatonId",
                table: "ToolOperations",
                column: "OperatonId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolOperations_ToolId",
                table: "ToolOperations",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionOperations_MachineId",
                table: "VersionOperations",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionOperations_OperationId",
                table: "VersionOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionOperations_ToolId",
                table: "VersionOperations",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionOperations_VersionId",
                table: "VersionOperations",
                column: "VersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartVersions");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "ToolOperations");

            migrationBuilder.DropTable(
                name: "VersionOperations");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Versions");
        }
    }
}
