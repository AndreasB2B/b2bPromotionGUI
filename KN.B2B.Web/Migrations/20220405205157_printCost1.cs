using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class printCost1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaFromEU",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaFromFI",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaFromSupplier",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaToDK",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaToEU",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaToFI",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaToSupplier",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "printCost_areaTo",
                table: "SupplierPrintCosts",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
