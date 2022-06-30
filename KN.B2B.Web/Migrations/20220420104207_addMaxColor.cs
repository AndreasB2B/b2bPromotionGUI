using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class addMaxColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "maxColors",
                table: "B2BPrintPositions",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxColors",
                table: "B2BPrintPositions");
        }
    }
}
