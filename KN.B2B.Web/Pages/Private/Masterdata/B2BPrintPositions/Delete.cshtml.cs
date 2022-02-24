using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BPrintPositions
{
    public class DeleteModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public B2BPrintPosition PrintPosition { get; set; }
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

            PrintPosition = await _context.B2BPrintPositions.FirstOrDefaultAsync(m => m.Id == id);

            if (PrintPosition == null)
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

            PrintPosition = await _context.B2BPrintPositions.FindAsync(id);

            if (PrintPosition != null)
            {
                _context.B2BPrintPositions.Remove(PrintPosition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
