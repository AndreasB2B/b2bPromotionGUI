using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class AddCurrentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStatusId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CurrentStatusId",
                table: "Requests",
                column: "CurrentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_CurrentStatuses_CurrentStatusId",
                table: "Requests",
                column: "CurrentStatusId",
                principalTable: "CurrentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_CurrentStatuses_CurrentStatusId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "CurrentStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CurrentStatusId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CurrentStatusId",
                table: "Requests");
        }
    }
}
