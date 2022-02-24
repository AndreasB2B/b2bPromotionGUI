using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class RequestLineExpansion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeliveryDeadline",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "FollowUpDeadline",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ShipmentDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TrackAndTrace",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "LineDate",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "RequestLines");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "RequestLines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "RequestLines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "RequestLines",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDate",
                table: "RequestLines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrackingCode",
                table: "RequestLines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "RequestLines",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "RequestLines",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestLines_VendorId",
                table: "RequestLines",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLines_Vendor_VendorId",
                table: "RequestLines",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_Vendor_VendorId",
                table: "RequestLines");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_RequestLines_VendorId",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "ShipmentDate",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "TrackingCode",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "RequestLines");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDeadline",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FollowUpDeadline",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TrackAndTrace",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "RequestLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LineDate",
                table: "RequestLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "RequestLines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
