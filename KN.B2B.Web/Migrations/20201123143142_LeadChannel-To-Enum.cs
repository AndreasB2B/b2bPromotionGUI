using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class LeadChannelToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_LeadChannel_ChannelId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "LeadChannel");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ChannelId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeliveryDeadline",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "Channel",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Channel",
                table: "Leads",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Channel",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDeadline",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Channel",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LeadChannel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Occurence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ChannelId",
                table: "Requests",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_RequestId",
                table: "Status",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_LeadChannel_ChannelId",
                table: "Requests",
                column: "ChannelId",
                principalTable: "LeadChannel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
