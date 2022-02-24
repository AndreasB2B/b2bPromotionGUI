using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddJobTitlesContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_JobTitle_JobTitleId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitle",
                table: "JobTitle");

            migrationBuilder.RenameTable(
                name: "JobTitle",
                newName: "JobTitles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_JobTitles_JobTitleId",
                table: "Customers",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_JobTitles_JobTitleId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles");

            migrationBuilder.RenameTable(
                name: "JobTitles",
                newName: "JobTitle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitle",
                table: "JobTitle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_JobTitle_JobTitleId",
                table: "Customers",
                column: "JobTitleId",
                principalTable: "JobTitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
