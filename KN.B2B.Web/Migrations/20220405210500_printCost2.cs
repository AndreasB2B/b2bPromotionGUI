using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class printCost2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scale_nextPrice",
                table: "SupplierPrintPriceScales");

            migrationBuilder.AddColumn<bool>(
                name: "alert",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "alertMessage",
                table: "SupplierPrintPriceScales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alertStatus",
                table: "SupplierPrintPriceScales",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "scale_nextPriceDK",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "scale_nextPriceEU",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "scale_nextPriceFI",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "scale_nextPriceSupplier",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "alert",
                table: "SupplierPrintPrices",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "alertMessage",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alertStatus",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "alert",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "alertMessage",
                table: "SupplierPrintCosts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alertStatus",
                table: "SupplierPrintCosts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alert",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "alertMessage",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "alertStatus",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_nextPriceDK",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_nextPriceEU",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_nextPriceFI",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_nextPriceSupplier",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "alert",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "alertMessage",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "alertStatus",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "alert",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "alertMessage",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "alertStatus",
                table: "SupplierPrintCosts");

            migrationBuilder.AddColumn<float>(
                name: "scale_nextPrice",
                table: "SupplierPrintPriceScales",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
