using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class RemoveRequestLinesAndContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLines");

            migrationBuilder.DropColumn(
                name: "TrackAndTraceNo",
                table: "RequestProducts");

            migrationBuilder.AddColumn<string>(
                name: "TrackingCode",
                table: "RequestProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackingCode",
                table: "RequestProducts");

            migrationBuilder.AddColumn<string>(
                name: "TrackAndTraceNo",
                table: "RequestProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    Volume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestLines_B2BCategories_ProductId",
                        column: x => x.ProductId,
                        principalTable: "B2BCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestLines_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestLines_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestLines_ProductId",
                table: "RequestLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLines_RequestId",
                table: "RequestLines",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLines_VendorId",
                table: "RequestLines",
                column: "VendorId");
        }
    }
}
