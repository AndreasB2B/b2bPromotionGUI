using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scale_price",
                table: "B2BPriceScaling");

            migrationBuilder.AddColumn<string>(
                name: "scale_priceDK",
                table: "B2BPriceScaling",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "scale_priceEU",
                table: "B2BPriceScaling",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scale_priceDK",
                table: "B2BPriceScaling");

            migrationBuilder.DropColumn(
                name: "scale_priceEU",
                table: "B2BPriceScaling");

            migrationBuilder.AddColumn<string>(
                name: "scale_price",
                table: "B2BPriceScaling",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
