using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class scalingUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BProductPrices_B2BProdducts_fk_productSkuproduct_id",
                table: "B2BProductPrices");

            migrationBuilder.DropIndex(
                name: "IX_B2BProductPrices_fk_productSkuproduct_id",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "fk_productSkuproduct_id",
                table: "B2BProductPrices");

            migrationBuilder.AddColumn<string>(
                name: "parrentSku",
                table: "B2BProductPrices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parrentSku",
                table: "B2BProductPrices");

            migrationBuilder.AddColumn<int>(
                name: "fk_productSkuproduct_id",
                table: "B2BProductPrices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_B2BProductPrices_fk_productSkuproduct_id",
                table: "B2BProductPrices",
                column: "fk_productSkuproduct_id");

            migrationBuilder.AddForeignKey(
                name: "FK_B2BProductPrices_B2BProdducts_fk_productSkuproduct_id",
                table: "B2BProductPrices",
                column: "fk_productSkuproduct_id",
                principalTable: "B2BProdducts",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
