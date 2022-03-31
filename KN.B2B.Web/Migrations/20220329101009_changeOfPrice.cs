using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class changeOfPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BPriceScales_B2BProductPrices_fk_priceIdid",
                table: "B2BPriceScales");

            migrationBuilder.DropIndex(
                name: "IX_B2BPriceScales_fk_priceIdid",
                table: "B2BPriceScales");

            migrationBuilder.DropColumn(
                name: "price_scale",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "fk_priceIdid",
                table: "B2BPriceScales");

            migrationBuilder.AddColumn<int>(
                name: "fk_scaleIdscale_id",
                table: "B2BProductPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "price_validUntill",
                table: "B2BProductPrices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_B2BProductPrices_fk_scaleIdscale_id",
                table: "B2BProductPrices",
                column: "fk_scaleIdscale_id");

            migrationBuilder.AddForeignKey(
                name: "FK_B2BProductPrices_B2BPriceScales_fk_scaleIdscale_id",
                table: "B2BProductPrices",
                column: "fk_scaleIdscale_id",
                principalTable: "B2BPriceScales",
                principalColumn: "scale_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BProductPrices_B2BPriceScales_fk_scaleIdscale_id",
                table: "B2BProductPrices");

            migrationBuilder.DropIndex(
                name: "IX_B2BProductPrices_fk_scaleIdscale_id",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "fk_scaleIdscale_id",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "price_validUntill",
                table: "B2BProductPrices");

            migrationBuilder.AddColumn<int>(
                name: "price_scale",
                table: "B2BProductPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_priceIdid",
                table: "B2BPriceScales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_B2BPriceScales_fk_priceIdid",
                table: "B2BPriceScales",
                column: "fk_priceIdid");

            migrationBuilder.AddForeignKey(
                name: "FK_B2BPriceScales_B2BProductPrices_fk_priceIdid",
                table: "B2BPriceScales",
                column: "fk_priceIdid",
                principalTable: "B2BProductPrices",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
