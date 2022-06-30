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
using KN.B2B.Web.Services.Products;

namespace KN.B2B.Web.Pages.Private.Requests.Products
{
    public class viewAllModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly B2BDbContext _db;
        private readonly IConfiguration _config;
        public ExportProducts _exportProducts;

        SupplierPrintPrice supplierPrintPrice { get; set; }


        public B2BProduct B2BProduct { get; set; }

        public PaginatedList<B2BParrentProducts> productPaging { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string message { get; set; }
        public string searchQuery { get; set; }

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

            var pageSize = _config.GetValue("PageSize", 4);
            productPaging = await PaginatedList<B2BParrentProducts>.CreateAsync(
                products.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
       
    }
}
