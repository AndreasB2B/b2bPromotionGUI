using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrintPrices4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "printCost_areaTo",
                table: "SupplierPrintCosts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "printCost_areaFrom",
                table: "SupplierPrintCosts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "printCost_areaTo",
                table: "SupplierPrintCosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "printCost_areaFrom",
                table: "SupplierPrintCosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
