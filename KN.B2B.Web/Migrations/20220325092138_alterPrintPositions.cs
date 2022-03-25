using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class alterPrintPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fk_techniqueIdtechnique_id",
                table: "B2BPrintPositions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "print_express",
                table: "B2BPrintPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "print_height",
                table: "B2BPrintPositions",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "print_position",
                table: "B2BPrintPositions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "print_product",
                table: "B2BPrintPositions",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "print_size",
                table: "B2BPrintPositions",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "print_supplier",
                table: "B2BPrintPositions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_B2BPrintPositions_fk_techniqueIdtechnique_id",
                table: "B2BPrintPositions",
                column: "fk_techniqueIdtechnique_id");

            migrationBuilder.AddForeignKey(
                name: "FK_B2BPrintPositions_B2BPrintTechniques_fk_techniqueIdtechnique_id",
                table: "B2BPrintPositions",
                column: "fk_techniqueIdtechnique_id",
                principalTable: "B2BPrintTechniques",
                principalColumn: "technique_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BPrintPositions_B2BPrintTechniques_fk_techniqueIdtechnique_id",
                table: "B2BPrintPositions");

            migrationBuilder.DropIndex(
                name: "IX_B2BPrintPositions_fk_techniqueIdtechnique_id",
                table: "B2BPrintPositions");

            migrationBuilder.DropColumn(
                name: "fk_techniqueIdtechnique_id",
                table: "B2BPrintPositions");

            migrationBuilder.DropColumn(
                name: "print_express",
                table: "B2BPrintPositions");

            migrationBuilder.DropColumn(
                name: "print_height",
                table: "B2BPrintPositions");

            migrationBuilder.DropColumn(
                name: "print_position",
                table: "B2BPrintPositions");

            migrationBuilder.DropColumn(
                name: "print_product",
                table: "B2BPrintPositions");

            migrationBuilder.DropColumn(
                name: "print_size",
                table: "B2BPrintPositions");

            migrationBuilder.DropColumn(
                name: "print_supplier",
                table: "B2BPrintPositions");
        }
    }
}
