using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class UpdateZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_ZipCode_AddressId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_DUNSGroup_GroupId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Leads_LeadId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_LeadId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leads",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "B2bRegion",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "Municipality",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "Leads",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_GroupId",
                table: "Customers",
                newName: "IX_Customers_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_AddressId",
                table: "Customers",
                newName: "IX_Customers_AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "ZipCode",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "B2bRegionId",
                table: "ZipCode",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "ZipCode",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "ZipCode",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "ZipCode",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "B2BRegion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestCommunications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Communication = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCommunications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestCommunications_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_B2bRegionId",
                table: "ZipCode",
                column: "B2bRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_CityId",
                table: "ZipCode",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_MunicipalityId",
                table: "ZipCode",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_RegionId",
                table: "ZipCode",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCommunications_RequestId",
                table: "RequestCommunications",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ZipCode_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "ZipCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_DUNSGroup_GroupId",
                table: "Customers",
                column: "GroupId",
                principalTable: "DUNSGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Customers_CustomerId",
                table: "Requests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZipCode_B2BRegion_B2bRegionId",
                table: "ZipCode",
                column: "B2bRegionId",
                principalTable: "B2BRegion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZipCode_City_CityId",
                table: "ZipCode",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZipCode_Municipality_MunicipalityId",
                table: "ZipCode",
                column: "MunicipalityId",
                principalTable: "Municipality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ZipCode_Region_RegionId",
                table: "ZipCode",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ZipCode_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_DUNSGroup_GroupId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Customers_CustomerId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_ZipCode_B2BRegion_B2bRegionId",
                table: "ZipCode");

            migrationBuilder.DropForeignKey(
                name: "FK_ZipCode_City_CityId",
                table: "ZipCode");

            migrationBuilder.DropForeignKey(
                name: "FK_ZipCode_Municipality_MunicipalityId",
                table: "ZipCode");

            migrationBuilder.DropForeignKey(
                name: "FK_ZipCode_Region_RegionId",
                table: "ZipCode");

            migrationBuilder.DropTable(
                name: "B2BRegion");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "RequestCommunications");

            migrationBuilder.DropIndex(
                name: "IX_ZipCode_B2bRegionId",
                table: "ZipCode");

            migrationBuilder.DropIndex(
                name: "IX_ZipCode_CityId",
                table: "ZipCode");

            migrationBuilder.DropIndex(
                name: "IX_ZipCode_MunicipalityId",
                table: "ZipCode");

            migrationBuilder.DropIndex(
                name: "IX_ZipCode_RegionId",
                table: "ZipCode");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "B2bRegionId",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "ZipCode");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Leads");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_GroupId",
                table: "Leads",
                newName: "IX_Leads_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_AddressId",
                table: "Leads",
                newName: "IX_Leads_AddressId");

            migrationBuilder.AlterColumn<int>(
                name: "Zip",
                table: "ZipCode",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "B2bRegion",
                table: "ZipCode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ZipCode",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Municipality",
                table: "ZipCode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "ZipCode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leads",
                table: "Leads",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_LeadId",
                table: "Requests",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_ZipCode_AddressId",
                table: "Leads",
                column: "AddressId",
                principalTable: "ZipCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_DUNSGroup_GroupId",
                table: "Leads",
                column: "GroupId",
                principalTable: "DUNSGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Leads_LeadId",
                table: "Requests",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
