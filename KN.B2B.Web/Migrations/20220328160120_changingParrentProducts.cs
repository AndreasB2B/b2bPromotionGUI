using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class changingParrentProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parrentProduct_mertial",
                table: "B2BParrentProducts");

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_material",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_productName",
                table: "B2BParrentProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parrentProduct_material",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_productName",
                table: "B2BParrentProducts");

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_mertial",
                table: "B2BParrentProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
