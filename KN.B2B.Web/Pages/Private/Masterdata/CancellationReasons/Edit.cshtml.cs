using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.CancellationReasons
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public CancellationReason CancellationReason { get; set; }
        #endregion

        #region Properties
        #endregion

        public EditModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                CancellationReason = await _context.CancellationReasons.FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                CancellationReason = new CancellationReason();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (CancellationReasonExists(CancellationReason.Id) == false)
            {
                _context.CancellationReasons.Add(CancellationReason);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(CancellationReason).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CancellationReasonExists(CancellationReason.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CancellationReasonExists(int id)
        {
            return _context.CancellationReasons.Any(e => e.Id == id);
        }
    }
}
