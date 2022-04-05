using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrices1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "scale_supplierPrice",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "handles_supplierPrice",
                table: "SupplierHandles",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scale_supplierPrice",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "handles_supplierPrice",
                table: "SupplierHandles");
        }
    }
}
