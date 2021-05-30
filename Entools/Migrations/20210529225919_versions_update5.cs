using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class versions_update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GCodeUrl",
                table: "Versions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GCodeUrl",
                table: "Versions");
        }
    }
}
