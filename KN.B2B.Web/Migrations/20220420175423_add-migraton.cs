using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class addmigraton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "B2BProductImages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imagePath = table.Column<string>(nullable: true),
                    fk_childProductproduct_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BProductImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_B2BProductImages_B2BProdducts_fk_childProductproduct_id",
                        column: x => x.fk_childProductproduct_id,
                        principalTable: "B2BProdducts",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_B2BProductImages_fk_childProductproduct_id",
                table: "B2BProductImages",
                column: "fk_childProductproduct_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B2BProductImages");
        }
    }
}
