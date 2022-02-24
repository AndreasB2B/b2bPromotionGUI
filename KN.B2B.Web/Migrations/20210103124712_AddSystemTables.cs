using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddSystemTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Address_AddressId",
                table: "Leads");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropColumn(
                name: "Copydan",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CopydanTax",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DesignFee",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ExpressDelivery",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ExpressProduction",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "InvoiceDiscount",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Packaging",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PackagingTax",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Sugar",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SugarFree",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SugarFreeTax",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SugarTax",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "LeadName",
                table: "Leads");

            migrationBuilder.AddColumn<int>(
                name: "CancelationReasonId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndStatus",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartStatus",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "RequestLines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Leads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Leads",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "B2BCategoryGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BCategoryGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CancelationReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelationReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUNSGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true),
                    DunsGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUNSGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZipCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<int>(nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    City = table.Column<string>(maxLength: 64, nullable: false),
                    Municipality = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    B2bRegion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "B2BCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryGroupId = table.Column<int>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B2BCategory_B2BCategoryGroup_CategoryGroupId",
                        column: x => x.CategoryGroupId,
                        principalTable: "B2BCategoryGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CancelationReasonId",
                table: "Requests",
                column: "CancelationReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLines_ProductId",
                table: "RequestLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_GroupId",
                table: "Leads",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_B2BCategory_CategoryGroupId",
                table: "B2BCategory",
                column: "CategoryGroupId");

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
                name: "FK_RequestLines_B2BCategory_ProductId",
                table: "RequestLines",
                column: "ProductId",
                principalTable: "B2BCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_CancelationReason_CancelationReasonId",
                table: "Requests",
                column: "CancelationReasonId",
                principalTable: "CancelationReason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_ZipCode_AddressId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_DUNSGroup_GroupId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_B2BCategory_ProductId",
                table: "RequestLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_CancelationReason_CancelationReasonId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "B2BCategory");

            migrationBuilder.DropTable(
                name: "CancelationReason");

            migrationBuilder.DropTable(
                name: "DUNSGroup");

            migrationBuilder.DropTable(
                name: "ZipCode");

            migrationBuilder.DropTable(
                name: "B2BCategoryGroup");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CancelationReasonId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_RequestLines_ProductId",
                table: "RequestLines");

            migrationBuilder.DropIndex(
                name: "IX_Leads_GroupId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "CancelationReasonId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "EndStatus",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StartStatus",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "RequestLines");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Leads");

            migrationBuilder.AddColumn<int>(
                name: "Copydan",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CopydanTax",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesignFee",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ExpressDelivery",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExpressProduction",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceDiscount",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Packaging",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackagingTax",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sugar",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SugarFree",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SugarFreeTax",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SugarTax",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "RequestLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Branch",
                table: "Leads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeadName",
                table: "Leads",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B2bRegion = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LocalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Address_AddressId",
                table: "Leads",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
