using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KN.B2B.Web.Migrations
{
    public partial class pushNewTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "scale_minimumQuantity",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "scale_nextPrice",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "scale_price",
                table: "SupplierPrintPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "fk_printCostprintCost_id",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_code",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_nextColourIndicator",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_pricingType",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_repeat",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "printPrice_setup",
                table: "SupplierPrintPrices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "printCost_areaFrom",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "printCost_areaTo",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "printCost_rangeId",
                table: "SupplierPrintCosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "handles_code",
                table: "SupplierHandles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "handles_description",
                table: "SupplierHandles",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "handles_price",
                table: "SupplierHandles",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "fk_productSkuproduct_id",
                table: "B2BProductPrices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "price_scale",
                table: "B2BProductPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "price_startingPrice",
                table: "B2BProductPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_ParentSKUparrentProduct_id",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_printPositionId",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_BatteryType",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_ColorName",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_CommercialItemHeight",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_CommercialItemLength",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_CommercialItemWeight",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_CommercialItemWidth",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_CountryOfOrigin",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "product_DeliveryTimeMT_IL1_T1",
                table: "B2BProdducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "product_Flavours",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_IntraCode",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_NumberOfBatteries",
                table: "B2BProdducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "product_OrderUnit",
                table: "B2BProdducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_CN",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_CN2",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_CN3",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_CN4",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_CN5",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_CN6",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_T1",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_T2",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_T3",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_T4",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_T5",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_PriceClass_IL1_T6",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_ProductImageURL",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_Q_OnPallet",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_SearchTerms",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_Sizes",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_WritingColor",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_brandNames",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_longDescriptionDK",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_longDescriptionEN",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_longDescriptionFI",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_shortDescriptionDK",
                table: "B2BProdducts",
                maxLength: 31,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_shortDescriptionEN",
                table: "B2BProdducts",
                maxLength: 31,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_shortDescriptionFI",
                table: "B2BProdducts",
                maxLength: 31,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_sku",
                table: "B2BProdducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_supplierHandleCodehandles_id",
                table: "B2BPrintTechniques",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fk_supplierPriceCodeprintPrice_id",
                table: "B2BPrintTechniques",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "technique_description",
                table: "B2BPrintTechniques",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "technique_maxColors",
                table: "B2BPrintTechniques",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "technique_name",
                table: "B2BPrintTechniques",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "technique_supplier",
                table: "B2BPrintTechniques",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_priceIdid",
                table: "B2BPriceScales",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "scale_minimumQuantity",
                table: "B2BPriceScales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "scale_price",
                table: "B2BPriceScales",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "priceClass_name",
                table: "B2BPriceClasses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "priceClass_price01",
                table: "B2BPriceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceClass_price02",
                table: "B2BPriceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceClass_price03",
                table: "B2BPriceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceClass_price04",
                table: "B2BPriceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceClass_price05",
                table: "B2BPriceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceClass_price06",
                table: "B2BPriceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceClass_price07",
                table: "B2BPriceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceClass_quantity",
                table: "B2BPriceClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fk_B2BCategoriesId",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fk_B2BCategoryGroupsId",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_dimensions",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "parrentProduct_height",
                table: "B2BParrentProducts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "parrentProduct_length",
                table: "B2BParrentProducts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_longDescription",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_mainCategory",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "parrentProduct_masterId",
                table: "B2BParrentProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_mertial",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_parrentSku",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "parrentProduct_printPositions",
                table: "B2BParrentProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "parrentProduct_printable",
                table: "B2BParrentProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_shortDescription",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parrentProduct_subCategory",
                table: "B2BParrentProducts",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "parrentProduct_width",
                table: "B2BParrentProducts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPrintPrices_fk_printCostprintCost_id",
                table: "SupplierPrintPrices",
                column: "fk_printCostprintCost_id");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPrintCosts_fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts",
                column: "fk_printPriceScalesscale_id");

            migrationBuilder.CreateIndex(
                name: "IX_B2BProductPrices_fk_productSkuproduct_id",
                table: "B2BProductPrices",
                column: "fk_productSkuproduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_B2BProdducts_fk_ParentSKUparrentProduct_id",
                table: "B2BProdducts",
                column: "fk_ParentSKUparrentProduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_B2BProdducts_fk_printPositionId",
                table: "B2BProdducts",
                column: "fk_printPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_B2BPrintTechniques_fk_supplierHandleCodehandles_id",
                table: "B2BPrintTechniques",
                column: "fk_supplierHandleCodehandles_id");

            migrationBuilder.CreateIndex(
                name: "IX_B2BPrintTechniques_fk_supplierPriceCodeprintPrice_id",
                table: "B2BPrintTechniques",
                column: "fk_supplierPriceCodeprintPrice_id");

            migrationBuilder.CreateIndex(
                name: "IX_B2BPriceScales_fk_priceIdid",
                table: "B2BPriceScales",
                column: "fk_priceIdid");

            migrationBuilder.CreateIndex(
                name: "IX_B2BParrentProducts_fk_B2BCategoriesId",
                table: "B2BParrentProducts",
                column: "fk_B2BCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_B2BParrentProducts_fk_B2BCategoryGroupsId",
                table: "B2BParrentProducts",
                column: "fk_B2BCategoryGroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_B2BParrentProducts_B2BCategories_fk_B2BCategoriesId",
                table: "B2BParrentProducts",
                column: "fk_B2BCategoriesId",
                principalTable: "B2BCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BParrentProducts_B2BCategoryGroups_fk_B2BCategoryGroupsId",
                table: "B2BParrentProducts",
                column: "fk_B2BCategoryGroupsId",
                principalTable: "B2BCategoryGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BPriceScales_B2BProductPrices_fk_priceIdid",
                table: "B2BPriceScales",
                column: "fk_priceIdid",
                principalTable: "B2BProductPrices",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BPrintTechniques_SupplierHandles_fk_supplierHandleCodehandles_id",
                table: "B2BPrintTechniques",
                column: "fk_supplierHandleCodehandles_id",
                principalTable: "SupplierHandles",
                principalColumn: "handles_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BPrintTechniques_SupplierPrintPrices_fk_supplierPriceCodeprintPrice_id",
                table: "B2BPrintTechniques",
                column: "fk_supplierPriceCodeprintPrice_id",
                principalTable: "SupplierPrintPrices",
                principalColumn: "printPrice_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BProdducts_B2BParrentProducts_fk_ParentSKUparrentProduct_id",
                table: "B2BProdducts",
                column: "fk_ParentSKUparrentProduct_id",
                principalTable: "B2BParrentProducts",
                principalColumn: "parrentProduct_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BProdducts_B2BPrintPositions_fk_printPositionId",
                table: "B2BProdducts",
                column: "fk_printPositionId",
                principalTable: "B2BPrintPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_B2BProductPrices_B2BProdducts_fk_productSkuproduct_id",
                table: "B2BProductPrices",
                column: "fk_productSkuproduct_id",
                principalTable: "B2BProdducts",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPrintCosts_SupplierPrintPriceScales_fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts",
                column: "fk_printPriceScalesscale_id",
                principalTable: "SupplierPrintPriceScales",
                principalColumn: "scale_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPrintPrices_SupplierPrintCosts_fk_printCostprintCost_id",
                table: "SupplierPrintPrices",
                column: "fk_printCostprintCost_id",
                principalTable: "SupplierPrintCosts",
                principalColumn: "printCost_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B2BParrentProducts_B2BCategories_fk_B2BCategoriesId",
                table: "B2BParrentProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BParrentProducts_B2BCategoryGroups_fk_B2BCategoryGroupsId",
                table: "B2BParrentProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BPriceScales_B2BProductPrices_fk_priceIdid",
                table: "B2BPriceScales");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BPrintTechniques_SupplierHandles_fk_supplierHandleCodehandles_id",
                table: "B2BPrintTechniques");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BPrintTechniques_SupplierPrintPrices_fk_supplierPriceCodeprintPrice_id",
                table: "B2BPrintTechniques");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BProdducts_B2BParrentProducts_fk_ParentSKUparrentProduct_id",
                table: "B2BProdducts");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BProdducts_B2BPrintPositions_fk_printPositionId",
                table: "B2BProdducts");

            migrationBuilder.DropForeignKey(
                name: "FK_B2BProductPrices_B2BProdducts_fk_productSkuproduct_id",
                table: "B2BProductPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPrintCosts_SupplierPrintPriceScales_fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPrintPrices_SupplierPrintCosts_fk_printCostprintCost_id",
                table: "SupplierPrintPrices");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPrintPrices_fk_printCostprintCost_id",
                table: "SupplierPrintPrices");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPrintCosts_fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts");

            migrationBuilder.DropIndex(
                name: "IX_B2BProductPrices_fk_productSkuproduct_id",
                table: "B2BProductPrices");

            migrationBuilder.DropIndex(
                name: "IX_B2BProdducts_fk_ParentSKUparrentProduct_id",
                table: "B2BProdducts");

            migrationBuilder.DropIndex(
                name: "IX_B2BProdducts_fk_printPositionId",
                table: "B2BProdducts");

            migrationBuilder.DropIndex(
                name: "IX_B2BPrintTechniques_fk_supplierHandleCodehandles_id",
                table: "B2BPrintTechniques");

            migrationBuilder.DropIndex(
                name: "IX_B2BPrintTechniques_fk_supplierPriceCodeprintPrice_id",
                table: "B2BPrintTechniques");

            migrationBuilder.DropIndex(
                name: "IX_B2BPriceScales_fk_priceIdid",
                table: "B2BPriceScales");

            migrationBuilder.DropIndex(
                name: "IX_B2BParrentProducts_fk_B2BCategoriesId",
                table: "B2BParrentProducts");

            migrationBuilder.DropIndex(
                name: "IX_B2BParrentProducts_fk_B2BCategoryGroupsId",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "scale_minimumQuantity",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_nextPrice",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_price",
                table: "SupplierPrintPriceScales");

            migrationBuilder.DropColumn(
                name: "fk_printCostprintCost_id",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "printPrice_code",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "printPrice_nextColourIndicator",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "printPrice_pricingType",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "printPrice_repeat",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "printPrice_setup",
                table: "SupplierPrintPrices");

            migrationBuilder.DropColumn(
                name: "fk_printPriceScalesscale_id",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaFrom",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_areaTo",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "printCost_rangeId",
                table: "SupplierPrintCosts");

            migrationBuilder.DropColumn(
                name: "handles_code",
                table: "SupplierHandles");

            migrationBuilder.DropColumn(
                name: "handles_description",
                table: "SupplierHandles");

            migrationBuilder.DropColumn(
                name: "handles_price",
                table: "SupplierHandles");

            migrationBuilder.DropColumn(
                name: "fk_productSkuproduct_id",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "price_scale",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "price_startingPrice",
                table: "B2BProductPrices");

            migrationBuilder.DropColumn(
                name: "fk_ParentSKUparrentProduct_id",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "fk_printPositionId",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_BatteryType",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_ColorName",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_CommercialItemHeight",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_CommercialItemLength",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_CommercialItemWeight",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_CommercialItemWidth",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_CountryOfOrigin",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_DeliveryTimeMT_IL1_T1",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_Flavours",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_IntraCode",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_NumberOfBatteries",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_OrderUnit",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_CN",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_CN2",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_CN3",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_CN4",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_CN5",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_CN6",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_T1",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_T2",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_T3",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_T4",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_T5",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_PriceClass_IL1_T6",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_ProductImageURL",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_Q_OnPallet",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_SearchTerms",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_Sizes",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_WritingColor",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_brandNames",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_longDescriptionDK",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_longDescriptionEN",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_longDescriptionFI",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_shortDescriptionDK",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_shortDescriptionEN",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_shortDescriptionFI",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "product_sku",
                table: "B2BProdducts");

            migrationBuilder.DropColumn(
                name: "fk_supplierHandleCodehandles_id",
                table: "B2BPrintTechniques");

            migrationBuilder.DropColumn(
                name: "fk_supplierPriceCodeprintPrice_id",
                table: "B2BPrintTechniques");

            migrationBuilder.DropColumn(
                name: "technique_description",
                table: "B2BPrintTechniques");

            migrationBuilder.DropColumn(
                name: "technique_maxColors",
                table: "B2BPrintTechniques");

            migrationBuilder.DropColumn(
                name: "technique_name",
                table: "B2BPrintTechniques");

            migrationBuilder.DropColumn(
                name: "technique_supplier",
                table: "B2BPrintTechniques");

            migrationBuilder.DropColumn(
                name: "fk_priceIdid",
                table: "B2BPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_minimumQuantity",
                table: "B2BPriceScales");

            migrationBuilder.DropColumn(
                name: "scale_price",
                table: "B2BPriceScales");

            migrationBuilder.DropColumn(
                name: "priceClass_name",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "priceClass_price01",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "priceClass_price02",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "priceClass_price03",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "priceClass_price04",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "priceClass_price05",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "priceClass_price06",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "priceClass_price07",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "priceClass_quantity",
                table: "B2BPriceClasses");

            migrationBuilder.DropColumn(
                name: "fk_B2BCategoriesId",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "fk_B2BCategoryGroupsId",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_dimensions",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_height",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_length",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_longDescription",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_mainCategory",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_masterId",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_mertial",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_parrentSku",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_printPositions",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_printable",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_shortDescription",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_subCategory",
                table: "B2BParrentProducts");

            migrationBuilder.DropColumn(
                name: "parrentProduct_width",
                table: "B2BParrentProducts");
        }
    }
}
