using KN.B2B.Data;
using KN.B2B.Data.Repository;
using KN.B2B.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Customers
{
    public class DeleteModel : PageModel
    {
        #region Fields
        private readonly IRequestData _requestData;
        private readonly B2BDbContext _context;
        #endregion

        public DeleteModel(IRequestData requestData, B2BDbContext context)
        {
            _requestData = requestData;
            _context = context;
        }

        [BindProperty]
        public Customer B2BCustomer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            B2BCustomer = await _context.Customers.Include(x => x.JobTitle)
                                                  .Include(x => x.ZipCode)
                                                  .Include(x => x.InvoicingZip)
                                                  .Include(x => x.Industry)
                                                  .Include(x => x.Reseller)
                                                  .Include(x => x.B2BResponsible)
                                                  .Include(x => x.Channel)
                                                  .FirstOrDefaultAsync(x => x.Id == id);

            if (B2BCustomer == null)
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

            B2BCustomer = await _requestData.GetCustomerByIDAsync(id.Value);

            if (B2BCustomer != null)
            {
                //we're outing the variable in case we want to display some info post-deletion,
                //like a confirmation message containing some of its data
                _requestData.DeleteCustomer(B2BCustomer.Id, out var deleted);
                await _requestData.CommitAsync();
            }

            TempData["Message"] = $"{B2BCustomer.Name} ({B2BCustomer.Id}) was deleted.";
            return RedirectToPage("./Index");
        }
    }
}
