using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class RenameInquirytoRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deadline_Inquiries_InquiryId",
                table: "Deadline");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Inquiries_InquiryId",
                table: "Status");

            migrationBuilder.DropTable(
                name: "InquiryLines");

            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Status_InquiryId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Deadline_InquiryId",
                table: "Deadline");

            migrationBuilder.DropColumn(
                name: "InquiryId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "InquiryId",
                table: "Deadline");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Status",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Deadline",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    LeadId = table.Column<int>(nullable: true),
                    ChannelId = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    B2bInvoiceNumber = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    TrustPilot = table.Column<bool>(nullable: false),
                    TrustPilotDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    ShipmentDate = table.Column<DateTime>(nullable: false),
                    TrackAndTrace = table.Column<string>(nullable: true),
                    LegalAction = table.Column<bool>(nullable: false),
                    ExpressProduction = table.Column<bool>(nullable: false),
                    ExpressDelivery = table.Column<bool>(nullable: false),
                    Sugar = table.Column<int>(nullable: false),
                    SugarTax = table.Column<int>(nullable: false),
                    SugarFree = table.Column<int>(nullable: false),
                    SugarFreeTax = table.Column<int>(nullable: false),
                    Copydan = table.Column<int>(nullable: false),
                    CopydanTax = table.Column<int>(nullable: false),
                    Packaging = table.Column<int>(nullable: false),
                    PackagingTax = table.Column<int>(nullable: false),
                    Design = table.Column<int>(nullable: false),
                    DesignFee = table.Column<int>(nullable: false),
                    InvoiceDiscount = table.Column<int>(nullable: false),
                    DeliveryDeadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_LeadChannel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "LeadChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: true),
                    LineDate = table.Column<DateTime>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestLines_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Status_RequestId",
                table: "Status",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Deadline_RequestId",
                table: "Deadline",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLines_RequestId",
                table: "RequestLines",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ChannelId",
                table: "Requests",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_LeadId",
                table: "Requests",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deadline_Requests_RequestId",
                table: "Deadline",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Requests_RequestId",
                table: "Status",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deadline_Requests_RequestId",
                table: "Deadline");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Requests_RequestId",
                table: "Status");

            migrationBuilder.DropTable(
                name: "RequestLines");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Status_RequestId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Deadline_RequestId",
                table: "Deadline");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Deadline");

            migrationBuilder.AddColumn<int>(
                name: "InquiryId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InquiryId",
                table: "Deadline",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B2bInvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelId = table.Column<int>(type: "int", nullable: true),
                    Copydan = table.Column<int>(type: "int", nullable: false),
                    CopydanTax = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Design = table.Column<int>(type: "int", nullable: false),
                    DesignFee = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpressDelivery = table.Column<bool>(type: "bit", nullable: false),
                    ExpressProduction = table.Column<bool>(type: "bit", nullable: false),
                    InquiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceDiscount = table.Column<int>(type: "int", nullable: false),
                    LeadId = table.Column<int>(type: "int", nullable: true),
                    LegalAction = table.Column<bool>(type: "bit", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Packaging = table.Column<int>(type: "int", nullable: false),
                    PackagingTax = table.Column<int>(type: "int", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sugar = table.Column<int>(type: "int", nullable: false),
                    SugarFree = table.Column<int>(type: "int", nullable: false),
                    SugarFreeTax = table.Column<int>(type: "int", nullable: false),
                    SugarTax = table.Column<int>(type: "int", nullable: false),
                    TrackAndTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrustPilot = table.Column<bool>(type: "bit", nullable: false),
                    TrustPilotDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiries_LeadChannel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "LeadChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inquiries_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InquiryLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    InquiryId = table.Column<int>(type: "int", nullable: true),
                    LineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InquiryLines_Inquiries_InquiryId",
                        column: x => x.InquiryId,
                        principalTable: "Inquiries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Status_InquiryId",
                table: "Status",
                column: "InquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Deadline_InquiryId",
                table: "Deadline",
                column: "InquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_ChannelId",
                table: "Inquiries",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_LeadId",
                table: "Inquiries",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_InquiryLines_InquiryId",
                table: "InquiryLines",
                column: "InquiryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deadline_Inquiries_InquiryId",
                table: "Deadline",
                column: "InquiryId",
                principalTable: "Inquiries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Inquiries_InquiryId",
                table: "Status",
                column: "InquiryId",
                principalTable: "Inquiries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
