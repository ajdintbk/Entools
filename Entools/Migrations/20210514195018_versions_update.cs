using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class versions_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GCodePath",
                table: "Versions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GCodePath",
                table: "Versions");
        }
    }
}
