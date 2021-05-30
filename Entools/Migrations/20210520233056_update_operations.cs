using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class update_operations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GCodeLocation",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GCodeLocation",
                table: "Operations");
        }
    }
}
