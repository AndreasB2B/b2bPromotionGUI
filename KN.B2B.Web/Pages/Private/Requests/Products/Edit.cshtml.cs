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

namespace KN.B2B.Web.Pages.Private.Requests.Products
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public RequestProduct Product { get; set; }
        [BindProperty]
        public Request ParentRequest { get; set; }
        #endregion

        #region Properties
        public IEnumerable<SelectListItem> Suppliers { get; set; }
        public IEnumerable<SelectListItem> B2BCategories { get; set; }
        public IEnumerable<SelectListItem> Complaints { get; set; }
        public B2BProduct product { get; set; }
        public B2BParrentProducts parrentProduct { get; set; }
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
                product = await _context.B2BProdducts.FirstOrDefaultAsync(x => x.fk_ParentSKU.parrentProduct_id == id.Value);
            }
            else
            {
                Product = new RequestProduct();
                Product.OrderDate = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone); //default to today's date
                //Product.ShippingDate = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone);
                //Product.DeliveryDate = DateTime.UtcNow.AddHours(ConstValues.DanishTimeZone);
            }



            //ParentRequest = _context.Requests.FirstOrDefault(x => x.Id == reqId); //a parent request will always be present
            Suppliers = await LoadCollections.LoadSuppliers(_context);
            B2BCategories = await LoadCollections.LoadB2BCategories(_context);
            Complaints = await LoadCollections.LoadComplaints(_context);
            return Page();
        }

        //Multiple handlers: https://www.learnrazorpages.com/razor-pages/handler-methods#handling-multiple-actions-for-the-same-form
        public async Task<IActionResult> OnPostProductAsync()
        {
            //Set the supplier
            var selectedSupplier = Request.Form["SupplierSelect"];
            if (string.IsNullOrEmpty(selectedSupplier) == false)
            {
                if (Int32.TryParse(selectedSupplier, out var id))
                {
                    var supplier = await _context.Suppliers.SingleAsync(x => x.Id == id);
                    Product.Supplier = supplier;
                }
            }

            //Set the B2BGroup
            var selectedB2bCategory = Request.Form["B2BCategorySelect"];
            if (string.IsNullOrEmpty(selectedB2bCategory) == false)
            {
                if (Int32.TryParse(selectedB2bCategory, out var id))
                {
                    var category = await _context.B2BCategories.SingleAsync(x => x.Id == id);
                    Product.B2BCategory = category;
                }
            }

            //Set the Complaint
            var selectedComplaint= Request.Form["ComplaintSelect"];
            if (string.IsNullOrEmpty(selectedComplaint) == false)
            {
                if (Int32.TryParse(selectedComplaint, out var id))
                {
                    var complaint = await _context.Complaints.SingleAsync(x => x.Id == id);
                    Product.Complaint = complaint;
                }
            }

            if (!ModelState.IsValid)
                return NotFound(); //TODO: Return error page

            //get the request this product belongs to;
            var fetchedRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == ParentRequest.Id);
            if (fetchedRequest == null)
                return NotFound(); //TODO: this would mean that the request has been deleted in the mean time - notify the user

            Product.Request = fetchedRequest;

            if (ProductExists(Product.Id) == false)
            {
                _context.RequestProducts.Add(Product);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(Product).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(Product.Id))
                        return NotFound();
                    else
                        throw;
                }
            }
            return RedirectToPage("../Edit", new { id = ParentRequest.Id});
        }

        public async Task<IActionResult> OnPostDeleteProductAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Product = await _context.RequestProducts.FindAsync(id);

            if (Product != null)
            {
                _context.RequestProducts.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Edit", new { id = ParentRequest.Id });
        }

        private bool ProductExists(int id)
        {
            return _context.RequestProducts.Any(e => e.Id == id);
        }
    }
}
