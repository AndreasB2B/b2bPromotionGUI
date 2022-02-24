using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddCustomerInvoicingZip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoicingZipId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_InvoicingZipId",
                table: "Customers",
                column: "InvoicingZipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ZipCodes_InvoicingZipId",
                table: "Customers",
                column: "InvoicingZipId",
                principalTable: "ZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ZipCodes_InvoicingZipId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_InvoicingZipId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "InvoicingZipId",
                table: "Customers");
        }
    }
}
