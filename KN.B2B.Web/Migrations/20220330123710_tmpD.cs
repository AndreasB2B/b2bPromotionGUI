using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class tmpD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "print_size",
                table: "B2BPrintPositions");

            migrationBuilder.AlterColumn<bool>(
                name: "print_express",
                table: "B2BPrintPositions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "print_width",
                table: "B2BPrintPositions",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "print_width",
                table: "B2BPrintPositions");

            migrationBuilder.AlterColumn<int>(
                name: "print_express",
                table: "B2BPrintPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<float>(
                name: "print_size",
                table: "B2BPrintPositions",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
