using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class RequestCancellationReasonEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_CancelationReason_CancelationReasonId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "CancelationReason");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CancelationReasonId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CancelationReasonId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "CancellationReason",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellationReason",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "CancelationReasonId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CancelationReason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelationReason", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CancelationReasonId",
                table: "Requests",
                column: "CancelationReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_CancelationReason_CancelationReasonId",
                table: "Requests",
                column: "CancelationReasonId",
                principalTable: "CancelationReason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
