using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class OwnerToB2BResponsible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "B2BResponsibleId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "B2BResponsibles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BResponsibles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_B2BResponsibleId",
                table: "Customers",
                column: "B2BResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_B2BResponsibles_B2BResponsibleId",
                table: "Customers",
                column: "B2BResponsibleId",
                principalTable: "B2BResponsibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_B2BResponsibles_B2BResponsibleId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "B2BResponsibles");

            migrationBuilder.DropIndex(
                name: "IX_Customers_B2BResponsibleId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "B2BResponsibleId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Owner",
                table: "Customers",
                type: "int",
                nullable: true);
        }
    }
}
