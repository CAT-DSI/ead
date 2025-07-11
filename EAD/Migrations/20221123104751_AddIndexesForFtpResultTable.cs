using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAD.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexesForFtpResultTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FtpConfigurations",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FtpResults_Date",
                table: "FtpResults",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_FtpResults_FilePath",
                table: "FtpResults",
                column: "FilePath");

            migrationBuilder.CreateIndex(
                name: "IX_FtpResults_Status",
                table: "FtpResults",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FtpResults_Date",
                table: "FtpResults");

            migrationBuilder.DropIndex(
                name: "IX_FtpResults_FilePath",
                table: "FtpResults");

            migrationBuilder.DropIndex(
                name: "IX_FtpResults_Status",
                table: "FtpResults");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FtpConfigurations",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }
    }
}
