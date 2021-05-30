using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class partoperations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BottomImagePath",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontImagePath",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BottomImagePath",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "FrontImagePath",
                table: "Parts");
        }
    }
}
