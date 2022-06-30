using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Model.products.B2BPrintPositions;
using KN.B2B.Model.products.productPrice;
using KN.B2B.Model.SupplierTables.MidoceanAPI.prices;
using KN.B2B.Model.SupplierTables.MidoceanAPI.printInfo;
using KN.B2B.Model.SupplierTables.MidoceanAPI.Products;
using KN.B2B.Model.SystemTables;
using KN.B2B.Web.Services.Products.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KN.B2B.Web.Services.Products
{
    public class MidOcean
    {

        private readonly B2BDbContext _db;
        private readonly IConfiguration _config;
        private readonly SortMNCategories _sortMnCategories;

        private ExportProducts _exportProducts;

        SupplierPrintPrice supplierPrintPrice { get; set; }


        public MidOcean(B2BDbContext db, IConfiguration config, ExportProducts exportProducts, SortMNCategories sortMNCategories)
        {
            _db = db;
            _config = config;
            _exportProducts = exportProducts;
            _sortMnCategories = sortMNCategories;
        }

        //public void fetchMNManipulations()
        //{
        //    HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/printpricelist/2.0/"));

        //    WebReqDk.Method = "GET";
        //    WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
        //    //WebReqDk.Credentials = new NetworkCredential("Casper@b2bpromotion.eu", "123456");
        //    HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

        //    string jsonStringDk;
        //    using (Stream stream = WebRespDk.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

        //        jsonStringDk = reader.ReadToEnd();
        //    }

        //    Console.WriteLine(jsonStringDk);

        //    var settings = new JsonSerializerSettings
        //    {
        //        NullValueHandling = NullValueHandling.Ignore,
        //        MissingMemberHandling = MissingMemberHandling.Ignore
        //    };
        //    MNPrintPricesRoot result = JsonConvert.DeserializeObject<MNPrintPricesRoot>(jsonStringDk);
        //    //List<MNRootObj> result = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringDk);
        //    Console.WriteLine(result);

        //    foreach (PrintManipulation maniItem in result.print_manipulations)
        //    {
        //        SupplierHandles handleObj = new SupplierHandles();
        //        handleObj.handles_code = maniItem.code;
        //        handleObj.handles_description = maniItem.description;
        //        double convertedPrice = (float.Parse(maniItem.price) * 1.5);
        //        handleObj.handles_priceDK = (float)convertedPrice;
        //        handleObj.handles_priceEU = (float)(float)Math.Round(convertedPrice * 0.13, 2);
        //        handleObj.handles_priceFI = (float)(float)Math.Round(convertedPrice * 0.13, 2);
        //        handleObj.handles_supplierPrice = float.Parse(maniItem.price);

        //        _db.SupplierHandles.Add(handleObj);
        //        _db.SaveChanges();
        //    }
        //}

        //public void fetchTechniquePrices()
        //{
        //    HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/printpricelist/2.0/"));
        //    WebReqDk.Method = "GET";
        //    WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");

        //    HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

        //    string jsonStringDk;
        //    using (Stream stream = WebRespDk.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

        //        jsonStringDk = reader.ReadToEnd();
        //    }

        //    Console.WriteLine(jsonStringDk);

        //    MNPrintPricesRoot result = JsonConvert.DeserializeObject<MNPrintPricesRoot>(jsonStringDk);

        //    foreach (PrintTechnique printTechnique in result.print_techniques)
        //    {

        //        bool alert = false;
        //        string alertmsg = "";
        //        string alertStatus = "green";
        //        double _price = double.Parse(printTechnique.setup) * 1.5;

        //        SupplierPrintPrice printObj = new SupplierPrintPrice();
        //        printObj.printPrice_descId = printTechnique.id;
        //        printObj.printPrice_description = printTechnique.description;
        //        printObj.printPrice_pricingType = printTechnique.pricing_type;
        //        printObj.printPrice_setupDK = Math.Round(_price, 2).ToString();
        //        printObj.printPrice_setupEU = Math.Round((_price * 0.13), 2).ToString();
        //        printObj.printPrice_setupFI = Math.Round((_price * 0.13), 2).ToString();
        //        printObj.printPrice_repeat = printTechnique.setup_repeat;
        //        printObj.printPrice_nextColourIndicator = printTechnique.next_colour_cost_indicator;

        //        printObj.alert = alert;
        //        printObj.alertMessage = alertmsg;
        //        printObj.alertStatus = alertStatus;



        //        //_db.SupplierPrintPrices.Add(printObj);
        //        //_db.SaveChanges();


        //        foreach (VarCost varCost in printTechnique.var_costs)
        //        {
        //            alert = false;
        //            alertmsg = "";
        //            alertStatus = "green";

        //            SupplierPrintCost costObj = new SupplierPrintCost();
        //            costObj.printCost_rangeId = varCost.range_id;

        //            if (varCost.area_from != "")
        //            {

        //                costObj.printCost_areaFrom = float.Parse(varCost.area_from);
        //            }
        //            else
        //            {
        //                costObj.printCost_areaFrom = 0;

        //            }
        //            if (varCost.area_to != "")
        //            {
        //                costObj.printCost_areaTo = float.Parse(varCost.area_to);
        //            }
        //            else
        //            {
        //                costObj.printCost_areaTo = 0;

        //            }
        //            costObj.fk_supplierPrintPrice = printObj;

        //            costObj.alert = alert;
        //            costObj.alertMessage = alertmsg;
        //            costObj.alertStatus = alertStatus;

        //            //_db.SupplierPrintCosts.Add(costObj);
        //            //_db.SaveChanges();
        //            _exportProducts.excelInsertPrintPrices(printObj.printPrice_descId, varCost, printObj.printPrice_setupEU.ToString());

        //            //foreach (Scales scale in varCost.scales)
        //            //{
        //            //    alert = false;
        //            //    alertmsg = "";
        //            //    alertStatus = "green";

        //            //    CultureInfo cv = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        //            //    cv.NumberFormat.CurrencyDecimalSeparator = ",";
        //            //    SupplierPrintPriceScales scaleObj = new SupplierPrintPriceScales();
        //            //    scaleObj.scale_minimumQuantity = float.Parse(scale.minimum_quantity);
        //            //    double convertedPrice = Math.Round((float.Parse(scale.price) * 1.5),2);
        //            //    double EUValuta = Math.Round(convertedPrice * 0.13, 2);
        //            //    scaleObj.scale_priceDK = (float)convertedPrice;
        //            //    scaleObj.scale_priceEU = (float)EUValuta;
        //            //    scaleObj.scale_priceFI = (float)EUValuta;
        //            //    scaleObj.scale_supplierPrice = float.Parse(scale.price);
        //            //    if (scale.next_price != "" && double.Parse(scale.next_price) > 0)
        //            //    {
        //            //        double originalNextPrice = Math.Round(double.Parse(varCost.area_to),2);
        //            //        double areaToB2BNextPrice = originalNextPrice * 1.5;
        //            //        double areaToFIEUNextPrice = Math.Round(areaToB2BNextPrice * 0.13, 2);
        //            //        scaleObj.scale_nextPriceSupplier = (float)originalNextPrice;
        //            //        scaleObj.scale_nextPriceDK = (float)originalNextPrice;
        //            //        scaleObj.scale_nextPriceFI = (float)originalNextPrice;
        //            //        scaleObj.scale_nextPriceEU = (float)originalNextPrice;
        //            //        scaleObj.area


        //            //    }
        //            //    else
        //            //    {
        //            //        scaleObj.scale_nextPriceSupplier = 0;
        //            //        scaleObj.scale_nextPriceDK = 0;
        //            //        scaleObj.scale_nextPriceEU = 0;
        //            //        scaleObj.scale_nextPriceFI = 0;

        //            //        alert = true;
        //            //        alertmsg += "Missing next prices; ";
        //            //        alertStatus = "yellow";
        //            //    }
        //            //    scaleObj.fk_supplerPrintCost = costObj;

        //            //    scaleObj.alert = alert;
        //            //    scaleObj.alertMessage = alertmsg;
        //            //    scaleObj.alertStatus = alertStatus;


        //            //    _db.SupplierPrintPriceScales.Add(scaleObj);
        //            //    _db.SaveChanges();
        //            //}
        //        }
        //        Console.WriteLine(printObj);
        //    }

        //}

        //// ==== FETCH MN PRODUCTS ====

        //public void fetchMNData()
        //{
        //    string country = "fi";
        //    HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language={country}"));

        //    WebReqDk.Method = "GET";
        //    WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
        //    HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

        //    string jsonStringDk;
        //    using (Stream stream = WebRespDk.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

        //        jsonStringDk = reader.ReadToEnd();
        //    }

        //    Console.WriteLine(jsonStringDk);

        //    List<MNRootObj> result = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringDk);
        //    List<B2BParrentProducts> productList = new List<B2BParrentProducts>();

        //    foreach (MNRootObj product in result)
        //    {
        //        //TODO === FILL COMMERCIAL TEXT
        //        //TODO === ADD COMMENTS
        //        string commercialText = "";
        //        string productName = product.product_name + " " + product.short_description;
        //        string productShortDesc = "";
        //        bool alert = false;
        //        string alertMessage = "";
        //        string alertStatus = "";
        //        B2BParrentProducts obj = new B2BParrentProducts();

        //        // === CHECK IF PRODUCT NAME > 31 CHARS ===
        //        if (productName.Length > 31)
        //        {
        //            obj.parrentProduct_productName = productName.Substring(0, 31);

        //        }
        //        else
        //        {
        //            obj.parrentProduct_productName = productName;
        //        }

        //        // === CHECK IF SHORT DESC == NULL ==
        //        if (product.short_description == null)
        //        {
        //            productShortDesc = "";
        //            alert = true;
        //            alertStatus = "red";
        //            alertMessage += " Ingen short description;";
        //        }
        //        else
        //        {
        //            // === CHECK IF SHORT DESC > 31 CHARS ===
        //            if (product.short_description.Length > 31)
        //            {
        //                productShortDesc = product.short_description.Substring(0, 31);
        //            }
        //            else
        //            {
        //                productShortDesc = product.short_description;
        //            }
        //        }


        //        obj.parrentProduct_masterId = product.master_id;
        //        obj.parrentProduct_parrentSku = "MN" + product.master_code;

        //        // === CHECK IF PRODUCT PRINT POSITIONS == NULL ===
        //        if (product.number_of_print_positions != null)
        //        {
        //            obj.parrentProduct_printPositions = Int32.Parse(product.number_of_print_positions);
        //        }
        //        else
        //        {
        //            obj.parrentProduct_printPositions = 0;
        //        }
        //        obj.parrentProduct_dimensions = product.dimensions;

        //        // === CHECK IF PRODUCT LENGTH == NULL ===
        //        if (product.length != null)
        //        {
        //            obj.parrentProduct_length = float.Parse(product.length);
        //        }
        //        else
        //        {
        //            obj.parrentProduct_length = 0;
        //            alert = true;
        //            alertStatus = "red";
        //            alertMessage += " missing product length;";
        //        }

        //        // === CHECK IF PRODUCT WIDTH == NULL ===
        //        if (product.width != null)
        //        {
        //            obj.parrentProduct_width = float.Parse(product.width);
        //        }
        //        else
        //        {
        //            obj.parrentProduct_height = 0;
        //            alert = true;
        //            alertStatus = "red";
        //            alertMessage += " missing product width;";
        //        }

        //        // === CHECK IF PRODUCT HEIGHT == NULL ===
        //        if (product.height != null)
        //        {
        //            obj.parrentProduct_height = float.Parse(product.height);
        //        }
        //        else
        //        {
        //            obj.parrentProduct_height = 0;
        //            alert = true;
        //            alertStatus = "red";
        //            alertMessage += " missing product height;";
        //        }
        //        if (product.long_description != null && product.dimensions != null)
        //        {
        //            obj.parrentProduct_longDescription = product.long_description + commercialText + product.dimensions;
        //        }
        //        else
        //        {
        //            alert = true;
        //            alertStatus = "red";
        //            alertMessage += " No long description;";
        //        }
        //        obj.parrentProduct_shortDescription = productShortDesc;
        //        if (product.printable == "yes")
        //        {
        //            obj.parrentProduct_printable = true;
        //        }
        //        else
        //        {
        //            obj.parrentProduct_printable = false;
        //        }
        //        obj.parrentProduct_material = product.material;
        //        obj.parrentProduct_mainCategory = product.product_class;

        //        // === VALIDATING SUBCATEGORY ===
        //        foreach (Variant searchSubCategory in product.variants)
        //        {
        //            obj.parrentProduct_supplierSubCategory = searchSubCategory.category_level2;
        //            var foundCategory = _sortMnCategories.asignCategories(searchSubCategory, country);
        //            if (foundCategory != null)
        //            {
        //                obj.parrentProduct_subCategoryDK = foundCategory.CategoryDK;
        //                obj.parrentProduct_subCategoryEN = foundCategory.Category;
        //                obj.parrentProduct_subCategoryFI = foundCategory.CategoryFI;
        //            }
        //            else
        //            {
        //                alert = true;
        //                alertMessage += "Missing Subcategory; ";
        //                alertStatus = "red";
        //            }
        //        }
        //        obj.fk_B2BCategories = null;
        //        obj.fk_B2BCategories = null;
        //        obj.alert = alert;
        //        obj.alertMessage = alertMessage;
        //        obj.alertStatus = alertStatus;

        //        productList.Add(obj);
        //        _db.B2BParrentProducts.Add(obj);
        //        _db.SaveChanges();

        //        // ==== CREATING CHILD PRODUCTS ===
        //        foreach (Variant childProduct in product.variants)
        //        {

        //            B2BProduct b2bProdcut = new B2BProduct();
        //            string _productName = product.product_name + product.short_description;


        //            b2bProdcut.product_sku = childProduct.sku;
        //            b2bProdcut.fk_ParentSKU = obj;
        //            b2bProdcut.product_ColorName = childProduct.color_description;
        //            b2bProdcut.product_brandNames = product.brand;
        //            b2bProdcut.product_longDescriptionDK = product.long_description;
        //            b2bProdcut.product_shortDescriptionDK = productShortDesc;

        //            _db.B2BProdducts.Add(b2bProdcut);
        //            _db.SaveChanges();

        //            int imgCount = 00;
        //            Console.WriteLine(b2bProdcut);
        //            //foreach(DigitalAsset img in childProduct.digital_assets)
        //            //{
        //            //    downloadImages(img.url, childProduct.sku + "_" + imgCount.ToString() + ".jpg");
        //            //    imgCount++;
        //            //}
        //            //var placeholderList = new[] { 1, 2, 3 }.ToList();

        //            // ==== CREATING CHILD PRODUCT IMAGES ===
        //            foreach (DigitalAsset image in childProduct.digital_assets)
        //            {
        //                string imageName = image.url.Substring(image.url.LastIndexOf('/') + 1);
        //                B2BProductImages imageObj = new B2BProductImages();
        //                imageObj.imagePath = $"https://www.b2bpromotion.dk/content/images/productImages/{imageName}";
        //                imageObj.fk_childProduct = b2bProdcut;

        //                _db.B2BProductImages.Add(imageObj);
        //                _db.SaveChanges();
        //            }

        //        }
        //    }
        //    //_exportProducts.patchProdDesc(productList, country);

        //}

        //public void fetchMNPriceList()
        //{
        //    HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/pricelist/2.0/"));

        //    WebReqDk.Method = "GET";
        //    WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
        //    HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

        //    string jsonStringDk;
        //    using (Stream stream = WebRespDk.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

        //        jsonStringDk = reader.ReadToEnd();
        //    }

        //    Console.WriteLine(jsonStringDk);

        //    var settings = new JsonSerializerSettings
        //    {
        //        NullValueHandling = NullValueHandling.Ignore,
        //        MissingMemberHandling = MissingMemberHandling.Ignore
        //    };
        //    MNPriceListRoot result = JsonConvert.DeserializeObject<MNPriceListRoot>(jsonStringDk);

        //    foreach (Price priceObj in result.price)
        //    {

        //        // === CREATING PARRENT PRODUCT ===
        //        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        //        ci.NumberFormat.CurrencyDecimalSeparator = ",";
        //        B2BProductPrices productPrice = new B2BProductPrices();
        //        // ===== STARTING PRICE
        //        var startingPrice = Math.Round(double.Parse(priceObj.price) * 1.5);
        //        //var startingPrice = Math.Round(double.Parse(priceObj.price) * 1.5);
        //        productPrice.price_startingPriceSupplier = priceObj.price;
        //        productPrice.price_startingPriceDK = startingPrice.ToString();
        //        productPrice.price_startingPriceFI = String.Format("{0:0.00}", startingPrice * 1.75);
        //        productPrice.price_startingPriceEU = String.Format("{0:0.00}", startingPrice * 1.75);
        //        productPrice.price_validUntill = priceObj.valid_until;
        //        //TODO ===> NOT PARRENT SKU // IT IS CHILD SKU
        //        productPrice.parrentSku = priceObj.sku;


        //        _db.B2BProductPrices.Add(productPrice);
        //        _db.SaveChanges();
        //        if (priceObj.scale != null)
        //        {
        //            // === CHECK IF MISSING 1 INDEX / TOTAL OF 6
        //            if (priceObj.scale.Count() == 6)
        //            {
        //                Console.WriteLine(priceObj.scale.Count());
        //                var lastMinimumPrice = float.Parse(priceObj.scale[priceObj.scale.Count() - 5].price, NumberStyles.Any, ci);
        //                var lastMinimumQ = Int32.Parse(priceObj.scale[priceObj.scale.Count() - 5].minimum_quantity);
        //                int finallyq = 1;
        //                if (lastMinimumQ <= 200000 && lastMinimumQ >= 5000)
        //                {
        //                    finallyq = 10000;
        //                }
        //                else if (lastMinimumQ <= 4999 && lastMinimumQ >= 2500)
        //                {
        //                    finallyq = 5000;
        //                }
        //                else if (lastMinimumQ <= 2499 && lastMinimumQ >= 1001)
        //                {
        //                    finallyq = 2500;
        //                }
        //                else if (lastMinimumQ <= 1000 && lastMinimumQ >= 801)
        //                {
        //                    finallyq = 1000;
        //                }
        //                else if (lastMinimumQ <= 800 && lastMinimumQ >= 500)
        //                {
        //                    finallyq = 500;
        //                }
        //                else if (lastMinimumQ <= 499 && lastMinimumQ >= 250)
        //                {
        //                    finallyq = 250;
        //                }
        //                else if (lastMinimumQ <= 249 && lastMinimumQ >= 125)
        //                {
        //                    finallyq = 125;
        //                }
        //                else if (lastMinimumQ <= 125 && lastMinimumQ >= 50)
        //                {
        //                    finallyq = 50;
        //                }
        //                else if (lastMinimumQ <= 49 && lastMinimumQ >= 1)
        //                {
        //                    finallyq = 25;
        //                }

        //                Scale priceScaleMin = new Scale
        //                {
        //                    price = lastMinimumPrice.ToString(),
        //                    minimum_quantity = finallyq.ToString()
        //                };
        //                priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin);
        //            }
        //            // === CHECK IF MISSING 2 INDEXES / TOTAL OF 6
        //            if (priceObj.scale.Count() == 5)
        //            {
        //                Console.WriteLine(priceObj.scale.Count());
        //                var lastMinimumPrice = float.Parse(priceObj.scale[priceObj.scale.Count() - 4].price, NumberStyles.Any, ci);
        //                var lastMinimumQ = Int32.Parse(priceObj.scale[priceObj.scale.Count() - 4].minimum_quantity);
        //                int finallyq1 = 2;
        //                int finallyq2 = 2;
        //                if (lastMinimumQ <= 200000 && lastMinimumQ >= 5000)
        //                {
        //                    finallyq1 = 10000;
        //                    finallyq2 = 5000;
        //                }
        //                else if (lastMinimumQ <= 4999 && lastMinimumQ >= 2500)
        //                {
        //                    finallyq1 = 5000;
        //                    finallyq2 = 2500;
        //                }
        //                else if (lastMinimumQ <= 2499 && lastMinimumQ >= 1001)
        //                {
        //                    finallyq1 = 2500;
        //                    finallyq2 = 1000;
        //                }
        //                else if (lastMinimumQ <= 1000 && lastMinimumQ >= 500)
        //                {
        //                    finallyq1 = 1000;
        //                    finallyq2 = 500;
        //                }
        //                else if (lastMinimumQ <= 499 && lastMinimumQ >= 125)
        //                {
        //                    finallyq1 = 250;
        //                    finallyq2 = 125;
        //                }
        //                else if (lastMinimumQ <= 124 && lastMinimumQ >= 50)
        //                {
        //                    finallyq1 = 125;
        //                    finallyq2 = 50;
        //                }
        //                else if (lastMinimumQ <= 49 && lastMinimumQ >= 1)
        //                {
        //                    finallyq1 = 50;
        //                    finallyq2 = 25;
        //                }

        //                Scale priceScaleMin = new Scale
        //                {
        //                    price = lastMinimumPrice.ToString(),
        //                    minimum_quantity = finallyq1.ToString(),
        //                };

        //                Scale priceScaleMin2 = new Scale
        //                {
        //                    price = lastMinimumPrice.ToString(),
        //                    minimum_quantity = finallyq2.ToString(),
        //                };
        //                priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin);
        //                priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin2);


        //            }

        //            // === CHECK IF MISSING 3 INDEXES / TOTAL OF 6
        //            if (priceObj.scale.Count() == 4)
        //            {
        //                Console.WriteLine(priceObj.scale.Count());
        //                var lastMinimumPrice = float.Parse(priceObj.scale[priceObj.scale.Count() - 3].price, NumberStyles.Any, ci);
        //                var lastMinimumQ = Int32.Parse(priceObj.scale[priceObj.scale.Count() - 3].minimum_quantity);
        //                int finallyq1 = 3;
        //                int finallyq2 = 4;
        //                int finallyq3 = 5;
        //                if (lastMinimumQ <= 200000 && lastMinimumQ >= 5000)
        //                {
        //                    finallyq1 = 10000;
        //                    finallyq2 = 5000;
        //                    finallyq3 = 2500;
        //                }
        //                else if (lastMinimumQ <= 4999 && lastMinimumQ >= 2500)
        //                {
        //                    finallyq1 = 5000;
        //                    finallyq2 = 2500;
        //                    finallyq3 = 1000;
        //                }
        //                else if (lastMinimumQ <= 2499 && lastMinimumQ >= 500)
        //                {
        //                    finallyq1 = 2500;
        //                    finallyq2 = 1000;
        //                    finallyq3 = 500;
        //                }
        //                else if (lastMinimumQ <= 1000 && lastMinimumQ >= 500)
        //                {
        //                    finallyq1 = 500;
        //                    finallyq2 = 250;
        //                    finallyq3 = 125;
        //                }
        //                else if (lastMinimumQ <= 499 && lastMinimumQ >= 250)
        //                {
        //                    finallyq1 = 250;
        //                    finallyq2 = 125;
        //                    finallyq3 = 50;
        //                }
        //                else if (lastMinimumQ <= 249 && lastMinimumQ >= 1)
        //                {
        //                    finallyq1 = 125;
        //                    finallyq2 = 50;
        //                    finallyq3 = 25;
        //                }


        //                Scale priceScaleMin = new Scale
        //                {
        //                    price = lastMinimumPrice.ToString(),
        //                    minimum_quantity = finallyq1.ToString(),
        //                };

        //                Scale priceScaleMin2 = new Scale
        //                {
        //                    price = lastMinimumPrice.ToString(),
        //                    minimum_quantity = finallyq2.ToString(),
        //                };

        //                Scale priceScaleMin3 = new Scale
        //                {
        //                    price = lastMinimumPrice.ToString(),
        //                    minimum_quantity = finallyq3.ToString(),
        //                };

        //                priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin);
        //                priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin2);
        //                priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin3);
        //            }
        //            int breakLoop = 0;


        //            // ======== INSERTING PRICE SCALE ========
        //            for (int i = priceObj.scale.Count() - 1; i >= 0; i--)
        //            {
        //                if (priceObj.scale.Count() > i && i > breakLoop)
        //                {
        //                    CultureInfo cd = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        //                    cd.NumberFormat.CurrencyDecimalSeparator = ".";
        //                    B2BPriceScaling priceScale = new B2BPriceScaling();

        //                    // === MINIMUM QUANITITY ===
        //                    if (Int32.Parse(priceObj.scale[i].minimum_quantity) == 1)
        //                    {
        //                        int index = priceObj.scale.FindIndex(a => Int32.Parse(a.minimum_quantity) == 1);
        //                        priceScale.scale_minimumQuantity = Int32.Parse(priceObj.scale[index - 1].minimum_quantity) / 2;
        //                    }
        //                    else
        //                    {
        //                        priceScale.scale_minimumQuantity = Int32.Parse(priceObj.scale[i].minimum_quantity);
        //                    }
        //                    string totalPrice = "";
        //                    float _price = float.Parse(priceObj.scale[i].price, NumberStyles.Any, cd);

        //                    // === PRICE STACKERS ===
        //                    switch (i)
        //                    {
        //                        case 6:
        //                            //totalPrice = String.Format("{0:0.00}", _price * 1.75);
        //                            totalPrice = String.Format("{0:0.00}", _price);
        //                            break;
        //                        case 5:
        //                            //totalPrice = String.Format("{0:0.00}", _price * 1.65);
        //                            totalPrice = String.Format("{0:0.00}", _price);

        //                            break;
        //                        case 4:
        //                            //totalPrice = String.Format("{0:0.00}", _price * 1.6);
        //                            totalPrice = String.Format("{0:0.00}", _price);

        //                            break;
        //                        case 3:
        //                            //totalPrice = String.Format("{0:0.00}", _price * 1.55);
        //                            totalPrice = String.Format("{0:0.00}", _price);

        //                            break;
        //                        case 2:
        //                            //totalPrice = String.Format("{0:0.00}", _price * 1.5);
        //                            totalPrice = String.Format("{0:0.00}", _price);

        //                            break;
        //                        case 1:
        //                            //totalPrice = String.Format("{0:0.00}", _price * 1.45);
        //                            totalPrice = String.Format("{0:0.00}", _price);

        //                            break;

        //                    }
        //                    string totalEuPrice = String.Format("{0:0.00}", Convert.ToDouble(totalPrice) * 0.13);
        //                    string totalFIPrice = String.Format("{0:0.00}", Convert.ToDouble(totalPrice) * 0.79);
        //                    priceScale.scale_supplierPrice = priceObj.scale[i].price;
        //                    // TODO == Round to numbers here
        //                    // === DK PRICES ===
        //                    priceScale.scale_priceDK = totalPrice;
        //                    // === EU PRICES===
        //                    priceScale.scale_priceEU = totalEuPrice;
        //                    // === FI PRICES ===
        //                    priceScale.scale_priceFI = totalFIPrice;
        //                    // =============================

        //                    // === FINALE FK_PRICEID ===
        //                    priceScale.fk_priceId = productPrice;


        //                    // == ALERTS ==
        //                    priceScale.alertActive = false;
        //                    priceScale.alert = "noAlert";

        //                    if (priceScale.scale_minimumQuantity == 1)
        //                    {
        //                        priceScale.alertActive = true;
        //                        priceScale.alert = "Error: with minimumQuanity";
        //                    }
        //                    if (Int32.Parse(priceObj.scale[i].minimum_quantity) == 1 && priceScale.scale_minimumQuantity > 250)
        //                    {
        //                        priceScale.alertActive = true;
        //                        priceScale.alert = "Warning: q1 seems to high = " + priceScale.scale_minimumQuantity;
        //                    }

        //                    _db.B2BPriceScaling.Add(priceScale);
        //                    _db.SaveChanges();
        //                }
        //            }

        //        }
        //        Console.WriteLine(priceObj);
        //    }


        //}

        //public async Task fetchPrintTechniques()
        //{
        //    string xmlString = string.Empty;

        //    using (StreamReader r = new StreamReader("printinfo.xml"))
        //    {

        //        xmlString = r.ReadToEnd();

        //    }
        //    byte[] byteArray = Encoding.UTF8.GetBytes(xmlString);
        //    MemoryStream stream = new MemoryStream(byteArray);

        //    var s = new System.Xml.Serialization.XmlSerializer(typeof(PRINTINGINFORMATION));
        //    PRINTINGINFORMATION o = (PRINTINGINFORMATION)s.Deserialize(XmlReader.Create(stream));

        //    IEnumerable<B2BPrintTechnique> techniquesList = _db.B2BPrintTechniques;



        //    foreach (PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTION technique in o.pRINTING_TECHNIQUE_DESCRIPTIONSField)
        //    {
        //        supplierPrintPrice = await _db.SupplierPrintPrices.FirstOrDefaultAsync(c => c.printPrice_descId == technique.idField);
        //        //var = await _db.SupplierHandles.FirstOrDefaultAsync(c => c.printPrice_descId == technique.idField);

        //        B2BPrintTechnique printTechnique = new B2BPrintTechnique();
        //        printTechnique.technique_name = technique.idField;
        //        printTechnique.technique_description = technique.nAMEField[3].valueField;
        //        printTechnique.technique_supplier = "midocean";
        //        printTechnique.fk_supplierPriceCode = supplierPrintPrice;
        //        _db.B2BPrintTechniques.Add(printTechnique);
        //        _db.SaveChanges();
        //        Console.WriteLine(printTechnique);

        //    }

        //    //Console.ReadLine();

        //    foreach (PRINTINGINFORMATIONPRODUCT product in o.pRODUCTSField)
        //    {



        //        foreach (PRINTINGINFORMATIONPRODUCTPRINTING_POSITION printPos in product.pRINTING_POSITIONSField)
        //        {
        //            foreach (PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE technique in printPos.pRINTING_TECHNIQUEField)
        //            {
        //                B2BPrintPosition b2BPrintPosition = new B2BPrintPosition();
        //                b2BPrintPosition.print_supplier = o.sUPPLIERField;
        //                b2BPrintPosition.print_productName = "MN" + product.pRODUCT_BASE_NUMBERField;
        //                if (product.pRINT_EXPRESS_POSSIBLEField == "N")
        //                {
        //                    b2BPrintPosition.print_express = false;
        //                }
        //                else
        //                {
        //                    b2BPrintPosition.print_express = true;
        //                }
        //                foreach (B2BPrintTechnique fk_technique in techniquesList)
        //                {
        //                    //B2BPrintTechnique techniqueObj = fk_technique;
        //                    if (technique.idField == fk_technique.technique_name)
        //                    {
        //                        b2BPrintPosition.fk_techniqueId = fk_technique;
        //                        Console.WriteLine(fk_technique);
        //                        break;
        //                    }

        //                }
        //                b2BPrintPosition.print_position = printPos.idField;
        //                b2BPrintPosition.print_width = float.Parse(printPos.mAX_PRINT_SIZE_WIDTHField);
        //                b2BPrintPosition.print_height = float.Parse(printPos.mAX_PRINT_SIZE_HEIGHTField);
        //                b2BPrintPosition.maxColors = technique.MAX_COLORS;
        //                _db.B2BPrintPositions.Add(b2BPrintPosition);
        //                _db.SaveChanges();
        //                Console.WriteLine(product);
        //            }
        //            //foreach (PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE technique in printPos.pRINTING_TECHNIQUEField)





        //            //}

        //        }

        //    }

        //}
        //public void downloadImages(string linkName, string imgName)
        //{
        //    using (WebClient webclient = new WebClient())
        //        // TODO - SAVES UNINDENTIFIED FORMAT
        //        webclient.DownloadFile(linkName, "assets\\images\\" + imgName);
        //    string serverFolder = "assets\\images\\";
        //    string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    string specificFolder = Path.Combine(folder, "assets\\images\\");
        //    string file = @imgName;
        //    if (!Directory.Exists(specificFolder))
        //        Directory.CreateDirectory(specificFolder);
        //    System.IO.File.Copy(serverFolder + file, Path.Combine(specificFolder, Path.GetFileName(file)), true);
        //}

    }


}
