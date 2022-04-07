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
        public B2BParrentProducts newProduct { get; set; }
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
        public IEnumerable<B2BPrintTechnique> techniques { get; set; }
        public IEnumerable<SupplierPrintPrice> printPrices { get; set; }
        public IEnumerable<B2BPriceScaling> priceScaling { get; set; }
        public B2BParrentProducts parrentProduct { get; set; }
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

                var productPrices = await _context.B2BProductPrices.Where(x => x.parrentSku == childProducts[0].product_sku).ToArrayAsync();
                //IndexOf(productPrices, productPrices.id);
                productScaling = await _context.B2BPriceScaling.Where(x => x.fk_priceId.id == productPrices[0].id).ToListAsync();
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
            techniques = await LoadCollections.LoadAllPrintTechniques(_context);
            printPrices = await LoadCollections.LoadAllPrintPrices(_context);
            return Page();
        }

        //Multiple handlers: https://www.learnrazorpages.com/razor-pages/handler-methods#handling-multiple-actions-for-the-same-form
        public async Task<IActionResult> OnPostProductAsync()
        {
            //Set the supplier
            var selectedSupplier = Request.Form["shortDesc"];
            //if (string.IsNullOrEmpty(selectedSupplier) == false)
            //{
            //    if (Int32.TryParse(selectedSupplier, out var id))
            //    {
            //        var supplier = await _context.Suppliers.SingleAsync(x => x.Id == id);
            //        newProduct.Supplier = supplier;
            //    }
            //}

            //Set the B2BGroup
            //var selectedB2bCategory = Request.Form["B2BCategorySelect"];
            //if (string.IsNullOrEmpty(selectedB2bCategory) == false)
            //{
            //    if (Int32.TryParse(selectedB2bCategory, out var id))
            //    {
            //        var category = await _context.B2BCategories.SingleAsync(x => x.Id == id);
            //        Product.B2BCategory = category;
            //    }
            //}

            ////Set the Complaint
            //var selectedComplaint= Request.Form["ComplaintSelect"];
            //if (string.IsNullOrEmpty(selectedComplaint) == false)
            //{
            //    if (Int32.TryParse(selectedComplaint, out var id))
            //    {
            //        var complaint = await _context.Complaints.SingleAsync(x => x.Id == id);
            //        Product.Complaint = complaint;
            //    }
            //}

            //if (!ModelState.IsValid)
            //    return NotFound(); //TODO: Return error page

            //get the request this product belongs to;
            //var fetchedRequest = await _context.B2BParrentProducts.FirstOrDefaultAsync(x => x.parrentProduct_id == tmpProduct.parrentProduct_id);
            //if (fetchedRequest == null)
            //    return NotFound(); //TODO: this would mean that the request has been deleted in the mean time - notify the user

            //newProduct

            //if (ProductExists(newProduct.parrentProduct_id) == false)
            //{
            //    _context.B2BParrentProducts.Add(newProduct);
            //    await _context.SaveChangesAsync();
            //}
            //else
            //{
            //    _context.Attach(newProduct).State = EntityState.Modified;
            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ProductExists(newProduct.parrentProduct_id))
            //            return NotFound();
            //        else
            //            throw;
            //    }
            //}
            return RedirectToPage("./Edit");
        }

        //public async Task<IActionResult> OnPostDeleteProductAsync(int? id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    tmpProduct = await _context.B2BParrentProducts.FindAsync(id);

        //    if (newProduct != null)
        //    {
        //        var tmpChildProduct = _context.B2BProdducts.Where(x => x.fk_ParentSKU == tmpProduct.parrentProduct_id)
        //        _context.B2BParrentProducts.Remove(newProduct.parrentProduct_id);
        //        _context.B2BParrentProducts.Remove(tmpProduct.parrentProduct_id);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("../Edit", new { id = ParentRequest.Id });
        //}

        private bool ProductExists(int id)
        {
            return _context.B2BParrentProducts.Any(e => e.parrentProduct_id == id);
        }
    }
}
