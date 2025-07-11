using Microsoft.EntityFrameworkCore.Migrations;

namespace EAD.Migrations
{
    public partial class AddFtpResultsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FtpResults",
                columns: table => new
                {
                    FilePath = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FtpConfigurationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FtpResults", x => x.FilePath);
                    table.ForeignKey(
                        name: "FK_FtpResults_FtpConfigurations_FtpConfigurationId",
                        column: x => x.FtpConfigurationId,
                        principalTable: "FtpConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FtpResults_FtpConfigurationId",
                table: "FtpResults",
                column: "FtpConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FtpResults");
        }
    }
}