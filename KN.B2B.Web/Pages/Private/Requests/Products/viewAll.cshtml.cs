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

namespace KN.B2B.Web.Pages.Private.Requests.Products
{
    public class viewAllModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly B2BDbContext _db;
        private readonly IConfiguration _config;

        public string message { get; set; }
        public string searchQuery { get; set; }

        public IEnumerable<B2BParrentProducts> parrentProductsList { get; set; }



        public viewAllModel(B2BDbContext db, ILogger<IndexModel> logger, IConfiguration config)
        {
            _db = db;
            _config = config;
        }



        public async Task OnGetAsync()
        {
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
                parrentProductsList = await _db.B2BParrentProducts
                    //.Include(x => x.parrentProduct_productName)
                    //.Include(x => x.parrentProduct_shortDescription)
                    .OrderByDescending(x => x.parrentProduct_id)
                    .ToListAsync();
            //fetchMNData();
            //sendMail();
            //fetchFtpFile();
            //fetchXmlFiles();
            //fetchMNPriceList();
            //fetchTechniquePrices();
            //fetchMNManipulations();
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
                handleObj.handles_price = float.Parse(maniItem.price);

                _db.SupplierHandles.Add(handleObj);
                _db.SaveChanges();
            }
        }
        public void fetchTechniquePrices() {
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


            foreach (PrintTechnique printTechnique in result.print_techniques)
            {
            SupplierPrintPrice printObj = new SupplierPrintPrice();
            //printObj.printPrice_id = 
            printObj.printPrice_description = printTechnique.description;
            printObj.printPrice_pricingType = printTechnique.pricing_type;
            printObj.printPrice_setup = printTechnique.setup;
            printObj.printPrice_repeat = printTechnique.setup_repeat;
            printObj.printPrice_nextColourIndicator = printTechnique.next_colour_cost_indicator;

            _db.SupplierPrintPrices.Add(printObj);
            _db.SaveChanges();


            foreach(VarCost varCost in printTechnique.var_costs)
            {
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

                _db.SupplierPrintCosts.Add(costObj);
                _db.SaveChanges();

                foreach(Scales scale in varCost.scales)
                {
                    CultureInfo cv = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    cv.NumberFormat.CurrencyDecimalSeparator = ",";
                    SupplierPrintPriceScales scaleObj = new SupplierPrintPriceScales();
                    scaleObj.scale_minimumQuantity = float.Parse(scale.minimum_quantity);
                    scaleObj.scale_price = float.Parse(scale.price);
                    if(scale.next_price != "")
                    {
                        scaleObj.scale_nextPrice = float.Parse(scale.next_price);

                    }
                    else
                    {
                        scaleObj.scale_nextPrice = 0;
                    }
                    scaleObj.fk_supplerPrintCost = costObj;

                    _db.SupplierPrintPriceScales.Add(scaleObj);
                    _db.SaveChanges();

                }
            }
                Console.WriteLine(printObj);
            }

        }

        public void fetchMNData()
        {
            HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/products/2.0?language=da"));

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
            List<MNRootObj> result = JsonConvert.DeserializeObject<List<MNRootObj>>(jsonStringDk);
            Console.WriteLine(result);
            foreach (MNRootObj product in result)
            {

                //B2BCategory b2Bcategory = new B2BCategory
                //{
                    //Id = 1;
                    //        CategoryGroup 
                    //        Category
                    //        CategoryDK
                    //    }

                B2BParrentProducts obj = new B2BParrentProducts();
                obj.parrentProduct_productName = product.product_name;
                obj.parrentProduct_masterId = Int32.Parse(product.master_id);
                obj.parrentProduct_parrentSku = product.master_code;
                obj.parrentProduct_printPositions = Int32.Parse(product.number_of_print_positions);
                obj.parrentProduct_dimensions = product.dimensions;
                obj.parrentProduct_length = float.Parse(product.length);
                obj.parrentProduct_width = float.Parse(product.width);
                obj.parrentProduct_height = float.Parse(product.height);
                obj.parrentProduct_longDescription = product.long_description;
                obj.parrentProduct_shortDescription = product.short_description;
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
                obj.parrentProduct_subCategory = "none";
                obj.fk_B2BCategories = null;
                obj.fk_B2BCategories = null;

                _db.B2BParrentProducts.Add(obj);
                _db.SaveChanges();

                foreach (Variant childProduct in product.variants)
                {
                    B2BProduct b2bProdcut = new B2BProduct();
                    b2bProdcut.product_sku = childProduct.sku;
                    b2bProdcut.fk_ParentSKU = obj;
                    b2bProdcut.product_ColorName = childProduct.color_description;
                    b2bProdcut.product_brandNames = product.brand;
                    b2bProdcut.product_shortDescriptionDK = product.short_description;
                    b2bProdcut.product_longDescriptionDK = product.long_description;

                    _db.B2BProdducts.Add(b2bProdcut);
                    _db.SaveChanges();

                    Console.WriteLine(b2bProdcut);

                }


                Console.WriteLine(obj);

            }

            //Console.WriteLine(myDeserializedClass);

        }

        public void fetchMNPriceList()
        {
            HttpWebRequest WebReqDk = (HttpWebRequest)WebRequest.Create(string.Format($"https://api.midocean.com/gateway/pricelist/2.0/"));

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
            MNPriceListRoot result = JsonConvert.DeserializeObject<MNPriceListRoot>(jsonStringDk);

            foreach (Price priceObj in result.price)
            {
                CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.CurrencyDecimalSeparator = ",";
                B2BProductPrices productPrice = new B2BProductPrices();
                productPrice.price_startingPrice = priceObj.price;
                productPrice.price_validUntill = priceObj.valid_until;
                productPrice.parrentSku = priceObj.sku;


                _db.B2BProductPrices.Add(productPrice);
                _db.SaveChanges();
                if (priceObj.scale != null)
                {
                    foreach (Scale scaleObj in priceObj.scale)
                    {
                        CultureInfo cd = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        cd.NumberFormat.CurrencyDecimalSeparator = ".";
                        B2BPriceScaling priceScale = new B2BPriceScaling();
                        priceScale.scale_minimumQuantity = Int32.Parse(scaleObj.minimum_quantity);
                        priceScale.scale_price = float.Parse(scaleObj.price, NumberStyles.Any, cd);
                        priceScale.fk_priceId = productPrice;

                        _db.B2BPriceScaling.Add(priceScale);
                        _db.SaveChanges();
                    }


                }



                Console.WriteLine(priceObj);
                //foreach(Price priceObj in rootObj.price)
                //{

                //}


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

        public void fetchXmlFiles()
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



            //foreach(PRINTINGINFORMATIONPRINTING_TECHNIQUE_DESCRIPTION technique in o.pRINTING_TECHNIQUE_DESCRIPTIONSField)
            //{
            //    B2BPrintTechnique printTechnique = new B2BPrintTechnique();
            //    printTechnique.technique_name = technique.idField;
            //    printTechnique.technique_description = technique.nAMEField[7].valueField;
            //    _db.B2BPrintTechniques.Add(printTechnique);
            //    _db.SaveChanges();
            //    Console.WriteLine(printTechnique);

            //}

            //Console.ReadLine();

            foreach (PRINTINGINFORMATIONPRODUCT product in o.pRODUCTSField)
            {



                foreach (PRINTINGINFORMATIONPRODUCTPRINTING_POSITION printPos in product.pRINTING_POSITIONSField)
                {
                    foreach(PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE technique in printPos.pRINTING_TECHNIQUEField)
                    {
                        B2BPrintPosition b2BPrintPosition = new B2BPrintPosition();
                        b2BPrintPosition.print_supplier = o.sUPPLIERField;
                        b2BPrintPosition.Position = product.pRODUCT_BASE_NUMBERField;
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
        //foreach (PRINTINGINFORMATIONPRODUCTPRINTING_POSITIONPRINTING_TECHNIQUE technique in printPos.pRINTING_TECHNIQUEField)
        //{

        //                                foreach(B2BPrintTechnique fk_technique in techniquesList)
        //                        {
        //                            //B2BPrintTechnique techniqueObj = fk_technique;
        //                            if(technique.idField == fk_technique.technique_name)
        //                            {
        //                                b2BPrintPosition.fk_techniqueId = fk_technique;
        //                            }
        //}
        //}

    }
}
