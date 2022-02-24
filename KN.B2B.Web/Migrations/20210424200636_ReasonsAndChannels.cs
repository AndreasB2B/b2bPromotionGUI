using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class ReasonsAndChannels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellationReason",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Channel",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CancellationReasonId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colours",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CancellationReasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerChannels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerChannels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CancellationReasonId",
                table: "Requests",
                column: "CancellationReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ChannelId",
                table: "Customers",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerChannels_ChannelId",
                table: "Customers",
                column: "ChannelId",
                principalTable: "CustomerChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_CancellationReasons_CancellationReasonId",
                table: "Requests",
                column: "CancellationReasonId",
                principalTable: "CancellationReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerChannels_ChannelId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_CancellationReasons_CancellationReasonId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "CancellationReasons");

            migrationBuilder.DropTable(
                name: "CustomerChannels");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CancellationReasonId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ChannelId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CancellationReasonId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CancellationReason",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "Channel",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
