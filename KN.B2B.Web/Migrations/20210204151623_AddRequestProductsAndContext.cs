using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddRequestProductsAndContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: true),
                    B2BCategoryId = table.Column<int>(nullable: true),
                    VendorId = table.Column<int>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippingDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    TrackAndTraceNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestProducts_B2BCategories_B2BCategoryId",
                        column: x => x.B2BCategoryId,
                        principalTable: "B2BCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestProducts_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestProducts_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestProducts_B2BCategoryId",
                table: "RequestProducts",
                column: "B2BCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestProducts_RequestId",
                table: "RequestProducts",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestProducts_VendorId",
                table: "RequestProducts",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestProducts");
        }
    }
}
