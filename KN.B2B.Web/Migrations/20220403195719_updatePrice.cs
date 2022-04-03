using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class updatePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "scale_price",
                table: "B2BPriceScaling",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "scale_price",
                table: "B2BPriceScaling",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
