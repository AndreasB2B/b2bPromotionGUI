using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.CancellationReasons
{
    public class DeleteModel : PageModel
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

            CancellationReason = await _context.CancellationReasons.FirstOrDefaultAsync(m => m.Id == id);

            if (CancellationReason == null)
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

            CancellationReason = await _context.CancellationReasons.FindAsync(id);

            if (CancellationReason != null)
            {
                _context.CancellationReasons.Remove(CancellationReason);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
