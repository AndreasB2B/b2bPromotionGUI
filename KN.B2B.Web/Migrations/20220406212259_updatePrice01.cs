using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrice01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price_startingPrice",
                table: "B2BProductPrices");

            migrationBuilder.AddColumn<string>(
                name: "price_startingPriceDK",
                table: "B2BProductPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "price_startingPriceEU",
                table: "B2BProductPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "price_startingPriceFI",
                table: "B2BProductPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "price_startingPriceSupplier",
                table: "B2BProductPrices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price_startingPriceDK",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "price_startingPriceEU",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "price_startingPriceFI",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "price_startingPriceSupplier",
                table: "B2BProductPrices");

            migrationBuilder.AddColumn<string>(
                name: "price_startingPrice",
                table: "B2BProductPrices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
