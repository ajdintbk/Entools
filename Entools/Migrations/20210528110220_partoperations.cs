using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class partoperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VersionOperations_Versions_VersionId",
                table: "VersionOperations");

            migrationBuilder.RenameColumn(
                name: "VersionId",
                table: "VersionOperations",
                newName: "PartId");

            migrationBuilder.RenameIndex(
                name: "IX_VersionOperations_VersionId",
                table: "VersionOperations",
                newName: "IX_VersionOperations_PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_VersionOperations_Parts_PartId",
                table: "VersionOperations",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VersionOperations_Parts_PartId",
                table: "VersionOperations");

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "VersionOperations",
                newName: "VersionId");

            migrationBuilder.RenameIndex(
                name: "IX_VersionOperations_PartId",
                table: "VersionOperations",
                newName: "IX_VersionOperations_VersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_VersionOperations_Versions_VersionId",
                table: "VersionOperations",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
