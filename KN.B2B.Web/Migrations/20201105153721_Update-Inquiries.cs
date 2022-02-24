using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class _20201105_UpdateInquiries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Leads");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Leads",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalAddress = table.Column<string>(maxLength: 255, nullable: false),
                    City = table.Column<string>(maxLength: 60, nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    Municipality = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    B2bRegion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadChannel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inquiry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InquiryDate = table.Column<DateTime>(nullable: false),
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
                    table.PrimaryKey("PK_Inquiry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiry_LeadChannel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "LeadChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inquiry_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deadline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    InquiryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deadline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deadline_Inquiry_InquiryId",
                        column: x => x.InquiryId,
                        principalTable: "Inquiry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Occurence = table.Column<DateTime>(nullable: false),
                    InquiryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_Inquiry_InquiryId",
                        column: x => x.InquiryId,
                        principalTable: "Inquiry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_AddressId",
                table: "Leads",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Deadline_InquiryId",
                table: "Deadline",
                column: "InquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiry_ChannelId",
                table: "Inquiry",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiry_LeadId",
                table: "Inquiry",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_InquiryId",
                table: "Status",
                column: "InquiryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Address_AddressId",
                table: "Leads",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Address_AddressId",
                table: "Leads");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Deadline");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Inquiry");

            migrationBuilder.DropTable(
                name: "LeadChannel");

            migrationBuilder.DropIndex(
                name: "IX_Leads_AddressId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Leads");

            migrationBuilder.AddColumn<int>(
                name: "Zipcode",
                table: "Leads",
                type: "int",
                nullable: true);
        }
    }
}
