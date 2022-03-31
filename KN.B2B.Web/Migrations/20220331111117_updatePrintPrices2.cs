using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrintPrices2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "scale_nextPrice",
                table: "SupplierPrintPriceScales",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "scale_nextPrice",
                table: "SupplierPrintPriceScales",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
