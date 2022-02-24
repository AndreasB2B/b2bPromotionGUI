using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class ShowroomAndSample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SampleApproved",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SampleRequested",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SampleSent",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Showroom",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SampleApproved",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SampleRequested",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SampleSent",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Showroom",
                table: "Customers");
        }
    }
}
