using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class versions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VersionRequests_Versions_VersionId",
                table: "VersionRequests");

            migrationBuilder.DropIndex(
                name: "IX_VersionRequests_VersionId",
                table: "VersionRequests");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "VersionRequests");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PartId",
                table: "Requests",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_VersionId",
                table: "Requests",
                column: "VersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Parts_PartId",
                table: "Requests",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Versions_VersionId",
                table: "Requests",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Parts_PartId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Versions_VersionId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_PartId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_VersionId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "VersionRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VersionRequests_VersionId",
                table: "VersionRequests",
                column: "VersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_VersionRequests_Versions_VersionId",
                table: "VersionRequests",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
