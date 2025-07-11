using Microsoft.EntityFrameworkCore.Migrations;

namespace EAD.Migrations
{
    public partial class RemovedUnnecessaryColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OcrConfigurations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "OcrConfigurations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OcrConfigurations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "OcrConfigurations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}