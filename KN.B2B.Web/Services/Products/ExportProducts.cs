using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Model.products.B2BPrintPositions;
using KN.B2B.Model.products.productPrice;
using KN.B2B.Model.SupplierTables.MidoceanAPI.printInfo;
using KN.B2B.Model.SupplierTables.MidoceanAPI.Products;
using KN.B2B.Model.SystemTables;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KN.B2B.Web.Services.Products
{
    public class ExportProducts
    {
        //private readonly B2BDbContext _db;

        //public IEnumerable<B2BParrentProducts> parrentProductsList { get; set; }
        //public IEnumerable<B2BProduct> childProducts { get; set; }
        //public IEnumerable<B2BProductPrices> productPriceList { get; set; }
        //public List<B2BPriceScaling> priceScalingList { get; set; }

        //public IEnumerable<SupplierPrintCost> supplierPrintCostLists { get; set; }
        //public IEnumerable<SupplierPrintPrice> SupplierPrintPricesLists { get; set; }
        //public IEnumerable<SupplierPrintPriceScales> SupplierPrintPriceScalesLists { get; set; }
        //public IEnumerable<B2BPrintTechnique> techniqueList { get; set; }
        //public IEnumerable<B2BPrintPosition> printPositionList { get; set; }

        public ExportProducts()
        {
            //_db = db;
        }

        //public void excelInsertPrintPrices(string printCode, VarCost costObj, string setupPrice)
        //{
        //    string filePath = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss") + "-" + "printCodes" + ".csv";
        //    try
        //    {
        //        using (StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("iso-8859-1")))
        //        {
        //            //file.WriteLine("print_code;q1;q2;q3;q4;q5;q6;next1;next2;next3;next4;next5;next6");
        //            file.WriteLine($"------------PRINTCODE :{printCode + "-" + costObj.range_id}--------------");

        //            for (int i = 0; costObj.scales.Count > i; i++)
        //            {
        //                //if(costObj.)
        //                file.WriteLine($"#_{i}:;" + "MN" + printCode + ";" + "Quantity: ;" + costObj.scales[i].minimum_quantity + ";" + "price:;" + costObj.scales[i].price + ";" + "Next price: ;" + costObj.scales[i].next_price + ";" + "Setup Price :;" + setupPrice + ";" + "area_from: ;" + costObj.area_from + ";" + "area_to: ;" + costObj.area_to + ";");
        //            }
        //            file.WriteLine("---------------------END------------------------;");
        //            file.WriteLine(":");



        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("This program did an oopsie :", ex);
        //    }
        //}

        //// ==== FETCH MN PRODUCTS AND EXPORT TO EXCEL ====
        //public void fetchMNCategoryAndExport()
        //{
        //    HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language=da"));
        //    HttpWebRequest WebReqEN = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language=en"));
        //    HttpWebRequest WebReqFI = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language=fi"));

        //    WebReqDk.Method = "GET";
        //    WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
        //    HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

        //    WebReqEN.Method = "GET";
        //    WebReqEN.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
        //    HttpWebResponse WebRespEN = (HttpWebResponse)WebReqEN.GetResponse();

        //    WebReqFI.Method = "GET";
        //    WebReqFI.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
        //    HttpWebResponse WebRespFI = (HttpWebResponse)WebReqFI.GetResponse();

        //    string jsonStringDk;
        //    using (Stream stream = WebRespDk.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

        //        jsonStringDk = reader.ReadToEnd();
        //    }

        //    string jsonStringEN;
        //    using (Stream stream = WebRespEN.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

        //        jsonStringEN = reader.ReadToEnd();
        //    }

        //    string jsonStringFI;
        //    using (Stream stream = WebRespFI.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

        //        jsonStringFI = reader.ReadToEnd();
        //    }

        //    List<MNRootObj> resultDK = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringDk);
        //    List<MNRootObj> resultEN = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringEN);
        //    List<MNRootObj> resultFI = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringFI);

        //    List<string> categoryListLevel1DK = new List<string>();
        //    List<string> categoryListLevel2DK = new List<string>();
        //    List<string> categoryListLevel3DK = new List<string>();
        //    List<string> master_colorDK = new List<string>();

        //    List<string> categoryListLevel1FI = new List<string>();
        //    List<string> categoryListLevel2FI = new List<string>();
        //    List<string> categoryListLevel3FI = new List<string>();
        //    List<string> master_colorFI = new List<string>();

        //    List<string> categoryListLevel1EN = new List<string>();
        //    List<string> categoryListLevel2EN = new List<string>();
        //    List<string> categoryListLevel3EN = new List<string>();
        //    List<string> master_colorEN = new List<string>();

        //    foreach (MNRootObj product in resultDK)
        //    {
        //        foreach (Variant childProduct in product.variants)
        //        {
        //            categoryListLevel1DK.Add(childProduct.category_level1);
        //            categoryListLevel2DK.Add(childProduct.category_level2);
        //            categoryListLevel3DK.Add(childProduct.category_level3);
        //            master_colorDK.Add(childProduct.color_group);
        //        }
        //    }

        //    foreach (MNRootObj product in resultEN)
        //    {
        //        foreach (Variant childProduct in product.variants)
        //        {
        //            categoryListLevel1EN.Add(childProduct.category_level1);
        //            categoryListLevel2EN.Add(childProduct.category_level2);
        //            categoryListLevel3EN.Add(childProduct.category_level3);
        //            master_colorEN.Add(childProduct.color_group);
        //        }
        //    }

        //    foreach (MNRootObj product in resultFI)
        //    {
        //        foreach (Variant childProduct in product.variants)
        //        {
        //            categoryListLevel1FI.Add(childProduct.category_level1);
        //            categoryListLevel2FI.Add(childProduct.category_level2);
        //            categoryListLevel3FI.Add(childProduct.category_level3);
        //            master_colorFI.Add(childProduct.color_group);
        //        }
        //    }

        //    //List<string> categoryListLevel1SortedDK = categoryListLevel1DK.Distinct().ToList();
        //    //List<string> categoryListLevel2SortedDK = categoryListLevel2DK.Distinct().ToList();
        //    //List<string> categoryListLevel3SortedDK = categoryListLevel3DK.Distinct().ToList();
        //    //List<string> master_colorSortedDK = master_colorDK.Distinct().ToList();

        //    //List<string> categoryListLevel1SortedFI = categoryListLevel1FI.Distinct().ToList();
        //    //List<string> categoryListLevel2SortedFI = categoryListLevel2FI.Distinct().ToList();
        //    //List<string> categoryListLevel3SortedFI = categoryListLevel3FI.Distinct().ToList();
        //    //List<string> master_colorSortedFI = master_colorFI.Distinct().ToList();

        //    //List<string> categoryListLevel1SortedEN = categoryListLevel1EN.Distinct().ToList();
        //    //List<string> categoryListLevel2SortedEN = categoryListLevel2EN.Distinct().ToList();
        //    //List<string> categoryListLevel3SortedEN = categoryListLevel3EN.Distinct().ToList();
        //    //List<string> master_colorSortedEN = master_colorEN.Distinct().ToList();


        //    //patchToExcel(categoryListLevel1SortedDK, categoryListLevel2SortedDK, categoryListLevel3SortedDK, master_colorSortedDK, "DANISH");
        //    //patchToExcel(categoryListLevel1SortedEN, categoryListLevel2SortedEN, categoryListLevel3SortedEN, master_colorSortedEN, "ENGLISH");
        //    //patchToExcel(categoryListLevel1SortedFI, categoryListLevel2SortedFI, categoryListLevel3SortedFI, master_colorSortedFI, "FINNISH");
        //}
        //public void patchProdDesc(List<B2BParrentProducts> product, string country)
        //{
        //    string filePath = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss") + "_" + "ProductInformation" + "-" + country + ".csv";
        //    try
        //    {

        //        using (StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("iso-8859-1")))
        //        {
        //            file.WriteLine("Country;productName;shortDesc;longDesc;");

        //            for (int i = 0; product.Count() > i; i++)
        //            {
        //                file.WriteLine(country + ";" + product[i].parrentProduct_productName + ";" + product[i].parrentProduct_shortDescription + "," + product[i].parrentProduct_longDescription + ",");

        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("This program did an oopsie :", ex);
        //    }
        //}

        //public void patchToExcel(List<string> categoryLevel1, List<string> categoryLevel2, List<string> categoryLevel3, List<string> master_color, string country)
        //{

        //    string filePath = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss") + "-" + country + ".csv";
        //    try
        //    {

        //        using (StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("iso-8859-1")))
        //        {
        //            file.WriteLine("Country;Category_Level1_MN;Category1_Translated_B2B;");

        //            for (int i = 0; categoryLevel1.Count() > i; i++)
        //            {
        //                file.WriteLine(country + ";" + categoryLevel1[i]);

        //            }
        //            file.WriteLine(";");
        //            file.WriteLine(";");
        //            file.WriteLine("Country;Category_Level2_MN;Category2_Translated_B2B;");
        //            for (int i = 0; categoryLevel2.Count() > i; i++)
        //            {
        //                file.WriteLine(country + ";" + categoryLevel2[i]);

        //            }

        //            file.WriteLine(";");
        //            file.WriteLine(";");
        //            file.WriteLine("Country;Category_Level3_MN;Category3_Translated_B2B;");
        //            for (int i = 0; categoryLevel3.Count() > i; i++)
        //            {
        //                file.WriteLine(country + ";" + categoryLevel3[i]);

        //            }

        //        }

        //        using (StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("iso-8859-1")))
        //        {
        //            file.WriteLine(";");
        //            file.WriteLine(";");
        //            file.WriteLine(";");
        //            file.WriteLine("Country;Master_Color_MN;Master_color_B2B");

        //            for (int i = 0; master_color.Count() > i; i++)
        //            {
        //                if (master_color[i] != null)
        //                {
        //                    file.WriteLine(country + ";" + master_color[i] + ";;");
        //                }
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("This program did an oopsie :", ex);
        //    }
        //}

        //public async Task patchProduct()
        //{
        //    string country = "dk";
        //    string filePath = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss") + "_" + "Products" + "-" + country + ".csv";
        //    try
        //    {

        //        childProducts = await LoadCollections.LoadAllProducts(_db);

        //        //childProducts = await _db.B2BProdducts
        //        //    //.Include(x => x.parrentProduct_productName)
        //        //    //.Include(x => x.parrentProduct_shortDescription)
        //        //    .OrderByDescending(x => x.product_id)
        //        //    .ToListAsync();

        //        parrentProductsList = await LoadCollections.LoadAllParrentProducts(_db);
        //        //parrentProductsList = await _db.B2BParrentProducts
        //        //.OrderByDescending(x => x.parrentProduct_id)
        //        //.ToListAsync();

        //        productPriceList = await LoadCollections.LoadAllProductPrices(_db);

        //        //productPriceList = await _db.B2BProductPrices
        //        //.OrderByDescending(x => x.id)
        //        //.ToListAsync();

        //        priceScalingList = await LoadCollections.LoadAllPriceScales(_db);

        //        //priceScalingList = await _db.B2BPriceScaling
        //        //.OrderByDescending(x => x.scale_id)
        //        //.ToListAsync();


        //        techniqueList = await LoadCollections.LoadAllPrintTechniques(_db);


        //        //techniqueList = await _db.B2BPrintTechniques
        //        //.OrderByDescending(x => x.technique_id)
        //        //.ToListAsync();

        //        printPositionList = await LoadCollections.LoadAllPrintPositions(_db);

        //        //printPositionList = await _db.B2BPrintPositions
        //        //.OrderByDescending(x => x.Id)
        //        //.ToListAsync();


        //        supplierPrintCostLists = await LoadCollections.LoadAllSupplierPrintCosts(_db);
        //        //supplierPrintCostLists = await _db.SupplierPrintCosts
        //        //    .OrderByDescending(x => x.printCost_id)
        //        //    .ToListAsync();


        //        SupplierPrintPricesLists = await LoadCollections.LoadAllSupplierPrintPrices(_db);

        //        //SupplierPrintPricesLists = await _db.SupplierPrintPrices
        //        //    .OrderByDescending(x => x.printPrice_id)
        //        //    .ToListAsync();

        //        SupplierPrintPriceScalesLists = await LoadCollections.LoadAllSupplierPrintPriceScales(_db);

        //        //SupplierPrintPriceScalesLists = await _db.SupplierPrintPriceScales
        //        //    .OrderByDescending(x => x.scale_id)
        //        //    .ToListAsync();


        //        //var ammount = Enumerable.Repeat(new { q = "", p = "" }, 0).ToList();

        //        var list = Enumerable.Repeat(new { ParentSKU = "", ColorName = "", InternetName = "", InternetTxt = "" }, 0).ToList();
        //        foreach (var oneProduct in parrentProductsList)
        //        {
        //            list.Add(new
        //            {
        //                ParentSKU = oneProduct.parrentProduct_parrentSku,
        //                ColorName = "color",
        //                InternetName = oneProduct.parrentProduct_shortDescription,
        //                InternetTxt = oneProduct.parrentProduct_longDescription
        //            });

        //        }

        //        //Console.WriteLine(list);

        //        using (StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("iso-8859-1")))
        //        {
        //            file.WriteLine($"Parrent Sku;SKU;Name;Long description;Staggers;Q1;Q2;Q3;Q4;Q5;Q6;P1;P2;P3;P4;P5;P6;");
        //            //file.WriteLine("parentSku ; SKU ; ColorName ; InternetName ;  InternetTxt ;  Q1 ;  + Q2 ; Q3 ; Q4 ; Q5 ; Q6 ; P1 ; P2 ; P3 ; P4 ; P5 ; P6 ; GrossNett ; ImprintType_IL1_T1 ; ImprintDescription_IL1_T1 ; ImprintImage_IL1_T1 ; PriceClass_IL1_T1 ; PriceClass_IL1_CN ; SetupFee_IL1_T1 ; SetupFee_IL1_T1_NextColor ; SetupFeeStructure_IL1_T1 ; ExcludeFreeSetupCosts_IL1_T1 ; ImprintSize_IL1_T1 ; MaxColors_IL1_T1 ; Handling_IL1_T1 ; ImprintType_IL1_T2 ; ImprintDescription_IL1_T2 ; ImprintImage_IL1_T2 ; PriceClass_IL1_T2 ; PriceClass_IL1_CN2 ; SetupFee_IL1_T2 ; SetupFee_IL1_T2_NextColor ; SetupFeeStructure_IL1_T2 ; ExcludeFreeSetupCosts_IL1_T2 ; ImprintSize_IL1_T2 ; MaxColors_IL1_T2 ; Handling_IL1_T2 ; ImprintType_IL1_T3 ; ImprintDescription_IL1_T3 ; ImprintImage_IL1_T3 ; PriceClass_IL1_T3 ; PriceClass_IL1_CN3 ; SetupFee_IL1_T3 ; SetupFee_IL1_T3_NextColor ; SetupFeeStructure_IL1_T3 ; ExcludeFreeSetupCosts_IL1_T3 ; ImprintSize_IL1_T3 ; MaxColors_IL1_T3 ; Handling_IL1_T3 ; ImprintType_IL1_T4 ; ImprintDescription_IL1_T4 ; ImprintImage_IL1_T4 ; PriceClass_IL1_T4 ; PriceClass_IL1_CN4 ; SetupFee_IL1_T4 ; SetupFee_IL1_T4_NextColor ; SetupFeeStructure_IL1_T4 ; ExcludeFreeSetupCosts_IL1_T4 ; ImprintSize_IL1_T4 ; MaxColors_IL1_T4 ; Handling_IL1_T4 ; ImprintType_IL1_T5 ; ImprintDescription_IL1_T5 ; ImprintImage_IL1_T5 ; PriceClass_IL1_T5 ; PriceClass_IL1_CN5 ; SetupFee_IL1_T5 ; SetupFee_IL1_T5_NextColor ; SetupFeeStructure_IL1_T5 ; ExcludeFreeSetupCosts_IL1_T5 ; ImprintSize_IL1_T5 ; MaxColors_IL1_T5 ; Handling_IL1_T5 ; ImprintType_IL1_T6 ; ImprintDescription_IL1_T6 ; ImprintImage_IL1_T6 ; PriceClass_IL1_T6 ; PriceClass_IL1_CN6 ; SetupFee_IL1_T6 ; SetupFee_IL1_T6_NextColor ; SetupFeeStructure_IL1_T6 ; ExcludeFreeSetupCosts_IL1_T6 ; ImprintSize_IL1_T6 ; MaxColors_IL1_T6 ; Handling_IL1_T6 ; IntraCode ; CountryOfOrigin ; OuterCartonPieces ; OuterCartonLength ; OuterCartonWidth ; OuterCartonLength ; CommercialItemLength ; CommercialItemWidth ; CommercialItemHeight ; CommercialItemWeight ; Flavours ; Sizes ; WritingColor ; CapacityTxt ; OrderUnit ; MainGroup ; Material ; BatteryType ; NumberOfBatteries ; ProductImageURL ; DeliveryTimeMT_IL1_T1 ; SearchTerms ; Q_OnPallet ; Brandnames");
        //            string parentSku = "";
        //            string SKU = "";
        //            string ColorName = "";
        //            string InternetName = "";
        //            string InternetTxt = "";
        //            string Q1 = "";
        //            string Q2 = "";
        //            string Q3 = "";
        //            string Q4 = "";
        //            string Q5 = "";
        //            string Q6 = "";
        //            string P1 = "";
        //            string P2 = "";
        //            string P3 = "";
        //            string P4 = "";
        //            string P5 = "";
        //            string P6 = "";
        //            string GrossNett = "";
        //            string ImprintType_IL1_T1 = "";
        //            string ImprintDescription_IL1_T1 = "";
        //            string ImprintImage_IL1_T1 = "";
        //            string PriceClass_IL1_T1 = "";
        //            string PriceClass_IL1_CN = "";
        //            string SetupFee_IL1_T1 = "";
        //            string SetupFee_IL1_T1_NextColor = "";
        //            string SetupFeeStructure_IL1_T1 = "";
        //            string ExcludeFreeSetupCosts_IL1_T1 = "";
        //            string ImprintSize_IL1_T1 = "";
        //            string MaxColors_IL1_T1 = "";
        //            string Handling_IL1_T1 = "";
        //            string ImprintType_IL1_T2 = "";
        //            string ImprintDescription_IL1_T2 = "";
        //            string ImprintImage_IL1_T2 = "";
        //            string PriceClass_IL1_T2 = "";
        //            string PriceClass_IL1_CN2 = "";
        //            string SetupFee_IL1_T2 = "";
        //            string SetupFee_IL1_T2_NextColor = "";
        //            string SetupFeeStructure_IL1_T2 = "";
        //            string ExcludeFreeSetupCosts_IL1_T2 = "";
        //            string ImprintSize_IL1_T2 = "";
        //            string MaxColors_IL1_T2 = "";
        //            string Handling_IL1_T2 = "";
        //            string ImprintType_IL1_T3 = "";
        //            string ImprintDescription_IL1_T3 = "";
        //            string ImprintImage_IL1_T3 = "";
        //            string PriceClass_IL1_T3 = "";
        //            string PriceClass_IL1_CN3 = "";
        //            string SetupFee_IL1_T3 = "";
        //            string SetupFee_IL1_T3_NextColor = "";
        //            string SetupFeeStructure_IL1_T3 = "";
        //            string ExcludeFreeSetupCosts_IL1_T3 = "";
        //            string ImprintSize_IL1_T3 = "";
        //            string MaxColors_IL1_T3 = "";
        //            string Handling_IL1_T3 = "";
        //            string ImprintType_IL1_T4 = "";
        //            string ImprintDescription_IL1_T4 = "";
        //            string ImprintImage_IL1_T4 = "";
        //            string PriceClass_IL1_T4 = "";
        //            string PriceClass_IL1_CN4 = "";
        //            string SetupFee_IL1_T4 = "";
        //            string SetupFee_IL1_T4_NextColor = "";
        //            string SetupFeeStructure_IL1_T4 = "";
        //            string ExcludeFreeSetupCosts_IL1_T4 = "";
        //            string ImprintSize_IL1_T4 = "";
        //            string MaxColors_IL1_T4 = "";
        //            string Handling_IL1_T4 = "";
        //            string ImprintType_IL1_T5 = "";
        //            string ImprintDescription_IL1_T5 = "";
        //            string ImprintImage_IL1_T5 = "";
        //            string PriceClass_IL1_T5 = "";
        //            string PriceClass_IL1_CN5 = "";
        //            string SetupFee_IL1_T5 = "";
        //            string SetupFee_IL1_T5_NextColor = "";
        //            string SetupFeeStructure_IL1_T5 = "";
        //            string ExcludeFreeSetupCosts_IL1_T5 = "";
        //            string ImprintSize_IL1_T5 = "";
        //            string MaxColors_IL1_T5 = "";
        //            string Handling_IL1_T5 = "";
        //            string ImprintType_IL1_T6 = "";
        //            string ImprintDescription_IL1_T6 = "";
        //            string ImprintImage_IL1_T6 = "";
        //            string PriceClass_IL1_T6 = "";
        //            string PriceClass_IL1_CN6 = "";
        //            string SetupFee_IL1_T6 = "";
        //            string SetupFee_IL1_T6_NextColor = "";
        //            string SetupFeeStructure_IL1_T6 = "";
        //            string ExcludeFreeSetupCosts_IL1_T6 = "";
        //            string ImprintSize_IL1_T6 = "";
        //            string MaxColors_IL1_T6 = "";
        //            string Handling_IL1_T6 = "";
        //            string IntraCode = "";
        //            string CountryOfOrigin = "";
        //            string OuterCartonPieces = "";
        //            string OuterCartonLength = "";
        //            string OuterCartonWidth = "";
        //            string OuterCartonHeight = "";
        //            string CommercialItemLength = "";
        //            string CommercialItemWidth = "";
        //            string CommercialItemHeight = "";
        //            string CommercialItemWeight = "";
        //            string Flavours = "";
        //            string Sizes = "";
        //            string WritingColor = "";
        //            string CapacityTxt = "";
        //            string OrderUnit = "";
        //            string MainGroup = "";
        //            string Material = "";
        //            string BatteryType = "";
        //            string NumberOfBatteries = "";
        //            string ProductImageURL = "";
        //            string DeliveryTimeMT_IL1_T1 = "";
        //            string SearchTerms = "";
        //            string Q_OnPallet = "";
        //            string Brandnames = "";
        //            //file.WriteLine(parentSku + ";" + SKU + ";" + ColorName + ";" + InternetName + ";" + InternetTxt + ";" + Q1 + ";" + Q2 + ";" + Q3 + ";" + Q4 + ";" + Q5 + ";" + Q6 + ";" + P1 + ";" + P2 + ";" + P3 + ";" + P4 + ";" + P5 + ";" + P6 + ";" + GrossNett + ";" + ImprintType_IL1_T1 + ";" + ImprintDescription_IL1_T1 + ";" + ImprintImage_IL1_T1 + ";" + PriceClass_IL1_T1 + ";" + PriceClass_IL1_CN + ";" + SetupFee_IL1_T1 + ";" + SetupFee_IL1_T1_NextColor + ";" + SetupFeeStructure_IL1_T1 + ";" + ExcludeFreeSetupCosts_IL1_T1 + ";" + ImprintSize_IL1_T1 + ";" + MaxColors_IL1_T1 + ";" + Handling_IL1_T1 + ";" + ImprintType_IL1_T2 + ";" + ImprintDescription_IL1_T2 + ";" + ImprintImage_IL1_T2 + ";" + PriceClass_IL1_T2 + ";" + PriceClass_IL1_CN2 + ";" + SetupFee_IL1_T2 + ";" + SetupFee_IL1_T2_NextColor + ";" + SetupFeeStructure_IL1_T2 + ";" + ExcludeFreeSetupCosts_IL1_T2 + ";" + ImprintSize_IL1_T2 + ";" + MaxColors_IL1_T2 + ";" + Handling_IL1_T2 + ";" + ImprintType_IL1_T3 + ";" + ImprintDescription_IL1_T3 + ";" + ImprintImage_IL1_T3 + ";" + PriceClass_IL1_T3 + ";" + PriceClass_IL1_CN3 + ";" + SetupFee_IL1_T3 + ";" + SetupFee_IL1_T3_NextColor + ";" + SetupFeeStructure_IL1_T3 + ";" + ExcludeFreeSetupCosts_IL1_T3 + ";" + ImprintSize_IL1_T3 + ";" + MaxColors_IL1_T3 + ";" + Handling_IL1_T3 + ";" + ImprintType_IL1_T4 + ";" + ImprintDescription_IL1_T4 + ";" + ImprintImage_IL1_T4 + ";" + PriceClass_IL1_T4 + ";" + PriceClass_IL1_CN4 + ";" + SetupFee_IL1_T4 + ";" + SetupFee_IL1_T4_NextColor + ";" + SetupFeeStructure_IL1_T4 + ";" + ExcludeFreeSetupCosts_IL1_T4 + ";" + ImprintSize_IL1_T4 + ";" + MaxColors_IL1_T4 + ";" + Handling_IL1_T4 + ";" + ImprintType_IL1_T5 + ";" + ImprintDescription_IL1_T5 + ";" + ImprintImage_IL1_T5 + ";" + PriceClass_IL1_T5 + ";" + PriceClass_IL1_CN5 + ";" + SetupFee_IL1_T5 + ";" + SetupFee_IL1_T5_NextColor + ";" + SetupFeeStructure_IL1_T5 + ";" + ExcludeFreeSetupCosts_IL1_T5 + ";" + ImprintSize_IL1_T5 + ";" + MaxColors_IL1_T5 + ";" + Handling_IL1_T5 + ";" + ImprintType_IL1_T6 + ";" + ImprintDescription_IL1_T6 + ";" + ImprintImage_IL1_T6 + ";" + PriceClass_IL1_T6 + ";" + PriceClass_IL1_CN6 + ";" + SetupFee_IL1_T6 + ";" + SetupFee_IL1_T6_NextColor + ";" + SetupFeeStructure_IL1_T6 + ";" + ExcludeFreeSetupCosts_IL1_T6 + ";" + ImprintSize_IL1_T6 + ";" + MaxColors_IL1_T6 + ";" + Handling_IL1_T6 + ";" + IntraCode + ";" + CountryOfOrigin + ";" + OuterCartonPieces + ";" + OuterCartonLength + ";" + OuterCartonWidth + ";" + OuterCartonLength + ";" + CommercialItemLength + ";" + CommercialItemWidth + ";" + CommercialItemHeight + ";" + CommercialItemWeight + ";" + Flavours + ";" + Sizes + ";" + WritingColor + ";" + CapacityTxt + ";" + OrderUnit + ";" + MainGroup + ";" + Material + ";" + BatteryType + ";" + NumberOfBatteries + ";" + ProductImageURL + ";" + DeliveryTimeMT_IL1_T1 + ";" + SearchTerms + ";" + Q_OnPallet + ";" + Brandnames);

        //            foreach (var oneProduct in childProducts)
        //            {
        //                var ammount = Enumerable.Repeat(new { q = "", p = "" }, 0).ToList();
        //                parentSku = "";
        //                SKU = "";
        //                ColorName = "";
        //                InternetName = "";
        //                InternetTxt = "";
        //                Q1 = "";
        //                Q2 = "";
        //                Q3 = "";
        //                Q4 = "";
        //                Q5 = "";
        //                Q6 = "";
        //                P1 = "";
        //                P2 = "";
        //                P3 = "";
        //                P4 = "";
        //                P5 = "";
        //                P6 = "";
        //                GrossNett = "";
        //                ImprintType_IL1_T1 = "";
        //                ImprintDescription_IL1_T1 = "";
        //                ImprintImage_IL1_T1 = "";
        //                PriceClass_IL1_T1 = "";
        //                PriceClass_IL1_CN = "";
        //                SetupFee_IL1_T1 = "";
        //                SetupFee_IL1_T1_NextColor = "";
        //                SetupFeeStructure_IL1_T1 = "";
        //                ExcludeFreeSetupCosts_IL1_T1 = "";
        //                ImprintSize_IL1_T1 = "";
        //                MaxColors_IL1_T1 = "";
        //                Handling_IL1_T1 = "";
        //                ImprintType_IL1_T2 = "";
        //                ImprintDescription_IL1_T2 = "";
        //                ImprintImage_IL1_T2 = "";
        //                PriceClass_IL1_T2 = "";
        //                PriceClass_IL1_CN2 = "";
        //                SetupFee_IL1_T2 = "";
        //                SetupFee_IL1_T2_NextColor = "";
        //                SetupFeeStructure_IL1_T2 = "";
        //                ExcludeFreeSetupCosts_IL1_T2 = "";
        //                ImprintSize_IL1_T2 = "";
        //                MaxColors_IL1_T2 = "";
        //                Handling_IL1_T2 = "";
        //                ImprintType_IL1_T3 = "";
        //                ImprintDescription_IL1_T3 = "";
        //                ImprintImage_IL1_T3 = "";
        //                PriceClass_IL1_T3 = "";
        //                PriceClass_IL1_CN3 = "";
        //                SetupFee_IL1_T3 = "";
        //                SetupFee_IL1_T3_NextColor = "";
        //                SetupFeeStructure_IL1_T3 = "";
        //                ExcludeFreeSetupCosts_IL1_T3 = "";
        //                ImprintSize_IL1_T3 = "";
        //                MaxColors_IL1_T3 = "";
        //                Handling_IL1_T3 = "";
        //                ImprintType_IL1_T4 = "";
        //                ImprintDescription_IL1_T4 = "";
        //                ImprintImage_IL1_T4 = "";
        //                PriceClass_IL1_T4 = "";
        //                PriceClass_IL1_CN4 = "";
        //                SetupFee_IL1_T4 = "";
        //                SetupFee_IL1_T4_NextColor = "";
        //                SetupFeeStructure_IL1_T4 = "";
        //                ExcludeFreeSetupCosts_IL1_T4 = "";
        //                ImprintSize_IL1_T4 = "";
        //                MaxColors_IL1_T4 = "";
        //                Handling_IL1_T4 = "";
        //                ImprintType_IL1_T5 = "";
        //                ImprintDescription_IL1_T5 = "";
        //                ImprintImage_IL1_T5 = "";
        //                PriceClass_IL1_T5 = "";
        //                PriceClass_IL1_CN5 = "";
        //                SetupFee_IL1_T5 = "";
        //                SetupFee_IL1_T5_NextColor = "";
        //                SetupFeeStructure_IL1_T5 = "";
        //                ExcludeFreeSetupCosts_IL1_T5 = "";
        //                ImprintSize_IL1_T5 = "";
        //                MaxColors_IL1_T5 = "";
        //                Handling_IL1_T5 = "";
        //                ImprintType_IL1_T6 = "";
        //                ImprintDescription_IL1_T6 = "";
        //                ImprintImage_IL1_T6 = "";
        //                PriceClass_IL1_T6 = "";
        //                PriceClass_IL1_CN6 = "";
        //                SetupFee_IL1_T6 = "";
        //                SetupFee_IL1_T6_NextColor = "";
        //                SetupFeeStructure_IL1_T6 = "";
        //                ExcludeFreeSetupCosts_IL1_T6 = "";
        //                ImprintSize_IL1_T6 = "";
        //                MaxColors_IL1_T6 = "";
        //                Handling_IL1_T6 = "";
        //                IntraCode = "";
        //                CountryOfOrigin = "";
        //                OuterCartonPieces = "";
        //                OuterCartonLength = "";
        //                OuterCartonWidth = "";
        //                OuterCartonHeight = "";
        //                CommercialItemLength = "";
        //                CommercialItemWidth = "";
        //                CommercialItemHeight = "";
        //                CommercialItemWeight = "";
        //                Flavours = "";
        //                Sizes = "";
        //                WritingColor = "";
        //                CapacityTxt = "";
        //                OrderUnit = "";
        //                MainGroup = "";
        //                Material = "";
        //                BatteryType = "";
        //                NumberOfBatteries = "";
        //                ProductImageURL = "";
        //                DeliveryTimeMT_IL1_T1 = "";
        //                SearchTerms = "";
        //                Q_OnPallet = "";
        //                Brandnames = "";
        //                SKU = oneProduct.product_sku;
        //                ColorName = oneProduct.product_ColorName;

        //                //foreach (var parrentProduct in parrentProductsList)
        //                //{
        //                //    parentSku = parrentProduct.parrentProduct_parrentSku;
        //                //    InternetName = parrentProduct.parrentProduct_shortDescription;
        //                //    InternetTxt = parrentProduct.parrentProduct_longDescription;
        //                //    MainGroup = parrentProduct.parrentProduct_subCategoryDK;
        //                var tmpProductImages = await _db.B2BProductImages.Where(x => x.fk_childProduct.product_id == oneProduct.product_id).ToListAsync();

        //                foreach (var images in tmpProductImages)
        //                {
        //                    ProductImageURL += $"{images.imagePath}, ";
        //                }

        //                var tmpParrentProduct = await _db.B2BParrentProducts.FirstOrDefaultAsync(x => x.parrentProduct_id == oneProduct.fk_ParentSKU.parrentProduct_id);

        //                parentSku = tmpParrentProduct.parrentProduct_parrentSku;
        //                InternetName = tmpParrentProduct.parrentProduct_productName;
        //                InternetTxt = tmpParrentProduct.parrentProduct_longDescription;
        //                MainGroup = tmpParrentProduct.parrentProduct_subCategoryFI;

        //                //TODO => INSERT 
        //                //Material = 
        //                foreach (var price in productPriceList)
        //                {
        //                    if (price.parrentSku == oneProduct.product_sku)
        //                    {
        //                        List<B2BPriceScaling> tmpPriceScaleList = await _db.B2BPriceScaling.Where(x => x.fk_priceId == price).ToListAsync();
        //                        Console.WriteLine(tmpPriceScaleList);

        //                        if (tmpPriceScaleList.Count() == 0)
        //                        {

        //                        }

        //                        if (tmpPriceScaleList.Count() == 1)
        //                        {
        //                            Q1 = tmpPriceScaleList[0].scale_minimumQuantity.ToString();
        //                            P1 = tmpPriceScaleList[0].scale_priceDK.ToString();

        //                        }
        //                        if (tmpPriceScaleList.Count() == 2)
        //                        {
        //                            Q1 = tmpPriceScaleList[0].scale_minimumQuantity.ToString();
        //                            Q2 = tmpPriceScaleList[1].scale_minimumQuantity.ToString();

        //                            P1 = tmpPriceScaleList[0].scale_priceDK.ToString();
        //                            P2 = tmpPriceScaleList[1].scale_priceDK.ToString();
        //                        }
        //                        if (tmpPriceScaleList.Count() == 3)
        //                        {
        //                            Q1 = tmpPriceScaleList[0].scale_minimumQuantity.ToString();
        //                            Q2 = tmpPriceScaleList[1].scale_minimumQuantity.ToString();
        //                            Q3 = tmpPriceScaleList[2].scale_minimumQuantity.ToString();

        //                            P1 = tmpPriceScaleList[0].scale_priceDK.ToString();
        //                            P2 = tmpPriceScaleList[1].scale_priceDK.ToString();
        //                            P3 = tmpPriceScaleList[2].scale_priceDK.ToString();

        //                        }
        //                        if (tmpPriceScaleList.Count() == 4)
        //                        {
        //                            Q1 = tmpPriceScaleList[0].scale_minimumQuantity.ToString();
        //                            Q2 = tmpPriceScaleList[1].scale_minimumQuantity.ToString();
        //                            Q3 = tmpPriceScaleList[2].scale_minimumQuantity.ToString();
        //                            Q4 = tmpPriceScaleList[3].scale_minimumQuantity.ToString();

        //                            P1 = tmpPriceScaleList[0].scale_priceDK.ToString();
        //                            P2 = tmpPriceScaleList[1].scale_priceDK.ToString();
        //                            P3 = tmpPriceScaleList[2].scale_priceDK.ToString();
        //                            P4 = tmpPriceScaleList[3].scale_priceDK.ToString();

        //                        }
        //                        if (tmpPriceScaleList.Count() == 5)
        //                        {
        //                            Q1 = tmpPriceScaleList[0].scale_minimumQuantity.ToString();
        //                            Q2 = tmpPriceScaleList[1].scale_minimumQuantity.ToString();
        //                            Q3 = tmpPriceScaleList[2].scale_minimumQuantity.ToString();
        //                            Q4 = tmpPriceScaleList[3].scale_minimumQuantity.ToString();
        //                            Q5 = tmpPriceScaleList[4].scale_minimumQuantity.ToString();

        //                            P1 = tmpPriceScaleList[0].scale_priceDK.ToString();
        //                            P2 = tmpPriceScaleList[1].scale_priceDK.ToString();
        //                            P3 = tmpPriceScaleList[2].scale_priceDK.ToString();
        //                            P4 = tmpPriceScaleList[3].scale_priceDK.ToString();
        //                            P5 = tmpPriceScaleList[4].scale_priceDK.ToString();
        //                        }
        //                        if (tmpPriceScaleList.Count() == 6)
        //                        {
        //                            Q1 = tmpPriceScaleList[0].scale_minimumQuantity.ToString();
        //                            Q2 = tmpPriceScaleList[1].scale_minimumQuantity.ToString();
        //                            Q3 = tmpPriceScaleList[2].scale_minimumQuantity.ToString();
        //                            Q4 = tmpPriceScaleList[3].scale_minimumQuantity.ToString();
        //                            Q5 = tmpPriceScaleList[4].scale_minimumQuantity.ToString();
        //                            Q6 = tmpPriceScaleList[5].scale_minimumQuantity.ToString();

        //                            P1 = tmpPriceScaleList[0].scale_priceDK.ToString();
        //                            P2 = tmpPriceScaleList[1].scale_priceDK.ToString();
        //                            P3 = tmpPriceScaleList[2].scale_priceDK.ToString();
        //                            P4 = tmpPriceScaleList[3].scale_priceDK.ToString();
        //                            P5 = tmpPriceScaleList[4].scale_priceDK.ToString();
        //                            P6 = tmpPriceScaleList[5].scale_priceDK.ToString();
        //                        }

        //                        break;

        //                    }
        //                }
        //                var technique = Enumerable.Repeat(new { imprintType = "", imprintDesc = "", priceClass = "", setupFee = "", imprintSize = "", maxColors = "" }, 0).ToList();

        //                foreach (var printPos in printPositionList)
        //                {
        //                    if (printPos.print_productName == tmpParrentProduct.parrentProduct_parrentSku)
        //                    {



        //                        var onePrintTechnique = await _db.B2BPrintTechniques.FirstOrDefaultAsync(x => x.technique_id == printPos.fk_techniqueId.technique_id);
        //                        var onePrintPrice = await _db.SupplierPrintPrices.FirstOrDefaultAsync(x => x.printPrice_id == onePrintTechnique.fk_supplierPriceCode.printPrice_id);


        //                        string tmpImprintType = printPos.print_position;
        //                        string tmpImprintDesc = onePrintTechnique.technique_description;
        //                        string tmpPriceClass = onePrintPrice.printPrice_descId;
        //                        string tmpSetupFee = onePrintPrice.printPrice_setupEU;
        //                        string tmpImprintSize = printPos.print_height.ToString() + "x" + printPos.print_width.ToString() + " cm";
        //                        string tmpMaxColors = printPos.maxColors.ToString();

        //                        //if (printPos.print_productName == parentSku)
        //                        //{
        //                        //    foreach (var oneTechnique in techniqueList)
        //                        //    {
        //                        //        if (printPos.fk_techniqueId.technique_id == oneTechnique.technique_id)
        //                        //        {
        //                        //            tmpImprintDesc = oneTechnique.technique_description;
        //                        //            foreach (var printPrices in SupplierPrintPricesLists)
        //                        //            {
        //                        //                if (oneTechnique.technique_name == printPrices.printPrice_descId)
        //                        //                {
        //                        //                    tmpPriceClass = printPrices.printPrice_descId;
        //                        //                    tmpSetupFee = printPrices.printPrice_setupDK;
        //                        //                    break;

        //                        //                }
        //                        //            }

        //                        //        }
        //                        //    }

        //                        //}
        //                        technique.Add(new
        //                        {
        //                            imprintType = tmpImprintType,
        //                            imprintDesc = tmpImprintDesc,
        //                            priceClass = tmpPriceClass,
        //                            setupFee = tmpSetupFee,
        //                            imprintSize = tmpImprintSize,
        //                            maxColors = tmpMaxColors
        //                        });

        //                        Console.WriteLine(technique);
        //                    }
        //                }
        //                if (technique.Count() == 0)
        //                {

        //                }

        //                if (technique.Count() == 1)
        //                {
        //                    ImprintType_IL1_T1 = technique[0].imprintType;
        //                    ImprintDescription_IL1_T1 = technique[0].imprintDesc;
        //                    PriceClass_IL1_T1 = technique[0].priceClass;
        //                    SetupFee_IL1_T1 = technique[0].setupFee;
        //                    ImprintSize_IL1_T1 = technique[0].imprintSize;
        //                    MaxColors_IL1_T1 = technique[0].maxColors;

        //                }
        //                if (technique.Count() == 2)
        //                {
        //                    ImprintType_IL1_T1 = technique[0].imprintType;
        //                    ImprintDescription_IL1_T1 = technique[0].imprintDesc;
        //                    PriceClass_IL1_T1 = technique[0].priceClass;
        //                    SetupFee_IL1_T1 = technique[0].setupFee;
        //                    ImprintSize_IL1_T1 = technique[0].imprintSize;
        //                    MaxColors_IL1_T1 = technique[0].maxColors;

        //                    ImprintType_IL1_T2 = technique[1].imprintType;
        //                    ImprintDescription_IL1_T2 = technique[1].imprintDesc;
        //                    PriceClass_IL1_T2 = technique[1].priceClass;
        //                    SetupFee_IL1_T2 = technique[1].setupFee;
        //                    ImprintSize_IL1_T2 = technique[1].imprintSize;
        //                    MaxColors_IL1_T2 = technique[1].maxColors;
        //                }
        //                if (technique.Count() == 3)
        //                {
        //                    ImprintType_IL1_T1 = technique[0].imprintType;
        //                    ImprintDescription_IL1_T1 = technique[0].imprintDesc;
        //                    PriceClass_IL1_T1 = technique[0].priceClass;
        //                    SetupFee_IL1_T1 = technique[0].setupFee;
        //                    ImprintSize_IL1_T1 = technique[0].imprintSize;
        //                    MaxColors_IL1_T1 = technique[0].maxColors;

        //                    ImprintType_IL1_T2 = technique[1].imprintType;
        //                    ImprintDescription_IL1_T2 = technique[1].imprintDesc;
        //                    PriceClass_IL1_T2 = technique[1].priceClass;
        //                    SetupFee_IL1_T2 = technique[1].setupFee;
        //                    ImprintSize_IL1_T2 = technique[1].imprintSize;
        //                    MaxColors_IL1_T2 = technique[1].maxColors;

        //                    ImprintType_IL1_T3 = technique[2].imprintType;
        //                    ImprintDescription_IL1_T3 = technique[2].imprintDesc;
        //                    PriceClass_IL1_T3 = technique[2].priceClass;
        //                    SetupFee_IL1_T3 = technique[2].setupFee;
        //                    ImprintSize_IL1_T3 = technique[2].imprintSize;
        //                    MaxColors_IL1_T3 = technique[2].maxColors;

        //                }
        //                if (technique.Count() == 4)
        //                {
        //                    ImprintType_IL1_T1 = technique[0].imprintType;
        //                    ImprintDescription_IL1_T1 = technique[0].imprintDesc;
        //                    PriceClass_IL1_T1 = technique[0].priceClass;
        //                    SetupFee_IL1_T1 = technique[0].setupFee;
        //                    ImprintSize_IL1_T1 = technique[0].imprintSize;
        //                    MaxColors_IL1_T1 = technique[0].maxColors;

        //                    ImprintType_IL1_T2 = technique[1].imprintType;
        //                    ImprintDescription_IL1_T2 = technique[1].imprintDesc;
        //                    PriceClass_IL1_T2 = technique[1].priceClass;
        //                    SetupFee_IL1_T2 = technique[1].setupFee;
        //                    ImprintSize_IL1_T2 = technique[1].imprintSize;
        //                    MaxColors_IL1_T2 = technique[1].maxColors;

        //                    ImprintType_IL1_T3 = technique[2].imprintType;
        //                    ImprintDescription_IL1_T3 = technique[2].imprintDesc;
        //                    PriceClass_IL1_T3 = technique[2].priceClass;
        //                    SetupFee_IL1_T3 = technique[2].setupFee;
        //                    ImprintSize_IL1_T3 = technique[2].imprintSize;
        //                    MaxColors_IL1_T3 = technique[2].maxColors;

        //                    ImprintType_IL1_T4 = technique[3].imprintType;
        //                    ImprintDescription_IL1_T4 = technique[3].imprintDesc;
        //                    PriceClass_IL1_T4 = technique[3].priceClass;
        //                    SetupFee_IL1_T4 = technique[3].setupFee;
        //                    ImprintSize_IL1_T4 = technique[3].imprintSize;
        //                    MaxColors_IL1_T4 = technique[3].maxColors;

        //                }
        //                if (technique.Count() == 5)
        //                {
        //                    ImprintType_IL1_T1 = technique[0].imprintType;
        //                    ImprintDescription_IL1_T1 = technique[0].imprintDesc;
        //                    PriceClass_IL1_T1 = technique[0].priceClass;
        //                    SetupFee_IL1_T1 = technique[0].setupFee;
        //                    ImprintSize_IL1_T1 = technique[0].imprintSize;
        //                    MaxColors_IL1_T1 = technique[0].maxColors;

        //                    ImprintType_IL1_T2 = technique[1].imprintType;
        //                    ImprintDescription_IL1_T2 = technique[1].imprintDesc;
        //                    PriceClass_IL1_T2 = technique[1].priceClass;
        //                    SetupFee_IL1_T2 = technique[1].setupFee;
        //                    ImprintSize_IL1_T2 = technique[1].imprintSize;
        //                    MaxColors_IL1_T2 = technique[1].maxColors;

        //                    ImprintType_IL1_T3 = technique[2].imprintType;
        //                    ImprintDescription_IL1_T3 = technique[2].imprintDesc;
        //                    PriceClass_IL1_T3 = technique[2].priceClass;
        //                    SetupFee_IL1_T3 = technique[2].setupFee;
        //                    ImprintSize_IL1_T3 = technique[2].imprintSize;
        //                    MaxColors_IL1_T3 = technique[2].maxColors;

        //                    ImprintType_IL1_T4 = technique[3].imprintType;
        //                    ImprintDescription_IL1_T4 = technique[3].imprintDesc;
        //                    PriceClass_IL1_T4 = technique[3].priceClass;
        //                    SetupFee_IL1_T4 = technique[3].setupFee;
        //                    ImprintSize_IL1_T4 = technique[3].imprintSize;
        //                    MaxColors_IL1_T4 = technique[3].maxColors;

        //                    ImprintType_IL1_T5 = technique[4].imprintType;
        //                    ImprintDescription_IL1_T5 = technique[4].imprintDesc;
        //                    PriceClass_IL1_T5 = technique[4].priceClass;
        //                    SetupFee_IL1_T5 = technique[4].setupFee;
        //                    ImprintSize_IL1_T5 = technique[4].imprintSize;
        //                    MaxColors_IL1_T5 = technique[4].maxColors;
        //                }
        //                if (technique.Count() == 6)
        //                {
        //                    ImprintType_IL1_T1 = technique[0].imprintType;
        //                    ImprintDescription_IL1_T1 = technique[0].imprintDesc;
        //                    PriceClass_IL1_T1 = technique[0].priceClass;
        //                    SetupFee_IL1_T1 = technique[0].setupFee;
        //                    ImprintSize_IL1_T1 = technique[0].imprintSize;
        //                    MaxColors_IL1_T1 = technique[0].maxColors;

        //                    ImprintType_IL1_T2 = technique[1].imprintType;
        //                    ImprintDescription_IL1_T2 = technique[1].imprintDesc;
        //                    PriceClass_IL1_T2 = technique[1].priceClass;
        //                    SetupFee_IL1_T2 = technique[1].setupFee;
        //                    ImprintSize_IL1_T2 = technique[1].imprintSize;
        //                    MaxColors_IL1_T2 = technique[1].maxColors;

        //                    ImprintType_IL1_T3 = technique[2].imprintType;
        //                    ImprintDescription_IL1_T3 = technique[2].imprintDesc;
        //                    PriceClass_IL1_T3 = technique[2].priceClass;
        //                    SetupFee_IL1_T3 = technique[2].setupFee;
        //                    ImprintSize_IL1_T3 = technique[2].imprintSize;
        //                    MaxColors_IL1_T3 = technique[2].maxColors;

        //                    ImprintType_IL1_T4 = technique[3].imprintType;
        //                    ImprintDescription_IL1_T4 = technique[3].imprintDesc;
        //                    PriceClass_IL1_T4 = technique[3].priceClass;
        //                    SetupFee_IL1_T4 = technique[3].setupFee;
        //                    ImprintSize_IL1_T4 = technique[3].imprintSize;
        //                    MaxColors_IL1_T4 = technique[3].maxColors;

        //                    ImprintType_IL1_T5 = technique[4].imprintType;
        //                    ImprintDescription_IL1_T5 = technique[4].imprintDesc;
        //                    PriceClass_IL1_T5 = technique[4].priceClass;
        //                    SetupFee_IL1_T5 = technique[4].setupFee;
        //                    ImprintSize_IL1_T5 = technique[4].imprintSize;
        //                    MaxColors_IL1_T5 = technique[4].maxColors;

        //                    ImprintType_IL1_T6 = technique[5].imprintType;
        //                    ImprintDescription_IL1_T6 = technique[5].imprintDesc;
        //                    PriceClass_IL1_T6 = technique[5].priceClass;
        //                    SetupFee_IL1_T6 = technique[5].setupFee;
        //                    ImprintSize_IL1_T6 = technique[5].imprintSize;
        //                    MaxColors_IL1_T6 = technique[0].maxColors;
        //                }
        //                //foreach (var tech in technique)
        //                //{
        //                //    Console.WriteLine(tech);
        //                //}
        //                Console.WriteLine(technique);
        //                //file.WriteLine(parentSku + ";" + SKU + ";" + ColorName + ";" + InternetName + ";" + InternetTxt + ";" + Q1 + ";" + Q2 + ";" + Q3 + ";" + Q4 + ";" + Q5 + ";" + Q6 + ";" + P1 + ";" + P2 + ";" + P3 + ";" + P4 + ";" + P5 + ";" + P6 + ";" + GrossNett + ";" + ImprintType_IL1_T1 + ";" + ImprintDescription_IL1_T1 + ";" + ImprintImage_IL1_T1 + ";" + PriceClass_IL1_T1 + ";" + PriceClass_IL1_CN + ";" + SetupFee_IL1_T1 + ";" + SetupFee_IL1_T1_NextColor + ";" + SetupFeeStructure_IL1_T1 + ";" + ExcludeFreeSetupCosts_IL1_T1 + ";" + ImprintSize_IL1_T1 + ";" + MaxColors_IL1_T1 + ";" + Handling_IL1_T1 + ";" + ImprintType_IL1_T2 + ";" + ImprintDescription_IL1_T2 + ";" + ImprintImage_IL1_T2 + ";" + PriceClass_IL1_T2 + ";" + PriceClass_IL1_CN2 + ";" + SetupFee_IL1_T2 + ";" + SetupFee_IL1_T2_NextColor + ";" + SetupFeeStructure_IL1_T2 + ";" + ExcludeFreeSetupCosts_IL1_T2 + ";" + ImprintSize_IL1_T2 + ";" + MaxColors_IL1_T2 + ";" + Handling_IL1_T2 + ";" + ImprintType_IL1_T3 + ";" + ImprintDescription_IL1_T3 + ";" + ImprintImage_IL1_T3 + ";" + PriceClass_IL1_T3 + ";" + PriceClass_IL1_CN3 + ";" + SetupFee_IL1_T3 + ";" + SetupFee_IL1_T3_NextColor + ";" + SetupFeeStructure_IL1_T3 + ";" + ExcludeFreeSetupCosts_IL1_T3 + ";" + ImprintSize_IL1_T3 + ";" + MaxColors_IL1_T3 + ";" + Handling_IL1_T3 + ";" + ImprintType_IL1_T4 + ";" + ImprintDescription_IL1_T4 + ";" + ImprintImage_IL1_T4 + ";" + PriceClass_IL1_T4 + ";" + PriceClass_IL1_CN4 + ";" + SetupFee_IL1_T4 + ";" + SetupFee_IL1_T4_NextColor + ";" + SetupFeeStructure_IL1_T4 + ";" + ExcludeFreeSetupCosts_IL1_T4 + ";" + ImprintSize_IL1_T4 + ";" + MaxColors_IL1_T4 + ";" + Handling_IL1_T4 + ";" + ImprintType_IL1_T5 + ";" + ImprintDescription_IL1_T5 + ";" + ImprintImage_IL1_T5 + ";" + PriceClass_IL1_T5 + ";" + PriceClass_IL1_CN5 + ";" + SetupFee_IL1_T5 + ";" + SetupFee_IL1_T5_NextColor + ";" + SetupFeeStructure_IL1_T5 + ";" + ExcludeFreeSetupCosts_IL1_T5 + ";" + ImprintSize_IL1_T5 + ";" + MaxColors_IL1_T5 + ";" + Handling_IL1_T5 + ";" + ImprintType_IL1_T6 + ";" + ImprintDescription_IL1_T6 + ";" + ImprintImage_IL1_T6 + ";" + PriceClass_IL1_T6 + ";" + PriceClass_IL1_CN6 + ";" + SetupFee_IL1_T6 + ";" + SetupFee_IL1_T6_NextColor + ";" + SetupFeeStructure_IL1_T6 + ";" + ExcludeFreeSetupCosts_IL1_T6 + ";" + ImprintSize_IL1_T6 + ";" + MaxColors_IL1_T6 + ";" + Handling_IL1_T6 + ";" + IntraCode + ";" + CountryOfOrigin + ";" + OuterCartonPieces + ";" + OuterCartonLength + ";" + OuterCartonWidth + ";" + OuterCartonHeight + ";" + CommercialItemLength + ";" + CommercialItemWidth + ";" + CommercialItemHeight + ";" + Flavours + ";" + Sizes + ";" + WritingColor + ";" + CapacityTxt + ";" + OrderUnit + ";" + MainGroup + ";" + Material + ";" + BatteryType + ";" + NumberOfBatteries + ";" + " ;" + ProductImageURL + ";" + DeliveryTimeMT_IL1_T1 + ";" + SearchTerms + ";" + Q_OnPallet + ";" + Brandnames);
        //                file.WriteLine(parentSku + ";" + SKU + ";" + ColorName + ";" + InternetName + ";" + InternetTxt + ";" + Q1 + ";" + Q2 + ";" + Q3 + ";" + Q4 + ";" + Q5 + ";" + Q6 + ";" + P1 + ";" + P2 + ";" + P3 + ";" + P4 + ";" + P5 + ";" + P6);

        //            }

        //            //}

        //            //for (int i = 0; product.Count() > i; i++)
        //            //{
        //            //    file.WriteLine(country + ";" + product[i].parrentProduct_productName + ";" + product[i].parrentProduct_shortDescription + "," + product[i].parrentProduct_longDescription + ",");

        //            //}


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("This program did an oopsie :", ex);
        //    }
        //}
    }

}
