using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Web.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KN.B2B.Web.Services.Products
{
    public class ExcelImport : IExcelImport
    {
        public readonly IMasterProductImport _masterProductImport;
        //private readonly B2BDbContext _context;

        public B2BParrentProducts parrentProduct { get; set; }
        public B2BProduct childProduct { get; set; }
        public ExcelImport(IMasterProductImport masterProductImport)
        {
            //_context = context;
            _masterProductImport = masterProductImport;
        }
        public virtual void readXLS2(Stream stream, int countryId, int siteId, string database)
        {
            using (var xlPackage = new ExcelPackage(stream))
            {
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    Console.WriteLine("Hey");

                //var properties = new[]
                //   {
                //       new PropertyByName<CustomProductModel>("ParentSKU"),
                //       new PropertyByName<CustomProductModel>("SKU"),
                //       new PropertyByName<CustomProductModel>("ColorName"),
                //       new PropertyByName<CustomProductModel>("InternetName"),
                //       new PropertyByName<CustomProductModel>("InternetTxt"),
                //       new PropertyByName<CustomProductModel>("Q1"),
                //       new PropertyByName<CustomProductModel>("Q2"),
                //       new PropertyByName<CustomProductModel>("Q3"),
                //       new PropertyByName<CustomProductModel>("Q4"),
                //       new PropertyByName<CustomProductModel>("Q5"),
                //       new PropertyByName<CustomProductModel>("Q6"),
                //       new PropertyByName<CustomProductModel>("P1"),
                //       new PropertyByName<CustomProductModel>("P2"),
                //       new PropertyByName<CustomProductModel>("P3"),
                //       new PropertyByName<CustomProductModel>("P4"),
                //       new PropertyByName<CustomProductModel>("P5"),
                //       new PropertyByName<CustomProductModel>("P6"),
                //       new PropertyByName<CustomProductModel>("GrossNett"),

                //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN"),
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T1_NextColor"),
                //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("Handling_IL1_T1"),

                //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN2"), //Wrong
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T2_NextColor"),
                //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T2"),
                //       new PropertyByName<CustomProductModel>("Handling_IL1_T2"),

                //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN3"), //Wrong
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T3_NextColor"),
                //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T3"),
                //       new PropertyByName<CustomProductModel>("Handling_IL1_T3"),

                //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN4"), //Wrong
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T4_NextColor"),
                //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T4"),
                //       new PropertyByName<CustomProductModel>("Handling_IL1_T4"),

                //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN5"), //Wrong
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T5_NextColor"),
                //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T5"),
                //       new PropertyByName<CustomProductModel>("Handling_IL1_T5"),

                //        new PropertyByName<CustomProductModel>("ImprintType_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN6"), //Wrong
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T6_NextColor"),
                //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T6"),
                //       new PropertyByName<CustomProductModel>("Handling_IL1_T6"),

                //       new PropertyByName<CustomProductModel>("IntraCode"),
                //       new PropertyByName<CustomProductModel>("CountryOfOrigin"),
                //       new PropertyByName<CustomProductModel>("OuterCartonPieces"),
                //       new PropertyByName<CustomProductModel>("OuterCartonLength"),
                //       new PropertyByName<CustomProductModel>("OuterCartonWidth"),
                //       new PropertyByName<CustomProductModel>("OuterCartonHeight"),
                //       new PropertyByName<CustomProductModel>("CommercialItemLength"),
                //       new PropertyByName<CustomProductModel>("CommercialItemWidth"),
                //       new PropertyByName<CustomProductModel>("CommercialItemHeight"),
                //       new PropertyByName<CustomProductModel>("CommercialItemWeight"),
                //       new PropertyByName<CustomProductModel>("Flavours"),
                //       new PropertyByName<CustomProductModel>("Sizes"),
                //       new PropertyByName<CustomProductModel>("WritingColor"),
                //       new PropertyByName<CustomProductModel>("CapacityTxt"),
                //       new PropertyByName<CustomProductModel>("OrderUnit"),
                //       new PropertyByName<CustomProductModel>("MainGroup"),
                //       new PropertyByName<CustomProductModel>("Material"),
                //       new PropertyByName<CustomProductModel>("BatteryType"),
                //       new PropertyByName<CustomProductModel>("NumberOfBatteries"),
                //       new PropertyByName<CustomProductModel>("ProductImageURL"),
                //       new PropertyByName<CustomProductModel>("DeliveryTimeMT_IL1_T1"),
                //       new PropertyByName<CustomProductModel>("07_12_SearchTerms"),
                //       new PropertyByName<CustomProductModel>("Q_OnPallet"),
                //       new PropertyByName<CustomProductModel>("Brandnames")
                //};
                //var manager = new PropertyManager<CustomProductModel>(properties);

                var endRow = 2;

                //Clear the table
                //_clipperProductsService.ClearTable();
                Console.WriteLine(worksheet);
                //while (true)
                //{
                //    var allColumnsAreEmpty = manager.GetProperties
                //        .Select(property => worksheet.Cells[endRow, property.PropertyOrderPosition])
                //        .All(cell => cell == null || cell.Value == null || String.IsNullOrEmpty(cell.Value.ToString()));

                //    if (allColumnsAreEmpty)
                //        break;
                //    manager.ReadFromXlsx(worksheet, endRow);

                    //var CountryId = countryId;
                    //var ParentSKU = manager.GetProperty("ParentSKU").StringValue;
                    //var SKU = manager.GetProperty("SKU").StringValue;
                    //var InternetName = manager.GetProperty("InternetName").StringValue;
                    //var InternetTxt = manager.GetProperty("InternetTxt").StringValue;
                    //var ImprintLocation_IL1_T1 = manager.GetProperty("ImprintLocation_IL1_T1").StringValue;
                    ////var ImprintSize_IL1_T1 = manager.GetProperty("ImprintSize_IL1_T1").StringValue;
                    ////var ImprintType_IL1_T1 = manager.GetProperty("ImprintType_IL1_T1").StringValue;
                    //var Q1 = manager.GetProperty("Q1").IntValue;
                    //var Q2 = manager.GetProperty("Q2").IntValue;
                    //var Q3 = manager.GetProperty("Q3").IntValue;
                    //var Q4 = manager.GetProperty("Q4").IntValue;
                    //var Q5 = manager.GetProperty("Q5").IntValue;
                    //var Q6 = manager.GetProperty("Q6").IntValue;
                    //var P1 = manager.GetProperty("P1").DecimalValue;
                    //var P2 = manager.GetProperty("P2").DecimalValue;
                    //var P3 = manager.GetProperty("P3").DecimalValue;
                    //var P4 = manager.GetProperty("P4").DecimalValue;
                    //var P5 = manager.GetProperty("P5").DecimalValue;
                    //var P6 = manager.GetProperty("P6").DecimalValue;
                    //var GrossNett = manager.GetProperty("GrossNett").StringValue;


                    //var ImprintType_IL1_T1 = manager.GetProperty("ImprintType_IL1_T1").StringValue;
                    //var ImprintDescription_IL1_T1 = manager.GetProperty("ImprintDescription_IL1_T1").StringValue;
                    //var ImprintImage_IL1_T1 = manager.GetProperty("ImprintImage_IL1_T1").DecimalValue;
                    //var PriceClass_IL1_CN = manager.GetProperty("PriceClass_IL1_CN").StringValue;
                    //var SetupFee_IL1_T1 = manager.GetProperty("SetupFee_IL1_T1").StringValue;
                    //var SetupFee_IL1_T1_NextColor = manager.GetProperty("SetupFee_IL1_T1_NextColor").StringValue;
                    //var SetupFeeStructure_IL1_T1 = manager.GetProperty("SetupFeeStructure_IL1_T1").StringValue;
                    //var ExcludeFreeSetupCosts_IL1_T1 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T1").StringValue;
                    //var ImprintSize_IL1_T1 = manager.GetProperty("ImprintSize_IL1_T1").StringValue;
                    //var MaxColors_IL1_T1 = manager.GetProperty("MaxColors_IL1_T1").StringValue;
                    //var Handling_IL1_T1 = manager.GetProperty("Handling_IL1_T1").StringValue;

                    //var ImprintType_IL1_T2 = manager.GetProperty("ImprintType_IL1_T2").StringValue;
                    //var ImprintDescription_IL1_T2 = manager.GetProperty("ImprintDescription_IL1_T2").StringValue;
                    //var ImprintImage_IL1_T2 = manager.GetProperty("ImprintImage_IL1_T2").DecimalValue;
                    //var PriceClass_IL1_CN2 = manager.GetProperty("PriceClass_IL1_CN2").StringValue;
                    //var SetupFee_IL1_T2 = manager.GetProperty("SetupFee_IL1_T2").StringValue;
                    //var SetupFee_IL1_T2_NextColor = manager.GetProperty("SetupFee_IL1_T2_NextColor").StringValue;
                    //var SetupFeeStructure_IL1_T2 = manager.GetProperty("SetupFeeStructure_IL1_T2").StringValue;
                    //var ExcludeFreeSetupCosts_IL1_T2 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T2").StringValue;
                    //var ImprintSize_IL1_T2 = manager.GetProperty("ImprintSize_IL1_T2").StringValue;
                    //var MaxColors_IL1_T2 = manager.GetProperty("MaxColors_IL1_T2").StringValue;
                    //var Handling_IL1_T2 = manager.GetProperty("Handling_IL1_T2").StringValue;


                    //var MainGroup = manager.GetProperty("MainGroup").StringValue;
                    //var Material = manager.GetProperty("Material").StringValue;
                    //var MaxColors_IL1_T1 = manager.GetProperty("MaxColors_IL1_T1").IntValue;

                    //var BatteryType = manager.GetProperty("BatteryType").StringValue;
                    //var CapacityTxt = manager.GetProperty("CapacityTxt").StringValue;
                    //var ColorName = manager.GetProperty("ColorName").StringValue;
                    //var CommercialItemHeight = manager.GetProperty("CommercialItemHeight").DecimalValue;
                    //var CommercialItemLength = manager.GetProperty("CommercialItemLength").DecimalValue;
                    //var CommercialItemWeight = manager.GetProperty("CommercialItemWeight").DecimalValue;
                    //var CommercialItemWidth = manager.GetProperty("CommercialItemWidth").DecimalValue;
                    //var CountryOfOrigin = manager.GetProperty("CountryOfOrigin").StringValue;
                    //var DeliveryTimeMT_IL1_T1 = manager.GetProperty("DeliveryTimeMT_IL1_T1").StringValue;
                    //var Flavours = manager.GetProperty("Flavours").StringValue;
                    //var Handling_IL1_T1 = manager.GetProperty("Handling_IL1_T1").StringValue;
                    //var IntraCode = manager.GetProperty("IntraCode").StringValue;
                    //var NumberOfBatteries = manager.GetProperty("NumberOfBatteries").IntValue;
                    //var OrderUnit = manager.GetProperty("OrderUnit").StringValue;
                    //var OuterCartonHeight = manager.GetProperty("OuterCartonHeight").DecimalValue;
                    //var OuterCartonLength = manager.GetProperty("OuterCartonLength").DecimalValue;
                    //var OuterCartonPieces = manager.GetProperty("OuterCartonPieces").DecimalValue;
                    //var OuterCartonWidth = manager.GetProperty("OuterCartonWidth").DecimalValue;
                    //var Sizes = manager.GetProperty("Sizes").StringValue;
                    //var WritingColor = manager.GetProperty("WritingColor").StringValue;
                    //var ProductImageURL = manager.GetProperty("ProductImageURL").StringValue;




                    //var customProduct = new CustomProduct
                    //{
                    //    CountryId = countryId,
                    //    ParentSKU = manager.GetProperty("ParentSKU").StringValue,
                    //    SKU = manager.GetProperty("SKU").StringValue,
                    //    ColorName = manager.GetProperty("ColorName").StringValue,
                    //    InternetName = manager.GetProperty("InternetName").StringValue,
                    //    InternetTxt = manager.GetProperty("InternetTxt").StringValue,
                    //    Q1 = manager.GetProperty("Q1").DoubleValue,
                    //    Q2 = manager.GetProperty("Q2").DoubleValue,
                    //    Q3 = manager.GetProperty("Q3").DoubleValue,
                    //    Q4 = manager.GetProperty("Q4").DoubleValue,
                    //    Q5 = manager.GetProperty("Q5").DoubleValue,
                    //    Q6 = manager.GetProperty("Q6").DoubleValue,
                    //    P1 = manager.GetProperty("P1").DoubleValue,
                    //    P2 = manager.GetProperty("P2").DoubleValue,
                    //    P3 = manager.GetProperty("P3").DoubleValue,
                    //    P4 = manager.GetProperty("P4").DoubleValue,
                    //    P5 = manager.GetProperty("P5").DoubleValue,
                    //    P6 = manager.GetProperty("P6").DoubleValue,
                    //    GrossNett = manager.GetProperty("GrossNett").StringValue,

                    //    ImprintType_IL1_T1 = manager.GetProperty("ImprintType_IL1_T1").StringValue,
                    //    ImprintLocation_IL1_T1 = manager.GetProperty("ImprintDescription_IL1_T1").StringValue,
                    //    ImprintImage_IL1_T1 = manager.GetProperty("ImprintImage_IL1_T1").StringValue,
                    //    PriceClass_IL1_T1 = manager.GetProperty("PriceClass_IL1_T1").StringValue,
                    //    PriceClass_IL1_CN = manager.GetProperty("PriceClass_IL1_CN").StringValue,
                    //    SetupFee_IL1_T1 = manager.GetProperty("SetupFee_IL1_T1").DoubleValue,
                    //    SetupFee_IL1_NextColor = manager.GetProperty("SetupFee_IL1_T1_NextColor").DoubleValue,
                    //    SetupFeeStructure = manager.GetProperty("SetupFeeStructure_IL1_T1").StringValue,
                    //    ExcludeFreeSetupCosts = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T1").StringValue,
                    //    ImprintSize_IL1_T1 = manager.GetProperty("ImprintSize_IL1_T1").StringValue,
                    //    MaxColors_IL1_T1 = manager.GetProperty("MaxColors_IL1_T1").DoubleValue,
                    //    Handling_IL1_T1 = manager.GetProperty("Handling_IL1_T1").StringValue,

                    //    ImprintType_IL1_T2 = manager.GetProperty("ImprintType_IL1_T2").StringValue,
                    //    ImprintLocation_IL1_T2 = manager.GetProperty("ImprintDescription_IL1_T2").StringValue,
                    //    ImprintImage_IL1_T2 = manager.GetProperty("ImprintImage_IL1_T2").StringValue,
                    //    PriceClass_IL1_T2 = manager.GetProperty("PriceClass_IL1_T2").StringValue,
                    //    PriceClass_IL1_CN2 = manager.GetProperty("PriceClass_IL1_CN2").StringValue,
                    //    SetupFee_IL1_T2 = manager.GetProperty("SetupFee_IL1_T2").DoubleValue,
                    //    SetupFee_IL1_NextColor2 = manager.GetProperty("SetupFee_IL1_T2_NextColor").DoubleValue,
                    //    SetupFeeStructure2 = manager.GetProperty("SetupFeeStructure_IL1_T2").StringValue,
                    //    ExcludeFreeSetupCosts2 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T2").StringValue,
                    //    ImprintSize_IL1_T2 = manager.GetProperty("ImprintSize_IL1_T2").StringValue,
                    //    MaxColors_IL1_T2 = manager.GetProperty("MaxColors_IL1_T2").DoubleValue,
                    //    Handling_IL1_T2 = manager.GetProperty("Handling_IL1_T2").StringValue,

                    //    ImprintType_IL1_T3 = manager.GetProperty("ImprintType_IL1_T3").StringValue,
                    //    ImprintLocation_IL1_T3 = manager.GetProperty("ImprintDescription_IL1_T3").StringValue,
                    //    ImprintImage_IL1_T3 = manager.GetProperty("ImprintImage_IL1_T3").StringValue,
                    //    PriceClass_IL1_T3 = manager.GetProperty("PriceClass_IL1_T3").StringValue,
                    //    PriceClass_IL1_CN3 = manager.GetProperty("PriceClass_IL1_CN3").StringValue,
                    //    SetupFee_IL1_T3 = manager.GetProperty("SetupFee_IL1_T3").DoubleValue,
                    //    SetupFee_IL1_NextColor3 = manager.GetProperty("SetupFee_IL1_T3_NextColor").DoubleValue,
                    //    SetupFeeStructure3 = manager.GetProperty("SetupFeeStructure_IL1_T3").StringValue,
                    //    ExcludeFreeSetupCosts3 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T3").StringValue,
                    //    ImprintSize_IL1_T3 = manager.GetProperty("ImprintSize_IL1_T3").StringValue,
                    //    MaxColors_IL1_T3 = manager.GetProperty("MaxColors_IL1_T3").DoubleValue,
                    //    Handling_IL1_T3 = manager.GetProperty("Handling_IL1_T3").StringValue,

                    //    ImprintType_IL1_T4 = manager.GetProperty("ImprintType_IL1_T4").StringValue,
                    //    ImprintLocation_IL1_T4 = manager.GetProperty("ImprintDescription_IL1_T4").StringValue,
                    //    ImprintImage_IL1_T4 = manager.GetProperty("ImprintImage_IL1_T4").StringValue,
                    //    PriceClass_IL1_T4 = manager.GetProperty("PriceClass_IL1_T4").StringValue,
                    //    PriceClass_IL1_CN4 = manager.GetProperty("PriceClass_IL1_CN4").StringValue,
                    //    SetupFee_IL1_T4 = manager.GetProperty("SetupFee_IL1_T4").DoubleValue,
                    //    SetupFee_IL1_NextColor4 = manager.GetProperty("SetupFee_IL1_T4_NextColor").DoubleValue,
                    //    SetupFeeStructure4 = manager.GetProperty("SetupFeeStructure_IL1_T4").StringValue,
                    //    ExcludeFreeSetupCosts4 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T4").StringValue,
                    //    ImprintSize_IL1_T4 = manager.GetProperty("ImprintSize_IL1_T4").StringValue,
                    //    MaxColors_IL1_T4 = manager.GetProperty("MaxColors_IL1_T4").DoubleValue,
                    //    Handling_IL1_T4 = manager.GetProperty("Handling_IL1_T4").StringValue,

                    //    ImprintType_IL1_T5 = manager.GetProperty("ImprintType_IL1_T5").StringValue,
                    //    ImprintLocation_IL1_T5 = manager.GetProperty("ImprintDescription_IL1_T5").StringValue,
                    //    ImprintImage_IL1_T5 = manager.GetProperty("ImprintImage_IL1_T5").StringValue,
                    //    PriceClass_IL1_T5 = manager.GetProperty("PriceClass_IL1_T5").StringValue,
                    //    PriceClass_IL1_CN5 = manager.GetProperty("PriceClass_IL1_CN5").StringValue,
                    //    SetupFee_IL1_T5 = manager.GetProperty("SetupFee_IL1_T5").DoubleValue,
                    //    SetupFee_IL1_NextColor5 = manager.GetProperty("SetupFee_IL1_T5_NextColor").DoubleValue,
                    //    SetupFeeStructure5 = manager.GetProperty("SetupFeeStructure_IL1_T5").StringValue,
                    //    ExcludeFreeSetupCosts5 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T5").StringValue,
                    //    ImprintSize_IL1_T5 = manager.GetProperty("ImprintSize_IL1_T5").StringValue,
                    //    MaxColors_IL1_T5 = manager.GetProperty("MaxColors_IL1_T5").DoubleValue,
                    //    Handling_IL1_T5 = manager.GetProperty("Handling_IL1_T5").StringValue,

                    //    ImprintType_IL1_T6 = manager.GetProperty("ImprintType_IL1_T6").StringValue,
                    //    ImprintLocation_IL1_T6 = manager.GetProperty("ImprintDescription_IL1_T6").StringValue,
                    //    ImprintImage_IL1_T6 = manager.GetProperty("ImprintImage_IL1_T6").StringValue,
                    //    PriceClass_IL1_T6 = manager.GetProperty("PriceClass_IL1_T6").StringValue,
                    //    PriceClass_IL1_CN6 = manager.GetProperty("PriceClass_IL1_CN6").StringValue,
                    //    SetupFee_IL1_T6 = manager.GetProperty("SetupFee_IL1_T6").DoubleValue,
                    //    SetupFee_IL1_NextColor6 = manager.GetProperty("SetupFee_IL1_T6_NextColor").DoubleValue,
                    //    SetupFeeStructure6 = manager.GetProperty("SetupFeeStructure_IL1_T6").StringValue,
                    //    ExcludeFreeSetupCosts6 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T6").StringValue,
                    //    ImprintSize_IL1_T6 = manager.GetProperty("ImprintSize_IL1_T6").StringValue,
                    //    MaxColors_IL1_T6 = manager.GetProperty("MaxColors_IL1_T6").DoubleValue,
                    //    Handling_IL1_T6 = manager.GetProperty("Handling_IL1_T6").StringValue,

                    //    IntraCode = manager.GetProperty("IntraCode").StringValue,
                    //    CountryOfOrigin = manager.GetProperty("CountryOfOrigin").StringValue,
                    //    OuterCartonPieces = manager.GetProperty("OuterCartonPieces").DoubleValue,
                    //    OuterCartonLength = manager.GetProperty("OuterCartonLength").DoubleValue,
                    //    OuterCartonWidth = manager.GetProperty("OuterCartonWidth").DoubleValue,
                    //    OuterCartonHeight = manager.GetProperty("OuterCartonHeight").DoubleValue,
                    //    CommercialItemHeight = manager.GetProperty("CommercialItemHeight").DoubleValue,
                    //    CommercialItemLength = manager.GetProperty("CommercialItemLength").DoubleValue,
                    //    CommercialItemWeight = manager.GetProperty("CommercialItemWeight").DoubleValue,
                    //    CommercialItemWidth = manager.GetProperty("CommercialItemWidth").DoubleValue,
                    //    Flavours = manager.GetProperty("Flavours").StringValue,
                    //    Sizes = manager.GetProperty("Sizes").StringValue,
                    //    WritingColor = manager.GetProperty("WritingColor").StringValue,
                    //    CapacityTxt = manager.GetProperty("CapacityTxt").StringValue,
                    //    OrderUnit = manager.GetProperty("OrderUnit").StringValue,
                    //    MainGroup = manager.GetProperty("MainGroup").StringValue,
                    //    Material = manager.GetProperty("Material").StringValue,
                    //    BatteryType = manager.GetProperty("BatteryType").StringValue,
                    //    NumberOfBatteries = manager.GetProperty("NumberOfBatteries").IntValue,
                    //    ProductImageURL = manager.GetProperty("ProductImageURL").StringValue,
                    //    DeliveryTimeMT_IL1_T1 = manager.GetProperty("DeliveryTimeMT_IL1_T1").StringValue,
                    //    Q4_Q_OnPallet = manager.GetProperty("Q_OnPallet").StringValue
                    //};

                    //_clipperProductsService.InsertProduct(customProduct);

                    endRow++;
                }
            }
        
        public List<CustomProduct> readXLS(string FilePath, B2BDbContext _context)
        {
            Console.WriteLine(FilePath);
            FileInfo existingFile = new FileInfo(FilePath);
            //IEnumerable<B2BPrintTechnique> techniques = await _db.B2BPrintTechniques.Where(x => x.technique_description == "Doming").ToListAsync();

            //Console.WriteLine(parrentProduct);
            //Console.WriteLine(childProduct);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                Console.WriteLine(worksheet);
                //ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count

                List<CustomProduct> customProductList = new List<CustomProduct>();

                if(worksheet != null)
                for (int row = 1; row <= rowCount; row++)
                {
                    CustomProduct customProduct = new CustomProduct();

                    if (row != 1)
                        {
                                //eachVal = worksheet.Cells[row, col].Value.ToString().Trim();
                            try { 
                            customProduct.ParentSKU = _masterProductImport.ReturnData(worksheet, row, 1);
                            Console.WriteLine(customProduct.ParentSKU);
                            customProduct.SKU = _masterProductImport.ReturnData(worksheet, row, 2);
                            customProduct.ColorName = _masterProductImport.ReturnData(worksheet, row, 3);
                            customProduct.InternetName = _masterProductImport.ReturnData(worksheet, row, 4);
                            customProduct.InternetTxt = _masterProductImport.ReturnData(worksheet, row, 5);

                            customProduct.Q1 = _masterProductImport.ReturnDataDouble(worksheet, row, 6);
                            customProduct.Q2 = _masterProductImport.ReturnDataDouble(worksheet, row, 7);
                            customProduct.Q3 = _masterProductImport.ReturnDataDouble(worksheet, row, 8);
                            customProduct.Q4 = _masterProductImport.ReturnDataDouble(worksheet, row, 9);
                            customProduct.Q5 = _masterProductImport.ReturnDataDouble(worksheet, row, 10);
                            customProduct.Q6 = _masterProductImport.ReturnDataDouble(worksheet, row, 11);
                            customProduct.P1 = _masterProductImport.ReturnDataDouble(worksheet, row, 12);
                            customProduct.P2 = _masterProductImport.ReturnDataDouble(worksheet, row, 13);
                            customProduct.P3 = _masterProductImport.ReturnDataDouble(worksheet, row, 14);
                            customProduct.P4 = _masterProductImport.ReturnDataDouble(worksheet, row, 15);
                            customProduct.P5 = _masterProductImport.ReturnDataDouble(worksheet, row, 16);
                            customProduct.P6 = _masterProductImport.ReturnDataDouble(worksheet, row, 17);

                            customProduct.GrossNett = _masterProductImport.ReturnData(worksheet, row, 18);
                            customProduct.ImprintType_IL1_T1 = _masterProductImport.ReturnData(worksheet, row, 19);
                            customProduct.ImprintDescription_IL1_T1 = _masterProductImport.ReturnData(worksheet, row, 20);
                            customProduct.ImprintImage_IL1_T1 = _masterProductImport.ReturnData(worksheet, row, 21);
                            customProduct.PriceClass_IL1_CN = _masterProductImport.ReturnData(worksheet, row, 22);
                            customProduct.PriceClass_IL1_T1 = _masterProductImport.ReturnData(worksheet, row, 23);
                            customProduct.SetupFee_IL1_T1 = _masterProductImport.ReturnDataDouble(worksheet, row, 24);
                            customProduct.SetupFee_IL1_NextColor = _masterProductImport.ReturnDataDouble(worksheet, row, 25);
                            customProduct.SetupFeeStructure = _masterProductImport.ReturnData(worksheet, row, 26);
                            customProduct.ExcludeFreeSetupCosts = _masterProductImport.ReturnData(worksheet, row, 27);
                            customProduct.ImprintSize_IL1_T1 = _masterProductImport.ReturnData(worksheet, row, 28);
                            customProduct.MaxColors_IL1_T1 = _masterProductImport.ReturnDataDouble(worksheet, row, 29);
                            customProduct.Handling_IL1_T1 = _masterProductImport.ReturnData(worksheet, row, 30);

                            customProduct.ImprintType_IL1_T2 = _masterProductImport.ReturnData(worksheet, row, 31);
                            customProduct.ImprintDescription_IL1_T2 = _masterProductImport.ReturnData(worksheet, row, 32);
                            customProduct.ImprintImage_IL1_T2 = _masterProductImport.ReturnData(worksheet, row, 33);
                            customProduct.PriceClass_IL1_CN2 = _masterProductImport.ReturnData(worksheet, row, 34);
                            customProduct.PriceClass_IL1_T2 = _masterProductImport.ReturnData(worksheet, row, 35);
                            customProduct.SetupFee_IL1_T2 = _masterProductImport.ReturnDataDouble(worksheet, row, 36);
                            customProduct.SetupFee_IL1_NextColor2 = _masterProductImport.ReturnDataDouble(worksheet, row, 37);
                            customProduct.SetupFeeStructure2 = _masterProductImport.ReturnData(worksheet, row, 38);
                            customProduct.ExcludeFreeSetupCosts2 = _masterProductImport.ReturnData(worksheet, row, 39);
                            customProduct.ImprintSize_IL1_T2 = _masterProductImport.ReturnData(worksheet, row, 40);
                            customProduct.MaxColors_IL1_T2 = _masterProductImport.ReturnDataDouble(worksheet, row, 41);
                            customProduct.Handling_IL1_T2 = _masterProductImport.ReturnData(worksheet, row, 42);

                            customProduct.ImprintType_IL1_T3 = _masterProductImport.ReturnData(worksheet, row, 43);
                            customProduct.ImprintDescription_IL1_T3 = _masterProductImport.ReturnData(worksheet, row, 44);
                            customProduct.ImprintImage_IL1_T3 = _masterProductImport.ReturnData(worksheet, row, 45);
                            customProduct.PriceClass_IL1_CN3 = _masterProductImport.ReturnData(worksheet, row, 46);
                            customProduct.PriceClass_IL1_T3 = _masterProductImport.ReturnData(worksheet, row, 47);
                            customProduct.SetupFee_IL1_T3 = _masterProductImport.ReturnDataDouble(worksheet, row, 48);
                            customProduct.SetupFee_IL1_NextColor3 = _masterProductImport.ReturnDataDouble(worksheet, row, 49);
                            customProduct.SetupFeeStructure3 = _masterProductImport.ReturnData(worksheet, row, 50);
                            customProduct.ExcludeFreeSetupCosts3 = _masterProductImport.ReturnData(worksheet, row, 51);
                            customProduct.ImprintSize_IL1_T3 = _masterProductImport.ReturnData(worksheet, row, 52);
                            customProduct.MaxColors_IL1_T3 = _masterProductImport.ReturnDataDouble(worksheet, row, 53);
                            customProduct.Handling_IL1_T3 = _masterProductImport.ReturnData(worksheet, row, 54);

                            customProduct.ImprintType_IL1_T4 = _masterProductImport.ReturnData(worksheet, row, 55);
                            customProduct.ImprintDescription_IL1_T4 = _masterProductImport.ReturnData(worksheet, row, 56);
                            customProduct.ImprintImage_IL1_T4 = _masterProductImport.ReturnData(worksheet, row, 57);
                            customProduct.PriceClass_IL1_CN4 = _masterProductImport.ReturnData(worksheet, row, 58);
                            customProduct.PriceClass_IL1_T4 = _masterProductImport.ReturnData(worksheet, row, 59);
                            customProduct.SetupFee_IL1_T4 = _masterProductImport.ReturnDataDouble(worksheet, row, 60);
                            customProduct.SetupFee_IL1_NextColor4 = _masterProductImport.ReturnDataDouble(worksheet, row, 61);
                            customProduct.SetupFeeStructure4 = _masterProductImport.ReturnData(worksheet, row, 62);
                            customProduct.ExcludeFreeSetupCosts4 = _masterProductImport.ReturnData(worksheet, row, 63);
                            customProduct.ImprintSize_IL1_T4 = _masterProductImport.ReturnData(worksheet, row, 64);
                            customProduct.MaxColors_IL1_T4 = _masterProductImport.ReturnDataDouble(worksheet, row, 65);
                            customProduct.Handling_IL1_T4 = _masterProductImport.ReturnData(worksheet, row, 66);

                            customProduct.ImprintType_IL1_T5 = _masterProductImport.ReturnData(worksheet, row, 67);
                            customProduct.ImprintDescription_IL1_T5 = _masterProductImport.ReturnData(worksheet, row, 68);
                            customProduct.ImprintImage_IL1_T5 = _masterProductImport.ReturnData(worksheet, row, 69);
                            customProduct.PriceClass_IL1_CN5 = _masterProductImport.ReturnData(worksheet, row, 70);
                            customProduct.PriceClass_IL1_T5 = _masterProductImport.ReturnData(worksheet, row, 71);
                            customProduct.SetupFee_IL1_T5 = _masterProductImport.ReturnDataDouble(worksheet, row, 72);
                            customProduct.SetupFee_IL1_NextColor5 = _masterProductImport.ReturnDataDouble(worksheet, row, 73);
                            customProduct.SetupFeeStructure5 = _masterProductImport.ReturnData(worksheet, row, 74);
                            customProduct.ExcludeFreeSetupCosts5 = _masterProductImport.ReturnData(worksheet, row, 75);
                            customProduct.ImprintSize_IL1_T5 = _masterProductImport.ReturnData(worksheet, row, 76);
                            customProduct.MaxColors_IL1_T5 = _masterProductImport.ReturnDataDouble(worksheet, row, 77);
                            customProduct.Handling_IL1_T5 = _masterProductImport.ReturnData(worksheet, row, 78);

                            customProduct.ImprintType_IL1_T6 = _masterProductImport.ReturnData(worksheet, row, 79);
                            customProduct.ImprintDescription_IL1_T6 = _masterProductImport.ReturnData(worksheet, row, 80);
                            customProduct.ImprintImage_IL1_T6 = _masterProductImport.ReturnData(worksheet, row, 81);
                            customProduct.PriceClass_IL1_CN6 = _masterProductImport.ReturnData(worksheet, row, 82);
                            customProduct.PriceClass_IL1_T6 = _masterProductImport.ReturnData(worksheet, row, 83);
                            customProduct.SetupFee_IL1_T6 = _masterProductImport.ReturnDataDouble(worksheet, row, 84);
                            customProduct.SetupFee_IL1_NextColor6 = _masterProductImport.ReturnDataDouble(worksheet, row, 85);
                            customProduct.SetupFeeStructure6 = _masterProductImport.ReturnData(worksheet, row, 86);
                            customProduct.ExcludeFreeSetupCosts6 = _masterProductImport.ReturnData(worksheet, row, 87);
                            customProduct.ImprintSize_IL1_T6 = _masterProductImport.ReturnData(worksheet, row, 88);
                            customProduct.MaxColors_IL1_T6 = _masterProductImport.ReturnDataDouble(worksheet, row, 89);
                            customProduct.Handling_IL1_T6 = _masterProductImport.ReturnData(worksheet, row, 90);

                            customProduct.IntraCode = _masterProductImport.ReturnData(worksheet, row, 91);
                            customProduct.CountryOfOrigin = _masterProductImport.ReturnData(worksheet, row, 92);
                            customProduct.OuterCartonPieces = _masterProductImport.ReturnDataDouble(worksheet, row, 93);
                            customProduct.OuterCartonLength = _masterProductImport.ReturnDataDouble(worksheet, row, 94);
                            customProduct.OuterCartonWidth = _masterProductImport.ReturnDataDouble(worksheet, row, 95);
                            customProduct.OuterCartonHeight = _masterProductImport.ReturnDataDouble(worksheet, row, 96);
                            customProduct.CommercialItemLength = _masterProductImport.ReturnDataDouble(worksheet, row, 97);
                            customProduct.CommercialItemWidth = _masterProductImport.ReturnDataDouble(worksheet, row, 98);
                            customProduct.CommercialItemHeight = _masterProductImport.ReturnDataDouble(worksheet, row, 99);
                            customProduct.CommercialItemWeight = _masterProductImport.ReturnDataDouble(worksheet, row, 100);

                            customProduct.Flavours = _masterProductImport.ReturnData(worksheet, row, 101);
                            customProduct.Sizes = _masterProductImport.ReturnData(worksheet, row, 102);
                            customProduct.WritingColor = _masterProductImport.ReturnData(worksheet, row, 103);
                            customProduct.CapacityTxt = _masterProductImport.ReturnData(worksheet, row, 104);
                            customProduct.OrderUnit = _masterProductImport.ReturnData(worksheet, row, 105);
                            customProduct.MainGroup = _masterProductImport.ReturnData(worksheet, row, 106);
                            // SPACE IN EXCEL SHEET
                            customProduct.Material = _masterProductImport.ReturnData(worksheet, row, 107);
                            customProduct.BatteryType = _masterProductImport.ReturnData(worksheet, row, 108);
                            //customProduct.NumberOfBatteries = _masterProductImport.ReturnDataDouble(worksheet, row, 109);
                            customProduct.ProductImageURL = _masterProductImport.ReturnData(worksheet, row, 110);
                            customProduct.DeliveryTimeMT_IL1_T1 = _masterProductImport.ReturnData(worksheet, row, 111);
                            customProduct.SearchTerms = _masterProductImport.ReturnData(worksheet, row, 112);
                            customProduct.Q4_Q_OnPallet = _masterProductImport.ReturnData(worksheet, row, 113);
                            customProduct.Brandnames = _masterProductImport.ReturnData(worksheet, row, 114);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                    Console.WriteLine(customProduct);
                    if (customProduct.ParentSKU != null && customProduct.ParentSKU != "")
                    {
                        customProductList.Add(customProduct);
                    }
                }
                Console.WriteLine(customProductList);
                return customProductList;
            }
        }

        //public void ImportProductsFromExcel(Stream stream, int countryId, int siteId, string database)
        //{
            
        //    using (var xlPackage = new ExcelPackage(stream))
        //    {


        //        // get the first worksheet in the workbook
        //        var worksheet = xlPackage.Workbook.Worksheets.FirstOrDefault();
        //        if (worksheet == null)
        //            Console.WriteLine("Hey");

        //        int colCount = worksheet.Dimension.End.Column;  //get Column Count
        //        int rowCount = worksheet.Dimension.End.Row;     //get row count

        //        string queryString = "INSERT INTO tableName VALUES";        //Here I am using "blind insert". You can specify the column names Blient inset is strongly not recommanded
        //        string eachVal = "";
        //        bool status;

        //        for (int row = 1; row <= rowCount; row++)
        //        {
        //            queryString += "(";
        //            for (int col = 1; col <= colCount; col++)
        //            {
        //                eachVal = worksheet.Cells[row, col].Value.ToString().Trim();
        //                queryString += "'" + eachVal + "',";
        //            }
        //            queryString = queryString.Remove(queryString.Length - 1, 1);    //removing last comma (,) from the string
        //            if (row % 1000 == 0)        //On every 1000 query will execute, as maximum of 1000 will be executed at a time. 
        //            {
        //                queryString += ")";
        //                //status = this.runQuery(queryString);    //executing query
        //                if (status == false)
        //                    return status;
        //                queryString = "INSERT INTO tableName VALUES";
        //            }
        //            else
        //            {
        //                queryString += "),";
        //            }
        //        }
        //        queryString = queryString.Remove(queryString.Length - 1, 1);    //removing last comma (,) from the string
        //        status = this.runQuery(queryString);    //executing query
        //        //return status;
        //        //var properties = new[]
        //        //   {
        //        //       new PropertyByName<CustomProductModel>("ParentSKU"),
        //        //       new PropertyByName<CustomProductModel>("SKU"),
        //        //       new PropertyByName<CustomProductModel>("ColorName"),
        //        //       new PropertyByName<CustomProductModel>("InternetName"),
        //        //       new PropertyByName<CustomProductModel>("InternetTxt"),
        //        //       new PropertyByName<CustomProductModel>("Q1"),
        //        //       new PropertyByName<CustomProductModel>("Q2"),
        //        //       new PropertyByName<CustomProductModel>("Q3"),
        //        //       new PropertyByName<CustomProductModel>("Q4"),
        //        //       new PropertyByName<CustomProductModel>("Q5"),
        //        //       new PropertyByName<CustomProductModel>("Q6"),
        //        //       new PropertyByName<CustomProductModel>("P1"),
        //        //       new PropertyByName<CustomProductModel>("P2"),
        //        //       new PropertyByName<CustomProductModel>("P3"),
        //        //       new PropertyByName<CustomProductModel>("P4"),
        //        //       new PropertyByName<CustomProductModel>("P5"),
        //        //       new PropertyByName<CustomProductModel>("P6"),
        //        //       new PropertyByName<CustomProductModel>("GrossNett"),

        //        //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN"),
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T1_NextColor"),
        //        //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("Handling_IL1_T1"),

        //        //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN2"), //Wrong
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T2_NextColor"),
        //        //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T2"),
        //        //       new PropertyByName<CustomProductModel>("Handling_IL1_T2"),

        //        //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN3"), //Wrong
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T3_NextColor"),
        //        //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T3"),
        //        //       new PropertyByName<CustomProductModel>("Handling_IL1_T3"),

        //        //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN4"), //Wrong
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T4_NextColor"),
        //        //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T4"),
        //        //       new PropertyByName<CustomProductModel>("Handling_IL1_T4"),

        //        //       new PropertyByName<CustomProductModel>("ImprintType_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN5"), //Wrong
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T5_NextColor"),
        //        //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T5"),
        //        //       new PropertyByName<CustomProductModel>("Handling_IL1_T5"),

        //        //        new PropertyByName<CustomProductModel>("ImprintType_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("ImprintDescription_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("ImprintImage_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("PriceClass_IL1_CN6"), //Wrong
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("SetupFee_IL1_T6_NextColor"),
        //        //       new PropertyByName<CustomProductModel>("SetupFeeStructure_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("ExcludeFreeSetupCosts_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("ImprintSize_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("MaxColors_IL1_T6"),
        //        //       new PropertyByName<CustomProductModel>("Handling_IL1_T6"),

        //        //       new PropertyByName<CustomProductModel>("IntraCode"),
        //        //       new PropertyByName<CustomProductModel>("CountryOfOrigin"),
        //        //       new PropertyByName<CustomProductModel>("OuterCartonPieces"),
        //        //       new PropertyByName<CustomProductModel>("OuterCartonLength"),
        //        //       new PropertyByName<CustomProductModel>("OuterCartonWidth"),
        //        //       new PropertyByName<CustomProductModel>("OuterCartonHeight"),
        //        //       new PropertyByName<CustomProductModel>("CommercialItemLength"),
        //        //       new PropertyByName<CustomProductModel>("CommercialItemWidth"),
        //        //       new PropertyByName<CustomProductModel>("CommercialItemHeight"),
        //        //       new PropertyByName<CustomProductModel>("CommercialItemWeight"),
        //        //       new PropertyByName<CustomProductModel>("Flavours"),
        //        //       new PropertyByName<CustomProductModel>("Sizes"),
        //        //       new PropertyByName<CustomProductModel>("WritingColor"),
        //        //       new PropertyByName<CustomProductModel>("CapacityTxt"),
        //        //       new PropertyByName<CustomProductModel>("OrderUnit"),
        //        //       new PropertyByName<CustomProductModel>("MainGroup"),
        //        //       new PropertyByName<CustomProductModel>("Material"),
        //        //       new PropertyByName<CustomProductModel>("BatteryType"),
        //        //       new PropertyByName<CustomProductModel>("NumberOfBatteries"),
        //        //       new PropertyByName<CustomProductModel>("ProductImageURL"),
        //        //       new PropertyByName<CustomProductModel>("DeliveryTimeMT_IL1_T1"),
        //        //       new PropertyByName<CustomProductModel>("07_12_SearchTerms"),
        //        //       new PropertyByName<CustomProductModel>("Q_OnPallet"),
        //        //       new PropertyByName<CustomProductModel>("Brandnames")
        //        //};
        //        //var manager = new PropertyManager<CustomProductModel>(properties);

        //        //var endRow = 2;

        //        ////Clear the table
        //        //_clipperProductsService.ClearTable();

        //        //while (true)
        //        //{
        //        //    var allColumnsAreEmpty = manager.GetProperties
        //        //        .Select(property => worksheet.Cells[endRow, property.PropertyOrderPosition])
        //        //        .All(cell => cell == null || cell.Value == null || String.IsNullOrEmpty(cell.Value.ToString()));

        //        //    if (allColumnsAreEmpty)
        //        //        break;
        //        //    manager.ReadFromXlsx(worksheet, endRow);

        //        //    //var CountryId = countryId;
        //        //    //var ParentSKU = manager.GetProperty("ParentSKU").StringValue;
        //        //    //var SKU = manager.GetProperty("SKU").StringValue;
        //        //    //var InternetName = manager.GetProperty("InternetName").StringValue;
        //        //    //var InternetTxt = manager.GetProperty("InternetTxt").StringValue;
        //        //    //var ImprintLocation_IL1_T1 = manager.GetProperty("ImprintLocation_IL1_T1").StringValue;
        //        //    ////var ImprintSize_IL1_T1 = manager.GetProperty("ImprintSize_IL1_T1").StringValue;
        //        //    ////var ImprintType_IL1_T1 = manager.GetProperty("ImprintType_IL1_T1").StringValue;
        //        //    //var Q1 = manager.GetProperty("Q1").IntValue;
        //        //    //var Q2 = manager.GetProperty("Q2").IntValue;
        //        //    //var Q3 = manager.GetProperty("Q3").IntValue;
        //        //    //var Q4 = manager.GetProperty("Q4").IntValue;
        //        //    //var Q5 = manager.GetProperty("Q5").IntValue;
        //        //    //var Q6 = manager.GetProperty("Q6").IntValue;
        //        //    //var P1 = manager.GetProperty("P1").DecimalValue;
        //        //    //var P2 = manager.GetProperty("P2").DecimalValue;
        //        //    //var P3 = manager.GetProperty("P3").DecimalValue;
        //        //    //var P4 = manager.GetProperty("P4").DecimalValue;
        //        //    //var P5 = manager.GetProperty("P5").DecimalValue;
        //        //    //var P6 = manager.GetProperty("P6").DecimalValue;
        //        //    //var GrossNett = manager.GetProperty("GrossNett").StringValue;


        //        //    //var ImprintType_IL1_T1 = manager.GetProperty("ImprintType_IL1_T1").StringValue;
        //        //    //var ImprintDescription_IL1_T1 = manager.GetProperty("ImprintDescription_IL1_T1").StringValue;
        //        //    //var ImprintImage_IL1_T1 = manager.GetProperty("ImprintImage_IL1_T1").DecimalValue;
        //        //    //var PriceClass_IL1_CN = manager.GetProperty("PriceClass_IL1_CN").StringValue;
        //        //    //var SetupFee_IL1_T1 = manager.GetProperty("SetupFee_IL1_T1").StringValue;
        //        //    //var SetupFee_IL1_T1_NextColor = manager.GetProperty("SetupFee_IL1_T1_NextColor").StringValue;
        //        //    //var SetupFeeStructure_IL1_T1 = manager.GetProperty("SetupFeeStructure_IL1_T1").StringValue;
        //        //    //var ExcludeFreeSetupCosts_IL1_T1 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T1").StringValue;
        //        //    //var ImprintSize_IL1_T1 = manager.GetProperty("ImprintSize_IL1_T1").StringValue;
        //        //    //var MaxColors_IL1_T1 = manager.GetProperty("MaxColors_IL1_T1").StringValue;
        //        //    //var Handling_IL1_T1 = manager.GetProperty("Handling_IL1_T1").StringValue;

        //        //    //var ImprintType_IL1_T2 = manager.GetProperty("ImprintType_IL1_T2").StringValue;
        //        //    //var ImprintDescription_IL1_T2 = manager.GetProperty("ImprintDescription_IL1_T2").StringValue;
        //        //    //var ImprintImage_IL1_T2 = manager.GetProperty("ImprintImage_IL1_T2").DecimalValue;
        //        //    //var PriceClass_IL1_CN2 = manager.GetProperty("PriceClass_IL1_CN2").StringValue;
        //        //    //var SetupFee_IL1_T2 = manager.GetProperty("SetupFee_IL1_T2").StringValue;
        //        //    //var SetupFee_IL1_T2_NextColor = manager.GetProperty("SetupFee_IL1_T2_NextColor").StringValue;
        //        //    //var SetupFeeStructure_IL1_T2 = manager.GetProperty("SetupFeeStructure_IL1_T2").StringValue;
        //        //    //var ExcludeFreeSetupCosts_IL1_T2 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T2").StringValue;
        //        //    //var ImprintSize_IL1_T2 = manager.GetProperty("ImprintSize_IL1_T2").StringValue;
        //        //    //var MaxColors_IL1_T2 = manager.GetProperty("MaxColors_IL1_T2").StringValue;
        //        //    //var Handling_IL1_T2 = manager.GetProperty("Handling_IL1_T2").StringValue;


        //        //    //var MainGroup = manager.GetProperty("MainGroup").StringValue;
        //        //    //var Material = manager.GetProperty("Material").StringValue;
        //        //    //var MaxColors_IL1_T1 = manager.GetProperty("MaxColors_IL1_T1").IntValue;

        //        //    //var BatteryType = manager.GetProperty("BatteryType").StringValue;
        //        //    //var CapacityTxt = manager.GetProperty("CapacityTxt").StringValue;
        //        //    //var ColorName = manager.GetProperty("ColorName").StringValue;
        //        //    //var CommercialItemHeight = manager.GetProperty("CommercialItemHeight").DecimalValue;
        //        //    //var CommercialItemLength = manager.GetProperty("CommercialItemLength").DecimalValue;
        //        //    //var CommercialItemWeight = manager.GetProperty("CommercialItemWeight").DecimalValue;
        //        //    //var CommercialItemWidth = manager.GetProperty("CommercialItemWidth").DecimalValue;
        //        //    //var CountryOfOrigin = manager.GetProperty("CountryOfOrigin").StringValue;
        //        //    //var DeliveryTimeMT_IL1_T1 = manager.GetProperty("DeliveryTimeMT_IL1_T1").StringValue;
        //        //    //var Flavours = manager.GetProperty("Flavours").StringValue;
        //        //    //var Handling_IL1_T1 = manager.GetProperty("Handling_IL1_T1").StringValue;
        //        //    //var IntraCode = manager.GetProperty("IntraCode").StringValue;
        //        //    //var NumberOfBatteries = manager.GetProperty("NumberOfBatteries").IntValue;
        //        //    //var OrderUnit = manager.GetProperty("OrderUnit").StringValue;
        //        //    //var OuterCartonHeight = manager.GetProperty("OuterCartonHeight").DecimalValue;
        //        //    //var OuterCartonLength = manager.GetProperty("OuterCartonLength").DecimalValue;
        //        //    //var OuterCartonPieces = manager.GetProperty("OuterCartonPieces").DecimalValue;
        //        //    //var OuterCartonWidth = manager.GetProperty("OuterCartonWidth").DecimalValue;
        //        //    //var Sizes = manager.GetProperty("Sizes").StringValue;
        //        //    //var WritingColor = manager.GetProperty("WritingColor").StringValue;
        //        //    //var ProductImageURL = manager.GetProperty("ProductImageURL").StringValue;




        //        //    var customProduct = new CustomProduct
        //        //    {
        //        //        CountryId = countryId,
        //        //        ParentSKU = manager.GetProperty("ParentSKU").StringValue,
        //        //        SKU = manager.GetProperty("SKU").StringValue,
        //        //        ColorName = manager.GetProperty("ColorName").StringValue,
        //        //        InternetName = manager.GetProperty("InternetName").StringValue,
        //        //        InternetTxt = manager.GetProperty("InternetTxt").StringValue,
        //        //        Q1 = manager.GetProperty("Q1").DoubleValue,
        //        //        Q2 = manager.GetProperty("Q2").DoubleValue,
        //        //        Q3 = manager.GetProperty("Q3").DoubleValue,
        //        //        Q4 = manager.GetProperty("Q4").DoubleValue,
        //        //        Q5 = manager.GetProperty("Q5").DoubleValue,
        //        //        Q6 = manager.GetProperty("Q6").DoubleValue,
        //        //        P1 = manager.GetProperty("P1").DoubleValue,
        //        //        P2 = manager.GetProperty("P2").DoubleValue,
        //        //        P3 = manager.GetProperty("P3").DoubleValue,
        //        //        P4 = manager.GetProperty("P4").DoubleValue,
        //        //        P5 = manager.GetProperty("P5").DoubleValue,
        //        //        P6 = manager.GetProperty("P6").DoubleValue,
        //        //        GrossNett = manager.GetProperty("GrossNett").StringValue,

        //        //        ImprintType_IL1_T1 = manager.GetProperty("ImprintType_IL1_T1").StringValue,
        //        //        ImprintLocation_IL1_T1 = manager.GetProperty("ImprintDescription_IL1_T1").StringValue,
        //        //        ImprintImage_IL1_T1 = manager.GetProperty("ImprintImage_IL1_T1").StringValue,
        //        //        PriceClass_IL1_T1 = manager.GetProperty("PriceClass_IL1_T1").StringValue,
        //        //        PriceClass_IL1_CN = manager.GetProperty("PriceClass_IL1_CN").StringValue,
        //        //        SetupFee_IL1_T1 = manager.GetProperty("SetupFee_IL1_T1").DoubleValue,
        //        //        SetupFee_IL1_NextColor = manager.GetProperty("SetupFee_IL1_T1_NextColor").DoubleValue,
        //        //        SetupFeeStructure = manager.GetProperty("SetupFeeStructure_IL1_T1").StringValue,
        //        //        ExcludeFreeSetupCosts = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T1").StringValue,
        //        //        ImprintSize_IL1_T1 = manager.GetProperty("ImprintSize_IL1_T1").StringValue,
        //        //        MaxColors_IL1_T1 = manager.GetProperty("MaxColors_IL1_T1").DoubleValue,
        //        //        Handling_IL1_T1 = manager.GetProperty("Handling_IL1_T1").StringValue,

        //        //        ImprintType_IL1_T2 = manager.GetProperty("ImprintType_IL1_T2").StringValue,
        //        //        ImprintLocation_IL1_T2 = manager.GetProperty("ImprintDescription_IL1_T2").StringValue,
        //        //        ImprintImage_IL1_T2 = manager.GetProperty("ImprintImage_IL1_T2").StringValue,
        //        //        PriceClass_IL1_T2 = manager.GetProperty("PriceClass_IL1_T2").StringValue,
        //        //        PriceClass_IL1_CN2 = manager.GetProperty("PriceClass_IL1_CN2").StringValue,
        //        //        SetupFee_IL1_T2 = manager.GetProperty("SetupFee_IL1_T2").DoubleValue,
        //        //        SetupFee_IL1_NextColor2 = manager.GetProperty("SetupFee_IL1_T2_NextColor").DoubleValue,
        //        //        SetupFeeStructure2 = manager.GetProperty("SetupFeeStructure_IL1_T2").StringValue,
        //        //        ExcludeFreeSetupCosts2 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T2").StringValue,
        //        //        ImprintSize_IL1_T2 = manager.GetProperty("ImprintSize_IL1_T2").StringValue,
        //        //        MaxColors_IL1_T2 = manager.GetProperty("MaxColors_IL1_T2").DoubleValue,
        //        //        Handling_IL1_T2 = manager.GetProperty("Handling_IL1_T2").StringValue,

        //        //        ImprintType_IL1_T3 = manager.GetProperty("ImprintType_IL1_T3").StringValue,
        //        //        ImprintLocation_IL1_T3 = manager.GetProperty("ImprintDescription_IL1_T3").StringValue,
        //        //        ImprintImage_IL1_T3 = manager.GetProperty("ImprintImage_IL1_T3").StringValue,
        //        //        PriceClass_IL1_T3 = manager.GetProperty("PriceClass_IL1_T3").StringValue,
        //        //        PriceClass_IL1_CN3 = manager.GetProperty("PriceClass_IL1_CN3").StringValue,
        //        //        SetupFee_IL1_T3 = manager.GetProperty("SetupFee_IL1_T3").DoubleValue,
        //        //        SetupFee_IL1_NextColor3 = manager.GetProperty("SetupFee_IL1_T3_NextColor").DoubleValue,
        //        //        SetupFeeStructure3 = manager.GetProperty("SetupFeeStructure_IL1_T3").StringValue,
        //        //        ExcludeFreeSetupCosts3 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T3").StringValue,
        //        //        ImprintSize_IL1_T3 = manager.GetProperty("ImprintSize_IL1_T3").StringValue,
        //        //        MaxColors_IL1_T3 = manager.GetProperty("MaxColors_IL1_T3").DoubleValue,
        //        //        Handling_IL1_T3 = manager.GetProperty("Handling_IL1_T3").StringValue,

        //        //        ImprintType_IL1_T4 = manager.GetProperty("ImprintType_IL1_T4").StringValue,
        //        //        ImprintLocation_IL1_T4 = manager.GetProperty("ImprintDescription_IL1_T4").StringValue,
        //        //        ImprintImage_IL1_T4 = manager.GetProperty("ImprintImage_IL1_T4").StringValue,
        //        //        PriceClass_IL1_T4 = manager.GetProperty("PriceClass_IL1_T4").StringValue,
        //        //        PriceClass_IL1_CN4 = manager.GetProperty("PriceClass_IL1_CN4").StringValue,
        //        //        SetupFee_IL1_T4 = manager.GetProperty("SetupFee_IL1_T4").DoubleValue,
        //        //        SetupFee_IL1_NextColor4 = manager.GetProperty("SetupFee_IL1_T4_NextColor").DoubleValue,
        //        //        SetupFeeStructure4 = manager.GetProperty("SetupFeeStructure_IL1_T4").StringValue,
        //        //        ExcludeFreeSetupCosts4 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T4").StringValue,
        //        //        ImprintSize_IL1_T4 = manager.GetProperty("ImprintSize_IL1_T4").StringValue,
        //        //        MaxColors_IL1_T4 = manager.GetProperty("MaxColors_IL1_T4").DoubleValue,
        //        //        Handling_IL1_T4 = manager.GetProperty("Handling_IL1_T4").StringValue,

        //        //        ImprintType_IL1_T5 = manager.GetProperty("ImprintType_IL1_T5").StringValue,
        //        //        ImprintLocation_IL1_T5 = manager.GetProperty("ImprintDescription_IL1_T5").StringValue,
        //        //        ImprintImage_IL1_T5 = manager.GetProperty("ImprintImage_IL1_T5").StringValue,
        //        //        PriceClass_IL1_T5 = manager.GetProperty("PriceClass_IL1_T5").StringValue,
        //        //        PriceClass_IL1_CN5 = manager.GetProperty("PriceClass_IL1_CN5").StringValue,
        //        //        SetupFee_IL1_T5 = manager.GetProperty("SetupFee_IL1_T5").DoubleValue,
        //        //        SetupFee_IL1_NextColor5 = manager.GetProperty("SetupFee_IL1_T5_NextColor").DoubleValue,
        //        //        SetupFeeStructure5 = manager.GetProperty("SetupFeeStructure_IL1_T5").StringValue,
        //        //        ExcludeFreeSetupCosts5 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T5").StringValue,
        //        //        ImprintSize_IL1_T5 = manager.GetProperty("ImprintSize_IL1_T5").StringValue,
        //        //        MaxColors_IL1_T5 = manager.GetProperty("MaxColors_IL1_T5").DoubleValue,
        //        //        Handling_IL1_T5 = manager.GetProperty("Handling_IL1_T5").StringValue,

        //        //        ImprintType_IL1_T6 = manager.GetProperty("ImprintType_IL1_T6").StringValue,
        //        //        ImprintLocation_IL1_T6 = manager.GetProperty("ImprintDescription_IL1_T6").StringValue,
        //        //        ImprintImage_IL1_T6 = manager.GetProperty("ImprintImage_IL1_T6").StringValue,
        //        //        PriceClass_IL1_T6 = manager.GetProperty("PriceClass_IL1_T6").StringValue,
        //        //        PriceClass_IL1_CN6 = manager.GetProperty("PriceClass_IL1_CN6").StringValue,
        //        //        SetupFee_IL1_T6 = manager.GetProperty("SetupFee_IL1_T6").DoubleValue,
        //        //        SetupFee_IL1_NextColor6 = manager.GetProperty("SetupFee_IL1_T6_NextColor").DoubleValue,
        //        //        SetupFeeStructure6 = manager.GetProperty("SetupFeeStructure_IL1_T6").StringValue,
        //        //        ExcludeFreeSetupCosts6 = manager.GetProperty("ExcludeFreeSetupCosts_IL1_T6").StringValue,
        //        //        ImprintSize_IL1_T6 = manager.GetProperty("ImprintSize_IL1_T6").StringValue,
        //        //        MaxColors_IL1_T6 = manager.GetProperty("MaxColors_IL1_T6").DoubleValue,
        //        //        Handling_IL1_T6 = manager.GetProperty("Handling_IL1_T6").StringValue,

        //        //        IntraCode = manager.GetProperty("IntraCode").StringValue,
        //        //        CountryOfOrigin = manager.GetProperty("CountryOfOrigin").StringValue,
        //        //        OuterCartonPieces = manager.GetProperty("OuterCartonPieces").DoubleValue,
        //        //        OuterCartonLength = manager.GetProperty("OuterCartonLength").DoubleValue,
        //        //        OuterCartonWidth = manager.GetProperty("OuterCartonWidth").DoubleValue,
        //        //        OuterCartonHeight = manager.GetProperty("OuterCartonHeight").DoubleValue,
        //        //        CommercialItemHeight = manager.GetProperty("CommercialItemHeight").DoubleValue,
        //        //        CommercialItemLength = manager.GetProperty("CommercialItemLength").DoubleValue,
        //        //        CommercialItemWeight = manager.GetProperty("CommercialItemWeight").DoubleValue,
        //        //        CommercialItemWidth = manager.GetProperty("CommercialItemWidth").DoubleValue,
        //        //        Flavours = manager.GetProperty("Flavours").StringValue,
        //        //        Sizes = manager.GetProperty("Sizes").StringValue,
        //        //        WritingColor = manager.GetProperty("WritingColor").StringValue,
        //        //        CapacityTxt = manager.GetProperty("CapacityTxt").StringValue,
        //        //        OrderUnit = manager.GetProperty("OrderUnit").StringValue,
        //        //        MainGroup = manager.GetProperty("MainGroup").StringValue,
        //        //        Material = manager.GetProperty("Material").StringValue,
        //        //        BatteryType = manager.GetProperty("BatteryType").StringValue,
        //        //        NumberOfBatteries = manager.GetProperty("NumberOfBatteries").IntValue,
        //        //        ProductImageURL = manager.GetProperty("ProductImageURL").StringValue,
        //        //        DeliveryTimeMT_IL1_T1 = manager.GetProperty("DeliveryTimeMT_IL1_T1").StringValue,
        //        //        Q4_Q_OnPallet = manager.GetProperty("Q_OnPallet").StringValue
        //        //    };

        //        //    _clipperProductsService.InsertProduct(customProduct);

        //        //    endRow++;
        //        //}
        //    }
        //}
    }
}
