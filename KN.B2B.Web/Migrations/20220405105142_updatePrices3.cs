using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrices3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "printPrice_setup",
                table: "SupplierPrintPrices");

            migrationBuilder.AddColumn<string>(
                name: "printPrice_setupDK",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_setupEU",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_setupFI",
                table: "SupplierPrintPrices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "printPrice_setupDK",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "printPrice_setupEU",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "printPrice_setupFI",
                table: "SupplierPrintPrices");

            migrationBuilder.AddColumn<string>(
                name: "printPrice_setup",
                table: "SupplierPrintPrices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
