using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BPrintTypes
{
    public class DeleteModel : PageModel
    {
        #region Fields
        private readonly B2BDbContext _context;
        #endregion

        #region Bound Properties
        [BindProperty]
        public B2BPrintType B2BPrintType { get; set; }
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

            B2BPrintType = await _context.B2BPrintTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (B2BPrintType == null)
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

            B2BPrintType = await _context.B2BPrintTypes.FindAsync(id);

            if (B2BPrintType != null)
            {
                _context.B2BPrintTypes.Remove(B2BPrintType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
