using KN.B2B.Data;
using KN.B2B.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Requests
{
    public class DeleteModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Properties
        public IEnumerable<RequestCommunication> Communications { get; set; }
        public IEnumerable<RequestProduct> Products { get; set; }
        #endregion

        #region Bound Properties
        [BindProperty]
        public Request B2BRequest { get; set; }
        #endregion

        public DeleteModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            B2BRequest = await _context.Requests.Include(x => x.Customer)
                                                .Include(x => x.Communications)
                                                .Include(x => x.Products)
                                                .Include(x => x.StartStatus)
                                                .Include(x => x.EndStatus)
                                                .Include(x => x.CurrentStatus)
                                                .Include(x => x.CancellationReason)
                                                .FirstOrDefaultAsync(m => m.Id == id);

            Communications = await LoadCollections.LoadCommunications(_context, B2BRequest.Id);
            Products = await LoadCollections.LoadProducts(_context, B2BRequest.Id);

            if (B2BRequest == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            B2BRequest = await _context.Requests.FindAsync(id);
            Communications = await LoadCollections.LoadCommunications(_context, B2BRequest.Id);
            Products = await LoadCollections.LoadProducts(_context, B2BRequest.Id);

            if (B2BRequest != null)
            {
                if (Communications.Count() > 0)
                    _context.RequestCommunications.RemoveRange(Communications);
                if (Products.Count() > 0)
                    _context.RequestProducts.RemoveRange(Products);

                _context.Requests.Remove(B2BRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
