using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KN.B2B.Model.SupplierTables.MidoceanAPI.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace KN.B2B.Web.Pages.Private.Requests.Products
{
    public class viewAllModel : PageModel
    {
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

            var result = JsonConvert.DeserializeObject<MNRootobject>(jsonStringDk, settings);

            Console.WriteLine(result);

        }


    }
}
