using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KN.B2B.Data;
using KN.B2B.Model.products;
using KN.B2B.Model.SupplierTables.MidoceanAPI.Products;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace KN.B2B.Web.Pages.Private.Requests.Products
{
    public class viewAllModel : PageModel
    {
        private readonly B2BDbContext _db;

        public viewAllModel(B2BDbContext db)
        {
            _db = db;
        }



        public void OnGet()
        {
            getMNData();
        }

        public void getMNData()
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
            //var result = JsonConvert.DeserializeObject<List<Rootobject>>(jsonStringDk);

            //var result = JsonConvert.DeserializeObject<MNRootobject>(jsonStringDk, settings);

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


                Console.WriteLine(obj);

            }

            //Console.WriteLine(myDeserializedClass);

        }


    }
}
