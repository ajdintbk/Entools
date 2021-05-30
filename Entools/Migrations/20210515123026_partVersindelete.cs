using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class partVersindelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Versions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Versions_PartId",
                table: "Versions",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Versions_Parts_PartId",
                table: "Versions",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
