using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrintPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPrintCosts_SupplierPrintPriceScales_fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPrintPrices_SupplierPrintCosts_fk_printCostprintCost_id",
                table: "SupplierPrintPrices");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPrintPrices_fk_printCostprintCost_id",
                table: "SupplierPrintPrices");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPrintCosts_fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "fk_printCostprintCost_id",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "printPrice_code",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts");

            migrationBuilder.AddColumn<int>(
                name: "fk_supplerPrintCostprintCost_id",
                table: "SupplierPrintPriceScales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_description",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "printCost_rangeId",
                table: "SupplierPrintCosts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "fk_supplierPrintPriceprintPrice_id",
                table: "SupplierPrintCosts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPrintPriceScales_fk_supplerPrintCostprintCost_id",
                table: "SupplierPrintPriceScales",
                column: "fk_supplerPrintCostprintCost_id");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPrintCosts_fk_supplierPrintPriceprintPrice_id",
                table: "SupplierPrintCosts",
                column: "fk_supplierPrintPriceprintPrice_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPrintCosts_SupplierPrintPrices_fk_supplierPrintPriceprintPrice_id",
                table: "SupplierPrintCosts",
                column: "fk_supplierPrintPriceprintPrice_id",
                principalTable: "SupplierPrintPrices",
                principalColumn: "printPrice_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPrintPriceScales_SupplierPrintCosts_fk_supplerPrintCostprintCost_id",
                table: "SupplierPrintPriceScales",
                column: "fk_supplerPrintCostprintCost_id",
                principalTable: "SupplierPrintCosts",
                principalColumn: "printCost_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPrintCosts_SupplierPrintPrices_fk_supplierPrintPriceprintPrice_id",
                table: "SupplierPrintCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPrintPriceScales_SupplierPrintCosts_fk_supplerPrintCostprintCost_id",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPrintPriceScales_fk_supplerPrintCostprintCost_id",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPrintCosts_fk_supplierPrintPriceprintPrice_id",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "fk_supplerPrintCostprintCost_id",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "printPrice_description",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "fk_supplierPrintPriceprintPrice_id",
                table: "SupplierPrintCosts");

            migrationBuilder.AddColumn<int>(
                name: "fk_printCostprintCost_id",
                table: "SupplierPrintPrices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_code",
                table: "SupplierPrintPrices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "printCost_rangeId",
                table: "SupplierPrintCosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPrintPrices_fk_printCostprintCost_id",
                table: "SupplierPrintPrices",
                column: "fk_printCostprintCost_id");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPrintCosts_fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts",
                column: "fk_printPriceScalesscale_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPrintCosts_SupplierPrintPriceScales_fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts",
                column: "fk_printPriceScalesscale_id",
                principalTable: "SupplierPrintPriceScales",
                principalColumn: "scale_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPrintPrices_SupplierPrintCosts_fk_printCostprintCost_id",
                table: "SupplierPrintPrices",
                column: "fk_printCostprintCost_id",
                principalTable: "SupplierPrintCosts",
                principalColumn: "printCost_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
