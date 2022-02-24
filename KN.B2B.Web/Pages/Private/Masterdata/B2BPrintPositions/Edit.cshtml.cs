using KN.B2B.Data;
using KN.B2B.Model.SystemTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KN.B2B.Web.Pages.Private.Masterdata.B2BPrintPositions
{
    public class EditModel : PageModel
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

        public EditModel(B2BDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                PrintPosition = await _context.B2BPrintPositions.FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                PrintPosition = new B2BPrintPosition();
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

            if (B2BPrintPositionExists(PrintPosition.Id) == false)
            {
                _context.B2BPrintPositions.Add(PrintPosition);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Attach(PrintPosition).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!B2BPrintPositionExists(PrintPosition.Id))
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

        private bool B2BPrintPositionExists(int id)
        {
            return _context.B2BPrintPositions.Any(e => e.Id == id);
        }
    }
}
