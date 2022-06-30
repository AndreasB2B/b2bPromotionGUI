using KN.B2B.Data;
using KN.B2B.Model;
using KN.B2B.Model.products;
using KN.B2B.Model.products.B2BPrintPositions;
using KN.B2B.Model.products.productPrice;
using KN.B2B.Model.SystemTables;
using KN.B2B.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web
{
    public static class LoadCollections
    {

        public static async Task<List<B2BProduct>> LoadAllProducts(B2BDbContext _context)
        {

            List<B2BProduct> products = await _context.B2BProdducts.ToListAsync();
            return products;
        }

        public static async Task<bool> DoesProductExist(B2BDbContext _context, CustomProduct customProduct)
        {

            B2BProduct childProduct = await _context.B2BProdducts.FirstOrDefaultAsync(x => x.product_sku == customProduct.SKU);

            if(childProduct == null)
            {
                return false;
            }

            return true;
        }

        public static async Task<bool> DoesParrentProductExist(B2BDbContext _context, CustomProduct customProduct)
        {
            B2BParrentProducts parrentProduct = await _context.B2BParrentProducts.FirstOrDefaultAsync(x => x.parrentProduct_masterId == customProduct.ParentSKU);

            if (parrentProduct == null)
            {
                return false;
            }

            return true;
        }
        public static async Task<List<B2BParrentProducts>> LoadAllParrentProducts(B2BDbContext _context)
        {

            List<B2BParrentProducts> products = await _context.B2BParrentProducts.ToListAsync();
            return products;
        }
        public static async Task<IEnumerable<B2BProductPrices>> LoadAllProductPrices(B2BDbContext _context)
        {

            IEnumerable<B2BProductPrices> productPrices = await _context.B2BProductPrices.ToListAsync();
            return productPrices;
        }

        public static async Task<List<B2BPriceScaling>> LoadAllPriceScales(B2BDbContext _context)
        {

            List<B2BPriceScaling> productPricesScaling = await _context.B2BPriceScaling.ToListAsync();
            return productPricesScaling;
        }

        public static async Task<List<SupplierPrintCost>> LoadAllSupplierPrintCosts(B2BDbContext _context)
        {

            List<SupplierPrintCost> supplierPrintCosts = await _context.SupplierPrintCosts.ToListAsync();
            return supplierPrintCosts;
        }

        public static async Task<List<SupplierPrintPrice>> LoadAllSupplierPrintPrices(B2BDbContext _context)
        {

            List<SupplierPrintPrice> supplierPrintPrices = await _context.SupplierPrintPrices.ToListAsync();
            return supplierPrintPrices;
        }

        public static async Task<List<SupplierPrintPriceScales>> LoadAllSupplierPrintPriceScales(B2BDbContext _context)
        {

            List<SupplierPrintPriceScales> supplierPrintPriceScales = await _context.SupplierPrintPriceScales.ToListAsync();
            return supplierPrintPriceScales;
        }

        public static async Task<List<B2BPrintTechnique>> LoadAllPrintTechniques(B2BDbContext _context)
        {

            List<B2BPrintTechnique> printTechniques = await _context.B2BPrintTechniques.ToListAsync();
            return printTechniques;
        }

        public static async Task<List<B2BPrintPosition>> LoadAllPrintPositions(B2BDbContext _context)
        {

            List<B2BPrintPosition> printPositions = await _context.B2BPrintPositions.ToListAsync();
            return printPositions;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadCustomers(B2BDbContext _context)
        {
            var selectList = new List<SelectListItem>();
            var customers = await _context.Customers.Select(x => x).OrderBy(x => x.Name).ToListAsync();
            foreach (var customer in customers)
            {
                selectList.Add(new SelectListItem(customer.Name, customer.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<List<B2BProduct>> LoadProductsWherePId(B2BDbContext _context, int? parrentId)
        {
            var products = await _context.B2BProdducts.Where(x => x.fk_ParentSKU.parrentProduct_id == parrentId).ToListAsync();
            
            return products;
        }

        public static async Task<IEnumerable<B2BPrintPosition>> LoadPrintPositionsWProductSKU(B2BDbContext _context, string parrentSku)
        {
            var position = await _context.B2BPrintPositions.Where(x => x.print_productName == parrentSku).ToListAsync();

            return position;
        }
        public static async Task<IEnumerable<B2BPriceScaling>> LoadProductPricesWSku(B2BDbContext _context, string parrentSku)
        {
            IEnumerable<B2BPriceScaling> printPrices;
            B2BProductPrices productPrices;

            productPrices = await _context.B2BProductPrices.FirstOrDefaultAsync(x => x.parrentSku == parrentSku);
            printPrices = await _context.B2BPriceScaling.Where(x => x.fk_priceId.id == productPrices.id).ToListAsync();

            return printPrices;
        }

        public static async Task<IEnumerable<SupplierPrintPrice>> LoadAllPrintPrices(B2BDbContext _context)
        {
            IEnumerable<SupplierPrintPrice> printPrices;
            printPrices = await _context.SupplierPrintPrices.ToListAsync();

            return printPrices;
        }

        //public static async Task<IEnumerable<B2BPrintTechnique>> LoadAllPrintTechniques(B2BDbContext _context)
        //{
        //    IEnumerable<B2BPrintTechnique> techniques;
        //    techniques = await _context.B2BPrintTechniques.ToListAsync();

        //    //techniques = await _context.B2BPrintTechniques.Where(x => x.technique_description == "Doming").ToListAsync();

        //    return techniques;
        //}

        public static async Task<IEnumerable<RequestCommunication>> LoadCommunications(B2BDbContext _context, int requestId)
        {
            var customers = await _context.RequestCommunications.Where(x => x.Request.Id == requestId)
                                                                .OrderByDescending(x => x.Date)
                                                                .ToListAsync();
            return customers;
        }

        public static async Task<IEnumerable<RequestProduct>> LoadProducts(B2BDbContext _context, int requestId)
        {
            var products = await _context.RequestProducts.Include(x => x.B2BCategory)
                                                         .Include(x => x.Supplier)
                                                         .Where(x => x.Request.Id == requestId)
                                                         .ToListAsync();
            return products;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadZipCodes(B2BDbContext _context)
        {
            var selectList = new List<SelectListItem>();
            var zipCodes = await _context.ZipCodes.ToListAsync();
            foreach (var code in zipCodes)
            {
                selectList.Add(new SelectListItem(code.ToString(), code.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadZipCodesRedux(B2BDbContext _context, bool orderAlphabetically = false)
        {
            var selectList = new List<SelectListItem>();
            List<ZipCode> zipCodes = null;
            if (orderAlphabetically)
                zipCodes = await _context.ZipCodes.OrderBy(x => x.City).ToListAsync();
            else
                zipCodes = await _context.ZipCodes.ToListAsync();
            
            var zipCodesRedux = Converter.CrunchZipCodes(zipCodes);
            foreach (var code in zipCodesRedux)
            {
                selectList.Add(new SelectListItem(code.ToString(), code.Zip));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadJobTitles(B2BDbContext _context)
        {
            var selectList = new List<SelectListItem>();
            var titles = await _context.JobTitles.ToListAsync();
            foreach (var title in titles)
            {
                selectList.Add(new SelectListItem(title.Title, title.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadIndustries(B2BDbContext _context, bool orderAlphabetically = false)
        {
            var selectList = new List<SelectListItem>();

            List<DUNSGroup> industries = null;
            if (orderAlphabetically)
                industries = await _context.Industries.OrderBy(x => x.Industry).ToListAsync();
            else
                industries = await _context.Industries.ToListAsync();

            foreach (var industry in industries)
            {
                selectList.Add(new SelectListItem(industry.Industry, industry.Id.ToString()));
            }

            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadSuppliers(B2BDbContext _context)
        {
            var selectList = new List<SelectListItem>();
            var suppliers = await _context.Suppliers.ToListAsync();
            foreach (var supplier in suppliers)
            {
                selectList.Add(new SelectListItem(supplier.Name, supplier.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadB2BCategories(B2BDbContext _context)
        {
            var selectList = new List<SelectListItem>();
            var b2bCats = await _context.B2BCategories.ToListAsync();
            foreach (var cat in b2bCats)
            {
                selectList.Add(new SelectListItem(cat.Category, cat.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadComplaints(B2BDbContext _context)
        {
            var selectList = new List<SelectListItem>();
            var complaints = await _context.Complaints.ToListAsync();
            foreach (var complaint in complaints)
            {
                selectList.Add(new SelectListItem(complaint.Cause, complaint.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadStartStatuses(B2BDbContext _context, bool includeEmptyRow = true)
        {
            var selectList = new List<SelectListItem>();
            var statuses = await _context.StartStatuses.ToListAsync();

            //start with an empty option, since the field is not mandatory
            if (includeEmptyRow)
                selectList.Add(new SelectListItem("", ""));

            foreach (var status in statuses)
            {
                selectList.Add(new SelectListItem(status.Status, status.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadEndStatuses(B2BDbContext _context, bool includeEmptyRow = true)
        {
            var selectList = new List<SelectListItem>();
            var statuses = await _context.EndStatuses.ToListAsync();

            //start with an empty option, since the field is not mandatory
            if (includeEmptyRow)
                selectList.Add(new SelectListItem("", ""));

            foreach (var status in statuses)
            {
                selectList.Add(new SelectListItem(status.Status, status.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadCurrentStatuses(B2BDbContext _context, bool includeEmptyRow = true)
        {
            var selectList = new List<SelectListItem>();
            var statuses = await _context.CurrentStatuses.ToListAsync();

            //start with an empty option, since the field is not mandatory
            if (includeEmptyRow)
                selectList.Add(new SelectListItem("", ""));

            foreach (var status in statuses)
            {
                selectList.Add(new SelectListItem(status.Name, status.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadResellers(B2BDbContext _context, bool includeEmptyRow = true)
        {
            var selectList = new List<SelectListItem>();
            var resellers = await _context.Resellers.ToListAsync();

            //start with an empty option, since the field is not mandatory
            if (includeEmptyRow)
                selectList.Add(new SelectListItem("", ""));

            foreach (var reseller in resellers)
            {
                selectList.Add(new SelectListItem(reseller.Name, reseller.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadB2BResponsibles(B2BDbContext _context, bool includeEmptyRow = true)
        {
            var selectList = new List<SelectListItem>();
            var owners = await _context.B2BResponsibles.ToListAsync();

            //start with an empty option, since the field is not mandatory
            if (includeEmptyRow)
                selectList.Add(new SelectListItem("", ""));

            foreach (var owner in owners)
            {
                selectList.Add(new SelectListItem(owner.Name, owner.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadCustomerChannels(B2BDbContext _context, bool includeEmptyRow = true)
        {
            var selectList = new List<SelectListItem>();
            var channels = await _context.CustomerChannels.ToListAsync();

            //start with an empty option, since the field is not mandatory
            if (includeEmptyRow)
                selectList.Add(new SelectListItem("", ""));

            foreach (var channel in channels)
            {
                selectList.Add(new SelectListItem(channel.Channel, channel.Id.ToString()));
            }
            return selectList;
        }

        public static async Task<IEnumerable<SelectListItem>> LoadCancellationReasons(B2BDbContext _context, bool includeEmptyRow = true)
        {
            var selectList = new List<SelectListItem>();
            var reasons = await _context.CancellationReasons.ToListAsync();

            //start with an empty option, since the field is not mandatory
            if (includeEmptyRow)
                selectList.Add(new SelectListItem("", ""));

            foreach (var reason in reasons)
            {
                selectList.Add(new SelectListItem(reason.Reason, reason.Id.ToString()));
            }
            return selectList;
        }
    }
}
