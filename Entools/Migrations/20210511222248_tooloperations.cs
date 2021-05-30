using Microsoft.EntityFrameworkCore.Migrations;

namespace Entools.Migrations
{
    public partial class tooloperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToolOperations_Operations_OperatonId",
                table: "ToolOperations");

            migrationBuilder.DropIndex(
                name: "IX_ToolOperations_OperatonId",
                table: "ToolOperations");

            migrationBuilder.DropColumn(
                name: "OperatonId",
                table: "ToolOperations");

            migrationBuilder.CreateIndex(
                name: "IX_ToolOperations_Operationid",
                table: "ToolOperations",
                column: "Operationid");

            migrationBuilder.AddForeignKey(
                name: "FK_ToolOperations_Operations_Operationid",
                table: "ToolOperations",
                column: "Operationid",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToolOperations_Operations_Operationid",
                table: "ToolOperations");

            migrationBuilder.DropIndex(
                name: "IX_ToolOperations_Operationid",
                table: "ToolOperations");

            migrationBuilder.AddColumn<int>(
                name: "OperatonId",
                table: "ToolOperations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToolOperations_OperatonId",
                table: "ToolOperations",
                column: "OperatonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToolOperations_Operations_OperatonId",
                table: "ToolOperations",
                column: "OperatonId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
