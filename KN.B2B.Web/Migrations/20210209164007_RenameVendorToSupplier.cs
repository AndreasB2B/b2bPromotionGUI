using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class RenameVendorToSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestProducts_Vendors_VendorId",
                table: "RequestProducts");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_RequestProducts_VendorId",
                table: "RequestProducts");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "RequestProducts");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "RequestProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "RequestProducts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestProducts_SupplierId",
                table: "RequestProducts",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProducts_Suppliers_SupplierId",
                table: "RequestProducts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestProducts_Suppliers_SupplierId",
                table: "RequestProducts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_RequestProducts_SupplierId",
                table: "RequestProducts");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "RequestProducts");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "RequestProducts");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "RequestProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestProducts_VendorId",
                table: "RequestProducts",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProducts_Vendors_VendorId",
                table: "RequestProducts",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
