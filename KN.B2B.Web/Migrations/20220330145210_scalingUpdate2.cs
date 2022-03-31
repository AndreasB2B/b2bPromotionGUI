using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class scalingUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fk_priceIdid",
                table: "B2BPriceScaling",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_B2BPriceScaling_fk_priceIdid",
                table: "B2BPriceScaling",
                column: "fk_priceIdid");

            migrationBuilder.AddForeignKey(
                name: "FK_B2BPriceScaling_B2BProductPrices_fk_priceIdid",
                table: "B2BPriceScaling",
                column: "fk_priceIdid",
                principalTable: "B2BProductPrices",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BPriceScaling_B2BProductPrices_fk_priceIdid",
                table: "B2BPriceScaling");

            migrationBuilder.DropIndex(
                name: "IX_B2BPriceScaling_fk_priceIdid",
                table: "B2BPriceScaling");

            migrationBuilder.DropColumn(
                name: "fk_priceIdid",
                table: "B2BPriceScaling");
        }
    }
}
