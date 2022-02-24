using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class UpdateInquiryLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deadline_Inquiry_InquiryId",
                table: "Deadline");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquiry_LeadChannel_ChannelId",
                table: "Inquiry");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquiry_Leads_LeadId",
                table: "Inquiry");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Inquiry_InquiryId",
                table: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inquiry",
                table: "Inquiry");

            migrationBuilder.RenameTable(
                name: "Inquiry",
                newName: "Inquiries");

            migrationBuilder.RenameIndex(
                name: "IX_Inquiry_LeadId",
                table: "Inquiries",
                newName: "IX_Inquiries_LeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Inquiry_ChannelId",
                table: "Inquiries",
                newName: "IX_Inquiries_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inquiries",
                table: "Inquiries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InquiryLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InquiryId = table.Column<int>(nullable: true),
                    LineDate = table.Column<DateTime>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
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
                name: "FK_Inquiries_LeadChannel_ChannelId",
                table: "Inquiries",
                column: "ChannelId",
                principalTable: "LeadChannel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiries_Leads_LeadId",
                table: "Inquiries",
                column: "LeadId",
                principalTable: "Leads",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deadline_Inquiries_InquiryId",
                table: "Deadline");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_LeadChannel_ChannelId",
                table: "Inquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquiries_Leads_LeadId",
                table: "Inquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Inquiries_InquiryId",
                table: "Status");

            migrationBuilder.DropTable(
                name: "InquiryLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inquiries",
                table: "Inquiries");

            migrationBuilder.RenameTable(
                name: "Inquiries",
                newName: "Inquiry");

            migrationBuilder.RenameIndex(
                name: "IX_Inquiries_LeadId",
                table: "Inquiry",
                newName: "IX_Inquiry_LeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Inquiries_ChannelId",
                table: "Inquiry",
                newName: "IX_Inquiry_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inquiry",
                table: "Inquiry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deadline_Inquiry_InquiryId",
                table: "Deadline",
                column: "InquiryId",
                principalTable: "Inquiry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiry_LeadChannel_ChannelId",
                table: "Inquiry",
                column: "ChannelId",
                principalTable: "LeadChannel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiry_Leads_LeadId",
                table: "Inquiry",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Inquiry_InquiryId",
                table: "Status",
                column: "InquiryId",
                principalTable: "Inquiry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
