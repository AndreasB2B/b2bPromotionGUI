using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class StartEndStatusResellerAsObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndStatus",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StartStatus",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Reseller",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "EndStatusId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartStatusId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResellerId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EndStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resellers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StartStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EndStatusId",
                table: "Requests",
                column: "EndStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StartStatusId",
                table: "Requests",
                column: "StartStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ResellerId",
                table: "Customers",
                column: "ResellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Resellers_ResellerId",
                table: "Customers",
                column: "ResellerId",
                principalTable: "Resellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_EndStatuses_EndStatusId",
                table: "Requests",
                column: "EndStatusId",
                principalTable: "EndStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StartStatuses_StartStatusId",
                table: "Requests",
                column: "StartStatusId",
                principalTable: "StartStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Resellers_ResellerId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_EndStatuses_EndStatusId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StartStatuses_StartStatusId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "EndStatuses");

            migrationBuilder.DropTable(
                name: "Resellers");

            migrationBuilder.DropTable(
                name: "StartStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Requests_EndStatusId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_StartStatusId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ResellerId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EndStatusId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StartStatusId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ResellerId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "EndStatus",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartStatus",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reseller",
                table: "Customers",
                type: "int",
                nullable: true);
        }
    }
}
