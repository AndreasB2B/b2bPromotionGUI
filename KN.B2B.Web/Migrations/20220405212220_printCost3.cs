using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class printCost3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "printCost_areaFromDK",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaFromEU",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaFromFI",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaFromSupplier",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaToDK",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaToEU",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaToFI",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaToSupplier",
                table: "SupplierPrintCosts");

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaFrom",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaTo",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "printCost_areaFrom",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaTo",
                table: "SupplierPrintCosts");

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaFromDK",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaFromEU",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaFromFI",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaFromSupplier",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaToDK",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaToEU",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaToFI",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaToSupplier",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
