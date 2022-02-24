using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddComplaints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComplaintId",
                table: "RequestProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoicingEmail",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cause = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestProducts_ComplaintId",
                table: "RequestProducts",
                column: "ComplaintId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProducts_Complaints_ComplaintId",
                table: "RequestProducts",
                column: "ComplaintId",
                principalTable: "Complaints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestProducts_Complaints_ComplaintId",
                table: "RequestProducts");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_RequestProducts_ComplaintId",
                table: "RequestProducts");

            migrationBuilder.DropColumn(
                name: "ComplaintId",
                table: "RequestProducts");

            migrationBuilder.DropColumn(
                name: "InvoicingEmail",
                table: "Customers");
        }
    }
}
