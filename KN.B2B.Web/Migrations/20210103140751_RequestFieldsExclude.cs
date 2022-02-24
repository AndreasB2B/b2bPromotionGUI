using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class RequestFieldsExclude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Channel",
                table: "Requests");

            migrationBuilder.AddColumn<bool>(
                name: "ExpressDelivery",
                table: "Requests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExpressProduction",
                table: "Requests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpressDelivery",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ExpressProduction",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "Channel",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
