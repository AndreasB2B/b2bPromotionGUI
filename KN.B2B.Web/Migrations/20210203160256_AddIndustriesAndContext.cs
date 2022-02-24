using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddIndustriesAndContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ZipCode_ZipCodeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZipCode",
                table: "ZipCode");

            migrationBuilder.RenameTable(
                name: "ZipCode",
                newName: "ZipCodes");

            migrationBuilder.AddColumn<int>(
                name: "IndustryId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZipCodes",
                table: "ZipCodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IndustryId",
                table: "Customers",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Industries_IndustryId",
                table: "Customers",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ZipCodes_ZipCodeId",
                table: "Customers",
                column: "ZipCodeId",
                principalTable: "ZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Industries_IndustryId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ZipCodes_ZipCodeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IndustryId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ZipCodes",
                table: "ZipCodes");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "ZipCodes",
                newName: "ZipCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZipCode",
                table: "ZipCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ZipCode_ZipCodeId",
                table: "Customers",
                column: "ZipCodeId",
                principalTable: "ZipCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
