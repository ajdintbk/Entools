using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class partoperations8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GCodeUrl",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpened",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GCodeUrl",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsOpened",
                table: "Requests");
        }
    }
}
