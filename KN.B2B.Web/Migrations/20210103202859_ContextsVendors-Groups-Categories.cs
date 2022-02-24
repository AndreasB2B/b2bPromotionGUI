using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class ContextsVendorsGroupsCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BCategory_B2BCategoryGroup_CategoryGroupId",
                table: "B2BCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_B2BCategory_ProductId",
                table: "RequestLines");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_Vendor_VendorId",
                table: "RequestLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_B2BCategoryGroup",
                table: "B2BCategoryGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_B2BCategory",
                table: "B2BCategory");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vendors");

            migrationBuilder.RenameTable(
                name: "B2BCategoryGroup",
                newName: "B2BCategoryGroups");

            migrationBuilder.RenameTable(
                name: "B2BCategory",
                newName: "B2BCategories");

            migrationBuilder.RenameIndex(
                name: "IX_B2BCategory_CategoryGroupId",
                table: "B2BCategories",
                newName: "IX_B2BCategories_CategoryGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_B2BCategoryGroups",
                table: "B2BCategoryGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_B2BCategories",
                table: "B2BCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_B2BCategories_B2BCategoryGroups_CategoryGroupId",
                table: "B2BCategories",
                column: "CategoryGroupId",
                principalTable: "B2BCategoryGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLines_B2BCategories_ProductId",
                table: "RequestLines",
                column: "ProductId",
                principalTable: "B2BCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLines_Vendors_VendorId",
                table: "RequestLines",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BCategories_B2BCategoryGroups_CategoryGroupId",
                table: "B2BCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_B2BCategories_ProductId",
                table: "RequestLines");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestLines_Vendors_VendorId",
                table: "RequestLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_B2BCategoryGroups",
                table: "B2BCategoryGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_B2BCategories",
                table: "B2BCategories");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Vendor");

            migrationBuilder.RenameTable(
                name: "B2BCategoryGroups",
                newName: "B2BCategoryGroup");

            migrationBuilder.RenameTable(
                name: "B2BCategories",
                newName: "B2BCategory");

            migrationBuilder.RenameIndex(
                name: "IX_B2BCategories_CategoryGroupId",
                table: "B2BCategory",
                newName: "IX_B2BCategory_CategoryGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_B2BCategoryGroup",
                table: "B2BCategoryGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_B2BCategory",
                table: "B2BCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_B2BCategory_B2BCategoryGroup_CategoryGroupId",
                table: "B2BCategory",
                column: "CategoryGroupId",
                principalTable: "B2BCategoryGroup",
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
                name: "FK_RequestLines_Vendor_VendorId",
                table: "RequestLines",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
