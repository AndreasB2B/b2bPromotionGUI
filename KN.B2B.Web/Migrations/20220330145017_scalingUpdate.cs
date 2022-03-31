using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class scalingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B2BPriceScales");

            migrationBuilder.CreateTable(
                name: "B2BPriceScaling",
                columns: table => new
                {
                    scale_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scale_minimumQuantity = table.Column<int>(nullable: false),
                    scale_price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BPriceScaling", x => x.scale_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B2BPriceScaling");

            migrationBuilder.CreateTable(
                name: "B2BPriceScales",
                columns: table => new
                {
                    scale_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scale_minimumQuantity = table.Column<int>(type: "int", nullable: false),
                    scale_price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BPriceScales", x => x.scale_id);
                });
        }
    }
}
