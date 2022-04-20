using KN.B2B.Data;
using KN.B2B.Model;
using KN.B2B.Model.products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using KN.B2B.Web.Models;
using System.Collections;
using System.Web;
using KN.B2B.Model.products.B2BPrintPositions;
using KN.B2B.Model.SystemTables;
using KN.B2B.Model.products.productPrice;

namespace KN.B2B.Web.Pages.Private.Requests.Products
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public B2BParrentProducts parrentProduct { get; set; }

        //[BindProperty]
        //public B2BParrentProducts newProduct { get; set; }
        [BindProperty]
        public B2BParrentProducts tmpProduct { get; set; }
        //public B2BProduct childProducts { get; set; }
        #endregion

        #region Properties
        public IEnumerable<SelectListItem> Suppliers { get; set; }
        public IEnumerable<SelectListItem> B2BCategories { get; set; }
        public IEnumerable<SelectListItem> Complaints { get; set; }
        public List<B2BProduct> childProducts { get; set; }
        public IEnumerable<B2BPrintPosition> positions { get; set; }
        public IEnumerable<B2BPrintTechnique> printTechniques { get; set; }
        //public List<B2BPrintTechnique> techniques { get; set; }
        public B2BPrintTechnique techniques { get; set; }
        public IEnumerable<SupplierPrintPrice> printPrices { get; set; }
        public IEnumerable<B2BPriceScaling> priceScaling { get; set; }
        public IEnumerable<B2BPriceScaling> productScaling { get; set; }
        //B2BPriceScaling productScaling { get; set; }
        //IEnumerable<B2BProductPrices>  productPrices { get; set; }
        #endregion

        public EditModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int? id)
        {

            if (id.HasValue)
            {
                //b2bProduct = await _context.B2BProdducts.FirstOrDefaultAsync(x => x.fk_ParentSKU == id.Value);

                parrentProduct = await _context.B2BParrentProducts.FirstOrDefaultAsync(x => x.parrentProduct_id == id.Value);
                childProducts = await LoadCollections.LoadProductsWherePId(_context, id);
                positions = await LoadCollections.LoadPrintPositionsWProductSKU(_context, parrentProduct.parrentProduct_parrentSku);
                //priceScaling = await LoadCollections.LoadProductPricesWSku(_context, parrentProduct.parrentProduct_parrentSku);
                if(childProducts.Count > 0)
                {
                    var productPrices = await _context.B2BProductPrices.Where(x => x.parrentSku == childProducts[0].product_sku).ToArrayAsync();
                    productScaling = await _context.B2BPriceScaling.Where(x => x.fk_priceId.id == productPrices[0].id).ToListAsync();
                }
                //IndexOf(productPrices, productPrices.id);
                //productScaling = await _context.B2BPriceScaling.FirstOrDefaultAsync(x => x.fk_priceId.id == productPrices[0].id);
                //printTechniques = await _context
                //product = await _context.B2BProdducts.FirstOrDefaultAsync(x => x.fk_ParentSKU.parrentProduct_id == id.Value);
            }
            else
            {
                //Product = new B2BParrentProducts();
                //Product.OrderDate = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone); //default to today's date
                //Product.ShippingDate = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone);
                //Product.DeliveryDate = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone);
            }



            tmpProduct = _context.B2BParrentProducts.FirstOrDefault(x => x.parrentProduct_id == id); //a parent request will always be present
            Suppliers = await LoadCollections.LoadSuppliers(_context);
            B2BCategories = await LoadCollections.LoadB2BCategories(_context);
            Complaints = await LoadCollections.LoadComplaints(_context);
            //techniques = await _context.B2BPrintTechniques.ToListAsync();
            techniques = await _context.B2BPrintTechniques.FirstOrDefaultAsync();
            printPrices = await LoadCollections.LoadAllPrintPrices(_context);
            return Page();
        }

        //Multiple handlers: https://www.learnrazorpages.com/razor-pages/handler-methods#handling-multiple-actions-for-the-same-form
        public async Task<IActionResult> OnPost()
        {
            //Set the supplier
            var id = int.Parse(Request.Form["id"]);
            parrentProduct = await _context.B2BParrentProducts.FirstOrDefaultAsync(x => x.parrentProduct_id == id);


            parrentProduct.parrentProduct_shortDescription = Request.Form["shortDesc"];
            parrentProduct.parrentProduct_longDescription = Request.Form["longDesc"];
            parrentProduct.parrentProduct_subCategoryDK = Request.Form["category"];
            parrentProduct.parrentProduct_printPositions = int.Parse(Request.Form["printPositions"]);
            //productScaling

            _context.Attach(parrentProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(parrentProduct.parrentProduct_id))
                    return NotFound();
                else
                    throw;
            }


            return RedirectToAction("Edit", new { @id=parrentProduct.parrentProduct_id });
        }

        public async Task<IActionResult> OnPostDeleteProductAsync(int? id)
        {

            Console.WriteLine(id);
            if (id == null)
                return NotFound();

            parrentProduct = await _context.B2BParrentProducts.FindAsync(id);

            if (parrentProduct != null)
            {
                parrentProduct = _context.B2BParrentProducts.FirstOrDefault(x => x.parrentProduct_id == id);
                childProducts = await LoadCollections.LoadProductsWherePId(_context, id);
                if(childProducts.Count > 0)
                {
                    foreach(var childProduct in childProducts)
                    {
                        _context.B2BProdducts.Remove(childProduct);
                    }
                }
                _context.B2BParrentProducts.Remove(parrentProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./viewAll");
        }

        private bool ProductExists(int id)
        {
            return _context.B2BParrentProducts.Any(e => e.parrentProduct_id == id);
        }
    }
}
