using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class update_operations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VersionRequests");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "VersionRequests");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "VersionRequests");

            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "VersionRequests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "VersionRequests");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "VersionRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VersionRequests_RequestId",
                table: "VersionRequests",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_VersionRequests_Request_RequestId",
                table: "VersionRequests",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VersionRequests_Request_RequestId",
                table: "VersionRequests");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropIndex(
                name: "IX_VersionRequests_RequestId",
                table: "VersionRequests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "VersionRequests");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VersionRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "VersionRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "VersionRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "VersionRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "VersionRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
