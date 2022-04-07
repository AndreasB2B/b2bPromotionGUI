using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Model.products.productPrice;
using KN.B2B.Model.SupplierTables.MidoceanAPI.prices;
using KN.B2B.Model.SupplierTables.MidoceanAPI.Products;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using KN.B2B.Model.SupplierTables.MidoceanAPI.printInfo;
using System.Xml;
using KN.B2B.Model.products.B2BPrintPositions;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;
using KN.B2B.Web.Models;
using System.Collections;
using System.Web;

namespace KN.B2B.Web.Pages.Private.Requests.Products
{
    public class viewAllModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly B2BDbContext _db;
        private readonly IConfiguration _config;

        SupplierPrintPrice supplierPrintPrice { get; set; }

        public string message { get; set; }
        public string searchQuery { get; set; }
        public B2BProduct B2BProduct { get; set; }
        public IEnumerable<B2BParrentProducts> parrentProductsList { get; set; }
        public IEnumerable<B2BPrintTechnique> techniqueList { get; set; }
        public PaginatedList<B2BParrentProducts> productPaging { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public viewAllModel(B2BDbContext db, ILogger<IndexModel> logger, IConfiguration config)
        {
            _db = db;
            _config = config;
        }



        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-6.0
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<B2BParrentProducts> products = from s in _db.B2BParrentProducts select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.parrentProduct_parrentSku.Contains(searchString) || s.parrentProduct_productName.Contains(searchString));
            }



            message = _config["Message"];
            //if (string.IsNullOrEmpty(searchQuery) == false)
            //    parrentProductsList = await _db.B2BParrentProducts
            //        .Include(x => x.parrentProduct_productName)
            //        .Include(x => x.parrentProduct_shortDescription)
            //        .Include(x => x.)
            //        .Where(x => x.Customer.Name.ToLower().Contains(SearchQuery.ToLower()))
            //        .OrderByDescending(x => x.Id)
            //        .ToListAsync();
            //else

            //techniqueList = await _db.B2BPrintTechniques.ToListAsync();

            //Console.WriteLine(techniqueList);

            //parrentProductsList = await _db.B2BParrentProducts
            //    //.Include(x => x.parrentProduct_productName)
            //    //.Include(x => x.parrentProduct_shortDescription)
            //    .OrderByDescending(x => x.parrentProduct_id)
            //    .ToListAsync();

            //IEnumerable<B2BPrintTechnique> techniques = await _db.B2BPrintTechniques.Where(x => x.technique_description == "Doming").ToListAsync();

            //Console.WriteLine(techniques);
            //fetchMNData();
            //sendMail();
            //fetchFtpFile();
            //await fetchPrintTechniques();
            //fetchMNPriceList();
            //fetchTechniquePrices();
            //fetchMNManipulations();
            //fetchMNCategoryAndExport();
            //insertCategories();
            var pageSize = _config.GetValue("PageSize", 4);
            productPaging = await PaginatedList<B2BParrentProducts>.CreateAsync(
                products.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
        public void fetchMNManipulations()
        {
            HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/printpricelist/2.0/"));

            WebReqDk.Method = "GET";
            WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
            //WebReqDk.Credentials = new NetworkCredential("Casper@b2bpromotion.eu", "123456");
            HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

            string jsonStringDk;
            using (Stream stream = WebRespDk.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

                jsonStringDk = reader.ReadToEnd();
            }

            Console.WriteLine(jsonStringDk);

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            MNPrintPricesRoot result = JsonConvert.DeserializeObject<MNPrintPricesRoot>(jsonStringDk);
            //List<MNRootObj> result = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringDk);
            Console.WriteLine(result);

            foreach (PrintManipulation maniItem in result.print_manipulations)
            {
                SupplierHandles handleObj = new SupplierHandles();
                handleObj.handles_code = maniItem.code;
                handleObj.handles_description = maniItem.description;
                double convertedPrice = (float.Parse(maniItem.price) * 1.5);
                handleObj.handles_priceDK = (float)convertedPrice;
                handleObj.handles_priceEU = (float)(float)Math.Round(convertedPrice * 0.13, 2);
                handleObj.handles_priceFI = (float)(float)Math.Round(convertedPrice * 0.13, 2);
                handleObj.handles_supplierPrice = float.Parse(maniItem.price);

                _db.SupplierHandles.Add(handleObj);
                _db.SaveChanges();
            }
        }
        public void fetchTechniquePrices() {
            HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/printpricelist/2.0/"));
            WebReqDk.Method = "GET";
            WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");

            HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

            string jsonStringDk;
            using (Stream stream = WebRespDk.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

                jsonStringDk = reader.ReadToEnd();
            }

            Console.WriteLine(jsonStringDk);

            MNPrintPricesRoot result = JsonConvert.DeserializeObject<MNPrintPricesRoot>(jsonStringDk);

            foreach (PrintTechnique printTechnique in result.print_techniques)
            {

                bool alert = false;
                string alertmsg = "";
                string alertStatus = "green";
                double _price = double.Parse(printTechnique.setup) * 1.5;

                SupplierPrintPrice printObj = new SupplierPrintPrice();
                printObj.printPrice_descId = printTechnique.id;
                printObj.printPrice_description = printTechnique.description;
                printObj.printPrice_pricingType = printTechnique.pricing_type;
                printObj.printPrice_setupDK = Math.Round(_price, 2).ToString();
                printObj.printPrice_setupEU = Math.Round((_price * 0.13),2).ToString();
                printObj.printPrice_setupFI = Math.Round((_price * 0.13), 2).ToString();
                printObj.printPrice_repeat = printTechnique.setup_repeat;
                printObj.printPrice_nextColourIndicator = printTechnique.next_colour_cost_indicator;

                printObj.alert = alert;
                printObj.alertMessage = alertmsg;
                printObj.alertStatus = alertStatus;

                _db.SupplierPrintPrices.Add(printObj);
                _db.SaveChanges();


                foreach(VarCost varCost in printTechnique.var_costs)
                {
                    alert = false;
                    alertmsg = "";
                    alertStatus = "green";

                    SupplierPrintCost costObj = new SupplierPrintCost();
                    costObj.printCost_rangeId = varCost.range_id;

                    if(varCost.area_from != "")
                    {

                        costObj.printCost_areaFrom = float.Parse(varCost.area_from);
                    }
                    else
                    {
                        costObj.printCost_areaFrom = 0;

                    }
                    if(varCost.area_to != "")
                    {
                        costObj.printCost_areaTo = float.Parse(varCost.area_to);
                    }
                    else
                    {
                        costObj.printCost_areaTo = 0;

                    }
                    costObj.fk_supplierPrintPrice = printObj;

                    costObj.alert = alert;
                    costObj.alertMessage = alertmsg;
                    costObj.alertStatus = alertStatus;

                    _db.SupplierPrintCosts.Add(costObj);
                    _db.SaveChanges();

                    foreach(Scales scale in varCost.scales)
                    {
                        alert = false;
                        alertmsg = "";
                        alertStatus = "green";

                        CultureInfo cv = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        cv.NumberFormat.CurrencyDecimalSeparator = ",";
                        SupplierPrintPriceScales scaleObj = new SupplierPrintPriceScales();
                        scaleObj.scale_minimumQuantity = float.Parse(scale.minimum_quantity);
                        double convertedPrice = Math.Round((float.Parse(scale.price) * 1.5),2);
                        double EUValuta = Math.Round(convertedPrice * 0.13, 2);
                        scaleObj.scale_priceDK = (float)convertedPrice;
                        scaleObj.scale_priceEU = (float)EUValuta;
                        scaleObj.scale_priceFI = (float)EUValuta;
                        scaleObj.scale_supplierPrice = float.Parse(scale.price);
                        if (scale.next_price != "")
                        {
                            double originalNextPrice = Math.Round(double.Parse(varCost.area_to),2);
                            double areaToB2BNextPrice = originalNextPrice * 1.5;
                            double areaToFIEUNextPrice = Math.Round(areaToB2BNextPrice * 0.13, 2);
                            scaleObj.scale_nextPriceSupplier = (float)originalNextPrice;
                            scaleObj.scale_nextPriceDK = (float)originalNextPrice;
                            scaleObj.scale_nextPriceFI = (float)originalNextPrice;
                            scaleObj.scale_nextPriceEU = (float)originalNextPrice;


                        }
                        else
                        {
                            scaleObj.scale_nextPriceSupplier = 0;
                            scaleObj.scale_nextPriceDK = 0;
                            scaleObj.scale_nextPriceEU = 0;
                            scaleObj.scale_nextPriceFI = 0;

                            alert = true;
                            alertmsg += "Missing next prices; ";
                            alertStatus = "yellow";
                        }
                        scaleObj.fk_supplerPrintCost = costObj;

                        scaleObj.alert = alert;
                        scaleObj.alertMessage = alertmsg;
                        scaleObj.alertStatus = alertStatus;

                        _db.SupplierPrintPriceScales.Add(scaleObj);
                        _db.SaveChanges();

                    }
                }
                Console.WriteLine(printObj);
            }

        }
        public void fetchMNCategoryAndExport()
        {
            HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language=da"));
            HttpWebRequest WebReqEN = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language=en"));
            HttpWebRequest WebReqFI = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language=fi"));

            WebReqDk.Method = "GET";
            WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
            HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

            WebReqEN.Method = "GET";
            WebReqEN.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
            HttpWebResponse WebRespEN = (HttpWebResponse)WebReqEN.GetResponse();

            WebReqFI.Method = "GET";
            WebReqFI.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
            HttpWebResponse WebRespFI = (HttpWebResponse)WebReqFI.GetResponse();

            string jsonStringDk;
            using (Stream stream = WebRespDk.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

                jsonStringDk = reader.ReadToEnd();
            }

            string jsonStringEN;
            using (Stream stream = WebRespEN.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

                jsonStringEN = reader.ReadToEnd();
            }

            string jsonStringFI;
            using (Stream stream = WebRespFI.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

                jsonStringFI = reader.ReadToEnd();
            }

            List<MNRootObj> resultDK = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringDk);
            List<MNRootObj> resultEN = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringEN);
            List<MNRootObj> resultFI = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringFI);

            List<string> categoryListLevel1DK = new List<string>();
            List<string> categoryListLevel2DK = new List<string>();
            List<string> categoryListLevel3DK = new List<string>();
            List<string> master_colorDK= new List<string>();

            List<string> categoryListLevel1FI = new List<string>();
            List<string> categoryListLevel2FI = new List<string>();
            List<string> categoryListLevel3FI = new List<string>();
            List<string> master_colorFI = new List<string>();

            List<string> categoryListLevel1EN = new List<string>();
            List<string> categoryListLevel2EN = new List<string>();
            List<string> categoryListLevel3EN = new List<string>();
            List<string> master_colorEN = new List<string>();

            foreach (MNRootObj product in resultDK)
            {
                foreach (Variant childProduct in product.variants)
                {
                    categoryListLevel1DK.Add(childProduct.category_level1);
                    categoryListLevel2DK.Add(childProduct.category_level2);
                    categoryListLevel3DK.Add(childProduct.category_level3);
                    master_colorDK.Add(childProduct.color_group);
                }
            }

            foreach (MNRootObj product in resultEN)
            {
                foreach (Variant childProduct in product.variants)
                {
                    categoryListLevel1EN.Add(childProduct.category_level1);
                    categoryListLevel2EN.Add(childProduct.category_level2);
                    categoryListLevel3EN.Add(childProduct.category_level3);
                    master_colorEN.Add(childProduct.color_group);
                }
            }

            foreach (MNRootObj product in resultFI)
            {
                foreach (Variant childProduct in product.variants)
                {
                    categoryListLevel1FI.Add(childProduct.category_level1);
                    categoryListLevel2FI.Add(childProduct.category_level2);
                    categoryListLevel3FI.Add(childProduct.category_level3);
                    master_colorFI.Add(childProduct.color_group);
                }
            }

            List<string> categoryListLevel1SortedDK = categoryListLevel1DK.Distinct().ToList();
            List<string> categoryListLevel2SortedDK = categoryListLevel2DK.Distinct().ToList();
            List<string> categoryListLevel3SortedDK = categoryListLevel3DK.Distinct().ToList();
            List<string> master_colorSortedDK = master_colorDK.Distinct().ToList();

            List<string> categoryListLevel1SortedFI = categoryListLevel1FI.Distinct().ToList();
            List<string> categoryListLevel2SortedFI = categoryListLevel2FI.Distinct().ToList();
            List<string> categoryListLevel3SortedFI = categoryListLevel3FI.Distinct().ToList();
            List<string> master_colorSortedFI = master_colorFI.Distinct().ToList();

            List<string> categoryListLevel1SortedEN = categoryListLevel1EN.Distinct().ToList();
            List<string> categoryListLevel2SortedEN = categoryListLevel2EN.Distinct().ToList();
            List<string> categoryListLevel3SortedEN = categoryListLevel3EN.Distinct().ToList();
            List<string> master_colorSortedEN = master_colorEN.Distinct().ToList();


            patchToExcel(categoryListLevel1SortedDK, categoryListLevel2SortedDK, categoryListLevel3SortedDK, master_colorSortedDK, "DANISH");
            patchToExcel(categoryListLevel1SortedEN, categoryListLevel2SortedEN, categoryListLevel3SortedEN, master_colorSortedEN, "ENGLISH");
            patchToExcel(categoryListLevel1SortedFI, categoryListLevel2SortedFI, categoryListLevel3SortedFI, master_colorSortedFI, "FINNISH");
        }

        public void patchToExcel(List<string> categoryLevel1, List<string> categoryLevel2, List<string> categoryLevel3, List<string> master_color, string country)
        {

            string filePath = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss") + "-" + country + ".csv";
            try
            {

                using (StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("iso-8859-1")))
                {
                    file.WriteLine("Country;Category_Level1_MN;Category1_Translated_B2B;");

                    for (int i = 0; categoryLevel1.Count() > i; i++)
                    {
                        file.WriteLine(country + ";" + categoryLevel1[i]);

                    }
                    file.WriteLine(";");
                    file.WriteLine(";");
                    file.WriteLine("Country;Category_Level2_MN;Category2_Translated_B2B;");
                    for (int i = 0; categoryLevel2.Count() > i; i++)
                    {
                        file.WriteLine(country + ";" + categoryLevel2[i]);

                    }

                    file.WriteLine(";");
                    file.WriteLine(";");
                    file.WriteLine("Country;Category_Level3_MN;Category3_Translated_B2B;");
                    for (int i = 0; categoryLevel3.Count() > i; i++)
                    {
                        file.WriteLine(country + ";" + categoryLevel3[i]);

                    }

                }

                using (StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("iso-8859-1")))
                {
                    file.WriteLine(";");
                    file.WriteLine(";");
                    file.WriteLine(";");
                    file.WriteLine("Country;Master_Color_MN;Master_color_B2B");

                    for (int i = 0; master_color.Count() > i; i++)
                    {
                        if(master_color[i] != null)
                        {
                            file.WriteLine(country + ";" + master_color[i] +";;");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did an oopsie :", ex);
            }
        }

        
        public void fetchMNData()
        {
            string country = "fi";
            HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language={country}"));

            WebReqDk.Method = "GET";
            WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
            HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

            string jsonStringDk;
            using (Stream stream = WebRespDk.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

                jsonStringDk = reader.ReadToEnd();
            }

            Console.WriteLine(jsonStringDk);

            List<MNRootObj> result = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringDk);
            List<B2BParrentProducts> productList = new List<B2BParrentProducts>();
            
            foreach (MNRootObj product in result)
            {
    //TODO === FILL COMMERCIAL TEXT
    //TODO === ADD COMMENTS
                string commercialText = "";
                string productName = product.product_name+ " " + product.short_description;
                string productShortDesc = "";
                bool alert = false;
                string alertMessage = "";
                string alertStatus = "";
                B2BParrentProducts obj = new B2BParrentProducts();

                // === CHECK IF PRODUCT NAME > 31 CHARS ===
                if (productName.Length > 31)
                {
                    obj.parrentProduct_productName = productName.Substring(0, 31);

                }
                else
                {
                    obj.parrentProduct_productName = productName;
                }

                // === CHECK IF SHORT DESC == NULL ==
                if(product.short_description == null)
                {
                    productShortDesc = "";
                    alert = true;
                    alertStatus = "red";
                    alertMessage += " Ingen short description;";
                }
                else
                {
                    // === CHECK IF SHORT DESC > 31 CHARS ===
                    if (product.short_description.Length > 31)
                    {
                        productShortDesc = product.short_description.Substring(0, 31);
                    }
                    else
                    {
                        productShortDesc = product.short_description;
                    }
                }


                obj.parrentProduct_masterId = product.master_id;
                obj.parrentProduct_parrentSku = "MN" + product.master_code;

            // === CHECK IF PRODUCT PRINT POSITIONS == NULL ===
                if (product.number_of_print_positions != null)
                {
                    obj.parrentProduct_printPositions = Int32.Parse(product.number_of_print_positions);
                }
                else
                {
                    obj.parrentProduct_printPositions = 0;
                }
                obj.parrentProduct_dimensions = product.dimensions;

            // === CHECK IF PRODUCT LENGTH == NULL ===
                if(product.length != null)
                {
                    obj.parrentProduct_length = float.Parse(product.length);
                }
                else
                {
                    obj.parrentProduct_length = 0;
                    alert = true;
                    alertStatus = "red";
                    alertMessage += " missing product length;";
                }

            // === CHECK IF PRODUCT WIDTH == NULL ===
                if (product.width != null)
                {
                    obj.parrentProduct_width = float.Parse(product.width);
                }
                else
                {
                    obj.parrentProduct_height = 0;
                    alert = true;
                    alertStatus = "red";
                    alertMessage += " missing product width;";
                }

            // === CHECK IF PRODUCT HEIGHT == NULL ===
                if (product.height != null)
                {
                    obj.parrentProduct_height = float.Parse(product.height);
                }
                else
                {
                    obj.parrentProduct_height = 0;
                    alert = true;
                    alertStatus = "red";
                    alertMessage += " missing product height;";
                }
                if(product.long_description != null && product.dimensions != null)
                {
                    obj.parrentProduct_longDescription = product.long_description + commercialText + product.dimensions;
                }
                else
                {
                    alert = true;
                    alertStatus = "red";
                    alertMessage += " No long description;";
                }
                obj.parrentProduct_shortDescription = productShortDesc;
                if (product.printable == "yes")
                {
                    obj.parrentProduct_printable = true;
                }
                else
                {
                    obj.parrentProduct_printable = false;
                }
                obj.parrentProduct_material = product.material;
                obj.parrentProduct_mainCategory = product.product_class;

            // === VALIDATING SUBCATEGORY ===
                foreach(Variant searchSubCategory in product.variants)
                {
                    obj.parrentProduct_supplierSubCategory = searchSubCategory.category_level2;
                    var foundCategory = asignCategories(searchSubCategory, country);
                    if(foundCategory != null)
                    {
                        obj.parrentProduct_subCategoryDK = foundCategory.CategoryDK;
                        obj.parrentProduct_subCategoryEN = foundCategory.Category;
                        obj.parrentProduct_subCategoryFI = foundCategory.CategoryFI;
                    }
                    else
                    {
                        alert = true;
                        alertMessage += "Missing Subcategory; ";
                        alertStatus = "red";
                    }
                }
                obj.fk_B2BCategories = null;
                obj.fk_B2BCategories = null;
                obj.alert = alert;
                obj.alertMessage = alertMessage;
                obj.alertStatus = alertStatus;

                productList.Add(obj);
                _db.B2BParrentProducts.Add(obj);
                _db.SaveChanges();

                foreach (Variant childProduct in product.variants)
                {

                    B2BProduct b2bProdcut = new B2BProduct();
                    string _productName = product.product_name + product.short_description;


                    b2bProdcut.product_sku = childProduct.sku;
                    b2bProdcut.fk_ParentSKU = obj;
                    b2bProdcut.product_ColorName = childProduct.color_description;
                    b2bProdcut.product_brandNames = product.brand;
                    b2bProdcut.product_longDescriptionDK = product.long_description;
                    b2bProdcut.product_shortDescriptionDK = productShortDesc;

                    _db.B2BProdducts.Add(b2bProdcut);
                    _db.SaveChanges();

                    int imgCount = 00;
                    Console.WriteLine(b2bProdcut);
                    //foreach(DigitalAsset img in childProduct.digital_assets)
                    //{
                    //    downloadImages(img.url, childProduct.sku + "_" + imgCount.ToString() + ".jpg");
                    //    imgCount++;
                    //}

                }
            }
            //patchProdDesc(productList, country);

        }
        public void patchProdDesc(List<B2BParrentProducts> product, string country)
        {
            string filePath = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss") + "_" + "ProductInformation" + "-" + country + ".csv";
            try
            {

                using (StreamWriter file = new StreamWriter(filePath, true, Encoding.GetEncoding("iso-8859-1")))
                {
                    file.WriteLine("Country;productName;shortDesc;longDesc;");

                    for (int i = 0; product.Count() > i; i++)
                    {
                        file.WriteLine(country + ";" + product[i].parrentProduct_productName + ";" + product[i].parrentProduct_shortDescription + "," + product[i].parrentProduct_longDescription + ",");

                    }


                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program did an oopsie :", ex);
            }
        }

        public void fetchMNPriceList()
        {
            HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/pricelist/2.0/"));

            WebReqDk.Method = "GET";
            WebReqDk.Headers.Add("x-gateway-APIKey", "538d5726-fc8e-4917-9d1e-0c6e2c7fe205");
            HttpWebResponse WebRespDk = (HttpWebResponse)WebReqDk.GetResponse();

            string jsonStringDk;
            using (Stream stream = WebRespDk.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);

                jsonStringDk = reader.ReadToEnd();
            }

            Console.WriteLine(jsonStringDk);

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            MNPriceListRoot result = JsonConvert.DeserializeObject<MNPriceListRoot>(jsonStringDk);

            foreach (Price priceObj in result.price)
            {

        // === CREATING PARRENT PRODUCT ===
                CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.CurrencyDecimalSeparator = ",";
                B2BProductPrices productPrice = new B2BProductPrices();
                var startingPrice = Math.Round(double.Parse(priceObj.price) * 1.5);
                productPrice.price_startingPriceSupplier = priceObj.price;
                productPrice.price_startingPriceDK = startingPrice.ToString();
                productPrice.price_startingPriceFI = String.Format("{0:0.00}", startingPrice * 1.75);
                productPrice.price_startingPriceEU = String.Format("{0:0.00}", startingPrice * 1.75);
                productPrice.price_validUntill = priceObj.valid_until;
                productPrice.parrentSku = priceObj.sku;


                _db.B2BProductPrices.Add(productPrice);
                _db.SaveChanges();
                if (priceObj.scale != null)
                {
        // === CHECK IF MISSING 1 INDEX / TOTAL OF 6
                    if (priceObj.scale.Count() == 6 )
                    {
                        Console.WriteLine(priceObj.scale.Count());
                        var lastMinimumPrice = float.Parse(priceObj.scale[priceObj.scale.Count() -5].price, NumberStyles.Any, ci);
                        var lastMinimumQ = Int32.Parse(priceObj.scale[priceObj.scale.Count() - 5].minimum_quantity);
                        int finallyq = 1;
                        if(lastMinimumQ <= 200000 && lastMinimumQ >= 5000){
                            finallyq = 10000;
                        }
                        else if(lastMinimumQ <= 4999 && lastMinimumQ >= 2500)
                        {
                            finallyq = 5000;
                        }
                        else if (lastMinimumQ <= 2499 && lastMinimumQ >= 1001)
                        {
                            finallyq = 2500;
                        }
                        else if (lastMinimumQ <= 1000 && lastMinimumQ >= 801)
                        {
                            finallyq = 1000;
                        }
                        else if (lastMinimumQ <= 800 && lastMinimumQ >= 500)
                        {
                            finallyq = 500;
                        }
                        else if (lastMinimumQ <= 499 && lastMinimumQ >= 250)
                        {
                            finallyq = 250;
                        }
                        else if (lastMinimumQ <= 249 && lastMinimumQ >= 125)
                        {
                            finallyq = 125;
                        }
                        else if (lastMinimumQ <= 125 && lastMinimumQ >= 50)
                        {
                            finallyq = 50;
                        }
                        else if (lastMinimumQ <= 49 && lastMinimumQ >= 1)
                        {
                            finallyq = 25;
                        }

                        Scale priceScaleMin = new Scale
                        {
                            price = lastMinimumPrice.ToString(),
                            minimum_quantity = finallyq.ToString()
                        };
                        priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin);
                    }
        // === CHECK IF MISSING 2 INDEXES / TOTAL OF 6
                    if (priceObj.scale.Count() == 5)
                    {
                        Console.WriteLine(priceObj.scale.Count());
                        var lastMinimumPrice = float.Parse(priceObj.scale[priceObj.scale.Count() - 4].price, NumberStyles.Any, ci);
                        var lastMinimumQ = Int32.Parse(priceObj.scale[priceObj.scale.Count() - 4].minimum_quantity);
                        int finallyq1 = 2;
                        int finallyq2 = 2;
                        if (lastMinimumQ <= 200000 && lastMinimumQ >= 5000)
                        {
                            finallyq1 = 10000;
                            finallyq2 = 5000;
                        }
                        else if (lastMinimumQ <= 4999 && lastMinimumQ >= 2500)
                        {
                            finallyq1 = 5000;
                            finallyq2 = 2500;
                        }
                        else if (lastMinimumQ <= 2499 && lastMinimumQ >= 1001)
                        {
                            finallyq1 = 2500;
                            finallyq2 = 1000;
                        }
                        else if (lastMinimumQ <= 1000 && lastMinimumQ >= 500)
                        {
                            finallyq1 = 1000;
                            finallyq2 = 500;
                        }
                        else if (lastMinimumQ <= 499 && lastMinimumQ >= 125)
                        {
                            finallyq1 = 250;
                            finallyq2 = 125;
                        }
                        else if (lastMinimumQ <= 124 && lastMinimumQ >= 50)
                        {
                            finallyq1 = 125;
                            finallyq2 = 50;
                        }
                        else if (lastMinimumQ <= 49 && lastMinimumQ >= 1)
                        {
                            finallyq1 = 50;
                            finallyq2 = 25;
                        }

                        Scale priceScaleMin = new Scale
                        {
                            price = lastMinimumPrice.ToString(),
                            minimum_quantity = finallyq1.ToString(),
                        };

                        Scale priceScaleMin2 = new Scale
                        {
                            price = lastMinimumPrice.ToString(),
                            minimum_quantity = finallyq2.ToString(),
                        };
                        priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin);
                        priceObj.scale.Insert(priceObj.scale.Count(),priceScaleMin2);


                    }

        // === CHECK IF MISSING 3 INDEXES / TOTAL OF 6
                    if (priceObj.scale.Count() == 4)
                    {
                        Console.WriteLine(priceObj.scale.Count());
                        var lastMinimumPrice = float.Parse(priceObj.scale[priceObj.scale.Count() - 3].price, NumberStyles.Any, ci);
                        var lastMinimumQ = Int32.Parse(priceObj.scale[priceObj.scale.Count() - 3].minimum_quantity);
                        int finallyq1 = 3;
                        int finallyq2 = 4;
                        int finallyq3 = 5;
                        if (lastMinimumQ <= 200000 && lastMinimumQ >= 5000)
                        {
                            finallyq1 = 10000;
                            finallyq2 = 5000;
                            finallyq3 = 2500;
                        }
                        else if (lastMinimumQ <= 4999 && lastMinimumQ >= 2500)
                        {
                            finallyq1 = 5000;
                            finallyq2 = 2500;
                            finallyq3 = 1000;
                        }
                        else if (lastMinimumQ <= 2499 && lastMinimumQ >= 500)
                        {
                            finallyq1 = 2500;
                            finallyq2 = 1000;
                            finallyq3 = 500;
                        }
                        else if (lastMinimumQ <= 1000 && lastMinimumQ >= 500)
                        {
                            finallyq1 = 500;
                            finallyq2 = 250;
                            finallyq3 = 125;
                        }
                        else if (lastMinimumQ <= 499 && lastMinimumQ >= 250)
                        {
                            finallyq1 = 250;
                            finallyq2 = 125;
                            finallyq3 = 50;
                        }
                        else if (lastMinimumQ <= 249 && lastMinimumQ >= 1)
                        {
                            finallyq1 = 125;
                            finallyq2 = 50;
                            finallyq3 = 25;
                        }


                        Scale priceScaleMin = new Scale
                        {
                            price = lastMinimumPrice.ToString(),
                            minimum_quantity = finallyq1.ToString(),
                        };

                        Scale priceScaleMin2 = new Scale
                        {
                            price = lastMinimumPrice.ToString(),
                            minimum_quantity = finallyq2.ToString(),
                        }; 
                        
                        Scale priceScaleMin3 = new Scale
                        {
                            price = lastMinimumPrice.ToString(),
                            minimum_quantity = finallyq3.ToString(),
                        };

                        priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin);
                        priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin2);
                        priceObj.scale.Insert(priceObj.scale.Count(), priceScaleMin3);
                    }
                    int breakLoop = 0;


            // ======== INSERTING PRICE SCALE ========
                    for (int i = priceObj.scale.Count()-1; i >= 0; i--)
                    {
                        if (priceObj.scale.Count() > i && i > breakLoop)
                        {
                            CultureInfo cd = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                            cd.NumberFormat.CurrencyDecimalSeparator = ".";
                            B2BPriceScaling priceScale = new B2BPriceScaling();

                    // === MINIMUM QUANITITY ===
                            if (Int32.Parse(priceObj.scale[i].minimum_quantity) == 1)
                            {
                                int index = priceObj.scale.FindIndex(a => Int32.Parse(a.minimum_quantity) == 1);
                                priceScale.scale_minimumQuantity = Int32.Parse(priceObj.scale[index-1].minimum_quantity) / 2;
                            }
                            else
                            {
                                priceScale.scale_minimumQuantity = Int32.Parse(priceObj.scale[i].minimum_quantity);
                            }
                            string totalPrice = "";
                            float _price = float.Parse(priceObj.scale[i].price, NumberStyles.Any, cd);

                    // === PRICE STACKERS ===
                            switch (i)
                            {
                                case 6:
                                    totalPrice = String.Format("{0:0.00}", _price * 1.75);
                                    break;
                                case 5:
                                    totalPrice = String.Format("{0:0.00}", _price * 1.65);

                                    break;
                                case 4:
                                    totalPrice = String.Format("{0:0.00}", _price * 1.6);

                                    break;
                                case 3:
                                    totalPrice = String.Format("{0:0.00}", _price * 1.55);

                                    break;
                                case 2:
                                    totalPrice = String.Format("{0:0.00}", _price * 1.5);

                                    break;
                                case 1:
                                    totalPrice = String.Format("{0:0.00}", _price * 1.45);

                                    break;

                            }
                            string totalEuPrice = String.Format("{0:0.00}", Convert.ToDouble(totalPrice) * 0.13);
                            string totalFIPrice = String.Format("{0:0.00}", Convert.ToDouble(totalPrice) * 0.79);
                            priceScale.scale_supplierPrice = priceObj.scale[i].price;
                // TODO == Round to numbers here
                    // === DK PRICES ===
                            priceScale.scale_priceDK = totalPrice;
                    // === EU PRICES===
                            priceScale.scale_priceEU = totalEuPrice;
                    // === FI PRICES ===
                            priceScale.scale_priceFI = totalFIPrice;
                            // =============================

                    // === FINALE FK_PRICEID ===
                            priceScale.fk_priceId = productPrice;


                    // == ALERTS ==
                            priceScale.alertActive = false;
                            priceScale.alert = "noAlert";

                            if (priceScale.scale_minimumQuantity == 1)
                            {
                                priceScale.alertActive = true;
                                priceScale.alert = "Error: with minimumQuanity";
                            }if(Int32.Parse(priceObj.scale[i].minimum_quantity) == 1 && priceScale.scale_minimumQuantity > 250)
                            {
                                priceScale.alertActive = true;
                                priceScale.alert = "Warning: q1 seems to high = " + priceScale.scale_minimumQuantity;
                            }

                            _db.B2BPriceScaling.Add(priceScale);
                            _db.SaveChanges();
                        }
                    }

                }
                Console.WriteLine(priceObj);
            }


        }

        public void fetchFtpFile()
        {
            //SessionOptions sessionOptions = new SessionOptions
            //{
            //    Protocol = Protocol.Ftp,
            //    HostName = "example.com",
            //    UserName = "user",
            //    Password = "mypassword",
            //    FtpSecure = FtpSecure.Explicit, // Or .Implicit
            //};

            //// Configure proxy
            //sessionOptions.AddRawSettings("ProxyMethod", "3");
            //sessionOptions.AddRawSettings("ProxyHost", "proxy");

            //using (Session session = new Session())
            //{
            //    // Connect
            //    session.Open(sessionOptions);

            //    var listing = session.ListDirectory(path);
            //}
            //// Get the object used to communicate with the server.
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftps://trasnfer.midocean.com/printinfo.xml");
            //request.Method = WebRequestMethods.Ftp.DownloadFile;

            //// This example assumes the FTP site uses anonymous logon.
            //request.Credentials = new NetworkCredential("b2bpromotion", "80876412");

            //FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            //Stream responseStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());

            //Console.WriteLine($"Download Complete, status {response.StatusDescription}");

            //reader.Close();
            //response.Close();
        }

        public async Task fetchPrintTechniques()
        {
            string xmlString = string.Empty;

            using (StreamReader r = new StreamReader("printinfo.xml"))
            {

                xmlString = r.ReadToEnd();

            }
            byte[] byteArray = Encoding.UTF8.GetBytes(xmlString);
            MemoryStream stream = new MemoryStream(byteArray);

            var s = new System.Xml.Serialization.XmlSerializer(typeof(PRINTINGINFORMATION));
            PRINTINGINFORMATION o = (PRINTINGINFORMATION)s.Deserialize(XmlReader.Create(stream));

            IEnumerable<B2BPrintTechnique> techniquesList = _db.B2BPrintTechniques;



            foreach (PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTION technique in o.pRINTING_TECHNIQUE_DESCRIPTIONSField)
            {
                supplierPrintPrice = await _db.SupplierPrintPrices.FirstOrDefaultAsync(c => c.printPrice_descId == technique.idField);
                //var = await _db.SupplierHandles.FirstOrDefaultAsync(c => c.printPrice_descId == technique.idField);

                B2BPrintTechnique printTechnique = new B2BPrintTechnique();
                printTechnique.technique_name = technique.idField;
                printTechnique.technique_description = technique.nAMEField[7].valueField;
                printTechnique.technique_supplier = "midocean";
                printTechnique.fk_supplierPriceCode = supplierPrintPrice;
                _db.B2BPrintTechniques.Add(printTechnique);
                _db.SaveChanges();
                Console.WriteLine(printTechnique);

            }

            //Console.ReadLine();

            foreach (PRINTINGINFORMATIONPRODUCT product in o.pRODUCTSField)
            {



                foreach (PRINTINGINFORMATIONPRODUCTPRINTING_POSITION printPos in product.pRINTING_POSITIONSField)
                {
                    foreach (PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE technique in printPos.pRINTING_TECHNIQUEField)
                    {
                        B2BPrintPosition b2BPrintPosition = new B2BPrintPosition();
                        b2BPrintPosition.print_supplier = o.sUPPLIERField;
                        b2BPrintPosition.print_productName = "MN"+product.pRODUCT_BASE_NUMBERField;
                        if (product.pRINT_EXPRESS_POSSIBLEField == "N")
                        {
                            b2BPrintPosition.print_express = false;
                        }
                        else
                        {
                            b2BPrintPosition.print_express = true;
                        }
                        foreach (B2BPrintTechnique fk_technique in techniquesList)
                        {
                            //B2BPrintTechnique techniqueObj = fk_technique;
                            if (technique.idField == fk_technique.technique_name)
                            {
                                b2BPrintPosition.fk_techniqueId = fk_technique;
                                Console.WriteLine(fk_technique);
                                break;
                            }

                        }
                        b2BPrintPosition.print_position = printPos.idField;
                        b2BPrintPosition.print_width = float.Parse(printPos.mAX_PRINT_SIZE_WIDTHField);
                        b2BPrintPosition.print_height = float.Parse(printPos.mAX_PRINT_SIZE_HEIGHTField);
                        _db.B2BPrintPositions.Add(b2BPrintPosition);
                        _db.SaveChanges();
                        Console.WriteLine(product);
                    }
                    //foreach (PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE technique in printPos.pRINTING_TECHNIQUEField)





                    //}

                }

            }

        }

        //=== SUB METHODS ===
        public void downloadImages(string linkName, string imgName)
        {
            using (WebClient webclient = new WebClient())
            // TODO - SAVES UNINDENTIFIED FORMAT
                webclient.DownloadFile(linkName, "assets\\images\\" + imgName);
            string serverFolder = "assets\\images\\";
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string specificFolder = Path.Combine(folder, "assets\\images\\");
            string file = @imgName;
            if (!Directory.Exists(specificFolder))
                Directory.CreateDirectory(specificFolder);
            System.IO.File.Copy(serverFolder + file, Path.Combine(specificFolder, Path.GetFileName(file)),true);
        }
        public void insertCategories()
        {

            List<B2BCategory> categories = new List<B2BCategory>();

            B2BCategory category2 = new B2BCategory
            {
                Category = "Office & work",
                CategoryDK = "Toimisto",
                CategoryFI = "Kontor & Arbejde",
            };

            B2BCategory category3 = new B2BCategory
            {
                Category = "Leisure & Outdoor life",
                CategoryDK = "Vapaa-aika & Ulkoilu",
                CategoryFI = "Fritid & Udeliv",
            };

            B2BCategory category4 = new B2BCategory
            {
                Category = "Keychains & Lanyards",
                CategoryDK = "Avaimenperät & Avainnauhat",
                CategoryFI = "Nøgleringe & Nøglesnore",
            };

            B2BCategory category6 = new B2BCategory
            {
                Category = "Notebooks & Notepads",
                CategoryFI = "Muistikirjat & Muistivihkot",
                CategoryDK = "Muistikirjat & Muistivihkot",
            };

            B2BCategory category5 = new B2BCategory
            {
                Category = "Drinking bottles and Thermos",
                CategoryFI = "Juomapullot & Termokset",
                CategoryDK = "Drikkedunke & Termoflasker",
            };
            B2BCategory category7 = new B2BCategory
            {
                Category = "Kitchen",
                CategoryFI = "Keittiö",
                CategoryDK = "Køkken",
            };
            B2BCategory category8 = new B2BCategory
            {
                Category = "Umbrellas & Raincoats",
                CategoryFI = "Sateenvarjot & Sadeasut",
                CategoryDK = "Paraplyer & Regnslag",
            };

            B2BCategory category9 = new B2BCategory
            {
                Category = "Antistress",
                CategoryFI = "Stressilelut",
                CategoryDK = "Antistress",
            };

            B2BCategory category11 = new B2BCategory
            {
                Category = "Tote Bags & Shopping Bags",
                CategoryFI = "Ostos- & Kangaskassit",
                CategoryDK = "Muleposer & Indkøbstasker",
            };

            B2BCategory category12 = new B2BCategory
            {
                Category = "Suitcase & Travel Products",
                CategoryFI = "Matkustaminen",
                CategoryDK = "Kuffert- & Rejseprodukter",
            };

            B2BCategory category13 = new B2BCategory
            {
                Category = "Bags & backpacks",
                CategoryFI = "Laukut & Reput",
                CategoryDK = "Tasker & rygsække",
            };

            B2BCategory category14 = new B2BCategory
            {
                Category = "Health & wellness",
                CategoryFI = "Hyvinvointi",
                CategoryDK = "Helse & velvære",
            };

            B2BCategory category15 = new B2BCategory
            {
                Category = "Food & Wine accessories",
                CategoryFI = "Ruoka- & Viinitarvikkeet",
                CategoryDK = "Mad- & Vintilbehør",
            };

            B2BCategory category16 = new B2BCategory
            {
                Category = "At home",
                CategoryFI = "Koti",
                CategoryDK = "Hjemme",
            };

            B2BCategory category17 = new B2BCategory
            {
                Category = "Flashlights & Tools",
                CategoryFI = "Taskulamput & Työkalut",
                CategoryDK = "Lommelygter & Værktøj",
            };

            B2BCategory category18 = new B2BCategory
            {
                Category = "Pens & Pencils",
                CategoryFI = "Kynät & Kirjoitusvälineet",
                CategoryDK = "Kuglepenne & Blyanter",
            };



            B2BCategory category19 = new B2BCategory
            {
                Category = "Document & Portfolio",
                CategoryFI = "Dokumenttikansiot & Portfoliot",
                CategoryDK = "Dokument & Portfolio",
            };

            B2BCategory category20 = new B2BCategory
            {
                Category = "Toys & Games",
                CategoryFI = "Lelut & Pelit",
                CategoryDK = "Legetøj & Spil",
            };

            B2BCategory category21 = new B2BCategory
            {
                Category = "Hats",
                CategoryFI = "Päähineet",
                CategoryDK = "Huer",
            };

            B2BCategory category22 = new B2BCategory
            {
                Category = "Health & wellness",
                CategoryFI = "Hyvinvointi",
                CategoryDK = "Helse & velvære",
            };

            B2BCategory category23 = new B2BCategory
            {
                Category = "USB & Accessories",
                CategoryFI = "USB & Tarvikkeet",
                CategoryDK = "USB & Tilbehør",
            };


            B2BCategory category24 = new B2BCategory
            {
                Category = "Belts & Accessories",
                CategoryFI = "Vyöt & Asusteet",
                CategoryDK = "Bælter & Accessories",
            };

            B2BCategory category25 = new B2BCategory
            {
                Category = "Electronics & Gadgets",
                CategoryFI = "Elektroniikka & Laitteet",
                CategoryDK = "Elektronik & Gadgets",
            };

            B2BCategory category26 = new B2BCategory
            {
                Category = "Health & wellness",
                CategoryFI = "Hyvinvointi",
                CategoryDK = "Helse & velvære",
            };

            categories.Add(category2);
            categories.Add(category3);
            categories.Add(category4);
            categories.Add(category5);
            categories.Add(category6);
            categories.Add(category7);
            categories.Add(category8);
            categories.Add(category9);
            categories.Add(category11);
            categories.Add(category12);
            categories.Add(category13);
            categories.Add(category14);
            categories.Add(category15);
            categories.Add(category16);
            categories.Add(category17);
            categories.Add(category18);
            categories.Add(category19);
            categories.Add(category20);
            categories.Add(category21);
            categories.Add(category22);
            categories.Add(category23);
            categories.Add(category24);
            categories.Add(category25);
            categories.Add(category26);

            for(int i = 0; categories.Count > i; i++)
            {
                _db.B2BCategories.Add(categories[i]);
                _db.SaveChanges();
            }


        }

        public B2BCategory asignCategories(Variant product, string country)
        {
            B2BCategory category;

            if (country == "fi")
            {

            switch (product.category_level2)
            {
                case "Office accessories":
                    category = new B2BCategory
                    {
                        Category = "Office & work",
                        CategoryDK = "Toimisto",
                        CategoryFI = "Kontor & Arbejde",
                    };
                    return category;
                case "Outdoor":
                    category = new B2BCategory
                    {
                        Category = "Leisure & Outdoor life",
                        CategoryDK = "Vapaa-aika & Ulkoilu",
                        CategoryFI = "Fritid & Udeliv",
                    };
                    return category;
                case "Key rings":
                    category = new B2BCategory
                    {
                        Category = "Keychains & Lanyards",
                        CategoryDK = "Avaimenperät & Avainnauhat",
                        CategoryFI = "Nøgleringe & Nøglesnore",
                    };
                    return category;
                case "Notebooks":
                    category = new B2BCategory
                    {
                        Category = "Notebooks & Notepads",
                        CategoryFI = "Muistikirjat & Muistivihkot",
                        CategoryDK = "Muistikirjat & Muistivihkot",
                    };
                    return category;
                case "Drinkware":
                    category = new B2BCategory
                    {
                        Category = "Drinking bottles and Thermos",
                        CategoryFI = "Juomapullot & Termokset",
                        CategoryDK = "Drikkedunke & Termoflasker",
                    };
                    return category;
                case "Stuffed animals":
                    category = new B2BCategory
                    {
                        Category = "Toys & Games",
                        CategoryFI = "Lelut & Pelit",
                        CategoryDK = "Legetøj & Spil",
                    };
                    return category;
                case "Kitchenware":
                    category = new B2BCategory
                    {
                        Category = "Kitchen",
                        CategoryFI = "Keittiö",
                        CategoryDK = "Køkken",
                    };
                    return category;
                case "Rain gear":
                    category = new B2BCategory
                    {
                        Category = "Umbrellas & Raincoats",
                        CategoryFI = "Sateenvarjot & Sadeasut",
                        CategoryDK = "Paraplyer & Regnslag",
                    };
                    return category;
                case "Anti stress/Candies":
                    category = new B2BCategory
                    {
                        Category = "Antistress",
                        CategoryFI = "Stressilelut",
                        CategoryDK = "Antistress",
                    };
                    return category;
                case "Shopping bags":
                    category = new B2BCategory
                    {
                        Category = "Tote Bags & Shopping Bags",
                        CategoryFI = "Ostos- & Kangaskassit",
                        CategoryDK = "Muleposer & Indkøbstasker",
                    };
                    return category;
                case "Travel accessories":
                    category = new B2BCategory
                    {
                        Category = "Suitcase & Travel Products",
                        CategoryFI = "Matkustaminen",
                        CategoryDK = "Kuffert- & Rejseprodukter",
                    };
                    return category;
                case "Backpacks & Business bags":
                    category = new B2BCategory
                    {
                        Category = "Bags & backpacks",
                        CategoryFI = "Laukut & Reput",
                        CategoryDK = "Tasker & rygsække",
                    };
                    return category;
                case "Personal care":
                    category = new B2BCategory
                    {
                        Category = "Health & wellness",
                        CategoryFI = "Hyvinvointi",
                        CategoryDK = "Helse & velvære",
                    };
                    return category;
                case "Barware":
                    category = new B2BCategory
                    {
                        Category = "Food & Wine accessories",
                        CategoryFI = "Ruoka- & Viinitarvikkeet",
                        CategoryDK = "Mad- & Vintilbehør",
                    };
                    return category;
                case "Home & Living":
                    category = new B2BCategory
                    {
                        Category = "At home",
                        CategoryFI = "Koti",
                        CategoryDK = "Hjemme",
                    };
                    return category;
                case "Tools & Torches":
                    category = new B2BCategory
                    {
                        Category = "Flashlights & Tools",
                        CategoryFI = "Taskulamput & Työkalut",
                        CategoryDK = "Lommelygter & Værktøj",
                    };
                    return category;
                case "Writing":
                    category = new B2BCategory
                    {
                        Category = "pens & pencils",
                        CategoryFI = "kynät & kirjoitusvälineet",
                        CategoryDK = "kuglepenne & blyanter",
                    };
                    return category;
                case "Portfolios":
                    category = new B2BCategory
                    {
                        Category = "Document & Portfolio",
                        CategoryFI = "Dokumenttikansiot & Portfoliot",
                        CategoryDK = "Dokument & Portfolio",
                    };
                    return category;
                case "Head gear":
                    category = new B2BCategory
                    {
                        Category = "Hats",
                        CategoryFI = "Päähineet",
                        CategoryDK = "Huer",
                    };
                    return category;
                case "Games":
                    category = new B2BCategory
                    {
                        Category = "Toys & Games",
                        CategoryFI = "Lelut & Pelit",
                        CategoryDK = "Legetøj & Spil",
                    };
                    return category;
                case "Car accessories":
                    category = new B2BCategory
                    {
                        Category = "Leisure & Outdoor life",
                        CategoryDK = "Vapaa-aika & Ulkoilu",
                        CategoryFI = "Fritid & Udeliv",
                    };
                    return category;
                case "Umbrellas":
                    category = new B2BCategory
                    {
                        Category = "Umbrellas & Raincoats",
                        CategoryFI = "Sateenvarjot & Sadeasut",
                        CategoryDK = "Paraplyer & Regnslag",
                    };
                    return category;
                case "Sport & Health":
                    category = new B2BCategory
                    {
                        Category = "Leisure & Outdoor life",
                        CategoryDK = "Vapaa-aika & Ulkoilu",
                        CategoryFI = "Fritid & Udeliv",
                    };
                    return category;
                case "First aid":
                    category = new B2BCategory
                    {
                        Category = "Health & wellness",
                        CategoryFI = "Hyvinvointi",
                        CategoryDK = "Helse & velvære",
                    };
                    return category;
                case "USBs":
                    category = new B2BCategory
                    {
                        Category = "USB & Accessories",
                        CategoryFI = "USB & Tarvikkeet",
                        CategoryDK = "USB & Tilbehør",
                    };
                    return category;
                case "Chargers":
                    category = new B2BCategory
                    {
                        Category = "Electronics & Gadgets",
                        CategoryFI = "Elektroniikka & Laitteet",
                        CategoryDK = "Elektronik & Gadgets",
                    };
                    return category;
                case "Phone accessories":
                    category = new B2BCategory
                    {
                        Category = "Electronics & Gadgets",
                        CategoryFI = "Elektroniikka & Laitteet",
                        CategoryDK = "Elektronik & Gadgets",
                    };
                    return category;
                case "Eye wear":
                    category = new B2BCategory
                    {
                        Category = "Belts & Accessories",
                        CategoryFI = "Vyöt & Asusteet",
                        CategoryDK = "Bælter & Accessories",
                    };
                    return category;
                case "Lunchware":
                    category = new B2BCategory
                    {
                        Category = "Kitchen",
                        CategoryFI = "Keittiö",
                        CategoryDK = "Køkken",
                    };
                    return category;
                case "Audio & Sound":
                    category = new B2BCategory
                    {
                        Category = "Electronics & Gadgets",
                        CategoryFI = "Elektroniikka & Laitteet",
                        CategoryDK = "Elektronik & Gadgets",
                    };
                    return category;
                case "Wireless Chargers":
                    category = new B2BCategory
                    {
                        Category = "Electronics & Gadgets",
                        CategoryFI = "Elektroniikka & Laitteet",
                        CategoryDK = "Elektronik & Gadgets",
                    };
                    return category;
                case "Power banks":
                    category = new B2BCategory
                    {
                        Category = "Electronics & Gadgets",
                        CategoryFI = "Elektroniikka & Laitteet",
                        CategoryDK = "Elektronik & Gadgets",
                    };
                    return category;
                case "Windproof Umbrellas":
                    category = new B2BCategory
                    {
                        Category = "Umbrellas & Raincoats",
                        CategoryFI = "Sateenvarjot & Sadeasut",
                        CategoryDK = "Paraplyer & Regnslag",
                    };
                    return category;
                case "Care essentials":
                    category = new B2BCategory
                    {
                        Category = "Health & wellness",
                        CategoryFI = "Hyvinvointi",
                        CategoryDK = "Helse & velvære",
                    };
                    return category;
                default:
                    return null;
                }
            }
            if(country == "dk")
            {
                switch (product.category_level2)
                {
                    case "Kontorstilbehør":
                        category = new B2BCategory
                        {
                            Category = "Office & work",
                            CategoryDK = "Toimisto",
                            CategoryFI = "Kontor & Arbejde",
                        };
                        return category;
                    case "Udendørs":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "Nøgleringe":
                        category = new B2BCategory
                        {
                            Category = "Keychains & Lanyards",
                            CategoryDK = "Avaimenperät & Avainnauhat",
                            CategoryFI = "Nøgleringe & Nøglesnore",
                        };
                        return category;
                    case "Notesbøger":
                        category = new B2BCategory
                        {
                            Category = "Notebooks & Notepads",
                            CategoryFI = "Muistikirjat & Muistivihkot",
                            CategoryDK = "Muistikirjat & Muistivihkot",
                        };
                        return category;
                    case "Drikkevarer":
                        category = new B2BCategory
                        {
                            Category = "Drinking bottles and Thermos",
                            CategoryFI = "Juomapullot & Termokset",
                            CategoryDK = "Drikkedunke & Termoflasker",
                        };
                        return category;
                    case "Bamser":
                        category = new B2BCategory
                        {
                            Category = "Toys & Games",
                            CategoryFI = "Lelut & Pelit",
                            CategoryDK = "Legetøj & Spil",
                        };
                        return category;
                    case "Køkkenprodukter":
                        category = new B2BCategory
                        {
                            Category = "Kitchen",
                            CategoryFI = "Keittiö",
                            CategoryDK = "Køkken",
                        };
                        return category;
                    case "Regntøj":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    case "Anti stress/slik":
                        category = new B2BCategory
                        {
                            Category = "Antistress",
                            CategoryFI = "Stressilelut",
                            CategoryDK = "Antistress",
                        };
                        return category;
                    case "Indkøbsposer":
                        category = new B2BCategory
                        {
                            Category = "Tote Bags & Shopping Bags",
                            CategoryFI = "Ostos- & Kangaskassit",
                            CategoryDK = "Muleposer & Indkøbstasker",
                        };
                        return category;
                    case "Rejsetilbehør":
                        category = new B2BCategory
                        {
                            Category = "Suitcase & Travel Products",
                            CategoryFI = "Matkustaminen",
                            CategoryDK = "Kuffert- & Rejseprodukter",
                        };
                        return category;
                    case "Rygsæk & Portofølger":
                        category = new B2BCategory
                        {
                            Category = "Bags & backpacks",
                            CategoryFI = "Laukut & Reput",
                            CategoryDK = "Tasker & rygsække",
                        };
                        return category;
                    case "Personlig pleje":
                        category = new B2BCategory
                        {
                            Category = "Health & wellness",
                            CategoryFI = "Hyvinvointi",
                            CategoryDK = "Helse & velvære",
                        };
                        return category;
                    case "Barprodukter":
                        category = new B2BCategory
                        {
                            Category = "Food & Wine accessories",
                            CategoryFI = "Ruoka- & Viinitarvikkeet",
                            CategoryDK = "Mad- & Vintilbehør",
                        };
                        return category;
                    case "Hjem & Livsstil":
                        category = new B2BCategory
                        {
                            Category = "At home",
                            CategoryFI = "Koti",
                            CategoryDK = "Hjemme",
                        };
                        return category;
                    case "Værktøj og Lommelygter":
                        category = new B2BCategory
                        {
                            Category = "Flashlights & Tools",
                            CategoryFI = "Taskulamput & Työkalut",
                            CategoryDK = "Lommelygter & Værktøj",
                        };
                        return category;
                    case "Skriveredskaber":
                        category = new B2BCategory
                        {
                            Category = "pens & pencils",
                            CategoryFI = "kynät & kirjoitusvälineet",
                            CategoryDK = "kuglepenne & blyanter",
                        };
                        return category;
                    case "Portofølger":
                        category = new B2BCategory
                        {
                            Category = "Document & Portfolio",
                            CategoryFI = "Dokumenttikansiot & Portfoliot",
                            CategoryDK = "Dokument & Portfolio",
                        };
                        return category;
                    case "Kasketter & Huer":
                        category = new B2BCategory
                        {
                            Category = "Hats",
                            CategoryFI = "Päähineet",
                            CategoryDK = "Huer",
                        };
                        return category;
                    case "Spil":
                        category = new B2BCategory
                        {
                            Category = "Toys & Games",
                            CategoryFI = "Lelut & Pelit",
                            CategoryDK = "Legetøj & Spil",
                        };
                        return category;
                    case "Biltilbehør":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "Paraplyer":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    case "Sport & Sundhed":
                        category = new B2BCategory
                        {
                            Category = "Leisure & Outdoor life",
                            CategoryDK = "Vapaa-aika & Ulkoilu",
                            CategoryFI = "Fritid & Udeliv",
                        };
                        return category;
                    case "Førstehjælp":
                        category = new B2BCategory
                        {
                            Category = "Health & wellness",
                            CategoryFI = "Hyvinvointi",
                            CategoryDK = "Helse & velvære",
                        };
                        return category;
                    case "USB":
                        category = new B2BCategory
                        {
                            Category = "USB & Accessories",
                            CategoryFI = "USB & Tarvikkeet",
                            CategoryDK = "USB & Tilbehør",
                        };
                        return category;
                    case "Opladere":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Mobiltilbehør":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Solbriller":
                        category = new B2BCategory
                        {
                            Category = "Belts & Accessories",
                            CategoryFI = "Vyöt & Asusteet",
                            CategoryDK = "Bælter & Accessories",
                        };
                        return category;
                    case "Madkasse":
                        category = new B2BCategory
                        {
                            Category = "Kitchen",
                            CategoryFI = "Keittiö",
                            CategoryDK = "Køkken",
                        };
                        return category;
                    case "Audio & lyd":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Trådløse opladere":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Powerbanks":
                        category = new B2BCategory
                        {
                            Category = "Electronics & Gadgets",
                            CategoryFI = "Elektroniikka & Laitteet",
                            CategoryDK = "Elektronik & Gadgets",
                        };
                        return category;
                    case "Stormsikker paraply":
                        category = new B2BCategory
                        {
                            Category = "Umbrellas & Raincoats",
                            CategoryFI = "Sateenvarjot & Sadeasut",
                            CategoryDK = "Paraplyer & Regnslag",
                        };
                        return category;
                    default:
                        return null;
                }
            }
            return null;

        }
    }
}
