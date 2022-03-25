using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class pushNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "B2BParrentProducts",
                columns: table => new
                {
                    parrentProduct_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BParrentProducts", x => x.parrentProduct_id);
                });

            migrationBuilder.CreateTable(
                name: "B2BPriceClasses",
                columns: table => new
                {
                    priceClass_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BPriceClasses", x => x.priceClass_id);
                });

            migrationBuilder.CreateTable(
                name: "B2BPriceScales",
                columns: table => new
                {
                    scale_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BPriceScales", x => x.scale_id);
                });

            migrationBuilder.CreateTable(
                name: "B2BPrintTechniques",
                columns: table => new
                {
                    technique_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BPrintTechniques", x => x.technique_id);
                });

            migrationBuilder.CreateTable(
                name: "B2BProdducts",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BProdducts", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "B2BProductPrices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2BProductPrices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierHandles",
                columns: table => new
                {
                    handles_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierHandles", x => x.handles_id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierPrintCosts",
                columns: table => new
                {
                    printCost_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPrintCosts", x => x.printCost_id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierPrintPrices",
                columns: table => new
                {
                    printPrice_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPrintPrices", x => x.printPrice_id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierPrintPriceScales",
                columns: table => new
                {
                    scale_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPrintPriceScales", x => x.scale_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B2BParrentProducts");

            migrationBuilder.DropTable(
                name: "B2BPriceClasses");

            migrationBuilder.DropTable(
                name: "B2BPriceScales");

            migrationBuilder.DropTable(
                name: "B2BPrintTechniques");

            migrationBuilder.DropTable(
                name: "B2BProdducts");

            migrationBuilder.DropTable(
                name: "B2BProductPrices");

            migrationBuilder.DropTable(
                name: "SupplierHandles");

            migrationBuilder.DropTable(
                name: "SupplierPrintCosts");

            migrationBuilder.DropTable(
                name: "SupplierPrintPrices");

            migrationBuilder.DropTable(
                name: "SupplierPrintPriceScales");
        }
    }
}
