using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddRequestDeliveryAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryZipId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeliveryZipId",
                table: "Requests",
                column: "DeliveryZipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ZipCodes_DeliveryZipId",
                table: "Requests",
                column: "DeliveryZipId",
                principalTable: "ZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ZipCodes_DeliveryZipId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DeliveryZipId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeliveryZipId",
                table: "Requests");
        }
    }
}
