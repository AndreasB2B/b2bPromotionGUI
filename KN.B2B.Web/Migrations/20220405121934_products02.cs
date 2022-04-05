using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class products02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "alert",
                table: "B2BParrentProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "alertMessage",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alertStatus",
                table: "B2BParrentProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alert",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "alertMessage",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "alertStatus",
                table: "B2BParrentProducts");
        }
    }
}
