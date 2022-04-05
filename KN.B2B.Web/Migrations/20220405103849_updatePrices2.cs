using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrices2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scale_price",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "handles_price",
                table: "SupplierHandles");

            migrationBuilder.AddColumn<float>(
                name: "scale_priceDK",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "scale_priceEU",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "scale_priceFI",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "handles_priceDK",
                table: "SupplierHandles",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "handles_priceEU",
                table: "SupplierHandles",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "handles_priceFI",
                table: "SupplierHandles",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scale_priceDK",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_priceEU",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_priceFI",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "handles_priceDK",
                table: "SupplierHandles");

            migrationBuilder.DropColumn(
                name: "handles_priceEU",
                table: "SupplierHandles");

            migrationBuilder.DropColumn(
                name: "handles_priceFI",
                table: "SupplierHandles");

            migrationBuilder.AddColumn<float>(
                name: "scale_price",
                table: "SupplierPrintPriceScales",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "handles_price",
                table: "SupplierHandles",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
