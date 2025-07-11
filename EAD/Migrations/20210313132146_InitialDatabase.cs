using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EAD.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FtpConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Host = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsSFTP = table.Column<bool>(type: "bit", nullable: false),
                    Directory = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FtpConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OcrConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    DirectoryPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BarcodeLength = table.Column<int>(type: "int", nullable: false),
                    BarcodeSuffix = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    BarcodePrefix = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    FtpConfigurationId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcrConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcrConfigurations_FtpConfigurations_FtpConfigurationId",
                        column: x => x.FtpConfigurationId,
                        principalTable: "FtpConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OcrConfigurations_CreatedById",
                table: "OcrConfigurations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OcrConfigurations_FtpConfigurationId",
                table: "OcrConfigurations",
                column: "FtpConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_OcrConfigurations_Name",
                table: "OcrConfigurations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_OcrConfigurations_UpdatedById",
                table: "OcrConfigurations",
                column: "UpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OcrConfigurations");

            migrationBuilder.DropTable(
                name: "FtpConfigurations");
        }
    }
}