using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class versionsupdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DimensionsImagePath",
                table: "Versions",
                newName: "FrontImagePath");

            migrationBuilder.AddColumn<string>(
                name: "BottomImagePath",
                table: "Versions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottomImagePath",
                table: "Versions");

            migrationBuilder.RenameColumn(
                name: "FrontImagePath",
                table: "Versions",
                newName: "DimensionsImagePath");
        }
    }
}
