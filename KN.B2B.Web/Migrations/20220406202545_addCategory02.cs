using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class addCategory02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parrentProduct_subCategory",
                table: "B2BParrentProducts");

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_subCategoryDK",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_subCategoryEN",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_subCategoryFI",
                table: "B2BParrentProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parrentProduct_subCategoryDK",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_subCategoryEN",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_subCategoryFI",
                table: "B2BParrentProducts");

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_subCategory",
                table: "B2BParrentProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
