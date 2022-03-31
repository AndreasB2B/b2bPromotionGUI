using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fk_scaleIdscale_id",
                table: "B2BProductPrices",
                type: "int",
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
    }
}
