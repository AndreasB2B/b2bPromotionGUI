using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddZipCodesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZipCodeId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ZipCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<int>(nullable: true),
                    Amts = table.Column<int>(nullable: false),
                    Region = table.Column<string>(nullable: true),
                    MunicipalityNumber = table.Column<int>(nullable: false),
                    Municipality = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ZipCodeId",
                table: "Customers",
                column: "ZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ZipCode_ZipCodeId",
                table: "Customers",
                column: "ZipCodeId",
                principalTable: "ZipCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ZipCode_ZipCodeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "ZipCode");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ZipCodeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ZipCodeId",
                table: "Customers");
        }
    }
}
